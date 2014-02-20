using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class TitleList : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Title> Titles { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Title {
            [XmlAttribute("titleID")]
            public long TitleId { get; set; }

            [XmlAttribute("titleName")]
            public string TitleName { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> RolesAtHq { get; set; }

        }

        [Serializable]
        [XmlRoot("row")]
        public class Role {
            
            [XmlAttribute("roleID")]
            public long RoleId { get; set; }

            [XmlAttribute("roleName")]
            public string RoleName { get; set; }

            [XmlAttribute("roleDescription")]
            public string RoleDescription { get; set; }
        }
    }
}
