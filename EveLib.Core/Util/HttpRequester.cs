using System;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Exception;

namespace eZet.EveLib.Core.Util {
    public class HttpRequester : IHttpRequester {

        private const string ContentType = "application/x-www-form-urlencoded";

        /// <summary>
        /// Performs a http request and returns the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public string Request<T>(Uri uri) {
            try {
                var request = createRequest(uri);
                return HttpRequestHelper.GetResponseContent(request);
            } catch (WebException e) {
                throw new InvalidRequestException("A request caused a WebException.", e);
            }
        }

        /// <summary>
        /// Performs a http request and returns the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Task<string> RequestAsync<T>(Uri uri) {
            try {
                var request = createRequest(uri);
                return HttpRequestHelper.GetResponseContentAsync(request);
            } catch (WebException e) {
                throw new InvalidRequestException("A request caused a WebException.", e);
            }
        }

        private static HttpWebRequest createRequest(Uri uri) {
            var request = HttpRequestHelper.CreateRequest(uri);
            request.Proxy = null;
            request.UserAgent = Config.UserAgent;
            request.ContentType = ContentType;
            return request;
        }
    }
}