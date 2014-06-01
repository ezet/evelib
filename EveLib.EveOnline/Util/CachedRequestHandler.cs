using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Handles requests to the Eve API using a cache.
    /// </summary>
    public class CachedRequestHandler : IRequestHandler {

        public CachedRequestHandler(IHttpRequester httpRequester, ISerializer serializer, IEveApiCache cache) {
            HttpRequester = httpRequester;
            Serializer = serializer;
            Cache = cache;
        }

        public IEveApiCache Cache { get; set; }

        public IHttpRequester HttpRequester { get; set; }

        public ISerializer Serializer { get; set; }

        public async Task<T> RequestAsync<T>(Uri uri) {
            Debug.WriteLine("Requesting: " + uri.ToString());

            string data = "";
            bool cached = Cache.TryGet(uri, out data);
            if (cached) {

                Debug.WriteLine("From cache: True");
            } else {
                try {
                    data = await HttpRequester.RequestAsync<T>(uri).ConfigureAwait(false);
                } catch (WebException e) {
                    var response = (HttpWebResponse)e.Response;
                    if (response == null) throw;
                    var responseStream = response.GetResponseStream();
                    if (responseStream == null) throw;
                    using (var reader = new StreamReader(responseStream)) {
                        data = reader.ReadToEnd();
                        var error = Serializer.Deserialize<EveApiError>(data);
                        Debug.WriteLine("Error: " + error.Error.ErrorCode + ", " + error.Error.ErrorText);
                        throw new InvalidRequestException(error.Error.ErrorText, error.Error.ErrorCode, e);
                    }
                }
            }
            var xml = Serializer.Deserialize<T>(data);
            if (!cached)
                Cache.Store(uri, getCacheExpirationTime(xml), data);
            return xml;
        }

        private DateTime getCacheExpirationTime(dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            // TODO type check
            return xml.CachedUntil;
        }
    }
}