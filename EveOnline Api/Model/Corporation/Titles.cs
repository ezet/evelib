using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineApi.Model.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class TitleList : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Title> Titles { get; set; }

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

        [Serializable]
        [XmlRoot("row")]
        public class Title : XmlElement, IXmlSerializable {
            [XmlAttribute("titleID")]
            public long TitleId { get; set; }

            [XmlAttribute("titleName")]
            public string TitleName { get; set; }

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

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                setRoot(reader);
                TitleId = long.Parse(root.Attribute("titleID").Value);
                TitleName = root.Attribute("titleName").Value;
                Roles = deserializeRowSet(getRowSetReader("roles"), new Role());
                GrantableRoles = deserializeRowSet(getRowSetReader("grantableRoles"), new Role());
                RolesAtHq = deserializeRowSet(getRowSetReader("rolesAtHQ"), new Role());
                GrantableRolesAtHq = deserializeRowSet(getRowSetReader("grantableRolesAtHQ"), new Role());
                RolesAtBase = deserializeRowSet(getRowSetReader("rolesAtBase"), new Role());
                GrantableRolesAtBase = deserializeRowSet(getRowSetReader("grantableRolesAtBase"), new Role());
                RolesAtOther = deserializeRowSet(getRowSetReader("rolesAtOther"), new Role());
                GrantableRolesAtOther = deserializeRowSet(getRowSetReader("grantableRolesAtOther"), new Role());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}