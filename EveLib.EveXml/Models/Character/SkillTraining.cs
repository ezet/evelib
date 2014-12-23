// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="SkillTraining.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class SkillTraining.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SkillTraining {
        // TODO Convert zone
        /// <summary>
        ///     Gets the current tq time.
        /// </summary>
        /// <value>The current tq time.</value>
        [XmlIgnore]
        public DateTime CurrentTqTime { get; private set; }

        /// <summary>
        ///     Gets or sets the current tq time as string.
        /// </summary>
        /// <value>The current tq time as string.</value>
        [XmlElement("currentTQTime")]
        public string CurrentTqTimeAsString {
            get { return CurrentTqTime.ToString(XmlHelper.DateFormat); }
            set { CurrentTqTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets the end time.
        /// </summary>
        /// <value>The end time.</value>
        [XmlIgnore]
        public DateTime EndTime { get; private set; }

        /// <summary>
        ///     Gets or sets the end time as string.
        /// </summary>
        /// <value>The end time as string.</value>
        [XmlElement("EndTime")]
        public string EndTimeAsString {
            get { return EndTime.ToString(XmlHelper.DateFormat); }
            set { EndTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets the start time.
        /// </summary>
        /// <value>The start time.</value>
        [XmlIgnore]
        public DateTime StartTime { get; private set; }

        /// <summary>
        ///     Gets or sets the start time as string.
        /// </summary>
        /// <value>The start time as string.</value>
        [XmlElement("StartTime")]
        public string StartTimeAsString {
            get { return StartTime.ToString(XmlHelper.DateFormat); }
            set { StartTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [XmlElement("trainingTypeID")]
        public int TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the start sp.
        /// </summary>
        /// <value>The start sp.</value>
        [XmlElement("trainingStartSP")]
        public int StartSp { get; set; }

        /// <summary>
        ///     Gets or sets the destination sp.
        /// </summary>
        /// <value>The destination sp.</value>
        [XmlElement("trainingDestinationSP")]
        public int DestinationSp { get; set; }

        /// <summary>
        ///     Gets or sets to level.
        /// </summary>
        /// <value>To level.</value>
        [XmlElement("trainingToLevel")]
        public int ToLevel { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is training.
        /// </summary>
        /// <value><c>true</c> if this instance is training; otherwise, <c>false</c>.</value>
        [XmlElement("skillInTraining")]
        public bool IsTraining { get; set; }
    }
}