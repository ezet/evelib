// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="IndustrySpeciality.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Represents a speciality
    /// </summary>
    [DataContract]
    public sealed class IndustrySpeciality : CrestResource<IndustrySpeciality> {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndustrySpeciality"/> class.
        /// </summary>
        public IndustrySpeciality() {
            Version = "application/vnd.ccp.eve.IndustrySpeciality-v1+json";
        }

        /// <summary>
        /// The speciality ID
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The speciality name
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A list of the spezialization groups
        /// </summary>
        /// <value>The groups.</value>
        [DataMember(Name = "groups")]
        public IList<Group> Groups { get; set; }
    }

    /// <summary>
    /// Represents a speciality group
    /// </summary>
    [DataContract]
    public class Group {
        /// <summary>
        /// The group ID
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}