using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StandingsList {
        [XmlElement("corporationNPCStandings")]
        public StandingType CorporationStandings { get; set; }


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

        public class StandingType : IXmlSerializable {
            [XmlElement("rowset")]
            public EveOnlineRowCollection<StandingEntry> Agents { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<StandingEntry> Corporations { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<StandingEntry> Factions { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                Agents = xml.deserializeRowSet<StandingEntry>("agents");
                Corporations = xml.deserializeRowSet<StandingEntry>("NPCCorporations");
                Factions = xml.deserializeRowSet<StandingEntry>("factions");
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}