// ***********************************************************************
// Assembly         : EveLib.StaticData
// Author           : Lars Kristian
// Created          : 05-10-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="InvType.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.StaticDataModule.Models {
    /// <summary>
    ///     Class InvType.
    /// </summary>
    [DataContract]
    public class InvType {
        /// <summary>
        ///     Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        public long TypeId { get; set; }

        /// <summary>
        ///     Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        public long GroupId { get; set; }

        /// <summary>
        ///     Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        [DataMember(Name = "group")]
        public string Group { get; set; }

        /// <summary>
        ///     Gets or sets the market group identifier.
        /// </summary>
        /// <value>The market group identifier.</value>
        public long MarketGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the market group.
        /// </summary>
        /// <value>The market group.</value>
        [DataMember(Name = "market_group")]
        public string MarketGroup { get; set; }

        /// <summary>
        ///     Gets or sets the mass.
        /// </summary>
        /// <value>The mass.</value>
        [DataMember(Name = "mass")]
        public double Mass { get; set; }

        /// <summary>
        ///     Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        /// <summary>
        ///     Gets or sets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        [DataMember(Name = "capacity")]
        public double Capacity { get; set; }

        /// <summary>
        ///     Gets or sets the size of the portion.
        /// </summary>
        /// <value>The size of the portion.</value>
        [DataMember(Name = "portion_size")]
        public int PortionSize { get; set; }

        /// <summary>
        ///     Gets or sets the race.
        /// </summary>
        /// <value>The race.</value>
        [DataMember(Name = "race")]
        public string Race { get; set; }

        /// <summary>
        ///     Gets or sets the base price.
        /// </summary>
        /// <value>The base price.</value>
        [DataMember(Name = "base_price")]
        public double BasePrice { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value><c>true</c> if this instance is published; otherwise, <c>false</c>.</value>
        [DataMember(Name = "is_published")]
        public bool IsPublished { get; set; }

        /// <summary>
        ///     Gets or sets the chance of duplicating.
        /// </summary>
        /// <value>The chance of duplicating.</value>
        [DataMember(Name = "chance_of_duplicating")]
        public double ChanceOfDuplicating { get; set; }
    }
}