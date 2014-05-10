using System;

namespace eZet.EveLib.Core.Util {
    public class RequestHandler : IRequestHandler {

        public RequestHandler(IHttpRequester httpRequester, ISerializer serializer) {
            HttpRequester = httpRequester;
            Serializer = serializer;
        }

        public IHttpRequester HttpRequester { get; set; }
        public ISerializer Serializer { get; set; }
        public T Request<T>(Uri uri) {
            string data = HttpRequester.Request<T>(uri);
            return Serializer.Deserialize<T>(data);
        }
    }
}
