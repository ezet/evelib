using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;

namespace eZet.Eve.EveLib.Util.EveApi {

    /// <summary>
    /// Handles requests to the Eve API. Caching is accomplished by using the native HttpWebRequest caching (IE Cache).
    /// </summary>
    public class CachedRequestHandler : BaseRequestHandler {

        private const string ContentType = "application/x-www-form-urlencoded";

        public CachedRequestHandler(IXmlSerializer serializer)
            : base(serializer) {
        }

        /// <summary>
        /// Performs a request to the specified URI and returns an XmlResponse of specified type.
        /// </summary>
        /// <typeparam name="T">The type parameter for the xml response.</typeparam>
        /// <param name="uri">The URI to request.</param>
        /// <returns></returns>
        public override T Request<T>(Uri uri) {
            DateTime cachedUntil;
            var fromCache = CacheExpirationRegister.TryGetValue(uri, out cachedUntil) && DateTime.UtcNow < cachedUntil;
            var data = webRequest(uri, fromCache);
            var xml = Serializer.Deserialize<T>(data);
            register(uri, xml);
            SaveCacheState();
            return xml;
        }

        private void register(Uri uri, dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            // TODO type check
            CacheExpirationRegister.AddOrUpdate(uri, xml.CachedUntil);
        }

        /// <summary>
        /// Performs a web request.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="fromCache"></param>
        /// <returns></returns>
        private static string webRequest(Uri uri, bool fromCache) {
            var data = "";
            var request = WebRequest.CreateHttp(uri);
            request.ContentType = ContentType;

            request.CachePolicy = fromCache ? new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable) : new HttpRequestCachePolicy(HttpRequestCacheLevel.Reload);
            request.Proxy = null;

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
    }
}