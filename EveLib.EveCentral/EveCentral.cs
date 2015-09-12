using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCentralModule.Models;

namespace eZet.EveLib.EveCentralModule {
    /// <summary>
    ///     Class for accessing the EveCentral API
    /// </summary>
    public class EveCentral {
        private const string DefaultUri = "http://api.eve-central.com";

        /// <summary>
        /// Gets or sets the HTTP method.
        /// </summary>
        /// <value>The Http method.</value>
        public HttpMethod Method { get; set; }

        /// <summary>
        ///     Creates a new EveCentral object, with a default base uri and request handler.
        /// </summary>
        public EveCentral() {
            Method = HttpMethod.Post;
            BaseUri = new Uri(DefaultUri);
            RequestHandler = new RequestHandler(new XmlSerializer());
        }

        /// <summary>
        ///     Gets or sets the base URI for requests.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the RequestHandler used to perform requests.
        /// </summary>
        public IPostRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Returns aggregate statistics for the items specified.
        /// </summary>
        /// <param name="options">Valid options; Items, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public MarketStatResponse GetMarketStat(EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Items.Count != 0, "You need to specify atleast one type.");
            return GetMarketStatAsync(options).Result;
        }

        /// <summary>
        ///     Returns aggregate statistics for the items specified.
        /// </summary>
        /// <param name="options">Valid options; Items, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public Task<MarketStatResponse> GetMarketStatAsync(EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Items.Count != 0, "You need to specify atleast one type.");
            const string relUri = "/api/marketstat";
            string queryString = options.GetItemQuery("typeid") + options.GetHourQuery("hours") +
                                 options.GetMinQuantityQuery("minQ") +
                                 options.GetRegionQuery("regionlimit") + options.GetSystemQuery("usesystem");
            return requestAsync<MarketStatResponse>(relUri, queryString, Method);
        }

        /// <summary>
        ///     Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <param name="options">Valid options; Items, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public QuickLookResponse GetQuicklook(EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Items.Count != 0, "You need to specify atleast one type.");
            return GetQuicklookAsync(options).Result;
        }


        /// <summary>
        ///     Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <param name="options">Valid options; Items, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public Task<QuickLookResponse> GetQuicklookAsync(EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            Contract.Requires(options.Items.Count != 0, "You need to specify atleast one type.");
            const string relUri = "/api/quicklook";
            string queryString = options.GetItemQuery("typeid") + options.GetHourQuery("sethours") +
                                 options.GetMinQuantityQuery("setminQ") +
                                 options.GetRegionQuery("regionlimit") + options.GetSystemQuery("usesystem");
            return requestAsync<QuickLookResponse>(relUri, queryString, Method);
        }

        /// <summary>
        ///     Retrieve all of the available market orders, including prices, stations, order IDs, volumes, etc., on a given jump
        ///     path.
        /// </summary>
        /// <param name="startSystem">SystemID or System name</param>
        /// <param name="endSystem">SystemID or System name</param>
        /// <param name="typeId">Type ID</param>
        /// <param name="options">Optional; Valid options: HourLimit, MinQuantity.</param>
        /// <returns></returns>
        public QuickLookResponse GetQuicklookPath(object startSystem, object endSystem, long typeId,
            EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(startSystem != null, "Start system cannot be null.");
            Contract.Requires(endSystem != null, "End system cannot be null.");
            return GetQuicklookPathAsync(startSystem, endSystem, typeId, options).Result;
        }

        /// <summary>
        ///     Retrieve all of the available market orders, including prices, stations, order IDs, volumes, etc., on a given jump
        ///     path.
        /// </summary>
        /// <param name="startSystem">SystemID or System name</param>
        /// <param name="endSystem">SystemID or System name</param>
        /// <param name="typeId">Type ID</param>
        /// <param name="options">Optional; Valid options: HourLimit, MinQuantity.</param>
        /// <returns></returns>
        public Task<QuickLookResponse> GetQuicklookPathAsync(object startSystem, object endSystem, long typeId,
            EveCentralOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(startSystem != null, "Start system cannot be null.");
            Contract.Requires(endSystem != null, "End system cannot be null.");
            var relUri = "/api/quicklook/onpath";
            relUri += "/from/" + startSystem + "/to/" + endSystem + "/fortype/" + typeId;
            var queryString = options.GetHourQuery("sethours");
            queryString += options.GetMinQuantityQuery("setminQ");
            return requestAsync<QuickLookResponse>(relUri, queryString, Method);
        }

        /// <summary>
        ///     Retrieves the eve central market history
        /// </summary>
        public void GetHistory() {
            // TODO Implements this
            throw new NotImplementedException();
        }



        private async Task<T> requestAsync<T>(string relUri, string queryString, HttpMethod method) {
            if (method == HttpMethod.Post) {
                return await RequestHandler.PostRequestAsync<T>(new Uri(BaseUri, relUri), queryString).ConfigureAwait(false);
            }
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return await RequestHandler.RequestAsync<T>(uri).ConfigureAwait(false);
        }
    }
}