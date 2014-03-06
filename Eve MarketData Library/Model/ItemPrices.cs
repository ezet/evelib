using System;
using System.Xml.Serialization;
using eZet.EveLib.EveMarketDataLib.JsonConverter;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataLib.Model {
    [Serializable]
    [XmlType(AnonymousType = true)]
    [JsonConverter(typeof(ItemPricesJsonConverter))]
    public class ItemPrices {
        [XmlElement("rowset")]
        public RowCollection<ItemPriceEntry> Prices { get; set; }

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