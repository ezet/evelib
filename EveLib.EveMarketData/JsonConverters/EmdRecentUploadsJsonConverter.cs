using System;
using eZet.EveLib.Modules.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.Modules.JsonConverters {
    public class EmdRecentUploadsJsonConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var result = new EmdRecentUploads();
            JObject json = JObject.Load(reader);
            serializer.Converters.Add(new EmdRowSetCollectionJsonConverter<EmdRecentUploads.RecentUploadsEntry>());
            result.Uploads =
                serializer.Deserialize<EveMarketDataRowCollection<EmdRecentUploads.RecentUploadsEntry>>(
                    json["rowset"].CreateReader());

            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}