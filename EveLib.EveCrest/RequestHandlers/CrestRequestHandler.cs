using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
    /// <summary>
    ///     Performs requests on the Eve Online CREST API.
    /// </summary>
    public class CrestRequestHandler : ICrestRequestHandler {


        /// <summary>
        /// The default public rate per second
        /// </summary>
        public const int DefaultPublicRatePerSecond = 30;

        /// <summary>
        /// The default public burst size
        /// </summary>
        public const int DefaultPublicMaxConcurrentRequests = 50;

        /// <summary>
        /// The default authed rate per second
        /// </summary>
        public const int DefaultAuthedRatePerSecond = 30;

        /// <summary>
        /// The default authed burst size
        /// </summary>
        public const int DefaultAuthedMaxConcurrentRequests = 100;

        private Semaphore _publicPool;
        private Semaphore _authedPool;

        private Semaphore _perSecondPool;
        private int _publicMaxConcurrentRequests;
        private int _authedMaxConcurrentRequests;


        /// <summary>
        /// Gets or sets the public rate per second.
        /// </summary>
        /// <value>The public rate per second.</value>
        public int PublicRatePerSecond { get; set; }

        /// <summary>
        /// Gets or sets the size of the public burst.
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
        /// Gets or sets the authed rate per second.
        /// </summary>
        /// <value>The authed rate per second.</value>
        public int AuthedRatePerSecond { get; set; }

        /// <summary>
        /// Gets or sets the size of the authed burst.
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
        ///     The token type
        /// </summary>
        public const string TokenType = "Bearer";

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Creates a new CrestRequestHandler
        /// </summary>
        /// <param name="serializer"></param>
        public CrestRequestHandler(ISerializer serializer) {
            Serializer = serializer;
            PublicMaxConcurrentRequests = DefaultPublicMaxConcurrentRequests;
            AuthedMaxConcurrentRequests = DefaultAuthedMaxConcurrentRequests;
            PublicRatePerSecond = DefaultPublicRatePerSecond;
            AuthedRatePerSecond = DefaultAuthedRatePerSecond;
            _publicPool = new Semaphore(PublicMaxConcurrentRequests, PublicMaxConcurrentRequests);
            _authedPool = new Semaphore(AuthedMaxConcurrentRequests, AuthedMaxConcurrentRequests);
        }

        /// <summary>
        ///     Sets or gets whether to throw a DeprecatedResourceException when requesting a deprecated resource
        /// </summary>
        public bool ThrowOnDeprecated { get; set; }

        /// <summary>
        ///     Gets or sets the serializer used to deserialize CREST errors.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        ///     Performs a request, and returns the response content.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">URI to request</param>
        /// <param name="accessToken">CREST acces token</param>
        /// <returns></returns>
        public async Task<string> RequestAsync<T>(Uri uri, string accessToken = null) where T : class, ICrestResource<T> {
            string data;
            var mode = (accessToken == null) ? CrestMode.Public : CrestMode.Authenticated;
            HttpWebRequest request = HttpRequestHelper.CreateRequest(uri);
            request.Accept = CrestModels.Get<T>();
            _trace.TraceEvent(TraceEventType.Error, 0, "Initiating Request: " + uri);

            if (mode == CrestMode.Authenticated) {
                request.Headers.Add(HttpRequestHeader.Authorization, TokenType + " " + accessToken);
                _authedPool.WaitOne();
            } else {
                _publicPool.WaitOne();
            }
            try {
                HttpWebResponse response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false);

                string deprecated = response.GetResponseHeader("X-Deprecated");

                if (!String.IsNullOrEmpty(deprecated)) {
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
            } catch (WebException e) {
                // release semaphores
                if (mode == CrestMode.Authenticated) _authedPool.Release();
                else _publicPool.Release();

                _trace.TraceEvent(TraceEventType.Error, 0, "CREST Request Failed.");
                var response = (HttpWebResponse)e.Response;

                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) throw new EveCrestException("Undefined error", e);
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError) throw new EveCrestException(data, e);
                    var error = Serializer.Deserialize<CrestError>(data);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Message: {0}, Key: {1}",
                        "Exception Type: {2}, Ref ID: {3}", error.Message, error.Key, error.ExceptionType, error.RefId);
                    throw new EveCrestException(error.Message, e, error.Key, error.ExceptionType, error.RefId);
                }
            }
            return data;
            //return Serializer.Deserialize<T>(data);
        }
    }
}