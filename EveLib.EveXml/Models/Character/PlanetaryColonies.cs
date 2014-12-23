// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 05-05-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="PlanetaryColonies.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class PlanetaryColonies.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryColonies {
        /// <summary>
        ///     Gets or sets the colonies.
        /// </summary>
        /// <value>The colonies.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<PlanetaryColony> Colonies { get; set; }

        /// <summary>
        ///     Class PlanetaryColony.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryColony {
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
            ///     Gets or sets the planet identifier.
            /// </summary>
            /// <value>The planet identifier.</value>
            [XmlAttribute("planetID")]
            public long PlanetId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the planet.
            /// </summary>
            /// <value>The name of the planet.</value>
            [XmlAttribute("planetName")]
            public string PlanetName { get; set; }

            /// <summary>
            ///     Gets or sets the planet type identifier.
            /// </summary>
            /// <value>The planet type identifier.</value>
            [XmlAttribute("planetTypeID")]
            public int PlanetTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the owner.
            /// </summary>
            /// <value>The name of the owner.</value>
            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            /// <summary>
            ///     Gets or sets the last update as string.
            /// </summary>
            /// <value>The last update as string.</value>
            [XmlAttribute("lastUpdate")]
            public string LastUpdateAsString { get; set; }

            /// <summary>
            ///     Gets or sets the upgrade level.
            /// </summary>
            /// <value>The upgrade level.</value>
            [XmlAttribute("upgradeLevel")]
            public int UpgradeLevel { get; set; }

            /// <summary>
            ///     Gets or sets the number of pins.
            /// </summary>
            /// <value>The number of pins.</value>
            [XmlAttribute("numberOfPins")]
            public int NumberOfPins { get; set; }
        }
    }
}