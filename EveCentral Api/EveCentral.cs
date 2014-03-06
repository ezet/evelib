using System;
using System.Diagnostics.Contracts;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveCentralApi.Model;

namespace eZet.EveLib.EveCentralApi {
    public class EveCentral {
        public EveCentral() {
            BaseUri = new Uri("http://api.eve-central.com");
            RequestHandler = new RequestHandler(new XmlSerializerWrapper());
        }

        protected Uri BaseUri { get; set; }

        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Returns aggregate statistics for the items specified.
        /// </summary>
        /// <param name="options">Valid options; Types, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public MarketStatResponse GetMarketStat(EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Types.Count != 0, "You need to specify atleast one type.");
            const string relUri = "/api/marketstat";
            string queryString = options.TypeQuery("typeid") + options.HourQuery("hours") +
                                 options.MinQuantityQuery("minQ") +
                                 options.RegionQuery("regionlimit") + options.SystemQuery("usesystem");
            return request<MarketStatResponse>(relUri, queryString);
        }

        /// <summary>
        ///     Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <param name="options">Valid options; Types, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public QuicklookResponse GetQuicklook(EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Types.Count != 0, "You need to specify atleast one type.");
            const string relUri = "/api/quicklook";
            string queryString = options.TypeQuery("typeid") + options.HourQuery("sethours") +
                                 options.MinQuantityQuery("setminQ") +
                                 options.RegionQuery("regionlimit") + options.SystemQuery("usesystem");
            return request<QuicklookResponse>(relUri, queryString);
        }

        /// <summary>
        /// </summary>
        /// <param name="startSystem">SystemID or System name</param>
        /// <param name="endSystem">SystemID or System name</param>
        /// <param name="typeId">Type ID</param>
        /// <param name="options">Optional; Valid options: HourLimit, MinQuantity.</param>
        /// <returns></returns>
        public QuicklookResponse GetQuicklookPath(object startSystem, object endSystem, long typeId,
            EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(startSystem != null, "Start system cannot be null.");
            Contract.Requires(endSystem != null, "End system cannot be null.");
            string relUri = "/api/quicklook/onpath";
            relUri += "/from/" + startSystem + "/to/" + endSystem + "/fortype/" + typeId;
            string queryString = "";
            queryString = options.HourQuery("sethours");
            queryString += options.MinQuantityQuery("setminQ");
            return request<QuicklookResponse>(relUri, queryString);
        }

        /// <summary>
        /// </summary>
        /// <param name="startSystem">SystemID or System name</param>
        /// <param name="endSystem">SystemID or System name</param>
        /// <param name="typeId">Type ID</param>
        /// <returns></returns>
        public QuicklookResponse GetQuicklookPath(object startSystem, object endSystem, long typeId) {
            Contract.Requires(startSystem != null, "Start system cannot be null.");
            Contract.Requires(endSystem != null, "End system cannot be null.");
            return GetQuicklookPath(startSystem, endSystem, typeId, new EveCentralOptions());
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