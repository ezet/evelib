// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Planet.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class Planet. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class Planet : CrestResource<Planet> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Planet" /> class.
        /// </summary>
        public Planet() {
            Version = "application/vnd.ccp.eve.Planet-v1+json";
        }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Name = "type")]
        public Href<ItemType> Type { get; set; }

        /// <summary>
        ///     Gets or sets the system.
        /// </summary>
        /// <value>The system.</value>
        [DataMember(Name = "system")]
        public LinkedEntity<SolarSystem> System { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}