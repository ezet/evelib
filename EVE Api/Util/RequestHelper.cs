using System.IO;
using System.Net;
using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib.Util {
    public class RequestHelper : IRequestHelper {

        private const string ContentType = "application/x-www-form-urlencoded";

        public string Request(string uri, string postString) {
            var data = "";
            var request = WebRequest.Create(uri) as HttpWebRequest;
            if (request == null) return data;
            request.Method = "POST";
            request.ContentType = ContentType;
            request.ContentLength = postString.Length;
            request.Proxy = null;
            using (var writer = new StreamWriter(request.GetRequestStream())) {
                writer.Write(postString);
            }
            using (var response = (HttpWebResponse)request.GetResponse()) {
                //if (response.StatusCode != HttpStatusCode.OK) return data;
                var responseStream = response.GetResponseStream();
                if (responseStream == null) return data;
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                }
            }
            return data;
        }

        public string GeneratePostString(params object[] args) {
            var postString = "";
            for (var i = 0; i < args.Length; i += 2) {
                postString += args[i] + "=" + args[i + 1] + "&";
            }
            return postString;
        }

        public string GeneratePostString(ApiKey apiKey, params object[] args) {
            var authArgs = new object[args.Length + 4];
            args.CopyTo(authArgs, 0);
            var length = args.Length;
            authArgs[length++] = "keyId";
            authArgs[length++] = apiKey.KeyId;
            authArgs[length++] = "vCode";
            authArgs[length] = apiKey.VCode;
            return GeneratePostString(authArgs);
        }
    }
}