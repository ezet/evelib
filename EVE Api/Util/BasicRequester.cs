using System.IO;
using System.Net;

namespace eZet.Eve.EoLib.Util {
    public class BasicRequester : IRequester {

        private const string ContentType = "application/x-www-form-urlencoded";

        public string Request(string uri, params object[] args) {
            var postString = generatePostString(args);
            var data = "error";
            var request = WebRequest.Create(uri) as HttpWebRequest;
            if (request == null) return data;
            request.Method = "POST";
            request.ContentType = ContentType;
            request.ContentLength = postString.Length;
            request.Proxy = null;
            using (var writer = new StreamWriter(request.GetRequestStream())) {
                writer.Write(postString);
            }
            try {
                using (var response = (HttpWebResponse) request.GetResponse()) {
                    if (response.StatusCode.ToString() == "0") {
                        // TODO deal with http 0

                        
                    }
                    var responseStream = response.GetResponseStream();
                    if (responseStream == null) return data;
                    using (var reader = new StreamReader(responseStream)) {
                        data = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException e) {
                var response = (HttpWebResponse) e.Response;
                if (response.StatusCode != HttpStatusCode.BadRequest) throw;
                var responseStream = response.GetResponseStream();
                if (responseStream == null) return data;
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                }
                        // TODO deal with http 500
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