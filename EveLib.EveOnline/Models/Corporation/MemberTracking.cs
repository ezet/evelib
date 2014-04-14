using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberTracking {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Member> Members { get; set; }

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
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
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
                get { return LogonDate.ToString(XmlHelper.DateFormat); }
                set { LogonDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            [XmlIgnore]
            public DateTime LogoffDate { get; private set; }

            [XmlAttribute("logoffDateTime")]
            public string LogoffDateAsString {
                get { return LogoffDate.ToString(XmlHelper.DateFormat); }
                set { LogoffDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
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