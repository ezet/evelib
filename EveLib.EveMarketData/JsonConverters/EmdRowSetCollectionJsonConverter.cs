using System;
using eZet.EveLib.Modules.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.Modules.JsonConverters {
    public class EmdRowSetCollectionJsonConverter<T> : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var result = new EveMarketDataRowCollection<T>();
            JObject json = JObject.Load(reader);
            foreach (JToken row in json["row"]) {
                result.Add(serializer.Deserialize<T>(row.CreateReader()));
            }
            return result;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof (EveMarketDataRowCollection<T>);
        }
    }
}