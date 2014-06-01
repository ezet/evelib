using System;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Exception;

namespace eZet.EveLib.Core.Util {
    public class RequestHandler : IRequestHandler {

        public RequestHandler(IHttpRequester httpRequester, ISerializer serializer) {
            HttpRequester = httpRequester;
            Serializer = serializer;
        }

        public IHttpRequester HttpRequester { get; set; }
        public ISerializer Serializer { get; set; }

        public async Task<T> RequestAsync<T>(Uri uri) {
            string data = "";
            try {
                data = await HttpRequester.RequestAsync<T>(uri).ConfigureAwait(false);
            } catch (AggregateException e) {
                if (e.InnerException.GetType() == typeof(WebException))
                    throw new InvalidRequestException("A request caused a WebException.", e.InnerException as WebException);
            }
            var val = Serializer.Deserialize<T>(data);
            return val;
        }
    }
}
