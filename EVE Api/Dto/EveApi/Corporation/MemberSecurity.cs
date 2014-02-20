using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Corporation {
    public class MemberSecurity : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Member> Members { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Member : XmlResult, IXmlSerializable {
            
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> Roles { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> GrantableRoles { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> RolesAtHq { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> GrantableRolesAtHq { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> RolesAtBase { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> GrantableRolesAtBase { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> RolesAtOther { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Role> GrantableRolesAtOther { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<TitleList.Title> Titles { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                setRoot(reader);
                CharacterId = long.Parse(root.Attribute("characterID").Value);
                CharacterName = root.Attribute("name").Value;
                Roles = deserializeRowSet(getRowSetReader("roles"), new Role());
                GrantableRoles = deserializeRowSet(getRowSetReader("grantableRoles"), new Role());
                RolesAtHq = deserializeRowSet(getRowSetReader("rolesAtHQ"), new Role());
                GrantableRolesAtHq = deserializeRowSet(getRowSetReader("grantableRolesAtHQ"), new Role());
                RolesAtBase = deserializeRowSet(getRowSetReader("rolesAtBase"), new Role());
                GrantableRolesAtBase = deserializeRowSet(getRowSetReader("grantableRolesAtBase"), new Role());
                RolesAtOther = deserializeRowSet(getRowSetReader("rolesAtOther"), new Role());
                GrantableRolesAtOther = deserializeRowSet(getRowSetReader("grantableRolesAtOther"), new Role());
                Titles = deserializeRowSet(getRowSetReader("titles"), new TitleList.Title());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
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