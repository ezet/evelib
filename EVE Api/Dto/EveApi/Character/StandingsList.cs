using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class StandingsList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<StandingEntry> Standings { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class StandingEntry {
            
            [XmlAttribute("fromID")]
            public long FromId { get; set; }

            [XmlAttribute("fromName")]
            public string FromName { get; set; }

            [XmlAttribute("standing")]
            public float Standing { get; set; }
        }
    }
}
