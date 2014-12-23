// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="FactionWarfareStats.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class FactionWarfareStats.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarfareStats {
        /// <summary>
        ///     Gets or sets the faction identifier.
        /// </summary>
        /// <value>The faction identifier.</value>
        [XmlElement("factionID")]
        public long FactionId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the faction.
        /// </summary>
        /// <value>The name of the faction.</value>
        [XmlElement("factionName")]
        public string FactionName { get; set; }

        /// <summary>
        ///     Gets the enlisted date.
        /// </summary>
        /// <value>The enlisted date.</value>
        [XmlIgnore]
        public DateTime EnlistedDate { get; private set; }

        /// <summary>
        ///     Gets or sets the enlisted date as string.
        /// </summary>
        /// <value>The enlisted date as string.</value>
        [XmlElement("enlisted")]
        public string EnlistedDateAsString {
            get { return EnlistedDate.ToString(XmlHelper.DateFormat); }
            set { EnlistedDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the current rank.
        /// </summary>
        /// <value>The current rank.</value>
        [XmlElement("currentRank")]
        public int CurrentRank { get; set; }

        /// <summary>
        ///     Gets or sets the highest rank.
        /// </summary>
        /// <value>The highest rank.</value>
        [XmlElement("highestRank")]
        public int HighestRank { get; set; }

        /// <summary>
        ///     Gets or sets the kills yesterday.
        /// </summary>
        /// <value>The kills yesterday.</value>
        [XmlElement("killsYesterday")]
        public int KillsYesterday { get; set; }

        /// <summary>
        ///     Gets or sets the kills last week.
        /// </summary>
        /// <value>The kills last week.</value>
        [XmlElement("killsLastWeek")]
        public int KillsLastWeek { get; set; }

        /// <summary>
        ///     Gets or sets the kills total.
        /// </summary>
        /// <value>The kills total.</value>
        [XmlElement("killsTotal")]
        public int KillsTotal { get; set; }

        /// <summary>
        ///     Gets or sets the victory points yesterday.
        /// </summary>
        /// <value>The victory points yesterday.</value>
        [XmlElement("vicoryPointsYesterday")]
        public int VictoryPointsYesterday { get; set; }

        /// <summary>
        ///     Gets or sets the victory points last week.
        /// </summary>
        /// <value>The victory points last week.</value>
        [XmlElement("victoryPointsLastWeek")]
        public int VictoryPointsLastWeek { get; set; }

        /// <summary>
        ///     Gets or sets the victory points total.
        /// </summary>
        /// <value>The victory points total.</value>
        [XmlElement("victoryPointsTotal")]
        public int VictoryPointsTotal { get; set; }
    }
}