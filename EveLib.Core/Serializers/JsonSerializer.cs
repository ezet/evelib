using System.Diagnostics;
using Newtonsoft.Json;

namespace eZet.EveLib.Core.Serializers {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class JsonSerializer : ISerializer {

        private readonly TraceSource _trace = new TraceSource("EveLib");

        /// <summary>
        ///     Deserializes JSON
        /// </summary>
        /// <param name="data">A JSON string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Start");
            var result = JsonConvert.DeserializeObject<T>(data);
            _trace.TraceEvent(TraceEventType.Verbose, 0, "JsonSerializer.Deserialize:Complete");
            return result;
        }
    }
}