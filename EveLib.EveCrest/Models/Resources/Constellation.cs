// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Constellation.cs" company="">
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
    ///     Class Constellation. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class Constellation : CrestResource<Constellation> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Constellation" /> class.
        /// </summary>
        public Constellation() {
            ContentType = "application/vnd.ccp.eve.Constellation-v1+json";
        }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        /// <summary>
        ///     Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        [DataMember(Name = "region")]
        public Href<Region> Region { get; set; }

        /// <summary>
        ///     Gets or sets the systems.
        /// </summary>
        /// <value>The systems.</value>
        [DataMember(Name = "systems")]
        public IReadOnlyCollection<Href<SolarSystem>> Systems { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}