using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class MemberTracking : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Member> Members { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Member {
            
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            // TODO DateTime
            [XmlAttribute("startDateTime")]
            public string StartDate { get; set; }

            [XmlAttribute("baseID")]
            public long BaseId { get; set; }

            [XmlAttribute("base")]
            public string BaseName { get; set; }

            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("logonDateTime")]
            public string LogonDate { get; set; }

            [XmlAttribute("logoffDateTime")]
            public string LogoffDate { get; set; }

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
