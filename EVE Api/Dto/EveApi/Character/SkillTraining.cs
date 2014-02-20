using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class SkillTraining : XmlResult {

        // TODO DateTime
        [XmlElement("currentTQTime")]
        public string CurrentTqTime { get; set; }

        [XmlElement("EndTime")]
        public string EndTime { get; set; }

        [XmlElement("StartTime")]
        public string StartTime { get; set; }

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
