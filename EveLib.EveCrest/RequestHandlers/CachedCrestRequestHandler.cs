using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading;
using System.Threading.Tasks;
using eZet.EveLib.Core;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Shared;
using eZet.EveLib.EveCrestModule.RequestHandlers.eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
    /// <summary>
    ///     Performs requests on the Eve Online CREST API.
    /// </summary>
    public class CachedCrestRequestHandler : ICachedCrestRequestHandler {
        /// <summary>
        ///     The default public max concurrent requests
        /// </summary>
        public const int DefaultPublicMaxConcurrentRequests = 20;

        /// <summary>
        ///     The default authed max concurrent requests
        /// </summary>
        public const int DefaultAuthedMaxConcurrentRequests = 10;

        /// <summary>
        ///     The defualt charset
        /// </summary>
        public const string DefaultCharset = "utf-8";

        /// <summary>
        ///     The token type
        /// </summary>
        public const string TokenType = "Bearer";

        /// <summary>
        ///     Gets or sets the cache mode.
        /// </summary>
        /// <value>The cache mode.</value>
        public CacheLevel CacheLevel { get; set; }

        /// <summary>
        ///     Gets or sets the cache used by this request handler
        /// </summary>
        /// <value>The cache.</value>
        public IEveLibCache Cache { get; set; }

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);
        private int _authedMaxConcurrentRequests;
        private Semaphore _authedPool;
        private int _publicMaxConcurrentRequests;
        private Semaphore _publicPool;

        /// <summary>
        ///     Creates a new CachedCrestRequestHandler
        /// </summary>
        /// <param name="serializer"></param>
        public CachedCrestRequestHandler(ISerializer serializer) {
            Serializer = serializer;
            PublicMaxConcurrentRequests = DefaultPublicMaxConcurrentRequests;
            AuthedMaxConcurrentRequests = DefaultAuthedMaxConcurrentRequests;
            _publicPool = new Semaphore(PublicMaxConcurrentRequests, PublicMaxConcurrentRequests);
            _authedPool = new Semaphore(AuthedMaxConcurrentRequests, AuthedMaxConcurrentRequests);
            UserAgent = Config.UserAgent;
            Charset = DefaultCharset;
            Cache = new EveLibFileCache(Config.AppData + Config.Separator + "EveCrestCache", "register");
            CacheLevel = CacheLevel.Default;
        }

        /// <summary>
        ///     Gets or sets the size of the public burst.
        /// </summary>
        /// <value>The size of the public burst.</value>
        public int PublicMaxConcurrentRequests {
            get { return _publicMaxConcurrentRequests; }
            set {
                _publicMaxConcurrentRequests = value;
                _publicPool = new Semaphore(value, value);
            }
        }

        /// <summary>
        ///     Gets or sets the size of the authed burst.
        /// </summary>
        /// <value>The size of the authed burst.</value>
        public int AuthedMaxConcurrentRequests {
            get { return _authedMaxConcurrentRequests; }
            set {
                _authedMaxConcurrentRequests = value;
                _authedPool = new Semaphore(value, value);
            }
        }

        /// <summary>
        ///     Sets or gets whether to throw a DeprecatedResourceException when requesting a deprecated resource. This will help
        ///     discover outdated models.
        /// </summary>
        public bool ThrowOnDeprecated { get; set; }

        /// <summary>
        ///     Sets or gets whether to throw a NotImplementedException when requesting a resource model with no ContentType. Used
        ///     for debugging.
        /// </summary>
        public bool ThrowOnMissingContentType { get; set; }

        /// <summary>
        ///     Gets or sets the serializer used to deserialize CREST errors.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        ///     Gets or sets the x requested with.
        /// </summary>
        /// <value>The x requested with.</value>
        public string XRequestedWith { get; set; }

        /// <summary>
        ///     Gets or sets the user agent.
        /// </summary>
        /// <value>The user agent.</value>
        public string UserAgent { get; set; }

        /// <summary>
        ///     Gets or sets the charset.
        /// </summary>
        /// <value>The charset.</value>
        public string Charset { get; set; }

        /// <summary>
        ///     Performs a request, and returns the response content.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">URI to request</param>
        /// <param name="accessToken">CREST acces token</param>
        /// <returns>T.</returns>
        /// <exception cref="DeprecatedResourceException">The CREST resource is deprecated.</exception>
        /// <exception cref="EveCrestException">
        ///     Undefined error
        ///     or
        ///     or
        /// </exception>
        public async Task<T> RequestAsync<T>(Uri uri, string accessToken) where T : class, ICrestResource<T> {
            string data = null;
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.CacheOnly)
                data = await Cache.LoadAsync(uri).ConfigureAwait(false);
            var cached = data != null;
            T result;
            if (cached) {
                result = Serializer.Deserialize<T>(data);
                result.IsFromCache = true;
                return result;
            }
            if (CacheLevel == CacheLevel.CacheOnly) return default(T);
            // set up request
            var mode = (accessToken == null) ? CrestMode.Public : CrestMode.Authenticated;
            var request = HttpRequestHelper.CreateRequest(uri);
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Accept = ContentTypes.Get<T>(ThrowOnMissingContentType) + ";";
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
            if (!string.IsNullOrEmpty(Charset)) request.Accept = request.Accept + " " + Charset;
            if (!string.IsNullOrEmpty(XRequestedWith)) request.Headers.Add("X-Requested-With", XRequestedWith);
            if (!string.IsNullOrEmpty(UserAgent)) request.UserAgent = UserAgent;
            if (mode == CrestMode.Authenticated) {
                request.Headers.Add(HttpRequestHeader.Authorization, TokenType + " " + accessToken);
                _authedPool.WaitOne();
            }
            else {
                _publicPool.WaitOne();
            }

            _trace.TraceEvent(TraceEventType.Error, 0, "Initiating Request: " + uri);
            WebHeaderCollection header;
            try {
                var response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false);
                header = response.Headers;
                var deprecated = response.GetResponseHeader("X-Deprecated");

                if (!string.IsNullOrEmpty(deprecated)) {
                    _trace.TraceEvent(TraceEventType.Warning, 0,
                        "This CREST resource is deprecated. Please update to the newest EveLib version or notify the developers.");
                    if (ThrowOnDeprecated) {
                        throw new DeprecatedResourceException("The CREST resource is deprecated.", response);
                    }
                }
                data = await HttpRequestHelper.GetResponseContentAsync(response).ConfigureAwait(false);
                // release semaphores
                if (mode == CrestMode.Authenticated) _authedPool.Release();
                else _publicPool.Release();
            }
            catch (WebException e) {
                // release semaphores
                if (mode == CrestMode.Authenticated) _authedPool.Release();
                else _publicPool.Release();

                _trace.TraceEvent(TraceEventType.Error, 0, "CREST Request Failed.");
                if (e.Response == null) {
                    throw new EveCrestException(e.Message, e);
                }
                var response = (HttpWebResponse) e.Response;

                var responseStream = response.GetResponseStream();
                if (responseStream == null) throw new EveCrestException("Undefined error", e);
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError ||
                        response.StatusCode == HttpStatusCode.BadGateway) throw new EveCrestException(data, e);
                    var error = Serializer.Deserialize<CrestError>(data);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Message: {0}, Key: {1}",
                        "Exception Type: {2}, Ref ID: {3}", error.Message, error.Key, error.ExceptionType,
                        error.RefId);
                    throw new EveCrestException(error.Message, e, error.Key, error.ExceptionType, error.RefId);
                }
            }
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.Refresh)
                await Cache.StoreAsync(uri, getCacheExpirationTime(header), data).ConfigureAwait(false);
            result = Serializer.Deserialize<T>(data);
            result.ResponseHeaders = header;
            return result;
        }


        private static DateTime getCacheExpirationTime(NameValueCollection header) {
            var cache = header.Get("Cache-Control");
            if (cache == null) return DateTime.UtcNow;
            var str = cache.Substring(cache.IndexOf('=') + 1);
            var sec = int.Parse(str);
            return DateTime.UtcNow.AddSeconds(sec);
        }

        ///// <summary>
        ///// Gets or sets a value indicating whether [enable cache].
        ///// </summary>
        ///// <value><c>true</c> if [enable cache]; otherwise, <c>false</c>.</value>
        //public bool EnableCache { get; set; }
    }
}