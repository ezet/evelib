using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Entity.EveMarketData {


    public enum UploadType {
        [XmlEnum("o")]
        Orders,
        [XmlEnum("h")]
        History,
        [XmlEnum("b")]
        Both
    }

    public enum OrderType {
        [XmlEnum("s")]
        Sell,
        [XmlEnum("b")]
        Buy,
        [XmlEnum("a")]
        Both
    }

    public enum MinMax {
        Min, Max
    }


    public class EveMarketDataOptions {

        public ICollection<long> Items { get; set; }

        public ICollection<long> ItemGroups { get; set; }

        public ICollection<long> Regions { get; set; }

        public ICollection<long> Solarsystems { get; set; }

        public ICollection<long> Stations { get; set; }

        public int RowLimit { get; set; }

        public TimeSpan? AgeSpan { get; set; }

        public string GetAgeLimit() {
            AgeSpan = AgeSpan ?? TimeSpan.FromDays(30);
            return DateTime.UtcNow.Subtract((TimeSpan)AgeSpan).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public EveMarketDataOptions() {
            Items = new List<long>();
            ItemGroups = new List<long>();
            Regions = new List<long>();
            Solarsystems = new List<long>();
            Stations = new List<long>();
            RowLimit = 10000;
        }

        public string UploadTypeToString(UploadType type) {
            switch (type) {
                case UploadType.Orders: return "o";
                case UploadType.History: return "h";
                case UploadType.Both: return "b";
                default: throw new NotImplementedException();
            }
        }

        public string OrderTypeToString(OrderType type) {
            switch (type) {
                case OrderType.Sell: return "s";
                case OrderType.Buy: return "b";
                case OrderType.Both: return "a";
                default: throw new NotImplementedException();
            }
        }

        public string MinMaxToString(MinMax val) {
            return "";
        }

    }



}
