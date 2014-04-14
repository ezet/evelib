using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models {
    [Serializable]
    public abstract class Element43Response {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("method")]
        public string Method { get; set; }
    }
}