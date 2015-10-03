// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="OutpostList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Corporation {
    /// <summary>
    ///     Class OutpostList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class OutpostList {
        /// <summary>
        ///     Gets or sets the outposts.
        /// </summary>
        /// <value>The outposts.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Outpost> Outposts { get; set; }

        /// <summary>
        ///     Class Outpost.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Outpost {
            /// <summary>
            ///     Gets or sets the station identifier.
            /// </summary>
            /// <value>The station identifier.</value>
            [XmlAttribute("stationID")]
            public int StationId { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the station.
            /// </summary>
            /// <value>The name of the station.</value>
            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            /// <summary>
            ///     Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     Gets or sets the docking cost.
            /// </summary>
            /// <value>The docking cost.</value>
            [XmlAttribute("dockingCostPerShipVolume")]
            public decimal DockingCost { get; set; }

            /// <summary>
            ///     Gets or sets the office rental cost.
            /// </summary>
            /// <value>The office rental cost.</value>
            [XmlAttribute("officeRentalCost")]
            public decimal OfficeRentalCost { get; set; }

            /// <summary>
            ///     Gets or sets the station type identifier.
            /// </summary>
            /// <value>The station type identifier.</value>
            [XmlAttribute("stationTypeID")]
            public long StationTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the reprocessing efficiency.
            /// </summary>
            /// <value>The reprocessing efficiency.</value>
            [XmlAttribute("reprocessingEfficiency")]
            public double ReprocessingEfficiency { get; set; }

            /// <summary>
            ///     Gets or sets the reprocessing station take.
            /// </summary>
            /// <value>The reprocessing station take.</value>
            [XmlAttribute("reprocessingStationTake")]
            public double ReprocessingStationTake { get; set; }

            /// <summary>
            ///     Gets or sets the standing owner identifier.
            /// </summary>
            /// <value>The standing owner identifier.</value>
            [XmlAttribute("standingOwnerID")]
            public long StandingOwnerId { get; set; }

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