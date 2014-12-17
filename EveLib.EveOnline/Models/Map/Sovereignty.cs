// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Sovereignty.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Map {
    /// <summary>
    ///     Class Sovereignty.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class Sovereignty {
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
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            ///     Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the solar system.
            /// </summary>
            /// <value>The name of the solar system.</value>
            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }
        }
    }
}