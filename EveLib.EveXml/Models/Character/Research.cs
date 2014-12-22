// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Research.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveOnlineModule.Util;

namespace eZet.EveLib.EveOnlineModule.Models.Character {
    /// <summary>
    ///     Class Research.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Research {
        /// <summary>
        ///     Gets or sets the entries.
        /// </summary>
        /// <value>The entries.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<ResearchEntry> Entries { get; set; }

        /// <summary>
        ///     Class ResearchEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class ResearchEntry {
            /// <summary>
            ///     Gets or sets the agent identifier.
            /// </summary>
            /// <value>The agent identifier.</value>
            [XmlAttribute("agentID")]
            public long AgentId { get; set; }

            /// <summary>
            ///     Gets or sets the skill type identifier.
            /// </summary>
            /// <value>The skill type identifier.</value>
            [XmlAttribute("skillTypeID")]
            public long SkillTypeId { get; set; }

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
            [XmlAttribute("researchStartDate")]
            public string StartDateAsString {
                get { return StartDate.ToString(XmlHelper.DateFormat); }
                set { StartDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the points per day.
            /// </summary>
            /// <value>The points per day.</value>
            [XmlAttribute("pointsPerDay")]
            public decimal PointsPerDay { get; set; }

            /// <summary>
            ///     Gets or sets the points remaining.
            /// </summary>
            /// <value>The points remaining.</value>
            [XmlAttribute("remainderPoints")]
            public double pointsRemaining { get; set; }
        }
    }
}