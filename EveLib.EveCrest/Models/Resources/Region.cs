// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Region.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class Region. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class Region : CrestResource<Region> {
        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        public Region() {
            Version = "application/vnd.ccp.eve.Region-v1+json";
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the market buy orders.
        /// </summary>
        /// <value>The market buy orders.</value>
        [DataMember(Name = "marketBuyOrders")]
        public Href<MarketOrderCollection> MarketBuyOrders { get; set; }

        /// <summary>
        /// Gets or sets the market sell orders.
        /// </summary>
        /// <value>The market sell orders.</value>
        [DataMember(Name = "marketSellOrders")]
        public Href<MarketOrderCollection> MarketSellOrders { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the constellations.
        /// </summary>
        /// <value>The constellations.</value>
        [DataMember(Name = "constellations")]
        public IReadOnlyCollection<Href<Constellation>> Constellations { get; set; }
    }
}