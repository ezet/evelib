using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarfareStats : IXmlSerializable {
        [XmlElement("totals")]
        public FactionWarfareTotals Totals { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<FactionWarfareEntry> Factions { get; set; }

        [XmlElement("rowset")]
        public EveOnlineRowCollection<FactionWarfareEntry> FactionWars { get; set; }


        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            var xml = new XmlHelper(reader);
            Totals = xml.deserialize<FactionWarfareTotals>("totals");
            Factions = xml.deserializeRowSet<FactionWarfareEntry>("factions");
            FactionWars = xml.deserializeRowSet<FactionWarfareEntry>("factionWars");
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
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

        [Serializable]
        [XmlRoot("totals")]
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
    }
}