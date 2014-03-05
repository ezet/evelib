using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eZet.Eve.EveLib.Util.JsonConverter;
using Newtonsoft.Json;

namespace eZet.Eve.EveLib.Model.EveMarketData {
    [DataContract]
    [JsonConverter(typeof(ItemHistoryConverter))]
    public class ItemHistory {

        [DataMember(Name = "result")]
        [XmlElement("rowset")]
        public RowCollection<ItemHistoryEntry> History { get; set; }

        [XmlRoot("row")]
        [DataContract]
        public class ItemHistoryEntry {
            [XmlAttribute("typeID")]
            [DataMember(Name = "typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("regionID")]
            [DataMember(Name = "regionID")]
            public long RegionId { get; set; }

            [XmlAttribute("date")]
            [DataMember(Name = "date")]
            public string Date { get; set; }

            [XmlAttribute("lowPrice")]
            [DataMember(Name = "lowPrice")]
            public decimal MinPrice { get; set; }

            [XmlAttribute("highPrice")]
            [DataMember(Name = "highPrice")]
            public decimal MaxPrice { get; set; }

            [XmlAttribute("avgPrice")]
            [DataMember(Name = "avgPrice")]
            public decimal AvgPrice { get; set; }

            [XmlAttribute("volume")]
            [DataMember(Name = "volume")]
            public long Volume { get; set; }

            [XmlAttribute("orders")]
            [DataMember(Name = "orders")]
            public long Orders { get; set; }
        }
    }

    public class ItemHistoryConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var result = new ItemHistory();
            serializer.Converters.Add(new RowConverter<ItemHistory.ItemHistoryEntry>());
            result.History = serializer.Deserialize<RowCollection<ItemHistory.ItemHistoryEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}