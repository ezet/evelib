using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eZet.EveLib.EveMarketDataLib {
    public enum UploadType {
        [XmlEnum("o")] Orders = 'o',
        [XmlEnum("h")] History = 'h',
        [XmlEnum("b")] Both = 'b'
    }

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

    public class EveMarketDataOptions {
        public EveMarketDataOptions() {
            Items = new List<long>();
            ItemGroups = new List<long>();
            Regions = new List<long>();
            Solarsystems = new List<long>();
            Stations = new List<long>();
            RowLimit = 10000;
        }

        public ICollection<long> Items { get; private set; }

        public ICollection<long> ItemGroups { get; private set; }

        public ICollection<long> Regions { get; private set; }

        public ICollection<long> Solarsystems { get; private set; }

        public ICollection<long> Stations { get; private set; }

        public int RowLimit { get; set; }

        public TimeSpan? AgeSpan { get; set; }

        public string GetAgeLimit() {
            AgeSpan = AgeSpan ?? TimeSpan.FromDays(30);
            return DateTime.UtcNow.Subtract((TimeSpan) AgeSpan).ToString("yyyy-MM-dd HH:mm:ss");
        }

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