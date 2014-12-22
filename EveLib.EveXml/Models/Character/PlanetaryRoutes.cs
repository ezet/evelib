// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 05-05-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="PlanetaryRoutes.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Character {
    /// <summary>
    ///     Class PlanetaryRoutes.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryRoutes {
        /// <summary>
        ///     Gets or sets the routes.
        /// </summary>
        /// <value>The routes.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryRoute> Routes { get; set; }

        /// <summary>
        ///     Class PlanetaryRoute.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryRoute {
            /// <summary>
            ///     Gets or sets the route identifier.
            /// </summary>
            /// <value>The route identifier.</value>
            [XmlAttribute("routeID")]
            public long RouteId { get; set; }

            /// <summary>
            ///     Gets or sets the source pin identifier.
            /// </summary>
            /// <value>The source pin identifier.</value>
            [XmlAttribute("sourcePinID")]
            public long SourcePinId { get; set; }

            /// <summary>
            ///     Gets or sets the destination pin identifier.
            /// </summary>
            /// <value>The destination pin identifier.</value>
            [XmlAttribute("destinationPinID")]
            public long DestinationPinId { get; set; }

            /// <summary>
            ///     Gets or sets the content type identifier.
            /// </summary>
            /// <value>The content type identifier.</value>
            [XmlAttribute("contentTypeID")]
            public int ContentTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the content type.
            /// </summary>
            /// <value>The name of the content type.</value>
            [XmlAttribute("contentTypeName")]
            public string ContentTypeName { get; set; }

            /// <summary>
            ///     Gets or sets the quantity.
            /// </summary>
            /// <value>The quantity.</value>
            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            /// <summary>
            ///     Gets or sets the waypoint.
            /// </summary>
            /// <value>The waypoint.</value>
            [XmlAttribute("waypoint1")]
            public long Waypoint { get; set; }

            /// <summary>
            ///     Gets or sets the waypoint2.
            /// </summary>
            /// <value>The waypoint2.</value>
            [XmlAttribute("waypoint2")]
            public long Waypoint2 { get; set; }

            /// <summary>
            ///     Gets or sets the waypoint3.
            /// </summary>
            /// <value>The waypoint3.</value>
            [XmlAttribute("waypoint3")]
            public long Waypoint3 { get; set; }

            /// <summary>
            ///     Gets or sets the waypoint4.
            /// </summary>
            /// <value>The waypoint4.</value>
            [XmlAttribute("waypoint4")]
            public long Waypoint4 { get; set; }

            /// <summary>
            ///     Gets or sets the waypoint5.
            /// </summary>
            /// <value>The waypoint5.</value>
            [XmlAttribute("waypoint5")]
            public long Waypoint5 { get; set; }
        }
    }
}