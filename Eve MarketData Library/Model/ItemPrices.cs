using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.EveMarketDataLib.JsonConverter;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataLib.Model {
    [DataContract]
    [JsonConverter(typeof (ItemPricesJsonConverter))]
    public class ItemPrices {
        [XmlElement("rowset")]
        [DataMember(Name = "result")]
        public RowCollection<ItemPriceEntry> Prices { get; set; }

        [DataContract]
        [XmlRoot("row")]
        public class ItemPriceEntry {
            [XmlAttribute("buysell")]
            [DataMember(Name = "buysell")]
            public OrderType OrderType { get; set; }

            [XmlAttribute("typeID")]
            [DataMember(Name = "typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("regionID")]
            [DataMember(Name = "regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("price")]
            [DataMember(Name = "price")]
            public decimal Price { get; set; }

            [XmlAttribute("updated")]
            [DataMember(Name = "updated")]
            public string Updated { get; set; }
        }
    }
}