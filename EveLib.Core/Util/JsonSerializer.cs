using System.Web.Helpers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class JsonSerializer : ISerializer {
        /// <summary>
        ///     Deserializes JSON 
        /// </summary>
        /// <param name="data">A JSON string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            return Json.Decode(data);
        }
    }
}