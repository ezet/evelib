using System;
using Newtonsoft.Json;

namespace eZet.EveLib.Core.Converters {
    /// <summary>
    /// Class BoolConverter.
    /// </summary>
 public class BoolConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((bool)value) ? 1 : 0);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return reader.Value.ToString() == "1";
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }
}
}
