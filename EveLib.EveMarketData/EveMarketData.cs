using System;
using System.Diagnostics.Contracts;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public enum Format {
        Json,
        Xml,
    }

    /// <summary>
    ///     C# API for the API supplied by api.eve-marketdata.com.
    /// </summary>
    public class EveMarketData {

        private const string DefaultUri = "http://api.eve-marketdata.com";

        /// <summary>
        ///     Creates a new object using the specified format.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="name"></param>
        /// <param name="baseUri"></param>
        public EveMarketData(Format format = Format.Json, string name = "demo", string baseUri = DefaultUri) {
            Format = format;
            Name = name;
            BaseUri = new Uri(baseUri);
            setRequestHandler(format);
        }

        /// <summary>
        ///     Gets or sets the base URI for Eve Market Data.
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        ///     Gets or sets the request format.
        /// </summary>
        public Format Format { get; private set; }

        /// <summary>
        ///     Gets or sets the name supplied to marketdata in the query string. Use your ingame name if you want evemarketdata to
        ///     be able to contact you in case of problems.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets or sets the RequestHandler.
        /// </summary>
        public IRequestHandler RequestHandler { get; private set; }

        /// <summary>
        ///     Returns a list of any orders that were recently updated.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Date, RowLimit</param>
        /// <param name="type"></param>
        /// <returns>A list of any orders that were recently updated.</returns>
        /// <exception cref="InvalidRequestException">The request was invalid.</exception>
        public EveMarketDataResponse<RecentUploads> GetRecentUploads(EveMarketDataOptions options, UploadType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Items != null);
            Contract.Requires(options.ItemGroups != null);
            Contract.Requires(options.Regions != null);
            string relUri = "/api/recent_uploads2." + Format.ToString().ToLower();
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string regions = String.Join(",", options.Regions);
            string date = options.GetAgeLimit();
            string postString = generateQueryString("char_name", Name, "type_ids", items, "region_ids", regions,
                "marketgroup_ids", groups,
                "limit", options.RowLimit, "upload_type", options.UploadTypeToString(type), "date", date);
            return request<RecentUploads>(relUri, postString);
        }

        /// <summary>
        ///     Returns all the orders on the market.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Solarsystems, Stations</param>
        /// <param name="type"></param>
        /// <param name="minmax"></param>
        /// <returns>All orders on the market.</returns>
        public EveMarketDataResponse<ItemPrices> GetItemPrice(EveMarketDataOptions options, OrderType type,
            MinMax minmax = default(MinMax)) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Stations != null);
            Contract.Requires(options.Items != null);
            Contract.Requires(options.ItemGroups != null);
            Contract.Requires(options.Regions != null);
            Contract.Requires(options.Solarsystems != null);
            string relUri = "/api/item_prices2." + Format.ToString().ToLower();
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string regions = String.Join(",", options.Regions);
            string solarsystems = String.Join(",", options.Solarsystems);
            string stations = String.Join(",", options.Stations);
            var minmaxval = minmax == MinMax.None ? "" : minmax.ToString().ToLower();
            string postString = generateQueryString("char_name", Name, "type_ids", items, "marketgroup_ids", groups,
                "region_ids", regions,
                "solarsystem_ids", solarsystems, "station_ids", stations, "buysell", options.OrderTypeToString(type),
                "minmax", minmaxval);
            return request<ItemPrices>(relUri, postString);
        }

        /// <summary>
        ///     Returns market history for one or more items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <param name="type"></param>
        /// <returns>Market history for one or more items.</returns>
        public EveMarketDataResponse<ItemOrders> GetItemOrders(EveMarketDataOptions options, OrderType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Stations != null);
            Contract.Requires(options.Items != null);
            Contract.Requires(options.ItemGroups != null);
            Contract.Requires(options.Regions != null);
            Contract.Requires(options.Solarsystems != null);
            string relUri = "/api/item_orders2." + Format.ToString().ToLower();
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string regions = String.Join(",", options.Regions);
            string solarsystems = String.Join(",", options.Solarsystems);
            string stations = String.Join(",", options.Stations);
            string postString = generateQueryString("char_name", Name, "type_ids", items, "marketgroup_ids", groups,
                "region_ids", regions,
                "solarsystem_ids", solarsystems, "station_ids", stations, "buysell", options.OrderTypeToString(type));
            return request<ItemOrders>(relUri, postString);
        }

        /// <summary>
        ///     Returns a best guess price of one or multiple items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <returns>A best guess price of one or multiple items.</returns>
        public EveMarketDataResponse<ItemHistory> GetItemHistory(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Items.Count != 0, "You must specify atleast one type.");
            Contract.Requires(options.Regions.Count != 0, "You must specify atleast one region.");
            string relUri = "/api/item_history2." + Format.ToString().ToLower();
            string items = String.Join(",", options.Items);
            string regions = String.Join(",", options.Regions);
            string days = "" + (int)options.AgeSpan.GetValueOrDefault().TotalDays;
            string postString = generateQueryString("char_name", Name, "type_ids", items, "region_ids", regions, "days", days);
            return request<ItemHistory>(relUri, postString);
        }

        /// <summary>
        ///     Returns the daily station rank in a region and order statistics for stations.
        /// </summary>
        /// <param name="options">Valid options: Stations, Solarsystems, Regions, DayLimit</param>
        /// <returns>The daily station rank in a region and order statistics for stations</returns>
        public EveMarketDataResponse<StationRank> GetStationRank(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(
                options.Regions.Count != 0 ^ options.Solarsystems.Count != 0 ^ options.Stations.Count != 0,
                "You must specify atleast one of the following: Station, Solarsystem, Region.");
            string relUri = "/api/station_rank2." + Format.ToString().ToLower();
            string regions = String.Join(",", options.Regions);
            string solarsystems = String.Join(",", options.Solarsystems);
            string stations = String.Join(",", options.Stations);
            string days = "" + (int) options.AgeSpan.GetValueOrDefault().TotalDays;
            string postString = generateQueryString("char_name", Name, "region_ids", regions, "solarsystem_ids",
                solarsystems, "station_ids", stations, "days", days);
            return request<StationRank>(relUri, postString);
        }

        /// <summary>
        ///     Returns a url to a list of ingame item links. Reqiured use of the ingame browser.
        /// </summary>
        /// <param name="options">Valid options: Items, ItemGroups</param>
        /// <returns></returns>
        public Uri GetScannerUri(EveMarketDataOptions options) {
            // TODO Add support for return url and loop
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Items.Count != 0 || options.ItemGroups.Count != 0);
            const string relUri = "/update_market.php?step=Custom&";
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string query = generateQueryString("type_id", items, "marketgroup_id", groups);
            return new Uri("http://eve-marketdata.com" + relUri + query);
        }

        private EveMarketDataResponse<T> request<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.Request<EveMarketDataResponse<T>>(uri);
        }

        private string generateQueryString(params object[] args) {
            Contract.Requires(args != null);
            Contract.Requires(args.Length%2 == 0);
            string postString = "";
            for (int i = 0; i < args.Length; i += 2) {
                if (args[i + 1] != null && (args[i + 1]).ToString() != "")
                    postString += args[i] + "=" + args[i + 1] + "&";
            }
            return postString;
        }

        private void setRequestHandler(Format format) {
            if (format == Format.Xml)
                RequestHandler = new RequestHandler(new XmlSerializerWrapper());
            else RequestHandler = new RequestHandler(new JsonSerializer());
        }
    }
}