// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Jumps.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Map {
    /// <summary>
    /// Class Jumps.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Jumps {
        /// <summary>
        /// Gets or sets the solar systems.
        /// </summary>
        /// <value>The solar systems.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<SolarSystem> SolarSystems { get; set; }

        /// <summary>
        /// Class SolarSystem.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class SolarSystem {
            /// <summary>
            /// Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            /// Gets or sets the ship jumps.
            /// </summary>
            /// <value>The ship jumps.</value>
            [XmlAttribute("shipJumps")]
            public int ShipJumps { get; set; }
        }
    }
}