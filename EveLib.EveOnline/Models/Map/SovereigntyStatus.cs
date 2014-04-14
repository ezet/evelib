using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SovereigntyStatus {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Structure> Structures { get; set; }

        public class Structure {
            // TODO Implement
        }
    }
}