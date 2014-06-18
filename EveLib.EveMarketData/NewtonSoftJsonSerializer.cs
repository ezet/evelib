using System.Collections.Generic;
using System.Linq;
using eZet.EveLib.Core.Serializers;
using Newtonsoft.Json;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class NewtonSoftJsonSerializer : ISerializer {
        /// <summary>
        ///     Deserializes JSON using JSON.NET
        /// </summary>
        /// <param name="data">A JSON string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, T>>(data);
            return dict.First().Value;
        }
    }
}