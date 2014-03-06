using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineApi.Model.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberSecurity : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Member> Members { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Member : XmlElement, IXmlSerializable {
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> Roles { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRoles { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> RolesAtHq { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRolesAtHq { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> RolesAtBase { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRolesAtBase { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> RolesAtOther { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Role> GrantableRolesAtOther { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Title> Titles { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                setRoot(reader);
                CharacterId = getLongAttribute("characterID");
                CharacterName = getStringAttribute("name");
                Roles = deserializeRowSet(getRowSetReader("roles"), new Role());
                GrantableRoles = deserializeRowSet(getRowSetReader("grantableRoles"), new Role());
                RolesAtHq = deserializeRowSet(getRowSetReader("rolesAtHQ"), new Role());
                GrantableRolesAtHq = deserializeRowSet(getRowSetReader("grantableRolesAtHQ"), new Role());
                RolesAtBase = deserializeRowSet(getRowSetReader("rolesAtBase"), new Role());
                GrantableRolesAtBase = deserializeRowSet(getRowSetReader("grantableRolesAtBase"), new Role());
                RolesAtOther = deserializeRowSet(getRowSetReader("rolesAtOther"), new Role());
                GrantableRolesAtOther = deserializeRowSet(getRowSetReader("grantableRolesAtOther"), new Role());
                Titles = deserializeRowSet(getRowSetReader("titles"), new Title());
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

        [Serializable]
        [XmlRoot("row")]
        public class Title {
            [XmlAttribute("title")]
            public long TitleId { get; set; }

            [XmlAttribute("titleName")]
            public string TitleName { get; set; }
        }
    }
}