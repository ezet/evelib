// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestTournamentTeamMember.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Class CrestTournamentTeamMember. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentTeamMember : CrestResource {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentTeamMember"/> class.
        /// </summary>
        public CrestTournamentTeamMember() {
            Version = "application/vnd.ccp.eve.TournamentTeamMember-v1+json";
        }

        // TODO CCP why is the Href encased in Self ?
        /// <summary>
        /// Gets or sets the self.
        /// </summary>
        /// <value>The self.</value>
        [DataMember(Name = "self")]
        public CrestHref<CrestTournamentTeamMember> Self { get; set; }

        /// <summary>
        /// Gets or sets the alliance.
        /// </summary>
        /// <value>The alliance.</value>
        [DataMember(Name = "alliance")]
        public CrestHref<CrestAlliance> Alliance { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [DataMember(Name = "icon")]
        public CrestImageLink Icon { get; set; }
    }
}
