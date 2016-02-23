using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eZet.EveLib.Core.Serializers {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class JsonSerializer : ISerializer {
        private readonly TraceSource _trace = new TraceSource("EveLib");

        /// <summary>
        /// The date format
        /// </summary>
        public string DateFormat1 = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// The date format2
        /// </summary>
        public string DateFormat2 = "yyyy.MM.dd HH:mm:ss";

        /// <summary>
        ///     Deserializes JSON
        /// </summary>
        /// <param name="data">A JSON string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Start");
            var result = JsonConvert.DeserializeObject<T>(data, new IsoDateTimeConverter { DateTimeFormat = DateFormat1 }, new IsoDateTimeConverter { DateTimeFormat = DateFormat2 });
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Complete");
            return result;
        }
    }
}