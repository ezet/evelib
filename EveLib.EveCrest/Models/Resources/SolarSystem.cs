// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="SolarSystem.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class SolarSystem. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class SolarSystem : CrestResource<SolarSystem> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SolarSystem" /> class.
        /// </summary>
        public SolarSystem() {
            ContentType = "application/vnd.ccp.eve.System-v1+json";
        }

        /// <summary>
        ///     Gets or sets the stats.
        /// </summary>
        /// <value>The stats.</value>
        [DataMember(Name = "stats")]
        public Href<NotImplemented> Stats { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the security status.
        /// </summary>
        /// <value>The security status.</value>
        [DataMember(Name = "securityStatus")]
        public double SecurityStatus { get; set; }

        /// <summary>
        ///     Gets or sets the security class.
        /// </summary>
        /// <value>The security class.</value>
        [DataMember(Name = "securityClass")]
        public string SecurityClass { get; set; }

        /// <summary>
        ///     Gets or sets the href.
        /// </summary>
        /// <value>The href.</value>
        [DataMember(Name = "href")]
        public Href<SolarSystem> Href { get; set; }

        /// <summary>
        ///     Gets or sets the planets.
        /// </summary>
        /// <value>The planets.</value>
        [DataMember(Name = "planets")]
        public IReadOnlyCollection<Href<Planet>> Planets { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        /// <summary>
        ///     Gets or sets the constellation.
        /// </summary>
        /// <value>The constellation.</value>
        [DataMember(Name = "constellation")]
        public Href<Constellation> Constellation { get; set; }
    }
}