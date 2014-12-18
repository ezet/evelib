// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Alliance.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /allliances/$allianceId/ reponse
    /// </summary>
    [DataContract]
    public sealed class Alliance : CrestResource<Alliance> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Alliance" /> class.
        /// </summary>
        public Alliance() {
            Version = "application/vnd.ccp.eve.Alliance-v1+json";
        }

        /// <summary>
        ///     The alliance ID
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        ///     The alliance name
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }


        /// <summary>
        ///     The alliance ticker
        /// </summary>
        /// <value>The short name.</value>
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        /// <summary>
        ///     The alliance creation date
        /// </summary>
        /// <value>The start date.</value>
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }


        /// <summary>
        ///     The number of corporations in the alliance
        /// </summary>
        /// <value>The corporations count.</value>
        [DataMember(Name = "corporationsCount")]
        public int CorporationsCount { get; set; }

        /// <summary>
        ///     The alliance description
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     True if the alliance is deleted, otherwise false
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        ///     The alliance URL, if any
        /// </summary>
        /// <value>The URL.</value>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        ///     The alliance executor corporation
        /// </summary>
        /// <value>The executor corporation.</value>
        [DataMember(Name = "executorCorporation")]
        public LinkedEntity<NotImplemented> ExecutorCorporation { get; set; }

        /// <summary>
        ///     The alliance creator corporation
        /// </summary>
        /// <value>The creator corporation.</value>
        [DataMember(Name = "creatorCorporation")]
        public LinkedEntity<NotImplemented> CreatorCorporation { get; set; }

        /// <summary>
        ///     The alliance creator character
        /// </summary>
        /// <value>The creator character.</value>
        [DataMember(Name = "creatorCharacter")]
        public CharacterEntry CreatorCharacter { get; set; }

        /// <summary>
        ///     A list of all corporations in the alliance
        /// </summary>
        /// <value>The corporations.</value>
        [DataMember(Name = "corporations")]
        public IReadOnlyList<CorporationEntry> Corporations { get; set; }
    }
}