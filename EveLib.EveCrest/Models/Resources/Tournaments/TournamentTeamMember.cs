// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="TournamentTeamMember.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Tournaments {
    /// <summary>
    ///     Class TournamentTeamMember. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentTeamMember : CrestResource<TournamentTeamMember> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentTeamMember" /> class.
        /// </summary>
        public TournamentTeamMember() {
            ContentType = "application/vnd.ccp.eve.TournamentTeamMember-v1+json";
        }

        // TODO CCP why is the Href encased in Self ?
        /// <summary>
        ///     Gets or sets the self.
        /// </summary>
        /// <value>The self.</value>
        [DataMember(Name = "self")]
        public Href<TournamentTeamMember> Self { get; set; }

        /// <summary>
        ///     Gets or sets the alliance.
        /// </summary>
        /// <value>The alliance.</value>
        [DataMember(Name = "alliance")]
        public Href<Alliance> Alliance { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [DataMember(Name = "icon")]
        public ImageLinkCollection Icon { get; set; }
    }
}