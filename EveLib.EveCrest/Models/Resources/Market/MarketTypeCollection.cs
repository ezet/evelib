// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="MarketTypeCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Class MarketTypeCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class MarketTypeCollection : CollectionResource<MarketTypeCollection, MarketTypeCollection.Item> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketTypeCollection" /> class.
        /// </summary>
        public MarketTypeCollection() {
            ContentType = "application/vnd.ccp.eve.MarketTypeCollection-v1+json";
        }

        /// <summary>
        ///     Class Item.
        /// </summary>
        [DataContract]
        public class Item {
            /// <summary>
            ///     Gets or sets the market group.
            /// </summary>
            /// <value>The market group.</value>
            [DataMember(Name = "marketGroup")]
            public LinkedEntity<MarketGroup> MarketGroup { get; set; }

            /// <summary>
            ///     Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public TypeItem Type { get; set; }
        }

        /// <summary>
        ///     Class TypeItem.
        /// </summary>
        [DataContract]
        public class TypeItem : LinkedEntity<ItemType> {
            /// <summary>
            ///     Gets or sets the icon.
            /// </summary>
            /// <value>The icon.</value>
            [DataMember(Name = "icon")]
            public ImageLink Icon { get; set; }
        }
    }
}