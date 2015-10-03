// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-06-2015
// ***********************************************************************
// <copyright file="StarbaseDetails.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Corporation {
    /// <summary>
    ///     Class StarbaseDetails.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StarbaseDetails {
        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [XmlElement("state")]
        public int State { get; set; }

        /// <summary>
        ///     Gets the state timestamp.
        /// </summary>
        /// <value>The state timestamp.</value>
        [XmlIgnore]
        public DateTime StateTimestamp { get; private set; }

        /// <summary>
        ///     Gets or sets the state timestamp as string.
        /// </summary>
        /// <value>The state timestamp as string.</value>
        [XmlElement("stateTimestamp")]
        public string StateTimestampAsString {
            get { return StateTimestamp.ToString(XmlHelper.DateFormat); }
            set { StateTimestamp = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets the online timestamp.
        /// </summary>
        /// <value>The online timestamp.</value>
        [XmlIgnore]
        public DateTime OnlineTimestamp { get; private set; }

        /// <summary>
        ///     Gets or sets the online timestamp as string.
        /// </summary>
        /// <value>The online timestamp as string.</value>
        [XmlElement("onlineTimestamp")]
        public string OnlineTimestampAsString {
            get { return OnlineTimestamp.ToString(XmlHelper.DateFormat); }
            set { OnlineTimestamp = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the general settings.
        /// </summary>
        /// <value>The general settings.</value>
        [XmlElement("generalSettings")]
        public GeneralSetting GeneralSettings { get; set; }

        /// <summary>
        ///     Gets or sets the combat settings.
        /// </summary>
        /// <value>The combat settings.</value>
        [XmlElement("combatSettings")]
        public CombatSetting CombatSettings { get; set; }

        /// <summary>
        ///     Gets or sets the fuel.
        /// </summary>
        /// <value>The fuel.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<FuelEntry> Fuel { get; set; }


        /// <summary>
        ///     Class FuelEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class FuelEntry {
            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the quantity.
            /// </summary>
            /// <value>The quantity.</value>
            [XmlAttribute("quantity")]
            public int Quantity { get; set; }
        }

        /// <summary>
        ///     Class CombatSetting.
        /// </summary>
        [XmlRoot("combatSettings")]
        public class CombatSetting {
            /// <summary>
            ///     Gets or sets the use standings from.
            /// </summary>
            /// <value>The use standings from.</value>
            [XmlElement("useStandingsFrom")]
            public CombatSettingEntry UseStandingsFrom { get; set; }

            /// <summary>
            ///     Gets or sets the on standing drop.
            /// </summary>
            /// <value>The on standing drop.</value>
            [XmlElement("onStandingDrop")]
            public CombatSettingEntry OnStandingDrop { get; set; }

            /// <summary>
            ///     Gets or sets the on aggression.
            /// </summary>
            /// <value>The on aggression.</value>
            [XmlElement("onStatusDrop")]
            public CombatSettingEntry OnAggression { get; set; }

            /// <summary>
            ///     Gets or sets the on corporation war.
            /// </summary>
            /// <value>The on corporation war.</value>
            [XmlElement("onCorporationWar")]
            public CombatSettingEntry OnCorporationWar { get; set; }
        }

        /// <summary>
        ///     Class CombatSettingEntry.
        /// </summary>
        public class CombatSettingEntry {
            /// <summary>
            ///     Gets or sets the enabled.
            /// </summary>
            /// <value>The enabled.</value>
            [XmlAttribute("enabled")]
            public int Enabled { get; set; }

            /// <summary>
            ///     Gets or sets the standing.
            /// </summary>
            /// <value>The standing.</value>
            [XmlAttribute("standing")]
            public int Standing { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public int OwnerId { get; set; }
        }


        /// <summary>
        ///     Class GeneralSetting.
        /// </summary>
        [XmlRoot("generalSettings")]
        public class GeneralSetting {
            /// <summary>
            ///     Gets or sets the usage flags.
            /// </summary>
            /// <value>The usage flags.</value>
            [XmlElement("usageFlags")]
            public int UsageFlags { get; set; }

            /// <summary>
            ///     Gets or sets the deploy flags.
            /// </summary>
            /// <value>The deploy flags.</value>
            [XmlElement("deployFlags")]
            public int DeployFlags { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether [allow corporation members].
            /// </summary>
            /// <value><c>true</c> if [allow corporation members]; otherwise, <c>false</c>.</value>
            [XmlElement("allowCorporationMembers")]
            public bool AllowCorporationMembers { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether [allow alliance members].
            /// </summary>
            /// <value><c>true</c> if [allow alliance members]; otherwise, <c>false</c>.</value>
            [XmlElement("allowAllianceMembers")]
            public bool AllowAllianceMembers { get; set; }
        }
    }
}