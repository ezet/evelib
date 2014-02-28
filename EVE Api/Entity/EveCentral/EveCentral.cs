using System;
using eZet.Eve.EveLib.Model.EveCentral;
using eZet.Eve.EveLib.Util;
using eZet.Eve.EveLib.Util.EveApi;
using eZet.Eve.EveLib.Util.EveCentral;

namespace eZet.Eve.EveLib.Entity.EveCentral {
    public class EveCentral {

        protected Uri BaseUri { get; set; }

        public IRequestHandler RequestHandler { get; set; }

        internal EveCentral() {
            BaseUri = new Uri("http://api.eve-central.com");
            RequestHandler = new RequestHandler();
        }

        /// <summary>
        /// Returns aggregate statistics for the items specified.
        /// </summary>
        /// <returns></returns>
        public MarketStatResponse GetMarketStat(EveCentralOptions options) {
            const string relUri = "/api/marketstat";
            var queryString = options.TypeQuery("typeid") + options.HourQuery("hours") + options.QualityQuery("minQ") +
                             options.RegionQuery("regionlimit") + options.SystemQuery("usesystem");
            return request<MarketStatResponse>(relUri, queryString);
        }

        /// <summary>
        /// Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <returns></returns>
        public QuicklookResponse GetQuicklook(EveCentralOptions options) {
            const string relUri = "/api/quicklook";
            var queryString = options.TypeQuery("typeid") + options.HourQuery("sethours") + options.QualityQuery("setminQ") +
                      options.RegionQuery("regionlimit") + options.SystemQuery("usesystem");
            return request<QuicklookResponse>(relUri, queryString);
        }

        public QuicklookResponse GetQuicklookPath(long start, long end, long typeId, int hourLimit = 0, int qualityLimit = 0) {
            var relUri = "/api/quicklook/onpath";
            relUri += "/from/" + start + "/to/" + end + "/fortype/" + typeId;
            var queryString = "?";
            queryString += hourLimit == 0 ? "" : "sethours=" + hourLimit + "&";
            queryString += qualityLimit == 0 ? "" : "setminQ=" + qualityLimit;
            return request<QuicklookResponse>(relUri, queryString);
        }

        public void GetHistory() {
            throw new NotImplementedException();
        }

        private T request<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.Request<T>(uri);
        }
    }
}
