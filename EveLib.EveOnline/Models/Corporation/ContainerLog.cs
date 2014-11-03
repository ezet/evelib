// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ContainerLog.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Corporation {
    /// <summary>
    ///     Class ContainerLog.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ContainerLog {
        /// <summary>
        ///     Gets or sets the log entries.
        /// </summary>
        /// <value>The log entries.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<LogEntry> LogEntries { get; set; }

        /// <summary>
        ///     Class LogEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class LogEntry {
            /// <summary>
            ///     Gets the log time.
            /// </summary>
            /// <value>The log time.</value>
            [XmlIgnore]
            public DateTime LogTime { get; private set; }

            /// <summary>
            ///     Gets or sets the log time as string.
            /// </summary>
            /// <value>The log time as string.</value>
            [XmlAttribute("logTime")]
            public string LogTimeAsString {
                get { return LogTime.ToString(XmlHelper.DateFormat); }
                set { LogTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the item identifier.
            /// </summary>
            /// <value>The item identifier.</value>
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            /// <summary>
            ///     Gets or sets the item type identifier.
            /// </summary>
            /// <value>The item type identifier.</value>
            [XmlAttribute("itemTypeID")]
            public long itemTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the actor identifier.
            /// </summary>
            /// <value>The actor identifier.</value>
            [XmlAttribute("actorID")]
            public long ActorId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the actor.
            /// </summary>
            /// <value>The name of the actor.</value>
            [XmlAttribute("actorName")]
            public string ActorName { get; set; }

            /// <summary>
            ///     Gets or sets the flag.
            /// </summary>
            /// <value>The flag.</value>
            [XmlAttribute("flag")]
            public int Flag { get; set; }

            /// <summary>
            ///     Gets or sets the location identifier.
            /// </summary>
            /// <value>The location identifier.</value>
            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            /// <summary>
            ///     Gets or sets the action.
            /// </summary>
            /// <value>The action.</value>
            [XmlAttribute("action")]
            public string Action { get; set; }

            /// <summary>
            ///     Gets or sets the type of the password.
            /// </summary>
            /// <value>The type of the password.</value>
            [XmlAttribute("passwordType")]
            public string PasswordType { get; set; }

            /// <summary>
            ///     Can be empty string
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public string TypeId { get; set; }

            /// <summary>
            ///     Can be empty string
            /// </summary>
            /// <value>The quantity.</value>
            [XmlAttribute("quantity")]
            public string Quantity { get; set; }

            /// <summary>
            ///     Gets or sets the old configuration.
            /// </summary>
            /// <value>The old configuration.</value>
            [XmlAttribute("oldConfiguration")]
            public string OldConfiguration { get; set; }

            /// <summary>
            ///     Gets or sets the new configuration.
            /// </summary>
            /// <value>The new configuration.</value>
            [XmlAttribute("newConfiguration")]
            public string NewConfiguration { get; set; }
        }
    }
}