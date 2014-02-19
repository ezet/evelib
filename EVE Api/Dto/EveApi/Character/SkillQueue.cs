using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class SkillQueue : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Skill> Queue { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Skill {
            
            [XmlAttribute("queuePosition")]
            public int QueuePosition { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("level")]
            public int Level { get; set; }

            [XmlAttribute("startSP")]
            public int StartSp { get; set; }

            [XmlAttribute("endSP")]
            public int EndSp { get; set; }

            [XmlAttribute("startTime")]
            public DateTime StartTime { get; set; }

            [XmlAttribute("endTime")]
            public DateTime EndTime { get; set; }

        }
    }
}
