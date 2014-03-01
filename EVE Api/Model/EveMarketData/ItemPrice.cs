using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveMarketData {

    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ItemPrice {

        [XmlElement("rowset")]
        public XmlRowSet<ItemPriceEntry> RecentUploads { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class ItemPriceEntry {

            [XmlAttribute("buysell")]
            public string OrderType { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("regionID")]
            public long RegionID { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("updated")]
            public string Updated { get; set; }
        }
    }
}
