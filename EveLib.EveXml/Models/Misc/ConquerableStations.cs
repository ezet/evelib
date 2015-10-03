// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ConquerableStations.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Misc {
    /// <summary>
    ///     Class ConquerableStations.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ConquerableStations {
        /// <summary>
        ///     Gets or sets the stations.
        /// </summary>
        /// <value>The stations.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<StationData> Stations { get; set; }

        /// <summary>
        ///     Class StationData.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class StationData {
            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the station.
            /// </summary>
            /// <value>The name of the station.</value>
            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            /// <summary>
            ///     Gets or sets the station type identifier.
            /// </summary>
            /// <value>The station type identifier.</value>
            [XmlAttribute("stationTypeID")]
            public long StationTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the corporation.
            /// </summary>
            /// <value>The name of the corporation.</value>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            ///     Gets or sets the x.
            /// </summary>
            /// <value>The x.</value>
            [XmlAttribute("x")]
            public float X { get; set; }

            /// <summary>
            ///     Gets or sets the y.
            /// </summary>
            /// <value>The y.</value>
            [XmlAttribute("y")]
            public float Y { get; set; }

            /// <summary>
            ///     Gets or sets the z.
            /// </summary>
            /// <value>The z.</value>
            [XmlAttribute("z")]
            public float Z { get; set; }
        }
    }
}