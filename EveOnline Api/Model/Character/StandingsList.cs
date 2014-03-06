using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineApi.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StandingsList : XmlElement {
        [XmlElement("characterNPCStandings")]
        public StandingType CharacterStandings { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class StandingEntry {
            [XmlAttribute("fromID")]
            public long FromId { get; set; }

            [XmlAttribute("fromName")]
            public string FromName { get; set; }

            [XmlAttribute("standing")]
            public float Standing { get; set; }
        }

        public class StandingType : XmlElement, IXmlSerializable {
            [XmlElement("rowset")]
            public RowCollection<StandingEntry> Agents { get; set; }

            [XmlElement("rowset")]
            public RowCollection<StandingEntry> Corporations { get; set; }

            [XmlElement("rowset")]
            public RowCollection<StandingEntry> Factions { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                setRoot(reader);
                Agents = deserializeRowSet(getRowSetReader("agents"), new StandingEntry());
                Corporations = deserializeRowSet(getRowSetReader("NPCCorporations"), new StandingEntry());
                Factions = deserializeRowSet(getRowSetReader("factions"), new StandingEntry());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}