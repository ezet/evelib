using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class EveCentralResponse {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("method")]
        public string Method { get; set; }
    }
}