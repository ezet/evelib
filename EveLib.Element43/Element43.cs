using System;
using System.Diagnostics.Contracts;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public class Element43 {

        public const string DefaultUri = "http://element-43.com";

        /// <summary>
        ///     Default constructor, with a default base uri and request handler.
        /// </summary>
        public Element43(string baseUri = DefaultUri)
            : this(new RequestHandler(new XmlSerializerWrapper()), baseUri) {
        }

        public Element43(IRequestHandler requestHandler, string baseUri = DefaultUri) {
            RequestHandler = requestHandler;
            BaseUri = new Uri(baseUri);
        }

        /// <summary>
        ///     Gets or sets the base URI for requests.
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        ///     Gets or sets the RequestHandler used to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; private set; }

        /// <summary>
        ///     Returns aggregate statistics for the items specified.
        /// </summary>
        /// <param name="options">Valid options; Items, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public Element43MarketStatResponse GetMarketStat(Element43Options options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Items.Count != 0, "You need to specify atleast one type.");
            const string relUri = "/market/api/marketstat";
            string queryString = options.GetRegionQuery("regionlimit") + options.GetItemQuery("typeid");
            return request<Element43MarketStatResponse>(relUri, queryString);
        }

        private T request<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.Request<T>(uri);
        }
    }
}
