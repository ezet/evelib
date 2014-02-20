using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class MemberSecurity : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Member> Members { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Member {
            
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> Roles { get; set; }

            [XmlElement("rowset2")]
            public XmlRowSet<TitleList.Title> Titles { get; set; }

        }
        
        [Serializable]
        [XmlRoot("row")]
        public class Role {
            
            [XmlAttribute("roleID")]
            public long RoleId { get; set; }
            
            [XmlAttribute("roleName")]
            public string RoleName { get; set; }
        }
    }
}