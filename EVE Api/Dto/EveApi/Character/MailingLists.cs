using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MailingLists : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<List> Lists { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class List {
            
            [XmlAttribute("listID")]
            public long ListId { get; set; }

            [XmlAttribute("displayName")]
            public string DisplayName { get; set; }
        }
    }
}
