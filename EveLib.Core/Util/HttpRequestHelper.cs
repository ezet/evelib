using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    /// Helper class for performing web requests
    /// </summary>
    public static class HttpRequestHelper {
        /// <summary>
        /// Default content type
        /// </summary>
        public const string ContentType = "application/x-www-form-urlencoded";

        private static readonly TraceSource Trace = new TraceSource("EveLib");

        /// <summary>
        /// Creates a new HttpWebRequest for the specified URI, and returns it
        /// </summary>
        /// <param name="uri">URI to create request for</param>
        /// <returns>The HttpWebRequest</returns>
        public static HttpWebRequest CreateRequest(Uri uri) {
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.Proxy = null;
            request.UserAgent = Config.UserAgent;
            request.ContentType = ContentType;
            return request;
        }

        /// <summary>
        /// Performs a web request against the specified URI, and returns the response content
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns>The response content</returns>
        public static Task<string> RequestAsync(Uri uri) {
            HttpWebRequest request = CreateRequest(uri);
            return GetResponseContentAsync(request);
        }

        /// <summary>
        /// Executes a web request using the given request, and returns the HttpWebResponse
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
        /// Extracts and returns the response content from a HttpWebResponse
        /// </summary>
        /// <param name="response">The HttpWebResponse</param>
        /// <returns></returns>
        public static async Task<string> GetResponseContentAsync(HttpWebResponse response) {
            string data;
            Stream responseStream = response.GetResponseStream();
            if (responseStream == null) return null;
            using (var reader = new StreamReader(responseStream)) {
                data = await reader.ReadToEndAsync().ConfigureAwait(false);
            }
            return data;
        }

        /// <summary>
        /// Executes, exctracts and returns response content for a HttpWebRequest
        /// </summary>
        /// <param name="request">The HttpWebRequest</param>
        /// <returns></returns>
        public static async Task<string> GetResponseContentAsync(HttpWebRequest request) {
            Trace.TraceEvent(TraceEventType.Start, 0, "Starting request: " + request.RequestUri);
            string data = "";
            using (HttpWebResponse response = await GetResponseAsync(request).ConfigureAwait(false)) {
                Stream responseStream = response.GetResponseStream();
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