using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    /// <summary>
    /// Class for accessing the Element43 Legacy API
    /// </summary>
    public class Element43Legacy {
        /// <summary>
        /// The default api URI 
        /// </summary>
        public const string DefaultUri = "http://element-43.com";

        /// <summary>
        ///     Default constructor, with a default base uri and request handler.
        /// </summary>
        public Element43Legacy() {
            RequestHandler = new RequestHandler(new XmlSerializer());
            BaseUri = new Uri(DefaultUri);
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
            Contract.Requires(options != null);
            return GetMarketStatAsync(options).Result;
        }

        /// <summary>
        ///     Returns aggregate statistics for the items specified.
        /// </summary>
        /// <param name="options">Valid options; Items, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public Task<Element43MarketStatResponse> GetMarketStatAsync(Element43Options options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Items.Count != 0, "You need to specify atleast one type.");
            const string relUri = "/market/api/marketstat";
            string queryString = options.GetRegionQuery("regionlimit") + options.GetItemQuery("typeid");
            Task<Element43MarketStatResponse> res = requestAsync<Element43MarketStatResponse>(relUri, queryString);
            return res;
        }

        private Task<T> requestAsync<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.RequestAsync<T>(uri);
        }
    }
}