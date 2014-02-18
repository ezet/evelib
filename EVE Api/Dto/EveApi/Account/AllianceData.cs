using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Account {
    public class AllianceData {

        [XmlAttribute("name")]
        public string AllianceName { get; set; }

        [XmlAttribute("shortName")]
        public string AllianceTag { get; set; }

        [XmlAttribute("allianceID")]
        public long AllianceId { get; set; }

        [XmlAttribute("executorCorpID")]
        public long ExecutorCorpId { get; set; }

        [XmlAttribute("memberCount")]
        public int MemberCount { get; set; }

        [XmlAttribute("startDate")]
        public string StartDate { get; set; }
    }
}
