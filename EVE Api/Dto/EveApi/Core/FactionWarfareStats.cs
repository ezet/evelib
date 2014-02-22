using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class FactionWarfareStats : XmlElement, IXmlSerializable {

        [XmlElement("totals")]
        public FactionWarfareTotals Totals { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<FactionWarfareEntry> Factions { get; set; }

        [XmlElement("rowset")]
        public XmlRowSet<FactionWarfareEntry> FactionWars { get; set; }


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

        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            setRoot(reader);
            Totals = deserialize(getReader("totals"), new FactionWarfareTotals());
            Factions = deserializeRowSet(getRowSetReader("factions"), new FactionWarfareEntry());
            FactionWars = deserializeRowSet(getRowSetReader("factionWars"), new FactionWarfareEntry());
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }
    }


}
