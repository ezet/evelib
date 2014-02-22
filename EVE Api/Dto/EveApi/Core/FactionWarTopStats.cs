using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
 
namespace eZet.Eve.EoLib.Dto.EveApi.Core {
    public class FactionWarTopStats : XmlElement {

        [XmlElement("characters")]
        public CharacterStats Characters { get; set; }

        [XmlElement("corporations")]
        public CharacterStats Corporations { get; set; }

        public class CharacterStats : XmlElement, IXmlSerializable {

            [XmlElement("rowset")]
            public XmlRowSet<CharacterEntry> KillsYesterday { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CharacterEntry> KillsLastWeek { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CharacterEntry> KillsTotal { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CharacterEntry> VictoryPointsYesterday { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CharacterEntry> VictoryPointsLastWeek { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CharacterEntry> VictoryPointsTotal { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                KillsYesterday = deserializeRowSet(reader, new CharacterEntry());
                KillsLastWeek = deserializeRowSet(reader, new CharacterEntry());
                KillsTotal = deserializeRowSet(reader, new CharacterEntry());
                VictoryPointsYesterday = deserializeRowSet(reader, new CharacterEntry());
                VictoryPointsLastWeek = deserializeRowSet(reader, new CharacterEntry());
                VictoryPointsTotal = deserializeRowSet(reader, new CharacterEntry());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }


        public class CorporationStats : XmlElement, IXmlSerializable  {

            [XmlElement("rowset")]
            public XmlRowSet<CorporationEntry> KillsYesterday { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CorporationEntry> KillsLastWeek { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CorporationEntry> KillsTotal { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CorporationEntry> VictoryPointsYesterday { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CorporationEntry> VictoryPointsLastWeek { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<CorporationEntry> VictoryPointsTotal { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                KillsYesterday = deserializeRowSet(reader, new CorporationEntry());
                KillsLastWeek= deserializeRowSet(reader, new CorporationEntry());
                KillsTotal = deserializeRowSet(reader, new CorporationEntry());
                VictoryPointsYesterday = deserializeRowSet(reader, new CorporationEntry());
                VictoryPointsLastWeek = deserializeRowSet(reader, new CorporationEntry());
                VictoryPointsTotal = deserializeRowSet(reader, new CorporationEntry());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

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

    }
}
