using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     A simple wrapper for .NET XmlSerializer.
    /// </summary>
    public sealed class SimpleXmlSerializer : ISerializer {
        /// <summary>
        ///     Deserializes Eve API xml using the .NET XmlSerializer.
        /// </summary>
        /// <typeparam name="T">An xml result type</typeparam>
        /// <param name="data">An XML string</param>
        /// <returns></returns>
        T ISerializer.Deserialize<T>(string data) {
            var serializer = new XmlSerializer(typeof (T));
            T xmlResponse;
            using (XmlReader reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (T) serializer.Deserialize(reader);
            }
            return xmlResponse;
        }
    }
}