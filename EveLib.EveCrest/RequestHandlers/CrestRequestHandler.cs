using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Exceptions;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules.RequestHandlers {

    /// <summary>
    ///     Performs requests on the Eve Online CREST API.
    /// </summary>
    public class CrestRequestHandler : ICrestRequestHandler {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        public const string TokenType = "Bearer";

        /// <summary>
        /// Sets or gets whether to throw an exception when requesting a deprecated resource
        /// </summary>
        public bool ThrowOnDeprecated { get; set; }

        /// <summary>
        ///     Creates a new CrestRequestHandler
        /// </summary>
        /// <param name="serializer"></param>
        public CrestRequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        /// <summary>
        ///     Gets or sets the serialier used to deserialize responses
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        ///     Performs a request, deserializes it, and returns the deserialized data.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">URI to request</param>
        /// <param name="accessToken">CREST acces token</param>
        /// <returns></returns>
        public async Task<T> RequestAsync<T>(Uri uri, string accessToken) {
            string data;
            try {
                var request = HttpRequestHelper.CreateRequest(uri);
                if (!string.IsNullOrEmpty(accessToken)) {
                    request.Headers.Add(HttpRequestHeader.Authorization, TokenType + " " + accessToken);
                }
                var response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false);
                var deprecated = response.GetResponseHeader("X-Deprecated");
                if (!String.IsNullOrEmpty(deprecated)) {
                    _trace.TraceEvent(TraceEventType.Warning, 0, "This CREST resource is deprecated. Please update to the newest EveLib version or notify the developers.");
                    if (ThrowOnDeprecated) {
                        throw new CrestResourceDeprecatedException("The CREST resource is deprecated.", response);
                    }
                }
                data = await HttpRequestHelper.GetResponseContentAsync(response).ConfigureAwait(false);
            } catch (WebException e) {
                _trace.TraceEvent(TraceEventType.Error, 0, "CREST Request Failed.");
                var response = (HttpWebResponse)e.Response;

                if (response == null) throw;
                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) throw;
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                    var error = Serializer.Deserialize<CrestError>(data);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Message: {0}, Key: {1}",
                        "Exception Type: {2}, Ref ID: {3}", error.Message, error.Key, error.ExceptionType, error.RefId);
                    throw new EveCrestException(error.Message, e, error.Key, error.ExceptionType, error.RefId);
                }
            }
            var val = Serializer.Deserialize<T>(data);

            return val;
        }
    }
}