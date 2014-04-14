using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberSecurity {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Member> Members { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Member : IXmlSerializable {
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> Roles { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> GrantableRoles { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> RolesAtHq { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> GrantableRolesAtHq { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> RolesAtBase { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> GrantableRolesAtBase { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> RolesAtOther { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Role> GrantableRolesAtOther { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Title> Titles { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                CharacterId = xml.getLongAttribute("characterID");
                CharacterName = xml.getStringAttribute("name");
                Roles = xml.deserializeRowSet<Role>("roles");
                GrantableRoles = xml.deserializeRowSet<Role>("grantableRoles");
                RolesAtHq = xml.deserializeRowSet<Role>("rolesAtHQ");
                GrantableRolesAtHq = xml.deserializeRowSet<Role>("grantableRolesAtHQ");
                RolesAtBase = xml.deserializeRowSet<Role>("rolesAtBase");
                GrantableRolesAtBase = xml.deserializeRowSet<Role>("grantableRolesAtBase");
                RolesAtOther = xml.deserializeRowSet<Role>("rolesAtOther");
                GrantableRolesAtOther = xml.deserializeRowSet<Role>("grantableRolesAtOther");
                Titles = xml.deserializeRowSet<Title>("titles");
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