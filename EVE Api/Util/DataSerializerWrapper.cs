using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace eZet.Eve.EveLib.Util {
    /// <summary>
    ///     A simple wrapper for .NET XmlSerializer.
    /// </summary>
    public sealed class DataSerializerWrapper : ISerializer {
        /// <summary>
        ///     Deserializes Eve API xml using the .NET XmlSerializer.
        /// </summary>
        /// <typeparam name="T">An xml result type</typeparam>
        /// <param name="data">An XML string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            var serializer = new DataContractJsonSerializer(typeof (Emd<T>));
            Emd<T> result;
            using (Stream stream = generateStreamFromString(data)) {
                result = (Emd<T>) serializer.ReadObject(stream);
            }
            return result.emd;
        }

        private Stream generateStreamFromString(string s) {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        [DataContract]
        public class Emd<T> {
            [DataMember]
            public T emd { get; set; }
        }
    }
}