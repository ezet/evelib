using System;
using System.Diagnostics;
using System.Threading.Tasks;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules.RequestHandlers {
    public class ZkbRequestHandler : ICachedRequestHandler {

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        public ZkbRequestHandler(ISerializer serializer) {
            Serializer = serializer;
        }

        public ISerializer Serializer { get; set; }

        public async Task<T> RequestAsync<T>(Uri uri) {
            string data = null;
            if (EnableCacheLoad)
                data = await Cache.LoadAsync(uri).ConfigureAwait(false);
            var cacheTime = new DateTime();
            var isCached = data != null;
            if (!isCached) {
                var request = HttpRequestHelper.CreateRequest(uri);
                using (var response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false)) {
                    data = await HttpRequestHelper.GetResponseContentAsync(response).ConfigureAwait(false);
                    cacheTime = DateTime.Parse(response.GetResponseHeader("Expires"));
                }
            }
            if (!isCached && EnableCacheStore) {
                await Cache.StoreAsync(uri, cacheTime.ToUniversalTime(), data).ConfigureAwait(false);
                _trace.TraceEvent(TraceEventType.Verbose, 0, "ZKillboard Cache Time: {0}", cacheTime);
            }
            return Serializer.Deserialize<T>(data);
        }

        public IEveLibCache Cache { get; set; }
        public bool EnableCacheLoad { get; set; }
        public bool EnableCacheStore { get; set; }
    }
}
