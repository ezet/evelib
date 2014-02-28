using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace eZet.Eve.EveLib.Util {
    public static class HttpRequestHelper {

        private const string ContentType = "application/x-www-form-urlencoded";

        public static HttpWebRequest CreateRequest(Uri uri) {
            var request = WebRequest.CreateHttp(uri);
            //request.ContentType = ContentType;
            request.Proxy = null;
            return request;
        }

        public static string Request(Uri uri) {
            var request = CreateRequest(uri);
            return GetContent(request);
        }

        public static HttpWebResponse GetResponse(HttpWebRequest request) {
            HttpWebResponse response;
            try {
                response = request.GetResponse() as HttpWebResponse;
            } catch (WebException e) {
                response = (HttpWebResponse)e.Response;
                Debug.WriteLine(response.IsFromCache);
                if (response.StatusCode != HttpStatusCode.BadRequest) throw;
            }
            return response;
        }


        public static string GetContent(WebRequest request) {
            var data = "";
            try {
                using (var response = (HttpWebResponse)request.GetResponse()) {
                    var responseStream = response.GetResponseStream();
                    if (responseStream == null) return data;
                    using (var reader = new StreamReader(responseStream)) {
                        data = reader.ReadToEnd();
                    }
                }
            } catch (WebException e) {
                var response = (HttpWebResponse)e.Response;
                Debug.WriteLine(response.IsFromCache);
                if (response.StatusCode != HttpStatusCode.BadRequest) throw;
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
