using System.IO;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Model.EveApi;

namespace eZet.Eve.EoLib.Util.EveApi {

    /// <summary>
    /// A simple wrapper for .NET XmlSerializer.
    /// </summary>
    public class XmlSerializerWrapper : IXmlSerializer {

        /// <summary>
        /// Deserializes Eve API xml using the .NET XmlSerializer.
        /// </summary>
        /// <typeparam name="T">An xml result type</typeparam>
        /// <param name="data">An XML string</param>
        /// <returns></returns>
        XmlResponse<T> IXmlSerializer.Deserialize<T>(string data) {
            var serializer = new XmlSerializer(typeof(XmlResponse<T>));
            XmlResponse<T> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<T>)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }
    }
}
