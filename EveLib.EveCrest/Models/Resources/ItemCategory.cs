// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ItemCategory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ItemCategory. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemCategory : CrestResource<ItemCategory> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemCategory" /> class.
        /// </summary>
        public ItemCategory() {
            ContentType = "application/vnd.ccp.eve.ItemCategory-v1+json";
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        [DataMember(Name = "groups")]
        public IReadOnlyCollection<LinkedEntity<ItemGroup>> Groups { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ItemCategory" /> is published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
        [DataMember(Name = "published")]
        public bool Published { get; set; }
    }
}