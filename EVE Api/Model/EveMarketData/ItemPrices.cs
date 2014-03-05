using System;
using System.Xml.Serialization;
using eZet.Eve.EveLib.Entity.EveMarketData;

namespace eZet.Eve.EveLib.Model.EveMarketData {
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ItemPrices {
        [XmlElement("rowset")]
        public XmlRowSet<ItemPriceEntry> Prices { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class ItemPriceEntry {
            [XmlAttribute("buysell")]
            public OrderType OrderType { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("updated")]
            public string Updated { get; set; }
        }
    }
}