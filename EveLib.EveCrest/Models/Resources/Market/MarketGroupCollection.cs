// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 02-20-2016
// ***********************************************************************
// <copyright file="MarketGroupCollection.cs" company="Lars Kristian Dahl">
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
    public sealed class MarketGroupCollection :
        CollectionResource<MarketGroupCollection, MarketGroup> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketGroupCollection" /> class.
        /// </summary>
        public MarketGroupCollection() {
            ContentType = "application/vnd.ccp.eve.MarketGroupCollection-v1+json";
        }

        ///// <summary>
        /////     Class MarketGroupItem.
        ///// </summary>
        //[DataContract]
        //public class MarketGroupItem : LinkedEntity<MarketGroup> {
        //    /// <summary>
        //    ///     Gets or sets the types.
        //    /// </summary>
        //    /// <value>The types.</value>
        //    [DataMember(Name = "types")]
        //    public Href<MarketTypeCollection> Types { get; set; }

        //    /// <summary>
        //    ///     Gets or sets the description.
        //    /// </summary>
        //    /// <value>The description.</value>
        //    [DataMember(Name = "description")]
        //    public string Description { get; set; }

        //    /// <summary>
        //    ///     Gets or sets the parent group.
        //    /// </summary>
        //    /// <value>The parent group.</value>
        //    [DataMember(Name = "parentGroup")]
        //    public Href<MarketGroup> ParentGroup { get; set; }
        //}
    }
}