// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="TournamentSeriesCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class TournamentSeriesCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentSeriesCollection : CollectionResource<TournamentSeriesCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentSeriesCollection" /> class.
        /// </summary>
        public TournamentSeriesCollection() {
            Version = "application/vnd.ccp.eve.TournamentSeriesCollection-v1+json";
        }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyCollection<TournamentSeries> Items { get; set; }
    }
}