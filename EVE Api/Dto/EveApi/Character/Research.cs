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

            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            [XmlAttribute("researchStartDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(DateFormat); }
                set { StartDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("pointsPerDay")]
            public decimal PointsPerDay { get; set; }

            [XmlAttribute("remainderPoints")]
            public double pointsRemaining { get; set; }
        }
    }
}
