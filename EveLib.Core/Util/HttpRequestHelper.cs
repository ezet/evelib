using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     Helper class for performing web requests
    /// </summary>
    public static class HttpRequestHelper {
        /// <summary>
        ///     Default content type
        /// </summary>
        public const string ContentType = "application/x-www-form-urlencoded";

        private static readonly TraceSource Trace = new TraceSource("EveLib");

        /// <summary>
        ///     Creates a new HttpWebRequest for the specified URI, and returns it
        /// </summary>
        /// <param name="uri">URI to create request for</param>
        /// <returns>The HttpWebRequest</returns>
        public static HttpWebRequest CreateRequest(Uri uri) {
            var request = WebRequest.CreateHttp(uri);
            request.UserAgent = Config.UserAgent;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.GZip;
            request.ContentType = ContentType;
            return request;
        }

        /// <summary>
        ///     Performs a web request against the specified URI, and returns the response content
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns>The response content</returns>
        public static Task<string> RequestAsync(Uri uri) {
            var request = CreateRequest(uri);
            return GetResponseContentAsync(request);
        }

        /// <summary>
        ///     Performs a web request against the specified URI, and returns the response content
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <param name="postData"></param>
        /// <returns>The response content</returns>
        public static Task<string> PostRequestAsync(Uri uri, string postData) {
            var request = CreateRequest(uri);
            request.Method = "POST";
            AddPostData(request, postData);
            return GetResponseContentAsync(request);
        }

        /// <summary>
        ///     Adds the post data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="postData">The post data.</param>
        public static void AddPostData(HttpWebRequest request, string postData) {
            if (postData == null) return;
            var data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            using (var dataStream = request.GetRequestStream()) {
                dataStream.Write(data, 0, data.Length);
            }
            //using (var writer = new StreamWriter(request.GetRequestStream())) {
            //    writer.Write(postData);
            //}
        }

        /// <summary>
        ///     Executes a web request using the given request, and returns the HttpWebResponse
        /// </summary>
        /// <param name="request">The web request</param>
        /// <returns></returns>
        public static async Task<HttpWebResponse> GetResponseAsync(HttpWebRequest request) {
            HttpWebResponse response;
            try {
                response = (HttpWebResponse) await request.GetResponseAsync().ConfigureAwait(false);
                if (response != null) {
                    Trace.TraceEvent(TraceEventType.Information, 0,
                        "Response status: " + response.StatusCode + ", " + response.StatusDescription);
                    Trace.TraceEvent(TraceEventType.Verbose, 0, "From cache: " + response.IsFromCache);
                }
            }
            catch (WebException e) {
                response = (HttpWebResponse) e.Response;
                if (response == null) throw;
                Trace.TraceEvent(TraceEventType.Information, 0,
                    "Response status: " + response.StatusCode + ", " + response.StatusDescription);
                Trace.TraceEvent(TraceEventType.Verbose, 0, "From cache: " + response.IsFromCache);
                throw;
            }
            return response;
        }

        /// <summary>
        ///     Extracts and returns the response content from a HttpWebResponse
        /// </summary>
        /// <param name="response">The HttpWebResponse</param>
        /// <returns></returns>
        public static async Task<string> GetResponseContentAsync(HttpWebResponse response) {
            string data;
            var responseStream = response.GetResponseStream();
            if (responseStream == null) return null;
            using (var reader = new StreamReader(responseStream)) {
                data = await reader.ReadToEndAsync().ConfigureAwait(false);
            }
            return data;
        }

        /// <summary>
        ///     Executes, exctracts and returns response content for a HttpWebRequest
        /// </summary>
        /// <param name="request">The HttpWebRequest</param>
        /// <returns></returns>
        public static async Task<string> GetResponseContentAsync(HttpWebRequest request) {
            Trace.TraceEvent(TraceEventType.Start, 0, "Starting request: " + request.RequestUri);
            var data = "";
            using (var response = await GetResponseAsync(request).ConfigureAwait(false)) {
                var responseStream = response.GetResponseStream();
                if (responseStream == null) return data;
                using (var reader = new StreamReader(responseStream)) {
                    data = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
            Trace.TraceEvent(TraceEventType.Stop, 0, "Finished request: " + request.RequestUri);
            return data;
        }
    }
}