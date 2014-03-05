using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberTracking : XmlElement {
        [XmlElement("rowset")]
        public XmlRowSet<Member> Members { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Member {
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            [XmlAttribute("startDateTime")]
            public string StartDateAsString {
                get { return StartDate.ToString(DateFormat); }
                set { StartDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("baseID")]
            public long BaseId { get; set; }

            [XmlAttribute("base")]
            public string BaseName { get; set; }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlIgnore]
            public DateTime LogonDate { get; private set; }

            [XmlAttribute("logonDateTime")]
            public string LogonDateAsString {
                get { return LogonDate.ToString(DateFormat); }
                set { LogonDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlIgnore]
            public DateTime LogoffDate { get; private set; }

            [XmlAttribute("logoffDateTime")]
            public string LogoffDateAsString {
                get { return LogoffDate.ToString(DateFormat); }
                set { LogoffDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            [XmlAttribute("location")]
            public string LocationName { get; set; }

            [XmlAttribute("shipTypeId")]
            public long ShipTypeId { get; set; }

            [XmlAttribute("shipTypeName")]
            public string ShipTypeName { get; set; }

            [XmlAttribute("roles")]
            public string Roles { get; set; }

            [XmlAttribute("grantableRoles")]
            public string GrantableRoles { get; set; }
        }
    }
}