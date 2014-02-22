using System.IO;
using System.Net;

namespace eZet.Eve.EoLib.Util {
    public class BasicRequester : IRequester {

        private const string ContentType = "application/x-www-form-urlencoded";

        public string Request(string uri, params object[] args) {
            var postString = generatePostString(args);
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

        private string generatePostString(params object[] args) {
            var postString = "";
            for (var i = 0; i < args.Length; i += 2) {
                postString += args[i] + "=" + args[i + 1] + "&";
            }
            return postString;
        }

    }
}