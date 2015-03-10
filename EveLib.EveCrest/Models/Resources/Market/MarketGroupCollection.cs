// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="MarketGroupCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Class MarketGroupCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class MarketGroupCollection : CollectionResource<MarketGroupCollection, MarketGroup> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketGroupCollection" /> class.
        /// </summary>
        public MarketGroupCollection() {
            ContentType = "application/vnd.ccp.eve.MarketGroupCollection-v1+json";
        }

    }
}