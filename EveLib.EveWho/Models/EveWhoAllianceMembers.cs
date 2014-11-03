// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveWhoAllianceMembers.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Class EveWhoAllianceMembers.
    /// </summary>
    [DataContract]
    public class EveWhoAllianceMembers {
        /// <summary>
        /// Gets or sets the alliance identifier.
        /// </summary>
        /// <value>The alliance identifier.</value>
        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the member count.
        /// </summary>
        /// <value>The member count.</value>
        [DataMember(Name = "memberCount")]
        public int MemberCount { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        [DataMember(Name = "characters")]
        public IList<EveWhoMember> Members { get; set; }
    }
}