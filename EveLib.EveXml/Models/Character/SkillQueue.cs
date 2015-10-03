// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="SkillQueue.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class SkillQueue.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SkillQueue {
        /// <summary>
        ///     Gets or sets the queue.
        /// </summary>
        /// <value>The queue.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Skill> Queue { get; set; }

        /// <summary>
        ///     Class Skill.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Skill {
            /// <summary>
            ///     Gets or sets the queue position.
            /// </summary>
            /// <value>The queue position.</value>
            [XmlAttribute("queuePosition")]
            public int QueuePosition { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the level.
            /// </summary>
            /// <value>The level.</value>
            [XmlAttribute("level")]
            public int Level { get; set; }

            /// <summary>
            ///     Gets or sets the start sp.
            /// </summary>
            /// <value>The start sp.</value>
            [XmlAttribute("startSP")]
            public int StartSp { get; set; }

            /// <summary>
            ///     Gets or sets the end sp.
            /// </summary>
            /// <value>The end sp.</value>
            [XmlAttribute("endSP")]
            public int EndSp { get; set; }

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
            [XmlAttribute("startTime")]
            public string StartTimeAsString {
                get { return StartTime.ToString(XmlHelper.DateFormat); }
                set {
                    StartTime = value != "" ? DateTime.ParseExact(value, XmlHelper.DateFormat, null) : default(DateTime);
                }
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
            [XmlAttribute("endTime")]
            public string EndTimeAsString {
                get { return EndTime.ToString(XmlHelper.DateFormat); }
                set {
                    EndTime = value != "" ? DateTime.ParseExact(value, XmlHelper.DateFormat, null) : default(DateTime);
                }
            }
        }
    }
}