// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 05-05-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="PlanetaryPins.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Character {
    /// <summary>
    ///     Class PlanetaryPins.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class PlanetaryPins {
        /// <summary>
        ///     Gets or sets the pins.
        /// </summary>
        /// <value>The pins.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<PlanetaryPin> Pins { get; set; }

        /// <summary>
        ///     Class PlanetaryPin.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class PlanetaryPin {
            /// <summary>
            ///     Gets or sets the pin identifier.
            /// </summary>
            /// <value>The pin identifier.</value>
            [XmlAttribute("pinID")]
            public long PinId { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the type.
            /// </summary>
            /// <value>The name of the type.</value>
            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            /// <summary>
            ///     Gets or sets the schematic identifier.
            /// </summary>
            /// <value>The schematic identifier.</value>
            [XmlAttribute("schematicID")]
            public int SchematicId { get; set; }

            /// <summary>
            ///     Sets the last launch time as string.
            /// </summary>
            /// <value>The last launch time as string.</value>
            [XmlAttribute("lastLaunchTime")]
            public string LastLaunchTimeAsString {
                set { LastLaunchTime = DateTime.Parse(value); }
            }

            /// <summary>
            ///     Gets or sets the last launch time.
            /// </summary>
            /// <value>The last launch time.</value>
            [XmlIgnore]
            public DateTime LastLaunchTime { get; set; }

            /// <summary>
            ///     Gets or sets the cycle time.
            /// </summary>
            /// <value>The cycle time.</value>
            [XmlAttribute("cycleTime")]
            public int CycleTime { get; set; }

            /// <summary>
            ///     Gets or sets the quantity per cycle.
            /// </summary>
            /// <value>The quantity per cycle.</value>
            [XmlAttribute("quantityperCycle")]
            public int QuantityPerCycle { get; set; }

            /// <summary>
            ///     Sets the install time as string.
            /// </summary>
            /// <value>The install time as string.</value>
            [XmlAttribute("installTime")]
            public string InstallTimeAsString {
                set { InstallTime = DateTime.Parse(value); }
            }

            /// <summary>
            ///     Gets or sets the install time.
            /// </summary>
            /// <value>The install time.</value>
            [XmlIgnore]
            public DateTime InstallTime { get; set; }

            /// <summary>
            ///     Sets the expiry time as string.
            /// </summary>
            /// <value>The expiry time as string.</value>
            [XmlAttribute("expiryTime")]
            public string ExpiryTimeAsString {
                set { ExpiryTime = DateTime.Parse(value); }
            }

            /// <summary>
            ///     Gets or sets the expiry time.
            /// </summary>
            /// <value>The expiry time.</value>
            [XmlIgnore]
            public DateTime ExpiryTime { get; set; }

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
            ///     Gets or sets the content quantity.
            /// </summary>
            /// <value>The content quantity.</value>
            [XmlAttribute("contentQuantity")]
            public int ContentQuantity { get; set; }

            /// <summary>
            ///     Gets or sets the longitude.
            /// </summary>
            /// <value>The longitude.</value>
            [XmlAttribute("longitude")]
            public double Longitude { get; set; }

            /// <summary>
            ///     Gets or sets the latitude.
            /// </summary>
            /// <value>The latitude.</value>
            [XmlAttribute("latitude")]
            public double Latitude { get; set; }
        }
    }
}