using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Exceptions;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    ///     A basic RequestHandler with no special handling.
    /// </summary>
    public class RequestHandler : IPostRequestHandler {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="serializer">Serializer to use for deserialization</param>
        public RequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        /// <summary>
        ///     Gets or sets the ISerializer used to deserialize response data.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        ///     Performs a request against the specified URI, and returns the deserialized data.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="uri">URI to request</param>
        /// <returns></returns>
        public virtual async Task<T> RequestAsync<T>(Uri uri) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "RequestHandler.Deserialize:Start");
            string data;
            try {
                data = await HttpRequestHelper.RequestAsync(uri).ConfigureAwait(false);
            }
            catch (WebException e) {
                throw new EveLibWebException("A request caused a WebException.", e.InnerException as WebException);
            }
            var val = Serializer.Deserialize<T>(data);
            _trace.TraceEvent(TraceEventType.Verbose, 0, "RequestHandler.Deserialize:Complete");
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postData"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> PostRequestAsync<T>(Uri uri, string postData) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "RequestHandler.Deserialize:Start");
            string data;
            try {
                data = await HttpRequestHelper.PostRequestAsync(uri, postData).ConfigureAwait(false);
            }
            catch (WebException e) {
                throw new EveLibWebException("A request caused a WebException.", e.InnerException as WebException);
            }
            var val = Serializer.Deserialize<T>(data);
            _trace.TraceEvent(TraceEventType.Verbose, 0, "RequestHandler.Deserialize:Complete");
            return val;
        }
    }
}