using System;
using System.IO;
using System.Net;
using System.Net.Cache;

namespace eZet.Eve.EoLib.Util {
    public class WebRequester : BaseRequester {

        private const string ContentType = "application/x-www-form-urlencoded";

        public WebRequester(ICacheHandler cache) : base(cache) {
        }

        public override string Request(Uri uri) {
            string data;
            var query = uri.Query.Substring(1);
            if (Cache.TryGet(uri, out data))
                return data;
            var request = WebRequest.CreateHttp(uri.GetLeftPart(UriPartial.Path));
            request.Method = "POST";
            request.ContentType = ContentType;
            request.ContentLength = query.Length;
            request.Proxy = null;
            using (var writer = new StreamWriter(request.GetRequestStream())) {
                writer.Write(query);
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
            Cache.Store(uri, data);
            return data;
        }



    }
}