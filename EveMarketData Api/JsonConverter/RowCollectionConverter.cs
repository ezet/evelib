using System;
using System.Linq;
using eZet.EveLib.EveMarketData.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.EveMarketData.JsonConverter {
    public class RowCollectionJsonConverter<T> : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            Newtonsoft.Json.JsonSerializer serializer) {
            var result = new RowCollection<T>();
            JArray json = JArray.Load(reader);
            foreach (T a in json.Select(item => serializer.Deserialize<T>(item["row"].CreateReader()))) {
                result.Add(a);
            }
            return result;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof (RowCollection<T>);
        }
    }
}