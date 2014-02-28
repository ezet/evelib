using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EveLib.Model.EveCentral;
using eZet.Eve.EveLib.Util;

namespace eZet.Eve.EveLib.Entity.EveCentral {
    public class EveCentral {

        protected Uri BaseUri { get; set; }

        internal EveCentral() {
            BaseUri = new Uri("http://api.eve-central.com");
        }

        /// <summary>
        /// Returns aggregate statistics for the items specified.
        /// </summary>
        /// <returns></returns>
        public MarketStatResponse GetMarketStat(EveCentralOptions options) {
            const string relUri = "/api/marketstat";
            var queryString = options.TypeQuery("typeid") + options.HourQuery("hours") + options.QualityQuery("minQ") +
                             options.RegionQuery("regoinlimit") + options.SystemQuery("usesystem");
            queryString = "typeid=34&typeid=35&regionlimit=10000002";
            return request(new MarketStatResponse(), relUri, queryString);
        }

        /// <summary>
        /// Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <returns></returns>
        public QuicklookResponse GetQuicklook(EveCentralOptions options) {
            const string relUri = "/api/quicklook";
            var queryString = options.TypeQuery("typeid") + options.HourQuery("sethours") + options.QualityQuery("setminQ") +
                      options.RegionQuery("regoinlimit") + options.SystemQuery("usesystem");
            queryString = "typeid=34&regionlimit=10000002";
            return request(new QuicklookResponse(), relUri, queryString);
        }

        public QuicklookResponse GetQuicklookPath(long start, long end, long typeId, int hourLimit = 0, int qualityLimit = 0) {
            var relUri = "/api/quicklook/onpath";
            relUri += "/from/" + start + "/to/" + end + "/fortype/" + typeId;
            var queryString = "?";
            queryString += hourLimit == 0 ? "" : "sethours=" + hourLimit + "&";
            queryString += qualityLimit == 0 ? "" : "setminQ=" + qualityLimit;
            return request(new QuicklookResponse(), relUri, queryString);
        }

        public void GetHistory() {
            throw new NotImplementedException();
        }

        private T request<T>(T type, string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            var data = HttpRequestHelper.Request(uri);
            T xmlResponse;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (T)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }
    }
}
