// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="KillmailCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /killmails/ response
    /// </summary>
    [DataContract]
    public sealed class KillmailCollection : CollectionResource<KillmailCollection, LinkedEntity<Killmail>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="KillmailCollection" /> class.
        /// </summary>
        public KillmailCollection() {
            ContentType = "application/vnd.ccp.eve.WarKillmails-v1+json";
        }
    }
}