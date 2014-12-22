// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MemberSecurityLog.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveOnlineModule.Util;

namespace eZet.EveLib.EveOnlineModule.Models.Corporation {
    /// <summary>
    ///     Class MemberSecurityLog.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberSecurityLog {
        /// <summary>
        ///     Gets or sets the role history.
        /// </summary>
        /// <value>The role history.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<LogEntry> RoleHistory { get; set; }

        /// <summary>
        ///     Class LogEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class LogEntry : IXmlSerializable {
            /// <summary>
            ///     Gets the change time.
            /// </summary>
            /// <value>The change time.</value>
            [XmlIgnore]
            public DateTime ChangeTime { get; private set; }

            /// <summary>
            ///     Gets or sets the change time as string.
            /// </summary>
            /// <value>The change time as string.</value>
            [XmlAttribute("changeTime")]
            public string ChangeTimeAsString {
                get { return ChangeTime.ToString(XmlHelper.DateFormat); }
                set { ChangeTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            /// <summary>
            ///     Gets or sets the issuer identifier.
            /// </summary>
            /// <value>The issuer identifier.</value>
            [XmlAttribute("issuerID")]
            public long IssuerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the issuer.
            /// </summary>
            /// <value>The name of the issuer.</value>
            [XmlAttribute("issuerName")]
            public string IssuerName { get; set; }

            /// <summary>
            ///     Gets or sets the type of the role location.
            /// </summary>
            /// <value>The type of the role location.</value>
            [XmlAttribute("roleLocationType")]
            public string RoleLocationType { get; set; }

            /// <summary>
            ///     Gets or sets the old roles.
            /// </summary>
            /// <value>The old roles.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<MemberSecurity.Role> OldRoles { get; set; }

            /// <summary>
            ///     Gets or sets the new roles.
            /// </summary>
            /// <value>The new roles.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<MemberSecurity.Role> NewRoles { get; set; }

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
                ChangeTimeAsString = xml.getStringAttribute("changeTime");
                CharacterId = xml.getLongAttribute("characterID");
                CharacterName = xml.getStringAttribute("characterName");
                IssuerId = xml.getLongAttribute("issuerID");
                IssuerName = xml.getStringAttribute("issuerName");
                RoleLocationType = xml.getStringAttribute("roleLocationType");
                OldRoles = xml.deserializeRowSet<MemberSecurity.Role>("oldRoles");
                NewRoles = xml.deserializeRowSet<MemberSecurity.Role>("newRoles");
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