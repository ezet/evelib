// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="FactionWarfareSystems.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Map {
    /// <summary>
    ///     Class FactionWarfareSystems.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarfareSystems {
        /// <summary>
        ///     Gets or sets the solar systems.
        /// </summary>
        /// <value>The solar systems.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<SolarSystem> SolarSystems { get; set; }

        /// <summary>
        ///     Class SolarSystem.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            /// <summary>
            ///     Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the solar system.
            /// </summary>
            /// <value>The name of the solar system.</value>
            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            /// <summary>
            ///     Gets or sets the occupying faction identifier.
            /// </summary>
            /// <value>The occupying faction identifier.</value>
            [XmlAttribute("occupyingFactionID")]
            public long OccupyingFactionId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the occupying faction.
            /// </summary>
            /// <value>The name of the occupying faction.</value>
            [XmlAttribute("occupyingFactionName")]
            public string OccupyingFactionName { get; set; }

            /// <summary>
            ///     Gets a value indicating whether this <see cref="SolarSystem" /> is contested.
            /// </summary>
            /// <value><c>true</c> if contested; otherwise, <c>false</c>.</value>
            [XmlIgnore]
            public bool Contested { get; private set; }

            /// <summary>
            ///     Gets or sets the contested as string.
            /// </summary>
            /// <value>The contested as string.</value>
            [XmlAttribute("contested")]
            public string ContestedAsString {
                get { return Contested.ToString(); }
                set { Contested = value == "True".ToLower(); }
            }
        }
    }
}