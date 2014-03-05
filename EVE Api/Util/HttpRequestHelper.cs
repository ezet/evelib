using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;

namespace eZet.Eve.EveLib.Util {
    public static class HttpRequestHelper {

        public const string ContentTypeForm = "application/x-www-form-urlencoded";

        public static HttpWebRequest CreateRequest(Uri uri) {
            var request = WebRequest.CreateHttp(uri);
            request.Proxy = null;
            return request;
        }

        public static string Request(Uri uri) {
            var request = CreateRequest(uri);
            return GetContent(request);
        }

        public static HttpWebResponse GetResponse(HttpWebRequest request) {
            Contract.Requires(request != null);
            var response = request.GetResponse() as HttpWebResponse;
            return response;
        }


        public static string GetContent(WebRequest request) {
            Contract.Requires(request != null);
            var data = "";
            using (var response = (HttpWebResponse)request.GetResponse()) {
                var responseStream = response.GetResponseStream();
                if (responseStream == null) return data;
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                }
            }

            return data;
        }
    }
}
