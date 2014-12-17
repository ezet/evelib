// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentMatchCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models.Resources {

    /// <summary>
    /// Class CrestTournamentMatchCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentMatchCollection : CrestCollectionResource<CrestTournamentMatchCollection> {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentMatchCollection"/> class.
        /// </summary>
        public CrestTournamentMatchCollection() {
            Version = "application/vnd.ccp.eve.TournamentMatchCollection-v1+json";
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<CrestTournamentMatch> Items { get; set; }

    }
}
