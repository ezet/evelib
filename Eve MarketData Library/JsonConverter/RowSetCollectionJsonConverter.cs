using System;
using eZet.EveLib.EveMarketDataLib.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.EveMarketDataLib.JsonConverter {
    public class RowSetCollectionJsonConverter<T> : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) {
            var result = new RowCollection<T>();
            var json = JObject.Load(reader);
            foreach (var row in json["row"]) {
                result.Add(serializer.Deserialize<T>(row.CreateReader()));
            }
            return result;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(RowCollection<T>);
        }
    }
}