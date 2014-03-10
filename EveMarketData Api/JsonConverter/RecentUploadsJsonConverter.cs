using System;
using eZet.EveLib.EveMarketData.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.EveMarketData.JsonConverter {
    public class RecentUploadsJsonConverter : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            Newtonsoft.Json.JsonSerializer serializer) {
            var result = new RecentUploads();
            JObject json = JObject.Load(reader);
            serializer.Converters.Add(new RowSetCollectionJsonConverter<RecentUploads.RecentUploadsEntry>());
            result.Uploads =
                serializer.Deserialize<RowCollection<RecentUploads.RecentUploadsEntry>>(json["rowset"].CreateReader());

            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}