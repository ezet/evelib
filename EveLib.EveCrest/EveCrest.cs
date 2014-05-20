using System;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public class EveCrest {

        public const string DefaultUri = "http://public-crest.eveonline.com/";

        public EveCrest() {
            RequestHandler = new RequestHandler(new HttpRequester(), new DynamicJsonSerializer());
            BaseUri = new Uri(DefaultUri);
        }

        public IRequestHandler RequestHandler { get; set; }

        public ISerializer Serializer { get; set; }

        public Uri BaseUri { get; set; }

        public dynamic GetKillmails(long id, string hash) {
            string relPath = "killmails/" + id + "/" + hash + "/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetIncursions() {
            const string relPath = "incursions/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetAlliances() {
            const string relPath = "alliances/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetAlliance(long allianceId) {
            string relPath = "alliances/" + allianceId + "/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public MarketHistoryResponse GetMarketHistory(long regionId, long typeId) {
            string relPath = "market/" + regionId + "/types/" + typeId + "/history/";
            return request<MarketHistoryResponse>(new Uri(BaseUri, relPath));
        }

        private T request<T>(Uri uri) {
            return RequestHandler.Request<T>(uri);
        }
    }
}
