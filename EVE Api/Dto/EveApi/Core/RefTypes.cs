using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class ReferenceTypes : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<ReferenceType> RefTypes { get; set; }

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
