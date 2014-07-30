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
    public class EveCrestRequestHandler : IRequestHandler {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Creates a new EveCrestRequestHandler
        /// </summary>
        /// <param name="serializer"></param>
        public EveCrestRequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        /// <summary>
        /// Gets or sets the serialier used to deserialize responses
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        ///     Performs a request, deserializes it, and returns the deserialized data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<T> RequestAsync<T>(Uri uri) {
            string data;
            try {
                data = await HttpRequestHelper.RequestAsync(uri).ConfigureAwait(false);
            }
            catch (WebException e) {
                _trace.TraceEvent(TraceEventType.Error, 0, "Eve CREST Request Failed.");
                var response = (HttpWebResponse) e.Response;
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