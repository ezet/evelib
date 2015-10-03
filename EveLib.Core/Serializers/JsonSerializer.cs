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
        public string DateFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        ///     Deserializes JSON
        /// </summary>
        /// <param name="data">A JSON string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Start");
            var result = JsonConvert.DeserializeObject<T>(data, new IsoDateTimeConverter { DateTimeFormat = DateFormat });
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Complete");
            return result;
        }
    }
}