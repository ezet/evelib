using System;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules {
    public class EveCrest {

        public const string DefaultUri = "http://public-crest.eveonline.com";

        public EveCrest(string baseUri = DefaultUri) : this(new RequestHandler(new DynamicJsonSerializer()), baseUri) {
        }

        public EveCrest(IRequestHandler requestHandler, string baseUri = DefaultUri) {
            RequestHandler = requestHandler;
            BaseUri = new Uri(baseUri);
        }


        public IRequestHandler RequestHandler { get; private set; }

        public Uri BaseUri { get; private set; }

        public dynamic GetKillmails(long id, string hash) {
            string relPath = "/killmails/" + id + "/" + hash + "/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetIncursions() {
            const string relPath = "/incursions/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetAlliances() {
            const string relPath = "/alliances/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetAlliance(long allianceId) {
            string relPath = "/alliances/" + allianceId + "/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetMarketHistory(long regionId, long typeId) {
            string relPath = "/market/" + regionId + "/types/" + typeId + "/history/";
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        private T request<T>(Uri uri) {
            return RequestHandler.Request<T>(uri);
        }


    }
}
