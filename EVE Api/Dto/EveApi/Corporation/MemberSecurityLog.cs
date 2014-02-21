using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Corporation {
    public class MemberSecurityLog : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<LogEntry> RoleHistory { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class LogEntry : XmlResult, IXmlSerializable {

            [XmlIgnore]
            public DateTime ChangeTime { get; private set; }

            [XmlAttribute("changeTime")]
            public string ChangeTimeAsString {
                get { return ChangeTime.ToString(DateFormat); }
                set { ChangeTime = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            [XmlAttribute("roleLocationType")]
            public string RoleLocationType { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<MemberSecurity.Role> OldRoles { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<MemberSecurity.Role> NewRoles { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                OldRoles = deserializeRowSet(reader, new MemberSecurity.Role());
                NewRoles = deserializeRowSet(reader, new MemberSecurity.Role());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

    }
}
