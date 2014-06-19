using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.EveLib.Modules.JsonConverters;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.Models {
    [JsonConverter(typeof (EmdItemOrderJsonConverter))]
    [DataContract]
    public class EmdItemOrders {
        [XmlElement("rowset")]
        [DataMember(Name = "result")]
        public EveMarketDataRowCollection<ItemOrderEntry> Orders { get; set; }

        [XmlRoot("row")]
        [DataContract]
        public class ItemOrderEntry {
            [XmlAttribute("buysell")]
            [DataMember(Name = "buysell")]
            public OrderType OrderType { get; set; }

            [XmlAttribute("typeID")]
            [DataMember(Name = "typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("stationID")]
            [DataMember(Name = "stationID")]
            public int StationId { get; set; }

            [XmlAttribute("solarsystemID")]
            [DataMember(Name = "solarsystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("regionID")]
            [DataMember(Name = "regionID")]
            public int RegionId { get; set; }

            [XmlAttribute("price")]
            [DataMember(Name = "price")]
            public decimal Price { get; set; }

            [XmlAttribute("orderID")]
            [DataMember(Name = "orderID")]
            public long OrderId { get; set; }

            [XmlAttribute("volEntered")]
            [DataMember(Name = "volEntered")]
            public long VolEntered { get; set; }

            [XmlAttribute("volRemaining")]
            [DataMember(Name = "volRemaining")]
            public long VolRemaining { get; set; }

            [XmlAttribute("minVolume")]
            [DataMember(Name = "minVolume")]
            public int MinVolume { get; set; }

            [XmlAttribute("range")]
            [DataMember(Name = "range")]
            public int Range { get; set; }

            [XmlAttribute("issued")]
            [DataMember(Name = "issued")]
            public DateTime IssuedDate { get; set; }

            [XmlAttribute("expires")]
            [DataMember(Name = "expires")]
            public DateTime ExpiresDate { get; set; }

            [XmlAttribute("created")]
            [DataMember(Name = "created")]
            public DateTime CreatedDate { get; set; }
        }
    }
}