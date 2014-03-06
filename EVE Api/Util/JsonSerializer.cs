using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace eZet.EveLib.Common.Util {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class JsonSerializer : ISerializer {
        /// <summary>
        ///     Deserializes JSON using JSON.NET
        /// </summary>
        /// <typeparam name="T">An xml result type</typeparam>
        /// <param name="data">An XML string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, T>>(data);
            return dict.First().Value;
        }
    }
}