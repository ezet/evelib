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

        public dynamic GetKillmail(long id, string hash) {
            return GetKillmailAsync(id, hash).Result;
        }

        public Task<dynamic> GetKillmailAsync(long id, string hash) {
            string relPath = "killmails/" + id + "/" + hash + "/";
            return requestAsync<dynamic>(relPath);
        }

        public IncursionCollection GetIncursions() {
            return GetIncursionsAsync().Result;
        }

        public Task<IncursionCollection> GetIncursionsAsync() {
            const string relPath = "incursions/";
            return requestAsync<IncursionCollection>(relPath);
        }

        public AllianceCollection GetAlliances(int page = 1) {
            return GetAlliancesAsync(page).Result;
        }

        public Task<AllianceCollection> GetAlliancesAsync(int page = 1) {
            string relPath = "alliances/?page=" + page;
            return requestAsync<AllianceCollection>(relPath);
        }

        public Alliance GetAlliance(long allianceId) {
            return GetAllianceAsync(allianceId).Result;
        }

        public Task<Alliance> GetAllianceAsync(long allianceId) {
            string relPath = "alliances/" + allianceId + "/";
            return requestAsync<Alliance>(relPath);
        }

        public MarketHistoryCollection GetMarketHistory(int regionId, int typeId) {
            return GetMarketHistoryAsync(regionId, typeId).Result;
        }


        public Task<MarketHistoryCollection> GetMarketHistoryAsync(int regionId, int typeId) {
            string relPath = "market/" + regionId + "/types/" + typeId + "/history/";
            return requestAsync<MarketHistoryCollection>(relPath);
        }

        public WarCollection GetWars(int page = 1) {
            return GetWarsAsync().Result;
        }

        public Task<WarCollection> GetWarsAsync(int page = 1) {
            string relPath = "/wars/?page=" + page;
            return requestAsync<WarCollection>(relPath);
        }

        public War GetWar(int id) {
            return GetWarAsync(id).Result;
        }

        public Task<War> GetWarAsync(int id) {
            string relPath = "/wars/" + id + "/";
            return requestAsync<War>(relPath);
        }

        public KillmailCollection GetWarKillmails(int id) {
            return GetWarKillmailsAsync(id).Result;
        }

        public Task<KillmailCollection> GetWarKillmailsAsync(int id) {
            string relPath = "/wars/" + id + "/killmails/all/";
            return requestAsync<KillmailCollection>(relPath);
        }

        private Task<T> requestAsync<T>(string relPath) {
            return RequestHandler.RequestAsync<T>(new Uri(BaseUri, relPath));
        }
    }
}
