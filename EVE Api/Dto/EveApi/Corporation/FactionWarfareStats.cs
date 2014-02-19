using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class FactionWarfareStats : XmlResult {

        [XmlElement("factionID")]
        public long FactionId { get; set; }

        [XmlElement("factionName")]
        public string FactionName { get; set; }

        [XmlElement("enlisted")]
        public DateTime Enlisted { get; set; }

        [XmlElement("pilots")]
        public int Pilots { get; set; }

        [XmlElement("highestRank")]
        public int HighestRank { get; set; }

        [XmlElement("killsYesterday")]
        public int KillsYesterday { get; set; }

        [XmlElement("killsLastWeek")]
        public int KillsLastWeek { get; set; }

        [XmlElement("killsTotal")]
        public int KillsTotal { get; set; }

        [XmlElement("vicoryPointsYesterday")]
        public int VictoryPointsYesterday { get; set; }

        [XmlElement("victoryPointsLastWeek")]
        public int VictoryPointsLastWeek { get; set; }

        [XmlElement("victoryPointsTotal")]
        public int VictoryPointsTotal { get; set; }


    }
}
