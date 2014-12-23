// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Titles.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Corporation {
    /// <summary>
    ///     Class TitleList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class TitleList {
        /// <summary>
        ///     Gets or sets the titles.
        /// </summary>
        /// <value>The titles.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Title> Titles { get; set; }

        /// <summary>
        ///     Class Role.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Role {
            /// <summary>
            ///     Gets or sets the role identifier.
            /// </summary>
            /// <value>The role identifier.</value>
            [XmlAttribute("roleID")]
            public long RoleId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the role.
            /// </summary>
            /// <value>The name of the role.</value>
            [XmlAttribute("roleName")]
            public string RoleName { get; set; }

            /// <summary>
            ///     Gets or sets the role description.
            /// </summary>
            /// <value>The role description.</value>
            [XmlAttribute("roleDescription")]
            public string RoleDescription { get; set; }
        }

        /// <summary>
        ///     Class Title.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Title : IXmlSerializable {
            /// <summary>
            ///     Gets or sets the title identifier.
            /// </summary>
            /// <value>The title identifier.</value>
            [XmlAttribute("titleID")]
            public long TitleId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the title.
            /// </summary>
            /// <value>The name of the title.</value>
            [XmlAttribute("titleName")]
            public string TitleName { get; set; }

            /// <summary>
            ///     Gets or sets the roles.
            /// </summary>
            /// <value>The roles.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> Roles { get; set; }

            /// <summary>
            ///     Gets or sets the grantable roles.
            /// </summary>
            /// <value>The grantable roles.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> GrantableRoles { get; set; }

            /// <summary>
            ///     Gets or sets the roles at hq.
            /// </summary>
            /// <value>The roles at hq.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> RolesAtHq { get; set; }

            /// <summary>
            ///     Gets or sets the grantable roles at hq.
            /// </summary>
            /// <value>The grantable roles at hq.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> GrantableRolesAtHq { get; set; }

            /// <summary>
            ///     Gets or sets the roles at base.
            /// </summary>
            /// <value>The roles at base.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> RolesAtBase { get; set; }

            /// <summary>
            ///     Gets or sets the grantable roles at base.
            /// </summary>
            /// <value>The grantable roles at base.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> GrantableRolesAtBase { get; set; }

            /// <summary>
            ///     Gets or sets the roles at other.
            /// </summary>
            /// <value>The roles at other.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> RolesAtOther { get; set; }

            /// <summary>
            ///     Gets or sets the grantable roles at other.
            /// </summary>
            /// <value>The grantable roles at other.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Role> GrantableRolesAtOther { get; set; }

            /// <summary>
            ///     This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return
            ///     null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the
            ///     <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
            /// </summary>
            /// <returns>
            ///     An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is
            ///     produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method
            ///     and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" />
            ///     method.
            /// </returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Generates an object from its XML representation.
            /// </summary>
            /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                TitleId = xml.getLongAttribute("titleID");
                TitleName = xml.getStringAttribute("titleName");
                Roles = xml.deserializeRowSet<Role>("roles");
                GrantableRoles = xml.deserializeRowSet<Role>("grantableRoles");
                RolesAtHq = xml.deserializeRowSet<Role>("rolesAtHQ");
                GrantableRolesAtHq = xml.deserializeRowSet<Role>("grantableRolesAtHQ");
                RolesAtBase = xml.deserializeRowSet<Role>("rolesAtBase");
                GrantableRolesAtBase = xml.deserializeRowSet<Role>("grantableRolesAtBase");
                RolesAtOther = xml.deserializeRowSet<Role>("rolesAtOther");
                GrantableRolesAtOther = xml.deserializeRowSet<Role>("grantableRolesAtOther");
            }

            /// <summary>
            ///     Converts an object into its XML representation.
            /// </summary>
            /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}