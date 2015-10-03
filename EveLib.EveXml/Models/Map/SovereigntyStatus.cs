// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="SovereigntyStatus.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Map {
    /// <summary>
    ///     Class SovereigntyStatus.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class SovereigntyStatus {
        /// <summary>
        ///     Gets or sets the structures.
        /// </summary>
        /// <value>The structures.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<SolarSystem> SolarSystems { get; set; }

        /// <summary>
        ///     Class Structure.
        /// </summary>
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
            public long AllianceID { get; set; }

            /// <summary>
            ///     Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [XmlAttribute("factionID")]
            public int FactionId { get; set; }

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