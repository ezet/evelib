using System;
using eZet.EveLib.Modules.Models;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.JsonConverters {
    public class EmdItemPricesJsonConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var result = new EmdItemPrices();
            serializer.Converters.Add(new EmdRowCollectionJsonConverter<EmdItemPrices.ItemPriceEntry>());
            result.Prices = serializer.Deserialize<EveMarketDataRowCollection<EmdItemPrices.ItemPriceEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}