using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {
    public class MailingLists : XmlResult {

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
