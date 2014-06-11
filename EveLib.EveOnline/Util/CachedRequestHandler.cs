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

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        public CachedRequestHandler(IHttpRequester httpRequester, ISerializer serializer, IEveLibCache cache) {
            HttpRequester = httpRequester;
            Serializer = serializer;
            Cache = cache;
        }

        public IEveLibCache Cache { get; set; }

        public IHttpRequester HttpRequester { get; set; }

        public ISerializer Serializer { get; set; }

        public async Task<T> RequestAsync<T>(Uri uri) {
            string data  = await Cache.LoadAsync(uri).ConfigureAwait(false);
            var cached = data != null;
            if (!cached) {
                try {
                    data = await HttpRequester.RequestAsync<T>(uri).ConfigureAwait(false);
                } catch (WebException e) {
                    _trace.TraceEvent(TraceEventType.Error, 0, "Http Request failed");
                    var response = (HttpWebResponse)e.Response;
                    if (response == null) throw;
                    var responseStream = response.GetResponseStream();
                    if (responseStream == null) throw;
                    using (var reader = new StreamReader(responseStream)) {
                        data = reader.ReadToEnd();
                        var error = Serializer.Deserialize<EveApiError>(data);
                        _trace.TraceEvent(TraceEventType.Verbose, 0, "Error: {0}, Code: {1}", error.Error.ErrorText, error.Error.ErrorCode);
                        throw new InvalidRequestException(error.Error.ErrorText, error.Error.ErrorCode, e);
                    }
                }
            }
            var xml = Serializer.Deserialize<T>(data);
            if (!cached)
                await Cache.StoreAsync(uri, getCacheExpirationTime(xml), data).ConfigureAwait(false);
            return xml;
        }

        private DateTime getCacheExpirationTime(dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            // TODO type check
            return xml.CachedUntil;
        }
    }
}