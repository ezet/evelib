using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SkillTraining {
        // TODO Convert zone
        [XmlIgnore]
        public DateTime CurrentTqTime { get; private set; }

        [XmlElement("currentTQTime")]
        public string CurrentTqTimeAsString {
            get { return CurrentTqTime.ToString(XmlHelper.DateFormat); }
            set { CurrentTqTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime EndTime { get; private set; }

        [XmlElement("EndTime")]
        public string EndTimeAsString {
            get { return EndTime.ToString(XmlHelper.DateFormat); }
            set { EndTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime StartTime { get; private set; }

        [XmlElement("StartTime")]
        public string StartTimeAsString {
            get { return StartTime.ToString(XmlHelper.DateFormat); }
            set { StartTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        [XmlElement("trainingTypeID")]
        public int TypeId { get; set; }

        [XmlElement("trainingStartSP")]
        public int StartSp { get; set; }

        [XmlElement("trainingDestinationSP")]
        public int DestinationSp { get; set; }

        [XmlElement("trainingToLevel")]
        public int ToLevel { get; set; }

        [XmlElement("skillInTraining")]
        public bool IsTraining { get; set; }
    }
}