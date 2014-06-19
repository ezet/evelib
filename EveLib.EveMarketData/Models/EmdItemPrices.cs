using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.Modules.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    [JsonConverter(typeof (EmdItemPricesJsonConverter))]
    public class EmdItemPrices {
        [XmlElement("rowset")]
        [DataMember(Name = "result")]
        public EveMarketDataRowCollection<ItemPriceEntry> Prices { get; set; }

        [DataContract]
        [XmlRoot("row")]
        public class ItemPriceEntry {
            [XmlAttribute("buysell")]
            [DataMember(Name = "buysell")]
            public OrderType OrderType { get; set; }

            [XmlAttribute("typeID")]
            [DataMember(Name = "typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("regionID")]
            [DataMember(Name = "regionID")]
            public int RegionId { get; set; }

            [XmlAttribute("price")]
            [DataMember(Name = "price")]
            public decimal Price { get; set; }

            [XmlAttribute("updated")]
            [DataMember(Name = "updated")]
            public DateTime Updated { get; set; }
        }
    }
}