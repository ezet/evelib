using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SkillQueue {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Skill> Queue { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Skill {
            [XmlAttribute("queuePosition")]
            public int QueuePosition { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("level")]
            public int Level { get; set; }

            [XmlAttribute("startSP")]
            public int StartSp { get; set; }

            [XmlAttribute("endSP")]
            public int EndSp { get; set; }

            [XmlIgnore]
            public DateTime StartTime { get; private set; }

            [XmlAttribute("startTime")]
            public string StartTimeAsString {
                get { return StartTime.ToString(XmlHelper.DateFormat); }
                set { StartTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlIgnore]
            public DateTime EndTime { get; private set; }

            [XmlAttribute("endTime")]
            public string EndTimeAsString {
                get { return EndTime.ToString(XmlHelper.DateFormat); }
                set { EndTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}