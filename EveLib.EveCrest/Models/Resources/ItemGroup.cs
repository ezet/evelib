// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="ItemGroup.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class ItemGroup. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ItemGroup : CrestResource<ItemGroup> {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemGroup"/> class.
        /// </summary>
        public ItemGroup() {
            Version = "application/vnd.ccp.eve.ItemCategory-v1+json";
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [DataMember(Name = "category")]
        public Href<ItemCategory> Category { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        /// <value>The types.</value>
        [DataMember(Name = "types")]
        public IReadOnlyCollection<LinkedEntity<ItemType>> Types { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ItemGroup"/> is published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
        [DataMember(Name = "published")]
        public bool Published { get; set; }
    }
}