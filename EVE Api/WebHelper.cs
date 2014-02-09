using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eZet.Eve.EveApi {
    public static class WebHelper {

        private const string uriBase = "https://api.eveonline.com";

        private const string contentType = "application/x-www-form-urlencoded";

        public static string Request(string uri, params object[] args) {
            string postString = "";
            for (int i = 0; i < args.Length; i += 2) {
                postString += args[i] + "=" + args[i + 1] + "&";
            }
            uri = uriBase + uri;
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = postString.Length;
            string data = null;
            try {

                using (var writer = new StreamWriter(request.GetRequestStream())) {
                    writer.Write(postString);
                }
                using (var response = (HttpWebResponse)request.GetResponse()) {
                    if (response.StatusCode == HttpStatusCode.OK) {
                        var reader = new StreamReader(response.GetResponseStream());
                        data = reader.ReadToEnd();
                    }
                }
            } catch (Exception e) {
                throw;
            }
            return data;
        }

        public static string Request(string uri, ApiKey apiKey, params object[] args) {
            object[] authargs = new object[args.Length + 4];
            args.CopyTo(authargs, 0);
            int length = args.Length;
            authargs[length++] = "keyId";
            authargs[length++] = apiKey.KeyId;
            authargs[length++] = "vCode";
            authargs[length++] = apiKey.VCode;
            return Request(uri, authargs);
        }

    }
}
