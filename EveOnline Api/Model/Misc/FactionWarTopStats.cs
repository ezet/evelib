using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Misc {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarTopStats {
        [XmlElement("characters")]
        public CharacterStats Characters { get; set; }

        [XmlElement("corporations")]
        public CharacterStats Corporations { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class CharacterEntry {
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("kills")]
            public int Kills { get; set; }
        }

        public class CharacterStats : IXmlSerializable {
            [XmlElement("rowset")]
            public RowCollection<CharacterEntry> KillsYesterday { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CharacterEntry> KillsLastWeek { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CharacterEntry> KillsTotal { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CharacterEntry> VictoryPointsYesterday { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CharacterEntry> VictoryPointsLastWeek { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CharacterEntry> VictoryPointsTotal { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                KillsYesterday = xml.deserializeRowSet<CharacterEntry>("KillsYesterday");
                KillsLastWeek = xml.deserializeRowSet<CharacterEntry>("KillsLastWeek");
                KillsTotal = xml.deserializeRowSet<CharacterEntry>("KillsTotal");
                VictoryPointsYesterday = xml.deserializeRowSet<CharacterEntry>("VictoryPointsYesterday");
                VictoryPointsLastWeek = xml.deserializeRowSet<CharacterEntry>("VictoryPointsLastWeek");
                VictoryPointsTotal = xml.deserializeRowSet<CharacterEntry>("VictoryPointsTotal");
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

        [Serializable]
        [XmlRoot("row")]
        public class CorporationEntry {
            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            [XmlAttribute("kills")]
            public string Kills { get; set; }
        }

        public class CorporationStats : IXmlSerializable {
            [XmlElement("rowset")]
            public RowCollection<CorporationEntry> KillsYesterday { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CorporationEntry> KillsLastWeek { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CorporationEntry> KillsTotal { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CorporationEntry> VictoryPointsYesterday { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CorporationEntry> VictoryPointsLastWeek { get; set; }

            [XmlElement("rowset")]
            public RowCollection<CorporationEntry> VictoryPointsTotal { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                KillsYesterday = xml.deserializeRowSet<CorporationEntry>("KillsYesterday");
                KillsLastWeek = xml.deserializeRowSet<CorporationEntry>("KillsLastWeek");
                KillsTotal = xml.deserializeRowSet<CorporationEntry>("KillsTotal");
                VictoryPointsYesterday = xml.deserializeRowSet<CorporationEntry>("VictoryPointsYesterday");
                VictoryPointsLastWeek = xml.deserializeRowSet<CorporationEntry>("VictoryPointsLastWeek");
                VictoryPointsTotal = xml.deserializeRowSet<CorporationEntry>("VictoryPointsTotal");
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}