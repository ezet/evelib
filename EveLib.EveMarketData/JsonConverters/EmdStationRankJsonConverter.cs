using System;
using eZet.EveLib.Modules.Models;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.JsonConverters {
    public class EmdStationRankJsonConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var result = new EmdStationRank();
            serializer.Converters.Add(new EmdRowCollectionJsonConverter<EmdStationRank.StationRankEntry>());
            result.Stations = serializer.Deserialize<EveMarketDataRowCollection<EmdStationRank.StationRankEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}