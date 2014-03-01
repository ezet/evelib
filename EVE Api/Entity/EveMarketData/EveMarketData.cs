using System;
using eZet.Eve.EveLib.Model.EveMarketData;
using eZet.Eve.EveLib.Util;
using eZet.Eve.EveLib.Util.EveCentral;

namespace eZet.Eve.EveLib.Entity.EveMarketData {

    public enum Format {
        Xml,
        Json,
        Text
    }

    /// <summary>
    /// C# API for the API supplied by api.eve-marketdata.com.
    /// Only XML format is currently supported. The JSON api from marketdata is inconsistent.
    /// 
    /// </summary>
    public class EveMarketData {

        public Uri BaseUri { get; private set; }

        public string Name { get; set; }

        public Format Format { get; set; }

        public IRequestHandler RequestHandler { get; set; }

        public EveMarketData() {
            Format = Format.Xml;
            Name = "demo";
            BaseUri = new Uri("http://api.eve-marketdata.com");
            RequestHandler = new RequestHandler(new XmlSerializerWrapper());
        }

        /// <summary>
        /// Returns a list of any orders that were recently updated.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Date, RowLimit</param>
        /// <param name="type"></param>
        /// <returns>A list of any orders that were recently updated.</returns>
        public XmlResponse<RecentUploads> GetRecentUploads(EveMarketDataOptions options, UploadType type) {
            var relUri = "/api/recent_uploads2." + Format.ToString().ToLower();
            var items = String.Join(",", options.Items);
            var groups = String.Join(",", options.ItemGroups);
            var regions = String.Join(",", options.Regions);
            var date = options.DateLimit.ToString("yyyy-mm-dd HH:mm:ss");
            var postString = generatePostString("char_name", Name, "type_ids", items, "region_ids", regions, "marketgroup_ids", groups,
                "date", date, "limit", options.RowLimit, "upload_type", options.UploadTypeToString(type), "date", date);
            return request<RecentUploads>(relUri, postString);
        }

        /// <summary>
        /// Returns a best guess price of one or multiple items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <returns>A best guess price of one or multiple items.</returns>
        public XmlResponse<ItemHistory> GetItemHistory(EveMarketDataOptions options) {
            var relUri = "/api/item_history2." + Format.ToString().ToLower();
            var items = String.Join(",", options.Items);
            var regions = String.Join(",", options.Regions);
            var postString = generatePostString("char_name", Name, "type_ids", items, "region_ids", regions, "days", options.DayLimit);
            return request<ItemHistory>(relUri, postString);
        }

        /// <summary>
        /// Returns all the orders on the market.
        /// </summary>
        /// <param name="options">Valid options: Items, Marketgroups, Regions, Solarsystems, Stations</param>
        /// <param name="type"></param>
        /// <param name="minmax"></param>
        /// <returns>All orders on the market.</returns>
        public XmlResponse<ItemPrices> GetItemPrice(EveMarketDataOptions options, OrderType type, MinMax minmax) {
            var relUri = "/api/item_prices2." + Format.ToString().ToLower();
            var items = String.Join(",", options.Items);
            var groups = String.Join(",", options.ItemGroups);
            var regions = String.Join(",", options.Regions);
            var solarsystems = String.Join(",", options.Solarsystems);
            var stations = String.Join(",", options.Stations);
            var postString = generatePostString("char_name", Name, "type_ids", items, "marketgroup_ids", groups, "region_ids", regions,
                "solarsystem_ids", solarsystems, "station_ids", stations, "buysell", options.OrderTypeToString(type), "minmax", minmax.ToString().ToLower());
            return request<ItemPrices>(relUri, postString);
        }

        /// <summary>
        /// Returns market history for one or more items.
        /// </summary>
        /// <param name="options">Valid options: Items, Regions, DayLimit</param>
        /// <param name="type"></param>
        /// <returns>Market history for one or more items.</returns>
        public XmlResponse<ItemOrders> GetItemOrders(EveMarketDataOptions options, OrderType type) {
            var relUri = "/api/item_orders2." + Format.ToString().ToLower();
            var items = String.Join(",", options.Items);
            var groups = String.Join(",", options.ItemGroups);
            var regions = String.Join(",", options.Regions);
            var solarsystems = String.Join(",", options.Solarsystems);
            var stations = String.Join(",", options.Stations);
            var postString = generatePostString("char_name", Name, "type_ids", items, "marketgroup_ids", groups, "region_ids", regions,
                "solarsystem_ids", solarsystems, "station_ids", stations, "buysell", options.OrderTypeToString(type));
            return request<ItemOrders>(relUri, postString);
        }

        /// <summary>
        /// Returns the daily station rank in a region and order statistics for stations.
        /// </summary>
        /// <param name="options">Valid options: Stations, Solarsystems, Regions, DayLimit</param>
        /// <returns>The daily station rank in a region and order statistics for stations</returns>
        public XmlResponse<StationRank> GetStationRank(EveMarketDataOptions options) {
            var relUri = "/api/station_rank2." + Format.ToString().ToLower();
            var regions = String.Join(",", options.Regions);
            var solarsystems = String.Join(",", options.Solarsystems);
            var stations = String.Join(",", options.Stations);
            var postString = generatePostString("char_name", Name, "region_ids", regions, "solarsystem_ids", solarsystems, "station_ids", stations, "days", options.DayLimit);
            return request<StationRank>(relUri, postString);
        }

        private XmlResponse<T> request<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.Request<XmlResponse<T>>(uri);
        }

        private string generatePostString(params object[] args) {
            var postString = "";
            for (var i = 0; i < args.Length; i += 2) {
                if (args[i + 1] != null && (args[i + 1]).ToString() != "")
                    postString += args[i] + "=" + args[i + 1] + "&";
            }
            return postString;
        }
    }
}