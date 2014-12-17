// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 08-23-2014
// ***********************************************************************
// <copyright file="CharacterInfo.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveOnlineModule.Util;

namespace eZet.EveLib.EveOnlineModule.Models.Misc {
    /// <summary>
    ///     Class CharacterInfo.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterInfo {
        /// <summary>
        ///     Gets or sets the character identifier.
        /// </summary>
        /// <value>The character identifier.</value>
        [XmlElement("characterID")]
        public long CharacterId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the character.
        /// </summary>
        /// <value>The name of the character.</value>
        [XmlElement("characterName")]
        public string CharacterName { get; set; }

        /// <summary>
        ///     Gets or sets the race.
        /// </summary>
        /// <value>The race.</value>
        [XmlElement("race")]
        public string Race { get; set; }

        /// <summary>
        ///     Gets or sets the bloodline.
        /// </summary>
        /// <value>The bloodline.</value>
        [XmlElement("bloodline")]
        public string Bloodline { get; set; }

        /// <summary>
        ///     Gets or sets the account balance.
        /// </summary>
        /// <value>The account balance.</value>
        [XmlElement("accountBalance")]
        public string AccountBalance { get; set; }

        /// <summary>
        ///     Gets or sets the skill points.
        /// </summary>
        /// <value>The skill points.</value>
        [XmlElement("skillPoints")]
        public int SkillPoints { get; set; }

        /// <summary>
        ///     Gets or sets the name of the ship.
        /// </summary>
        /// <value>The name of the ship.</value>
        [XmlElement("shipName")]
        public string ShipName { get; set; }

        /// <summary>
        ///     Gets or sets the ship type identifier.
        /// </summary>
        /// <value>The ship type identifier.</value>
        [XmlElement("shipTypeID")]
        public long ShipTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the ship type.
        /// </summary>
        /// <value>The name of the ship type.</value>
        [XmlElement("shipTypeName")]
        public string ShipTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the corporation identifier.
        /// </summary>
        /// <value>The corporation identifier.</value>
        [XmlElement("corporationID")]
        public long CorporationId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the corporation.
        /// </summary>
        /// <value>The name of the corporation.</value>
        [XmlElement("corporation")]
        public string CorporationName { get; set; }

        /// <summary>
        ///     Gets the corporation date.
        /// </summary>
        /// <value>The corporation date.</value>
        [XmlIgnore]
        public DateTime CorporationDate { get; private set; }

        /// <summary>
        ///     Gets or sets the corporation date as string.
        /// </summary>
        /// <value>The corporation date as string.</value>
        [XmlElement("corporationDate")]
        public string CorporationDateAsString {
            get { return CorporationDate.ToString(XmlHelper.DateFormat); }
            set { CorporationDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the alliance identifier.
        /// </summary>
        /// <value>The alliance identifier.</value>
        [XmlElement("allianceID")]
        public long AllianceId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the alliance.
        /// </summary>
        /// <value>The name of the alliance.</value>
        [XmlElement("alliance")]
        public string AllianceName { get; set; }

        /// <summary>
        ///     Gets the alliance date.
        /// </summary>
        /// <value>The alliance date.</value>
        [XmlIgnore]
        public DateTime AllianceDate { get; private set; }

        /// <summary>
        ///     Gets or sets the alliance date as string.
        /// </summary>
        /// <value>The alliance date as string.</value>
        [XmlElement("allianceDate")]
        public string AllianceDateAsString {
            get { return AllianceDate.ToString(XmlHelper.DateFormat); }
            set { AllianceDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the last known location.
        /// </summary>
        /// <value>The last known location.</value>
        [XmlElement("lastKnownLocation")]
        public string LastKnownLocation { get; set; }

        /// <summary>
        ///     Gets or sets the security status.
        /// </summary>
        /// <value>The security status.</value>
        [XmlElement("securityStatus")]
        public double SecurityStatus { get; set; }

        /// <summary>
        ///     Gets or sets the employment history.
        /// </summary>
        /// <value>The employment history.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Employment> EmploymentHistory { get; set; }

        /// <summary>
        ///     Represents a employment entry
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Employment {
            /// <summary>
            ///     The employment record ID
            /// </summary>
            /// <value>The record identifier.</value>
            [XmlAttribute("recordID")]
            public long RecordId { get; set; }

            /// <summary>
            ///     The corporation ID
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     The corporation name
            /// </summary>
            /// <value>The name of the corporation.</value>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            ///     The employment start date
            /// </summary>
            /// <value>The start date.</value>
            [XmlIgnore]
            public DateTime StartDate { get; private set; }

            /// <summary>
            ///     Gets or sets the start date as string.
            /// </summary>
            /// <value>The start date as string.</value>
            [XmlAttribute("startDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }
        }
    }
}