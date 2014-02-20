using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class StandingsList : XmlResult {

        [XmlElement("characterNPCStandings")]
        public StandingType CharacterStandingsType { get; set; }

        [XmlElement("corporationNPCStandings")]
        public StandingType CorporationStandingsType { get; set; }


        public class StandingType {

            [XmlElement("rowset")]
            public XmlRowSet<StandingEntry> Standings { get; set; }
        }


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