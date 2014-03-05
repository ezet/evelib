using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;

namespace eZet.Eve.EveLib.Util {
    public static class HttpRequestHelper {
        public const string ContentTypeForm = "application/x-www-form-urlencoded";

        public static HttpWebRequest CreateRequest(Uri uri) {
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.Proxy = null;
            return request;
        }

        public static string Request(Uri uri) {
            HttpWebRequest request = CreateRequest(uri);
            return GetContent(request);
        }

        public static HttpWebResponse GetResponse(HttpWebRequest request) {
            Contract.Requires(request != null);
            var response = request.GetResponse() as HttpWebResponse;
            return response;
        }


        public static string GetContent(WebRequest request) {
            Contract.Requires(request != null);
            string data = "";
            using (var response = (HttpWebResponse) request.GetResponse()) {
                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) return data;
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                }
            }

            return data;
        }
    }
}