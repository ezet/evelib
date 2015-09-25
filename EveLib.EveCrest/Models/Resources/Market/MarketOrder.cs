// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-18-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-18-2014
// ***********************************************************************
// <copyright file="MarketOrder.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Class MarketOrder.
    /// </summary>
    [DataContract]
    public class MarketOrder : LinkedEntity<NotImplemented> {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="MarketOrder" /> is buy.
        /// </summary>
        /// <value><c>true</c> if buy; otherwise, <c>false</c>.</value>
        [DataMember(Name = "buy")]
        public bool Buy { get; set; }

        /// <summary>
        ///     Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        /// <summary>
        ///     Gets or sets the issued.
        /// </summary>
        /// <value>The issued.</value>
        [DataMember(Name = "issued")]
        public DateTime Issued { get; set; }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [DataMember(Name = "location")]
        public LinkedEntity<NotImplemented> Location { get; set; }

        /// <summary>
        ///     Gets or sets the minimum volume.
        /// </summary>
        /// <value>The minimum volume.</value>
        [DataMember(Name = "minVolume")]
        public int MinVolume { get; set; }

        /// <summary>
        /// Gets or sets the volume entered.
        /// </summary>
        /// <value>The volume entered.</value>
        [DataMember(Name = "volumeEntered")]
        public int VolumeEntered { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [DataMember(Name = "price")]
        public double Price { get; set; }

        /// <summary>
        ///     Gets or sets the range.
        /// </summary>
        /// <value>The range.</value>
        [DataMember(Name = "range")]
        public string Range { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Name = "type")]
        public LinkedEntity<ItemType> Type { get; set; }

        /// <summary>
        ///     Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        [DataMember(Name = "volume")]
        public int Volume { get; set; }

        /// Gets or sets the order identifier.
        /// 
        /// The identifier.
        [DataMember(Name = "id")]
        public new long Id { get; set; }

    }
}