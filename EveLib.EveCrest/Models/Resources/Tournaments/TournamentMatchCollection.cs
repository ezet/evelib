// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="TournamentMatchCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Tournaments {
    /// <summary>
    ///     Class TournamentMatchCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentMatchCollection : CollectionResource<TournamentMatchCollection, TournamentMatch> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentMatchCollection" /> class.
        /// </summary>
        public TournamentMatchCollection() {
            ContentType = "application/vnd.ccp.eve.TournamentMatchCollection-v1+json";
        }
    }
}