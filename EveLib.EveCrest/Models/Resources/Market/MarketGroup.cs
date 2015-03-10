// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="MarketGroup.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Class MarketGroup. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class MarketGroup : LinkedResource<MarketGroup> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketGroup" /> class.
        /// </summary>
        public MarketGroup() {
            ContentType = "application/vnd.ccp.eve.MarketGroup-v1+json";
        }

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
        public Href<MarketTypeCollection> Types { get; set; }

        /// <summary>
        /// Gets or sets the parent group.
        /// </summary>
        /// <value>The parent group.</value>
        [DataMember(Name = "parentGroup")]
        public Href<MarketGroup> ParentGroup { get; set; }
    }
}