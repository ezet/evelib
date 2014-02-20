using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class Research : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<ResearchEntry> Entries { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class ResearchEntry {
            
            [XmlAttribute("agentID")]
            public long AgentId { get; set; }

            [XmlAttribute("skillTypeID")]
            public long SkillTypeId { get; set; }

            // TODO DateTime
            [XmlAttribute("researchStartDate")]
            public string StartDate { get; set; }

            [XmlAttribute("pointsPerDay")]
            public decimal PointsPerDay { get; set; }

            [XmlAttribute("remainderPoints")]
            public double pointsRemaining { get; set; }
        }
    }
}
