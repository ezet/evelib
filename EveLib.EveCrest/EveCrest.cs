using System;
using System.Threading.Tasks;
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
            return GetKillmailsAsync(id, hash).Result;
        }

        public Task<dynamic> GetKillmailsAsync(long id, string hash) {
            string relPath = "killmails/" + id + "/" + hash + "/";
            return requestAsync<dynamic>(relPath);
        }

        public dynamic GetIncursions() {
            return GetIncursionsAsync().Result;
        }

        public Task<dynamic> GetIncursionsAsync() {
            const string relPath = "incursions/";
            return requestAsync<dynamic>(relPath);
        }

        public dynamic GetAlliances() {
            return GetAlliancesAsync().Result;
        }

        public Task<dynamic> GetAlliancesAsync() {
            const string relPath = "alliances/";
            return requestAsync<dynamic>(relPath);
        }

        public dynamic GetAlliance(long allianceId) {
            return GetAllianceAsync(allianceId).Result;
        }

        public Task<dynamic> GetAllianceAsync(long allianceId) {
            string relPath = "alliances/" + allianceId + "/";
            return requestAsync<dynamic>(relPath);
        }

        public MarketHistoryResponse GetMarketHistory(int regionId, int typeId) {
            return GetMarketHistoryAsync(regionId, typeId).Result;
        }


        public Task<MarketHistoryResponse> GetMarketHistoryAsync(int regionId, int typeId) {
            string relPath = "market/" + regionId + "/types/" + typeId + "/history/";
            return requestAsync<MarketHistoryResponse>(relPath);
        }

        public dynamic GetWars() {
            return GetWarsAsync().Result;
        }

        public Task<dynamic> GetWarsAsync() {
            string relPath = "/wars/";
            return requestAsync<dynamic>(relPath);
        }



        private Task<T> requestAsync<T>(string relPath) {
            return RequestHandler.RequestAsync<T>(new Uri(BaseUri, relPath));
        }
    }
}
