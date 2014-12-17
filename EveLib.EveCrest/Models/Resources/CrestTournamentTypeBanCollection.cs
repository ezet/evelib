// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentTypeBanCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Shared;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Class CrestTournamentTypeBanCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentTypeBanCollection : CrestCollectionResource<CrestTournamentTypeBanCollection> {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentTypeBanCollection"/> class.
        /// </summary>
        public CrestTournamentTypeBanCollection() {
            Version = "application/vnd.ccp.eve.TournamentTypeBanCollection-v1+json";
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<BanEntry> Items { get; set; }
    }
}
