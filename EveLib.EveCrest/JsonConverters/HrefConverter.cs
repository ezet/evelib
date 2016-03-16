using System;
using eZet.EveLib.EveCrestModule.Models.Links;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.EveLib.EveCrestModule.JsonConverters {
    /// <summary>
    ///     Class HrefConverter.
    /// </summary>
    public class HrefConverter : JsonConverter {
        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType) {
            return (objectType == typeof (Href<>));
        }

        /// <summary>
        ///     Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns>System.Object.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) {
            var token = JToken.ReadFrom(reader);
            while (token.HasValues) {
                token = token.First;
            }
            return Activator.CreateInstance(objectType, token.ToString());
        }

        /// <summary>
        ///     Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var val = JToken.FromObject(value.ToString());
            val.WriteTo(writer);
        }
    }
}