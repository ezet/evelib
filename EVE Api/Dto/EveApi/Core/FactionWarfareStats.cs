using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Core {
    public class FactionWarfareStats : XmlResult {

        [XmlElement("totals")]
        public FactionWarfareTotals Totals { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<FactionWarfareEntry> Factions { get; set; }

 
        public class FactionWarfareTotals {

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

        [Serializable]
        [XmlRoot("row")]
        public class FactionWarfareEntry {

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            [XmlAttribute("pilots")]
            public int Pilots { get; set; }

            [XmlAttribute("systemControlled")]
            public int SystemsControlled { get; set; }

            [XmlAttribute("killsYesterday")]
            public int KillsYesterday { get; set; }

            [XmlAttribute("killsLastWeek")]
            public int KillsLastWeek { get; set; }

            [XmlAttribute("killsTotal")]
            public int KillsTotal { get; set; }

            [XmlElement("vicoryPointsYesterday")]
            public int VictoryPointsYesterday { get; set; }

            [XmlElement("victoryPointsLastWeek")]
            public int VictoryPointsLastWeek { get; set; }

            [XmlElement("victoryPointsTotal")]
            public int VictoryPointsTotal { get; set; }

            [XmlAttribute("againstID")]
            public long AgainstId { get; set; }

            [XmlAttribute("againstName")]
            public string AgainstName { get; set; }
        }
    }


}
