// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Kills.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Map {
    /// <summary>
    ///     Class Kills.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Kills {
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
            ///     Gets or sets the ship kills.
            /// </summary>
            /// <value>The ship kills.</value>
            [XmlAttribute("shipKills")]
            public int ShipKills { get; set; }

            /// <summary>
            ///     Gets or sets the faction kills.
            /// </summary>
            /// <value>The faction kills.</value>
            [XmlAttribute("factionKills")]
            public int FactionKills { get; set; }

            /// <summary>
            ///     Gets or sets the pod kills.
            /// </summary>
            /// <value>The pod kills.</value>
            [XmlAttribute("podKills")]
            public int PodKills { get; set; }
        }
    }
}