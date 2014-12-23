// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ItemTypeCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ItemTypeCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemTypeCollection : CollectionResource<ItemTypeCollection, LinkedEntity<ItemType>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemTypeCollection" /> class.
        /// </summary>
        public ItemTypeCollection() {
            ContentType = "application/vnd.ccp.eve.ItemTypeCollection-v1+json";
        }
    }
}