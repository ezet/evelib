using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberSecurityLog {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<LogEntry> RoleHistory { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class LogEntry : IXmlSerializable {
            [XmlIgnore]
            public DateTime ChangeTime { get; private set; }

            [XmlAttribute("changeTime")]
            public string ChangeTimeAsString {
                get { return ChangeTime.ToString(XmlHelper.DateFormat); }
                set { ChangeTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
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
            public EveOnlineRowCollection<MemberSecurity.Role> OldRoles { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<MemberSecurity.Role> NewRoles { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                ChangeTimeAsString = xml.getStringAttribute("changeTime");
                CharacterId = xml.getLongAttribute("characterID");
                CharacterName = xml.getStringAttribute("characterName");
                IssuerId = xml.getLongAttribute("issuerID");
                IssuerName = xml.getStringAttribute("issuerName");
                RoleLocationType = xml.getStringAttribute("roleLocationType");
                OldRoles = xml.deserializeRowSet<MemberSecurity.Role>("oldRoles");
                NewRoles = xml.deserializeRowSet<MemberSecurity.Role>("newRoles");
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}