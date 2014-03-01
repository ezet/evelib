using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveMarketData {

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ItemHistory {

        [XmlElement("rowset")]
        public XmlRowSet<ItemHistory> RecentUploads { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class XmlItemHistoryEntry {

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("date")]
            public string Date { get; set; }

            [XmlAttribute("lowPrice")]
            public decimal MinPrice { get; set; }

            [XmlAttribute("highPrice")]
            public decimal MaxPrice { get; set; }

            [XmlAttribute("avgPrice")]
            public decimal AvgPrice { get; set; }

            [XmlAttribute("volume")]
            public long Volume { get; set; }

            [XmlAttribute("orders")]
            public long Orders { get; set; }
        }
    }
}
