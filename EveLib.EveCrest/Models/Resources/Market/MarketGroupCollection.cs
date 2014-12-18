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

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Class MarketGroupCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class MarketGroupCollection : CollectionResource<MarketGroupCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketGroupCollection" /> class.
        /// </summary>
        public MarketGroupCollection() {
            ContentType = "application/vnd.ccp.eve.MarketGroupCollection-v1+json";
        }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyCollection<MarketGroup> Items { get; set; }

        /// <summary>
        ///     Class MarketGroup.
        /// </summary>
        public class MarketGroup : LinkedEntity<MarketGroup> {
            /// <summary>
            ///     Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            [DataMember(Name = "description")]
            public string Description { get; set; }

            /// <summary>
            ///     Gets or sets the types.
            /// </summary>
            /// <value>The types.</value>
            [DataMember(Name = "types")]
            public LinkedEntity<MarketTypeCollection> Types { get; set; }
        }
    }
}