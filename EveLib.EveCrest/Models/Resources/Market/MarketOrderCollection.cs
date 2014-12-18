// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-18-2014
// ***********************************************************************
// <copyright file="MarketOrderCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    /// Class MarketOrderCollection.
    /// </summary>
    [DataContract]
    public sealed class MarketOrderCollection : CollectionResource<MarketOrderCollection> {

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketOrderCollection" /> class.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public MarketOrderCollection() {
            ContentType = "application/vnd.ccp.eve.MarketOrderCollection-v1+json";
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<MarketOrder> Items { get; set; }

    }
}