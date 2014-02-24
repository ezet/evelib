using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Runtime.Remoting.Messaging;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public class CachedRequester : IRequester {

        private const string ContentType = "application/x-www-form-urlencoded";

        public IXmlSerializer Serializer { get; private set; }

        private readonly ConcurrentDictionary<string, DateTime> cache = new ConcurrentDictionary<string, DateTime>();

        public CachedRequester() {
            Serializer = new XmlSerializerWrapper();
        }

        public XmlResponse<T> Request<T>(T type, Uri uri) where T : XmlElement {
            var filePath = resolveFile(uri);
            DateTime cachedUntil;
            var fromCache = cache.TryGetValue(filePath, out cachedUntil) && cachedUntil > DateTime.UtcNow;
            var data = webRequest(uri, fromCache);
            var xml = Serializer.Deserialize<T>(data);
            //cache.AddOrUpdate(filePath, xml.CachedUntil, (key, val) => xml.CachedUntil);
            return xml;
        }

        private string webRequest(Uri uri, bool fromCache) {
            var data = "";
            var request = WebRequest.CreateHttp(uri);
            request.ContentType = ContentType;
            if (fromCache)
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            request.Proxy = null;

            //using (var writer = new StreamWriter(request.GetRequestStream())) {
            //    writer.Write(query);
            //}
            try {
                using (var response = (HttpWebResponse)request.GetResponse()) {
                    if (response.StatusCode.ToString() == "0") {
                        // TODO deal with http 0
                    }
                    Debug.WriteLine(response.IsFromCache);
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
                // TODO deal with http 500
            }

            return data;
        }

        private static string resolveFile(Uri uri) {
            return uri.PathAndQuery.Replace("/", "").Replace(".aspx", "");
        }



    }
}