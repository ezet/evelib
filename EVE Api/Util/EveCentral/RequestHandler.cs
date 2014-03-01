using System;

namespace eZet.Eve.EveLib.Util.EveCentral {
    public class RequestHandler : IRequestHandler {

        public IXmlSerializer Serializer { get; set; }

        public RequestHandler(IXmlSerializer serializer) {
            Serializer = serializer;
        }

        T IRequestHandler.Request<T>(Uri uri) {
            var data = HttpRequestHelper.Request(uri);
            return Serializer.Deserialize<T>(data);
        }
    }
}
