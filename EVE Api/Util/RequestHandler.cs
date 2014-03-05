using System;
using System.Net;
using eZet.Eve.EveLib.Exception;

namespace eZet.Eve.EveLib.Util {
    public class RequestHandler : IRequestHandler {
        public RequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        public ISerializer Serializer { get; set; }

        public T Request<T>(Uri uri) {
            try {
                string data = HttpRequestHelper.Request(uri);
                return Serializer.Deserialize<T>(data);
            }
            catch (WebException e) {
                throw new InvalidRequestException("An invalid request caused a Web Exception.", e);
            }
        }
    }
}