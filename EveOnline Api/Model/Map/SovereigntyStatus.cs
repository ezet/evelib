using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Map {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SovereigntyStatus {
        [XmlElement("rowset")]
        public RowCollection<Structure> Structures { get; set; }

        public class Structure {
            // TODO Implement
        }
    }
}