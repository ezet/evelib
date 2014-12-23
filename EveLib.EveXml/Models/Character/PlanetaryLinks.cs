// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 05-05-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="PlanetaryLinks.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class PlanetaryLinks.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryLinks {
        /// <summary>
        ///     Gets or sets the links.
        /// </summary>
        /// <value>The links.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<PlanetaryLink> Links { get; set; }

        /// <summary>
        ///     Class PlanetaryLink.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryLink {
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
            ///     Gets or sets the link level.
            /// </summary>
            /// <value>The link level.</value>
            [XmlAttribute("linkLevel")]
            public int LinkLevel { get; set; }
        }
    }
}