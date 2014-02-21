using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {
    public class SkillTraining : XmlResult {

        // TODO Convert zone
        [XmlIgnore]
        public DateTime CurrentTqTime { get; private set; }

        [XmlElement("currentTQTime")]
        public string CurrentTqTimeAsString {
            get { return CurrentTqTime.ToString(DateFormat); }
            set { CurrentTqTime = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime EndTime { get; private set; }

        [XmlElement("EndTime")]
        public string EndTimeAsString {
            get { return EndTime.ToString(DateFormat); }
            set { EndTime = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlIgnore]
        public DateTime StartTime { get; private set; }

        [XmlElement("StartTime")]
        public string StartTimeAsString {
            get { return StartTime.ToString(DateFormat); }
            set { StartTime = DateTime.ParseExact(value, DateFormat, null); }
        }

        [XmlElement("trainingTypeID")]
        public long TypeId { get; set; }

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
