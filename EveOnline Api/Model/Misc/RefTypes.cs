using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ReferenceTypes {
        [XmlElement("rowset")]
        public RowCollection<ReferenceType> RefTypes { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class ReferenceType {
            [XmlAttribute("refTypeID")]
            public int RefTypeId { get; set; }

            [XmlAttribute("refTypeName")]
            public string RefTypeName { get; set; }
        }
    }
}