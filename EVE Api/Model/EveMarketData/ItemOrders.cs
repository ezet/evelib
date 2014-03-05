using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.Eve.EveLib.Entity.EveMarketData;
using eZet.Eve.EveLib.Util.JsonConverter;
using Newtonsoft.Json;

namespace eZet.Eve.EveLib.Model.EveMarketData {

    [JsonConverter(typeof(ItemOrderConverter))]
    [DataContract]
    public class ItemOrders {

        [XmlElement("rowset")]
        [DataMember(Name = "result")]
        public RowCollection<ItemOrderEntry> Orders { get; set; }

        [XmlRoot("row")]
        [DataContract]
        public class ItemOrderEntry {
            [XmlAttribute("buysell")]
            [DataMember(Name = "buysell")]
            public OrderType OrderType { get; set; }

            [XmlAttribute("typeID")]
            [DataMember(Name = "typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("stationID")]
            [DataMember(Name = "stationID")]
            public long StationId { get; set; }

            [XmlAttribute("solarsystemID")]
            [DataMember(Name = "solarsystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("regionID")]
            [DataMember(Name = "regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("price")]
            [DataMember(Name = "price")]
            public decimal Price { get; set; }

            [XmlAttribute("orderID")]
            [DataMember(Name = "orderID")]
            public long OrderId { get; set; }

            [XmlAttribute("volEntered")]
            [DataMember(Name = "volEntered")]
            public int VolEntered { get; set; }

            [XmlAttribute("volRemaining")]
            [DataMember(Name = "volRemaining")]
            public int VolRemaining { get; set; }

            [XmlAttribute("minVolume")]
            [DataMember(Name = "minVolume")]
            public int MinVolume { get; set; }

            [XmlAttribute("range")]
            [DataMember(Name = "range")]
            public int Range { get; set; }

            [XmlAttribute("issued")]
            [DataMember(Name = "issued")]
            public string IssuedDate { get; set; }

            [XmlAttribute("expires")]
            [DataMember(Name = "expires")]
            public string ExpiresDate { get; set; }

            [XmlAttribute("created")]
            [DataMember(Name = "created")]
            public string CreatedDate { get; set; }
        }
    }

    public class ItemOrderConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var result = new ItemOrders();
            serializer.Converters.Add(new RowConverter<ItemOrders.ItemOrderEntry>());
            result.Orders = serializer.Deserialize<RowCollection<ItemOrders.ItemOrderEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}