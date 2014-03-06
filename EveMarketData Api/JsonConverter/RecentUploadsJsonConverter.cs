using System;
using eZet.EveLib.EveMarketDataApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.EveMarketDataApi.JsonConverter {
    public class RecentUploadsJsonConverter : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
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