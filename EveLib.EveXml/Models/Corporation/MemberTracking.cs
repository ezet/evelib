// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="MemberTracking.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Corporation {
    /// <summary>
    ///     Class MemberTracking.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class MemberTracking {
        /// <summary>
        ///     Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Member> Members { get; set; }

        /// <summary>
        ///     Class Member.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Member {
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
            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            /// <summary>
            ///     Gets the start date.
            /// </summary>
            /// <value>The start date.</value>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            /// <summary>
            ///     Gets or sets the start date as string.
            /// </summary>
            /// <value>The start date as string.</value>
            [XmlAttribute("startDateTime")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the base identifier.
            /// </summary>
            /// <value>The base identifier.</value>
            [XmlAttribute("baseID")]
            public long BaseId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the base.
            /// </summary>
            /// <value>The name of the base.</value>
            [XmlAttribute("base")]
            public string BaseName { get; set; }

            /// <summary>
            ///     Gets or sets the title.
            /// </summary>
            /// <value>The title.</value>
            [XmlAttribute("title")]
            public string Title { get; set; }

            /// <summary>
            ///     Gets the logon date.
            /// </summary>
            /// <value>The logon date.</value>
            [XmlIgnore]
            public DateTime LogonDate { get; private set; }

            /// <summary>
            ///     Gets or sets the logon date as string.
            /// </summary>
            /// <value>The logon date as string.</value>
            [XmlAttribute("logonDateTime")]
            public string LogonDateAsString {
                get { return LogonDate.ToString(XmlHelper.DateFormat); }
                set { LogonDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets the logoff date.
            /// </summary>
            /// <value>The logoff date.</value>
            [XmlIgnore]
            public DateTime LogoffDate { get; private set; }

            /// <summary>
            ///     Gets or sets the logoff date as string.
            /// </summary>
            /// <value>The logoff date as string.</value>
            [XmlAttribute("logoffDateTime")]
            public string LogoffDateAsString {
                get { return LogoffDate.ToString(XmlHelper.DateFormat); }
                set { LogoffDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the location identifier.
            /// </summary>
            /// <value>The location identifier.</value>
            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the location.
            /// </summary>
            /// <value>The name of the location.</value>
            [XmlAttribute("location")]
            public string LocationName { get; set; }

            /// <summary>
            ///     Gets or sets the ship type identifier.
            /// </summary>
            /// <value>The ship type identifier.</value>
            [XmlAttribute("shipTypeId")]
            public long ShipTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the ship type.
            /// </summary>
            /// <value>The name of the ship type.</value>
            [XmlAttribute("shipTypeName")]
            public string ShipTypeName { get; set; }

            /// <summary>
            ///     Gets or sets the roles.
            /// </summary>
            /// <value>The roles.</value>
            [XmlAttribute("roles")]
            public string Roles { get; set; }

            /// <summary>
            ///     Gets or sets the grantable roles.
            /// </summary>
            /// <value>The grantable roles.</value>
            [XmlAttribute("grantableRoles")]
            public string GrantableRoles { get; set; }
        }
    }
}