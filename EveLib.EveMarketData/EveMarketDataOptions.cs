using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Represents the upload types.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (StringEnumConverter))]
    public enum UploadType {
        /// <summary>
        /// Orders
        /// </summary>
        [XmlEnum("o"), EnumMember(Value = "o")] Orders,
        /// <summary>
        /// History
        /// </summary>
        [XmlEnum("h"), EnumMember(Value = "h")] History,
        /// <summary>
        /// Order and history
        /// </summary>
        [XmlEnum("b"), EnumMember(Value = "b")] Both
    }

    /// <summary>
    ///     Represents the order types
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (StringEnumConverter))]
    public enum OrderType {
        /// <summary>
        /// Sell order
        /// </summary>
        [XmlEnum("s"), EnumMember(Value = "s")] Sell,
        /// <summary>
        /// Buy order
        /// </summary>
        [XmlEnum("b"), EnumMember(Value = "b")] Buy,
        /// <summary>
        /// Buy and sell orders
        /// </summary>
        [XmlEnum("a"), EnumMember(Value = "a")] Both
    }

    /// <summary>
    /// I honestly don't know what this represents, see marketdata api docs.
    /// </summary>
    public enum MinMax {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Minimum
        /// </summary>
        Min,
        /// <summary>
        /// Maximum
        /// </summary>
        Max
    }

    /// <summary>
    ///     Provides a set of configurable options for EveMarketData requests.
    /// </summary>
    public class EveMarketDataOptions {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EveMarketDataOptions() {
            Items = new List<int>();
            ItemGroups = new List<int>();
            Regions = new List<int>();
            Solarsystems = new List<int>();
            Stations = new List<int>();
            RowLimit = 10000;
            AgeSpan = TimeSpan.FromDays(10);
        }

        /// <summary>
        ///     Gets or sets a collection of item IDs.
        /// </summary>
        public ICollection<int> Items { get; set; }

        /// <summary>
        ///     Gets or sets a collection of item group IDs.
        /// </summary>
        public ICollection<int> ItemGroups { get; set; }

        /// <summary>
        ///     Gets or sets a list of region IDs.
        /// </summary>
        public ICollection<int> Regions { get; set; }

        /// <summary>
        ///     Gets or sets a list of solarsystem IDs.
        /// </summary>
        public ICollection<int> Solarsystems { get; set; }

        /// <summary>
        ///     Gets or sets a list of station IDs.
        /// </summary>
        public ICollection<int> Stations { get; set; }

        /// <summary>
        ///     Gets or sets the maximum nubmer of rows to request.
        /// </summary>
        public int RowLimit { get; set; }

        /// <summary>
        ///     Gets or sets the age span, a TimeSpan for how far back in time to request data for.
        /// </summary>
        public TimeSpan? AgeSpan { get; set; }

        /// <summary>
        ///     Returns a DateTime representing AgeSpan subtracted from current time.
        /// </summary>
        /// <returns></returns>
        public string GetAgeLimit() {
            AgeSpan = AgeSpan ?? TimeSpan.FromDays(30);
            return DateTime.UtcNow.Subtract((TimeSpan) AgeSpan).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        ///     Resolves UploadType to it's query string value.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string UploadTypeToString(UploadType type) {
            switch (type) {
                case UploadType.Orders:
                    return "o";
                case UploadType.History:
                    return "h";
                case UploadType.Both:
                    return "b";
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Resolves OrderType to it's query string value.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string OrderTypeToString(OrderType type) {
            switch (type) {
                case OrderType.Sell:
                    return "s";
                case OrderType.Buy:
                    return "b";
                case OrderType.Both:
                    return "a";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}