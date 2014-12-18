// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ItemCategoryCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ItemCategoryCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemCategoryCollection : CollectionResource<ItemCategoryCollection, LinkedEntity<ItemCategory>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemCategoryCollection" /> class.
        /// </summary>
        public ItemCategoryCollection() {
            ContentType = "application/vnd.ccp.eve.ItemCategoryCollection-v1+json";
        }

    }
}