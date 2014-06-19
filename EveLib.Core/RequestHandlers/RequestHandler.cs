using System;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Exceptions;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    ///     A basic RequestHandler with no special handling.
    /// </summary>
    public class RequestHandler : IRequestHandler {
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
            string data = "";
            try {
                data = await HttpRequestHelper.RequestAsync(uri).ConfigureAwait(false);
            }
            catch (WebException e) {
                throw new EveLibWebException("A request caused a WebException.", e.InnerException as WebException);
            }
            var val = Serializer.Deserialize<T>(data);
            return val;
        }
    }
}