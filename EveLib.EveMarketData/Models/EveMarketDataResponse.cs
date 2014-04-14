using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [XmlRoot("emd", Namespace = "", IsNullable = false)]
    [DataContract]
    public class EveMarketDataResponse<T> {
        [XmlElement("currentTime")]
        [DataMember(Name = "currentTime")]
        public string CurrentTime { get; set; }

        [XmlAttribute("version")]
        [DataMember(Name = "version")]
        public int Version { get; set; }

        [XmlElement("result")]
        [DataMember(Name = "result")]
        public T Result { get; set; }
    }
}