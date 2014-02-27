using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Corporation {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberSecurityLog : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<LogEntry> RoleHistory { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class LogEntry : XmlElement, IXmlSerializable {

            [XmlIgnore]
            public DateTime ChangeTime { get; private set; }

            [XmlAttribute("changeTime")]
            public string ChangeTimeAsString {
                get { return ChangeTime.ToString(DateFormat); }
                set { ChangeTime = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            [XmlAttribute("issuerName")]
            public string IssuerName { get; set; }

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
                setRoot(reader);
                ChangeTimeAsString = getStringAttribute("changeTime");
                CharacterId = getLongAttribute("characterID");
                CharacterName = getStringAttribute("characterName");
                IssuerId = getLongAttribute("issuerID");
                IssuerName = getStringAttribute("issuerName");
                RoleLocationType = getStringAttribute("roleLocationType");
                OldRoles = deserializeRowSet(getRowSetReader("oldRoles"), new MemberSecurity.Role());
                NewRoles = deserializeRowSet(getRowSetReader("newRoles"), new MemberSecurity.Role());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

    }
}
