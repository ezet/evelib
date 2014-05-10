using System;
using System.Net;
using eZet.EveLib.Core.Exception;

namespace eZet.EveLib.Core.Util {
    public class RequestHandler : IRequestHandler {
        public RequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        /// <summary>
        /// Gets or sets the serializer used to deserialize responses
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        /// Performs a http request and returns the deserialized response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public T Request<T>(Uri uri) {
            try {
                var request = HttpRequestHelper.CreateRequest(uri);
                request.Proxy = null;
                request.UserAgent = Config.UserAgent;
                string data = HttpRequestHelper.GetResponseContent(request);
                return Serializer.Deserialize<T>(data);
            } catch (WebException e) {
                throw new InvalidRequestException("A request caused a WebException.", e);
            }
        }
    }
}