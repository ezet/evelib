using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    public static class HttpRequestHelper {
        public const string ContentTypeForm = "application/x-www-form-urlencoded";

        private static readonly TraceSource Trace = new TraceSource("EveLib");


        public static HttpWebRequest CreateRequest(Uri uri) {
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            return request;
        }

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