using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.EveMarketDataLib.JsonConverter;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataLib.Model {

    [DataContract]
    [JsonConverter(typeof(StationRankJsonConverter))]
    public class StationRank {

        [DataMember(Name = "result")]
        [XmlElement("rowset")]
        public RowCollection<StationRankEntry> Stations { get; set; }

        [DataContract]
        [XmlRoot("row")]
        public class StationRankEntry {

            [DataMember(Name = "stationID")]
            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            [DataMember(Name = "date")]
            [XmlAttribute("date")]
            public string Date { get; set; }

            [DataMember(Name = "rankOrders")]
            [XmlAttribute("rankOrders")]
            public int RankByOrders { get; set; }

            [DataMember(Name = "rankPrice")]
            [XmlAttribute("rankPrice")]
            public int RankByPrice { get; set; }

            [DataMember(Name = "countSell")]
            [XmlAttribute("countSell")]
            public int SellOrders { get; set; }

            [DataMember(Name = "countBuy")]
            [XmlAttribute("countBuy")]
            public int BuyOrders { get; set; }

            [DataMember(Name = "priceTotalSell")]
            [XmlAttribute("priceTotalSell")]
            public decimal SellTotal { get; set; }

            [DataMember(Name = "priceTotalBuy")]
            [XmlAttribute("priceTotalBuy")]
            public decimal BuyTotal { get; set; }

            [DataMember(Name = "priceAvgSell")]
            [XmlAttribute("priceAvgSell")]
            public decimal AvgSellPrice { get; set; }

            [DataMember(Name = "priceAvgBuy")]
            [XmlAttribute("priceAvgBuy")]
            public decimal AvgBuyPrice { get; set; }
        }
    }
}