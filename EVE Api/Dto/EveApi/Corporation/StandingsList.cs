using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EolNet.Dto.EveApi.Corporation {
    public class StandingsList : XmlResult {

        [XmlElement("corporationNPCStandings")]
        public StandingType CorporationStandings { get; set; }


        public class StandingType : XmlResult, IXmlSerializable {

            [XmlElement("rowset")]
            public XmlRowSet<StandingEntry> Agents { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<StandingEntry> Corporations { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<StandingEntry> Factions { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                Agents = deserializeRowSet(reader, new StandingEntry());
                Corporations = deserializeRowSet(reader, new StandingEntry());
                Factions = deserializeRowSet(reader, new StandingEntry());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }


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
    }
}