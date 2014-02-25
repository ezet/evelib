using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Util {
    public class IeCachedRequestHandler : EveApiRequestHandler {

        private const string ContentType = "application/x-www-form-urlencoded";

        public IeCachedRequestHandler(IXmlSerializer serializer)
            : base(serializer) {
        }

        public override XmlResponse<T> Request<T>(T type, Uri uri) {
            DateTime cachedUntil;
            var fromCache = CacheExpirationRegister.TryGetValue(uri, out cachedUntil) && DateTime.UtcNow < cachedUntil;
            var data = webRequest(uri, fromCache);
            var xml = Serializer.Deserialize<T>(data);
            CacheExpirationRegister.AddOrUpdate(uri, xml.CachedUntil);
            SaveCacheState();
            return xml;
        }

        public override void SaveCacheState() {
            try {
                File.WriteAllLines(Configuration.AppDataPath + Path.DirectorySeparatorChar +
                                   Configuration.CacheFileName,
                    CacheExpirationRegister.Select(x => x.Key + "," + x.Value.ToString(CultureInfo.InvariantCulture)));
            }
            catch (DirectoryNotFoundException e) {
                Directory.CreateDirectory(Configuration.AppDataPath);
                SaveCacheState();
            }
        }

        private static string webRequest(Uri uri, bool fromCache) {
            var data = "";
            var request = WebRequest.CreateHttp(uri);
            request.ContentType = ContentType;

            if (fromCache)
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            else 
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Reload);
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