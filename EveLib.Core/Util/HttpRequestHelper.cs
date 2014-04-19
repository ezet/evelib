using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace eZet.EveLib.Core.Util {
    public static class HttpRequestHelper {
        public const string ContentTypeForm = "application/x-www-form-urlencoded";

        public static HttpWebRequest CreateRequest(Uri uri) {
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            return request;
        }

        public static string Request(Uri uri) {
            HttpWebRequest request = CreateRequest(uri);
            return GetResponseContent(request);
        }

        public static HttpWebResponse GetResponse(HttpWebRequest request) {
            Debug.WriteLine("Requesting: " + request.RequestUri);
            HttpWebResponse response;
            try {
                response = request.GetResponse() as HttpWebResponse;
                if (response != null) {
                    Debug.WriteLine("Reponse status: " + response.StatusCode + ", " + response.StatusDescription);
                    Debug.WriteLine("From cache: " + response.IsFromCache);
                }
            } catch (WebException e) {
                response = (HttpWebResponse)e.Response;
                if (response == null) throw;
                Debug.WriteLine("Reponse status: " + response.StatusCode + ", " + response.StatusDescription);
                Debug.WriteLine("From cache: " + response.IsFromCache);
                throw;
            }
            return response;
        }

        public static string GetResponseContent(HttpWebRequest request) {
            string data = "";
            using (var response = GetResponse(request)) {
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