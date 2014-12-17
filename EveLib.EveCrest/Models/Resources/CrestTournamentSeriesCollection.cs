// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentSeriesCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Class CrestTournamentSeriesCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentSeriesCollection : CrestCollectionResource<CrestTournamentSeriesCollection> {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentSeriesCollection"/> class.
        /// </summary>
        public CrestTournamentSeriesCollection() {
            Version = "application/vnd.ccp.eve.TournamentSeriesCollection-v1+json";
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyCollection<CrestTournamentSeries> Items { get; set; }
  
    }
}
