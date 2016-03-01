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
        public const int DefaultPublicMaxConcurrentRequests = 30;

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

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);
        private int _authedMaxConcurrentRequests;
        private SemaphoreSlim _authedPool;
        private int _publicMaxConcurrentRequests;
        private SemaphoreSlim _publicPool;

        /// <summary>
        ///     Creates a new CachedCrestRequestHandler
        /// </summary>
        /// <param name="serializer"></param>
        public CachedCrestRequestHandler(ISerializer serializer) {
            Serializer = serializer;
            PublicMaxConcurrentRequests = DefaultPublicMaxConcurrentRequests;
            AuthedMaxConcurrentRequests = DefaultAuthedMaxConcurrentRequests;
            _publicPool = new SemaphoreSlim(PublicMaxConcurrentRequests, PublicMaxConcurrentRequests);
            _authedPool = new SemaphoreSlim(AuthedMaxConcurrentRequests, AuthedMaxConcurrentRequests);
            UserAgent = Config.UserAgent;
            Charset = DefaultCharset;
            Cache = Config.CacheFactory("EveCrestCache");
            CacheLevel = CacheLevel.Default;
        }

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

        /// <summary>
        ///     Gets or sets the size of the public burst.
        /// </summary>
        /// <value>The size of the public burst.</value>
        public int PublicMaxConcurrentRequests {
            get { return _publicMaxConcurrentRequests; }
            set {
                _publicMaxConcurrentRequests = value;
                _publicPool = new SemaphoreSlim(value, value);
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
                _authedPool = new SemaphoreSlim(value, value);
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


        public async Task<string> PostAsync(Uri uri, string accessToken, string postData) {
            var request = HttpRequestHelper.CreateRequest(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";
            string retval = null;
            request.Headers.Add(HttpRequestHeader.Authorization, TokenType + " " + accessToken);
            HttpRequestHelper.AddPostData(request, postData);

            var response = await requestAsync(request, accessToken);
            if (response.StatusCode == HttpStatusCode.Created) {
                retval = response.GetResponseHeader("Location");
            }
            return retval;
        }

        public async Task<bool> PutAsync(Uri uri, string accessToken, string postData) {
            var request = HttpRequestHelper.CreateRequest(uri);
            request.Method = WebRequestMethods.Http.Put;
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, TokenType + " " + accessToken);
            HttpRequestHelper.AddPostData(request, postData);
            var response = await requestAsync(request, accessToken);
            var retval = response.StatusCode == HttpStatusCode.OK;
            return retval;
        }

        public async Task<bool> DeleteAsync(Uri uri, string accessToken) {
            var request = HttpRequestHelper.CreateRequest(uri);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            var response = await requestAsync(request, accessToken);
            var retval = response.StatusCode == HttpStatusCode.OK;
            return retval;
        }

        /// <summary>
        ///     Performs a request, and returns the response content.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">URI to request</param>
        /// <param name="accessToken">CREST acces token</param>
        /// <param name="method">The method.</param>
        /// <param name="postData">The post data.</param>
        /// <returns>T.</returns>
        /// <exception cref="DeprecatedResourceException">The CREST resource is deprecated.</exception>
        /// <exception cref="EveCrestException">Undefined error</exception>
        public async Task<T> GetAsync<T>(Uri uri, string accessToken)
            where T : class, ICrestResource<T> {
            string responseContent = null;
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.CacheOnly)
                responseContent = await Cache.LoadAsync(uri).ConfigureAwait(false);
            var cached = responseContent != null;
            T result;
            if (cached) {
                result = Serializer.Deserialize<T>(responseContent);
                result.IsFromCache = true;
                return result;
            }
            if (CacheLevel == CacheLevel.CacheOnly) return default(T);

            // set up request
            var request = HttpRequestHelper.CreateRequest(uri);
            request.Accept = ContentTypes.Get<T>(ThrowOnMissingContentType) + ";";
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
            request.Method = WebRequestMethods.Http.Get;
            _trace.TraceEvent(TraceEventType.Error, 0, "Initiating Request: " + uri);
            var response = await requestAsync(request, accessToken);

            // handle response
            var header = response.Headers;
            responseContent = await HttpRequestHelper.GetResponseContentAsync(response).ConfigureAwait(false);
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.Refresh)
                await Cache.StoreAsync(uri, getCacheExpirationTime(header), responseContent).ConfigureAwait(false);
            result = Serializer.Deserialize<T>(responseContent);
            result.ResponseHeaders = header;
            return result;
        }

        private async Task<HttpWebResponse> requestAsync(HttpWebRequest request, string accessToken) {
            var mode = (string.IsNullOrEmpty(accessToken)) ? CrestMode.Public : CrestMode.Authenticated;
            HttpWebResponse response;
            if (!string.IsNullOrEmpty(Charset)) request.Accept = request.Accept + " " + Charset;
            if (!string.IsNullOrEmpty(XRequestedWith)) request.Headers.Add("X-Requested-With", XRequestedWith);
            if (!string.IsNullOrEmpty(UserAgent)) request.UserAgent = UserAgent;
            try {
                if (mode == CrestMode.Authenticated) {
                    request.Headers.Add(HttpRequestHeader.Authorization, TokenType + " " + accessToken);
                    await _authedPool.WaitAsync().ConfigureAwait(false);
                }
                else {
                    await _publicPool.WaitAsync().ConfigureAwait(false);
                }
      
                response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false);
                var deprecated = response.GetResponseHeader("X-Deprecated");
                if (!string.IsNullOrEmpty(deprecated)) {
                    _trace.TraceEvent(TraceEventType.Warning, 0,
                        "This CREST resource is deprecated. Please update to the newest EveLib version or notify the developers.");
                    if (ThrowOnDeprecated) {
                        throw new DeprecatedResourceException("The CREST resource is deprecated.", response);
                    }
                }
            }
            catch (Exception exception) {
                var e = exception as WebException;
                if (e == null) throw;
                _trace.TraceEvent(TraceEventType.Error, 0, "CREST Request Failed.");
                if (e.Response == null) {
                    throw new EveCrestException(e.Message, e);
                }
                response = (HttpWebResponse)e.Response;

                var responseStream = response.GetResponseStream();
                if (responseStream == null) throw new EveCrestException("Undefined error", e);
                using (var reader = new StreamReader(responseStream)) {
                    var responseContent = reader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError ||
                        response.StatusCode == HttpStatusCode.BadGateway)
                        throw new EveCrestException(responseContent, e);
                    var error = Serializer.Deserialize<CrestError>(responseContent);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Message: {0}, Key: {1}",
                        "Exception Type: {2}, Ref ID: {3}", error.Message, error.Key, error.ExceptionType,
                        error.RefId);
                    throw new EveCrestException(error.Message, e, error.Key, error.ExceptionType, error.RefId);
                }
            }
            finally {
                // release semaphores
                if (mode == CrestMode.Authenticated) _authedPool.Release();
                else _publicPool.Release();
            }
            return response;
        }


        private static DateTime getCacheExpirationTime(NameValueCollection header) {
            var cache = header.Get("Cache-Control");
            if (cache == null) return DateTime.UtcNow;
            var str = cache.Substring(cache.IndexOf('=') + 1);
            var sec = int.Parse(str);
            return DateTime.UtcNow.AddSeconds(sec);
        }

    }
}