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

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Tournaments {
    /// <summary>
    ///     Class TournamentTeamMemberCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentTeamMemberCollection :
        CollectionResource<TournamentTeamMemberCollection, TournamentTeamMember> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentTeamMemberCollection" /> class.
        /// </summary>
        public TournamentTeamMemberCollection() {
            ContentType = "application/vnd.ccp.eve.TournamentTeamMemberCollection-v1+json";
        }
    }
}