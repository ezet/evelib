using System;
using System.Net;
using eZet.EveLib.Core.Exception;

namespace eZet.EveLib.Core.Util {
    public class RequestHandler : IRequestHandler {

        public RequestHandler(IHttpRequester httpRequester, ISerializer serializer) {
            HttpRequester = httpRequester;
            Serializer = serializer;
        }

        public IHttpRequester HttpRequester { get; set; }
        public ISerializer Serializer { get; set; }
        public T Request<T>(Uri uri) {
            string data = "";
            try {
                data = HttpRequester.Request<T>(uri);
            } catch (WebException e) {
                throw new InvalidRequestException("A request caused a WebException.", e);
            }
            return Serializer.Deserialize<T>(data);
        }
    }
}
