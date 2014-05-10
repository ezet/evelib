using System.Web.Helpers;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class DynamicJsonSerializer : ISerializer {
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