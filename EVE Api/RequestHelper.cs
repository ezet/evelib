using System.IO;
using System.Net;

namespace eZet.Eve.EveApi {
    public class RequestHelper : IRequestHelper {

        private const string ContentType = "application/x-www-form-urlencoded";

        public string Request(string uri, string postString) {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = ContentType;
            request.ContentLength = postString.Length;
            string data = null;
            using (var writer = new StreamWriter(request.GetRequestStream())) {
                writer.Write(postString);
            }
            using (var response = (HttpWebResponse)request.GetResponse()) {
                if (response.StatusCode == HttpStatusCode.OK) {
                    var reader = new StreamReader(response.GetResponseStream());
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