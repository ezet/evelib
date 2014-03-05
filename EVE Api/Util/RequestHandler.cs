using System;
using System.Net;
using eZet.Eve.EveLib.Exception;

namespace eZet.Eve.EveLib.Util {
    public class RequestHandler : IRequestHandler {

        public ISerializer Serializer { get; set; }

        public RequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        public T Request<T>(Uri uri) {
            try {
                var data = HttpRequestHelper.Request(uri);
                return Serializer.Deserialize<T>(data);
            } catch (WebException e) {
                throw new InvalidRequestException("An invalid request caused a Web Exception.", e);
            }
        }
    }
}
