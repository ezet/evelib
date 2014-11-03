// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="Facilities.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    /// <summary>
    ///     Class Facilities.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class Facilities {
        /// <summary>
        ///     Gets or sets the facility entries.
        /// </summary>
        /// <value>The facility entries.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Facility> FacilityEntries { get; set; }

        /// <summary>
        ///     Class Facility.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Facility {
            /// <summary>
            ///     Gets or sets the facility identifier.
            /// </summary>
            /// <value>The facility identifier.</value>
            [XmlAttribute("facilityID")]
            public long FacilityId { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

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
            ///     Gets or sets the region identifier.
            /// </summary>
            /// <value>The region identifier.</value>
            [XmlAttribute("regionID")]
            public int RegionId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the region.
            /// </summary>
            /// <value>The name of the region.</value>
            [XmlAttribute("regionName")]
            public string RegionName { get; set; }

            /// <summary>
            ///     Gets or sets the startbase modifier.
            /// </summary>
            /// <value>The startbase modifier.</value>
            [XmlAttribute("starbaseModifier")]
            public float StartbaseModifier { get; set; }

            /// <summary>
            ///     Gets or sets the tax.
            /// </summary>
            /// <value>The tax.</value>
            [XmlAttribute("tax")]
            public float Tax { get; set; }
        }
    }
}