using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class MemberSecurityLog : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<LogEntry> LogEntries { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class LogEntry {
            
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
            public XmlRowSet<MemberSecurity.Role> Roles { get; set; }

        }

    }
}
