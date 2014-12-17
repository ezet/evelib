// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="TournamentTeamMemberCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Tournaments {
    /// <summary>
    ///     Class TournamentTeamMemberCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentTeamMemberCollection :
        CollectionResource<TournamentTeamMemberCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentTeamMemberCollection" /> class.
        /// </summary>
        public TournamentTeamMemberCollection() {
            Version = "application/vnd.ccp.eve.TournamentTeamMemberCollection-v1+json";
        }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<TournamentTeamMember> Items { get; set; }
    }
}