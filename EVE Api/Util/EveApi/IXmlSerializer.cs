using eZet.Eve.EveLib.Model.EveApi;

namespace eZet.Eve.EveLib.Util.EveApi {

    /// <summary>
    /// Provides serialization methods for Eve API xml and objects.
    /// </summary>
    public interface IXmlSerializer {

        /// <summary>
        /// Deserializes Eve API xml.
        /// </summary>
        /// <typeparam name="T">Parameter type for XmlResponse.</typeparam>
        /// <param name="data">String of XML to deserialize.</param>
        /// <returns></returns>
        XmlResponse<T> Deserialize<T>(string data) where T : new();

    }
}
