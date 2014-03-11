using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eZet.EveLib.EveMarketData {
    /// <summary>
    ///     Used to specify upload type in requests.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (StringEnumConverter))]
    public enum UploadType {
        [XmlEnum("o"), EnumMember(Value = "o")] Orders,
        [XmlEnum("h"), EnumMember(Value = "h")] History,
        [XmlEnum("b"), EnumMember(Value = "b")] Both
    }

    /// <summary>
    ///     Used to specify OrderType in requests.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof (StringEnumConverter))]
    public enum OrderType {
        [XmlEnum("s"), EnumMember(Value = "s")] Sell,
        [XmlEnum("b"), EnumMember(Value = "b")] Buy,
        [XmlEnum("a"), EnumMember(Value = "a")] Both
    }

    public enum MinMax {
        Min,
        Max
    }

    /// <summary>
    ///     Provides a set of configurable options for EveMarketData requests.
    /// </summary>
    public class EveMarketDataOptions {
        public EveMarketDataOptions() {
            Items = new List<long>();
            ItemGroups = new List<long>();
            Regions = new List<long>();
            Solarsystems = new List<long>();
            Stations = new List<long>();
            RowLimit = 10000;
        }

        /// <summary>
        ///     Gets or sets a collection of item IDs.
        /// </summary>
        public ICollection<long> Items { get; set; }

        /// <summary>
        ///     Gets or sets a collection of item group IDs.
        /// </summary>
        public ICollection<long> ItemGroups { get; set; }

        /// <summary>
        ///     Gets or sets a list of region IDs.
        /// </summary>
        public ICollection<long> Regions { get; set; }

        /// <summary>
        ///     Gets or sets a list of solarsystem IDs.
        /// </summary>
        public ICollection<long> Solarsystems { get; set; }

        /// <summary>
        ///     Gets or sets a list of station IDs.
        /// </summary>
        public ICollection<long> Stations { get; set; }

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