using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class SkillTraining : XmlResult {

        [XmlElement("currentTQTime")]
        public DateTime CurrentTqTime { get; set; }

        [XmlElement("trainingEndTime")]
        public DateTime EndTime { get; set; }

        [XmlElement("trainingStartTime")]
        public DateTime StartTime { get; set; }

        [XmlElement("trainingTypeID")]
        public long TrainingTypeId { get; set; }

        [XmlElement("trainingStartSP")]
        public int TrainingStartSp { get; set; }

        [XmlElement("trainingDestinationSP")]
        public int TrainingDestinationSp { get; set; }

        [XmlElement("trainingToLevel")]
        public int TrainingToLevel { get; set; }

        [XmlElement("skillInTraining")]
        public bool IsTraining { get; set; }

    }
}
