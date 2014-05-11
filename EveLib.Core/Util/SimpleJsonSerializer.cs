using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     JSON serializer
    /// </summary>
    public sealed class SimpleJsonSerializer : ISerializer {
        /// <summary>
        ///     Deserializes JSON 
        /// </summary>
        /// <param name="data">A JSON string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(getStream(data));
        }


        private MemoryStream getStream(string value) {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}