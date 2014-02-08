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

        public static XDocument Request(string uri, params object[] args) {
            string postString = "";
            for (int i = 0; i < args.Length; i += 2) {
                postString += args[i] + "=" + args[i+1] + "&";
            }
            uri = uriBase + uri;
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = postString.Length;

            using (var writer = new StreamWriter(request.GetRequestStream())) {
                writer.Write(postString);
            }
            var document = new XDocument("");
            try {
                using (var response = (HttpWebResponse)request.GetResponse()) {
                    if (response.StatusCode == HttpStatusCode.OK) {
                        Stream data = response.GetResponseStream();
                        document = XDocument.Load(data);
                    }
                }
            } catch (Exception e) {
                throw;
            }
            return document;
        }

        public static XDocument Request(string uri, Auth apiKey, params object[] args) {
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
