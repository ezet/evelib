using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules.RequestHandlers {
    public class ZkbRequestHandler : ICachedRequestHandler {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        public ZkbRequestHandler(ISerializer serializer, IEveLibCache cache) {
            Serializer = serializer;
            Cache = cache;
            EnableCacheLoad = true;
            EnableCacheStore = true;
        }

        public ISerializer Serializer { get; set; }


        public async Task<T> RequestAsync<T>(Uri uri) {
            _trace.TraceEvent(TraceEventType.Start, 0, "ZkbRequestHandler.RequestAsync(): {0}", uri);
            string data = null;
            if (EnableCacheLoad) {
                data = await Cache.LoadAsync(uri).ConfigureAwait(false);
            }
            var cacheTime = new DateTime();
            bool isCached = data != null;
            if (!isCached) {
                HttpWebRequest request = HttpRequestHelper.CreateRequest(uri);
                using (
                    HttpWebResponse response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false)) {
                    data = await HttpRequestHelper.GetResponseContentAsync(response).ConfigureAwait(false);
                    cacheTime = DateTime.Parse(response.GetResponseHeader("Expires"));
                }
            }
            if (!isCached && EnableCacheStore) {
                await Cache.StoreAsync(uri, cacheTime.ToUniversalTime(), data).ConfigureAwait(false);
            }
            _trace.TraceEvent(TraceEventType.Stop, 0, "ZkbRequestHandler.RequestAsync()", uri);
            return Serializer.Deserialize<T>(data);
        }

        public IEveLibCache Cache { get; set; }
        public bool EnableCacheLoad { get; set; }
        public bool EnableCacheStore { get; set; }
    }
}