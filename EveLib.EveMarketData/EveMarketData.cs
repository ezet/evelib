using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.Core.Exceptions;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     C# API for the API supplied by api.eve-marketdata.com.
    /// </summary>
    public class EveMarketData {
        /// <summary>
        /// Represents the requestable data formats
        /// </summary>
        public enum DataFormat {
            /// <summary>
            /// JSON
            /// </summary>
            Json,
            /// <summary>
            /// XML
            /// </summary>
            Xml,
        }

        private const string DefaultUri = "http://api.eve-marketdata.com";

        /// <summary>
        ///     Creates a new object using the specified format.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="name"></param>
        public EveMarketData(DataFormat format = DataFormat.Json, string name = "EveLib") {
            Format = format;
            Name = name;
            BaseUri = new Uri(DefaultUri);
            RequestHandler = new RequestHandler(new NewtonSoftJsonSerializer());
            setSerializer(format);
        }

        /// <summary>
        ///     Gets or sets the base URI for Eve Market Data.
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        ///     Gets or sets the request format.
        /// </summary>
        public DataFormat Format { get; private set; }

        /// <summary>
        ///     Gets or sets the name supplied to marketdata in the query string. Use your ingame name if you want evemarketdata to
        ///     be able to contact you in case of problems.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the RequestHandler.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        /// Sets the request format
        /// </summary>
        /// <param name="format"></param>
        public void SetFormat(DataFormat format) {
            setSerializer(format);
            Format = format;
        }

        /// <summary>
        ///     Returns a list of any orders that were recently updated.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Date, RowLimit</param>
        /// <param name="type"></param>
        /// <returns>A list of any orders that were recently updated.</returns>
        /// <exception cref="EveLibWebException">The request was invalid.</exception>
        public EveMarketDataResponse<EmdRecentUploads> GetRecentUploads(EveMarketDataOptions options, UploadType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            return GetRecentUploadsAsync(options, type).Result;
        }


        /// <summary>
        ///     Returns a list of any orders that were recently updated.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Date, RowLimit</param>
        /// <param name="type"></param>
        /// <returns>A list of any orders that were recently updated.</returns>
        /// <exception cref="EveLibWebException">The request was invalid.</exception>
        public Task<EveMarketDataResponse<EmdRecentUploads>> GetRecentUploadsAsync(EveMarketDataOptions options,
            UploadType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            string relUri = "/api/recent_uploads2." + Format.ToString().ToLower();
            string postString = getRecentUploadsQueryString(options, type);
            return requestAsync<EmdRecentUploads>(relUri, postString);
        }

        private string getRecentUploadsQueryString(EveMarketDataOptions options, UploadType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Items != null);
            Contract.Requires(options.ItemGroups != null);
            Contract.Requires(options.Regions != null);
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string regions = String.Join(",", options.Regions);
            string date = options.GetAgeLimit();
            return generateQueryString("char_name", Name, "type_ids", items, "region_ids", regions,
                "marketgroup_ids", groups,
                "limit", options.RowLimit, "upload_type", options.UploadTypeToString(type), "date", date);
        }

        /// <summary>
        ///     Returns all the orders on the market.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Solarsystems, Stations</param>
        /// <param name="type"></param>
        /// <param name="minmax"></param>
        /// <returns>All orders on the market.</returns>
        public EveMarketDataResponse<EmdItemPrices> GetItemPrice(EveMarketDataOptions options, OrderType type,
            MinMax minmax = default(MinMax)) {
            Contract.Requires(options != null, "Options cannot be null.");
            return GetItemPriceAsync(options, type, minmax).Result;
        }

        /// <summary>
        ///     Returns all the orders on the market.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Solarsystems, Stations</param>
        /// <param name="type"></param>
        /// <param name="minmax"></param>
        /// <returns>All orders on the market.</returns>
        public Task<EveMarketDataResponse<EmdItemPrices>> GetItemPriceAsync(EveMarketDataOptions options, OrderType type,
            MinMax minmax = default(MinMax)) {
            Contract.Requires(options != null, "Options cannot be null.");
            string relUri = "/api/item_prices2." + Format.ToString().ToLower();
            string postString = getItemPriceQueryString(options, type, minmax);
            return requestAsync<EmdItemPrices>(relUri, postString);
        }

        private string getItemPriceQueryString(EveMarketDataOptions options, OrderType type,
            MinMax minmax = default(MinMax)) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Stations != null);
            Contract.Requires(options.Items != null);
            Contract.Requires(options.ItemGroups != null);
            Contract.Requires(options.Regions != null);
            Contract.Requires(options.Solarsystems != null);
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string regions = String.Join(",", options.Regions);
            string solarsystems = String.Join(",", options.Solarsystems);
            string stations = String.Join(",", options.Stations);
            string minmaxval = minmax == MinMax.None ? "" : minmax.ToString().ToLower();
            return generateQueryString("char_name", Name, "type_ids", items, "marketgroup_ids", groups,
                "region_ids", regions,
                "solarsystem_ids", solarsystems, "station_ids", stations, "buysell", options.OrderTypeToString(type),
                "minmax", minmaxval);
        }


        /// <summary>
        ///     Returns market history for one or more items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <param name="type"></param>
        /// <returns>Market history for one or more items.</returns>
        public EveMarketDataResponse<EmdItemOrders> GetItemOrders(EveMarketDataOptions options, OrderType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            return GetItemOrdersAsync(options, type).Result;
        }

        /// <summary>
        ///     Returns market history for one or more items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <param name="type"></param>
        /// <returns>Market history for one or more items.</returns>
        public Task<EveMarketDataResponse<EmdItemOrders>> GetItemOrdersAsync(EveMarketDataOptions options,
            OrderType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            string relUri = "/api/item_orders2." + Format.ToString().ToLower();
            string postString = getItemOrdersQueryString(options, type);
            return requestAsync<EmdItemOrders>(relUri, postString);
        }

        private string getItemOrdersQueryString(EveMarketDataOptions options, OrderType type) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Stations != null);
            Contract.Requires(options.Items != null);
            Contract.Requires(options.ItemGroups != null);
            Contract.Requires(options.Regions != null);
            Contract.Requires(options.Solarsystems != null);
            string items = String.Join(",", options.Items);
            string groups = String.Join(",", options.ItemGroups);
            string regions = String.Join(",", options.Regions);
            string solarsystems = String.Join(",", options.Solarsystems);
            string stations = String.Join(",", options.Stations);
            return generateQueryString("char_name", Name, "type_ids", items, "marketgroup_ids", groups,
                "region_ids", regions,
                "solarsystem_ids", solarsystems, "station_ids", stations, "buysell", options.OrderTypeToString(type));
        }


        /// <summary>
        ///     Returns a best guess price of one or multiple items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <returns>A best guess price of one or multiple items.</returns>
        public EveMarketDataResponse<EmdItemHistory> GetItemHistory(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            return GetItemHistoryAsync(options).Result;
        }

        /// <summary>
        ///     Returns a best guess price of one or multiple items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <returns>A best guess price of one or multiple items.</returns>
        public Task<EveMarketDataResponse<EmdItemHistory>> GetItemHistoryAsync(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            string relUri = "/api/item_history2." + Format.ToString().ToLower();
            string postString = getItemHistoryQueryString(options);
            return requestAsync<EmdItemHistory>(relUri, postString);
        }

        private string getItemHistoryQueryString(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(options.Items.Count != 0, "You must specify atleast one type.");
            Contract.Requires(options.Regions.Count != 0, "You must specify atleast one region.");
            string items = String.Join(",", options.Items);
            string regions = String.Join(",", options.Regions);
            string days = "" + (int) options.AgeSpan.GetValueOrDefault().TotalDays;
            return generateQueryString("char_name", Name, "type_ids", items, "region_ids", regions, "days", days);
        }


        /// <summary>
        ///     Returns the daily station rank in a region and order statistics for stations.
        /// </summary>
        /// <param name="options">Valid options: Stations, Solarsystems, Regions, DayLimit</param>
        /// <returns>The daily station rank in a region and order statistics for stations</returns>
        public EveMarketDataResponse<EmdStationRank> GetStationRank(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            return GetStationRankAsync(options).Result;
        }

        /// <summary>
        ///     Returns the daily station rank in a region and order statistics for stations.
        /// </summary>
        /// <param name="options">Valid options: Stations, Solarsystems, Regions, DayLimit</param>
        /// <returns>The daily station rank in a region and order statistics for stations</returns>
        public Task<EveMarketDataResponse<EmdStationRank>> GetStationRankAsync(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            string relUri = "/api/station_rank2." + Format.ToString().ToLower();
            string postString = getStationRankQueryString(options);
            return requestAsync<EmdStationRank>(relUri, postString);
        }

        private string getStationRankQueryString(EveMarketDataOptions options) {
            Contract.Requires(options != null, "Options cannot be null.");
            Contract.Requires(
                options.Regions.Count != 0 ^ options.Solarsystems.Count != 0 ^ options.Stations.Count != 0,
                "You must specify atleast one of the following: Station, Solarsystem, Region.");
            string regions = String.Join(",", options.Regions);
            string solarsystems = String.Join(",", options.Solarsystems);
            string stations = String.Join(",", options.Stations);
            string days = "" + (int) options.AgeSpan.GetValueOrDefault().TotalDays;
            return generateQueryString("char_name", Name, "region_ids", regions, "solarsystem_ids",
                solarsystems, "station_ids", stations, "days", days);
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

        private Task<EveMarketDataResponse<T>> requestAsync<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.RequestAsync<EveMarketDataResponse<T>>(uri);
        }

        private string generateQueryString(params object[] args) {
            Contract.Requires(args != null);
            Contract.Requires(args.Length == 0 || args.Length > 1);
            string postString = "";
            for (int i = 0; i < args.Length; i += 2) {
                if (args[i + 1] != null && (args[i + 1]).ToString() != "")
                    postString += args[i] + "=" + args[i + 1] + "&";
            }
            return postString;
        }

        private void setSerializer(DataFormat format) {
            if (format == DataFormat.Xml)
                RequestHandler.Serializer = new XmlSerializer();
            else if (format == DataFormat.Json)
                RequestHandler.Serializer = new NewtonSoftJsonSerializer();
        }
    }
}