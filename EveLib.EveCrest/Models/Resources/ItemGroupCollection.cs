// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ItemGroupCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ItemGroupCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemGroupCollection : CollectionResource<ItemGroupCollection, LinkedEntity<ItemGroup>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemGroupCollection" /> class.
        /// </summary>
        public ItemGroupCollection() {
            ContentType = "application/vnd.ccp.eve.ItemGroupCollection-v1+json";
        }

    }
}