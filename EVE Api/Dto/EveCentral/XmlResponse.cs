using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveCentral {

    [Serializable]
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "evec_api", Namespace = "", IsNullable = false)]
    public class XmlResponse {

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("method")]
        public string Method { get; set; }

    }
}
