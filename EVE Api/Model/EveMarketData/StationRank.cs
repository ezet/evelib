using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveMarketData {
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class StationRank {
        [XmlElement("rowset")]
        public XmlRowSet<StationRankEntry> Stations { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class StationRankEntry {
            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            [XmlAttribute("date")]
            public string Date { get; set; }

            [XmlAttribute("rankOrders")]
            public int RankByOrders { get; set; }

            [XmlAttribute("rankPrice")]
            public int RankByPrice { get; set; }

            [XmlAttribute("countSell")]
            public int SellOrders { get; set; }

            [XmlAttribute("countBuy")]
            public int BuyOrders { get; set; }

            [XmlAttribute("priceTotalSell")]
            public decimal SellTotal { get; set; }

            [XmlAttribute("priceTotalBuy")]
            public decimal BuyTotal { get; set; }

            [XmlAttribute("priceAvgSell")]
            public decimal AvgSellPrice { get; set; }

            [XmlAttribute("priceAvgBuy")]
            public decimal AvgBuyPrice { get; set; }
        }
    }
}