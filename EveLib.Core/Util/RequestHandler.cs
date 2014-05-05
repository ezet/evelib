using System;
using System.Net;
using eZet.EveLib.Core.Exception;

namespace eZet.EveLib.Core.Util {
    public class RequestHandler : IRequestHandler {
        public RequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        public ISerializer Serializer { get; set; }

        public T Request<T>(Uri uri) {
            try {
                var request = HttpRequestHelper.CreateRequest(uri);
                request.Proxy = null;
                request.UserAgent = Config.UserAgent;
                string data = HttpRequestHelper.GetResponseContent(request);
                return Serializer.Deserialize<T>(data);
            } catch (WebException e) {
                throw new InvalidRequestException("A request caused a WebException.", e);
            } catch (InvalidOperationException e) {
                throw new InvalidRequestException("A request caused an InvalidOperationException.", e);
            }
        }
    }
}