// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="StarbaseList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Corporation {
    /// <summary>
    ///     Class StarbaseList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StarbaseList {
        /// <summary>
        ///     Gets or sets the starbases.
        /// </summary>
        /// <value>The starbases.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Starbase> Starbases { get; set; }


        /// <summary>
        ///     Class Starbase.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Starbase {
            /// <summary>
            ///     Enum StarbaseState
            /// </summary>
            public enum StarbaseState {
                /// <summary>
                ///     The unanchored
                /// </summary>
                [XmlEnum("0")] Unanchored,

                /// <summary>
                ///     The anchored
                /// </summary>
                [XmlEnum("1")] Anchored,

                /// <summary>
                ///     The onlining
                /// </summary>
                [XmlEnum("2")] Onlining,

                /// <summary>
                ///     The reinforced
                /// </summary>
                [XmlEnum("3")] Reinforced,

                /// <summary>
                ///     The online
                /// </summary>
                [XmlEnum("4")] Online
            }

            /// <summary>
            ///     Gets or sets the item identifier.
            /// </summary>
            /// <value>The item identifier.</value>
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the location identifier.
            /// </summary>
            /// <value>The location identifier.</value>
            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            /// <summary>
            ///     Gets or sets the moon identifier.
            /// </summary>
            /// <value>The moon identifier.</value>
            [XmlAttribute("moonID")]
            public long MoonId { get; set; }

            /// <summary>
            ///     Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            [XmlAttribute("state")]
            public StarbaseState State { get; set; }

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
            ///     Gets or sets the standing owner identifier.
            /// </summary>
            /// <value>The standing owner identifier.</value>
            [XmlAttribute("standingOwnerID")]
            public long StandingOwnerId { get; set; }
        }
    }
}