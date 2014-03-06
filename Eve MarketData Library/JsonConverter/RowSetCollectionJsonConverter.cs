using System;
using eZet.EveLib.EveMarketDataLib.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.EveMarketDataLib.JsonConverter {
    public class RowSetCollectionJsonConverter<T> : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var result = new RowCollection<T>();
            JObject json = JObject.Load(reader);
            foreach (JToken row in json["row"]) {
                result.Add(serializer.Deserialize<T>(row.CreateReader()));
            }
            return result;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof (RowCollection<T>);
        }
    }
}