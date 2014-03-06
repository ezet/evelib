﻿using System;
using eZet.EveLib.EveMarketDataApi.Model;
using Newtonsoft.Json;

namespace eZet.EveLib.EveMarketDataApi.JsonConverter {
    public class ItemPricesJsonConverter : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var result = new ItemPrices();
            serializer.Converters.Add(new RowCollectionJsonConverter<ItemPrices.ItemPriceEntry>());
            result.Prices = serializer.Deserialize<RowCollection<ItemPrices.ItemPriceEntry>>(reader);
            return result;
        }

        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }
    }
}