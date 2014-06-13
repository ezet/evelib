using System;
using eZet.EveLib.Modules.Models;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules.JsonConverters {
    public class ItemPricesJsonConverter : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            Newtonsoft.Json.JsonSerializer serializer) {
            var result = new ItemPrices();
            serializer.Converters.Add(new RowCollectionJsonConverter<ItemPrices.ItemPriceEntry>());
            result.Prices = serializer.Deserialize<EveMarketDataRowCollection<ItemPrices.ItemPriceEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}