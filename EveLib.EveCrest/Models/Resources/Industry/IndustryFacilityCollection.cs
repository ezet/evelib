// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="IndustryFacilityCollection.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Industry {
    /// <summary>
    ///     Eve CREST Industry Facilities
    /// </summary>
    [DataContract]
    public sealed class IndustryFacilityCollection : CollectionResource<IndustryFacilityCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndustryFacilityCollection" /> class.
        /// </summary>
        public IndustryFacilityCollection() {
            Version = "application/vnd.ccp.eve.IndustryFacilityCollection-v1+json";
        }

        /// <summary>
        ///     A list of facilities
        /// </summary>
        /// <value>The facilities.</value>
        [DataMember(Name = "items")]
        public List<FacilityEntry> Facilities { get; set; }

        /// <summary>
        ///     Represents an industry facility
        /// </summary>
        public class FacilityEntry {
            /// <summary>
            ///     The facility ID
            /// </summary>
            /// <value>The facility identifier.</value>
            [DataMember(Name = "facilityID")]
            public int FacilityId { get; set; }

            /// <summary>
            ///     The facility name
            /// </summary>
            /// <value>The name.</value>
            [DataMember(Name = "name")]
            public string Name { get; set; }

            /// <summary>
            ///     The solar system
            /// </summary>
            /// <value>The solar system.</value>
            [DataMember(Name = "solarSystem")]
            public LinkedEntity<dynamic> SolarSystem { get; set; }

            /// <summary>
            ///     The region
            /// </summary>
            /// <value>The region.</value>
            [DataMember(Name = "region")]
            public LinkedEntity<dynamic> Region { get; set; }

            /// <summary>
            ///     The facility tax
            /// </summary>
            /// <value>The tax.</value>
            [DataMember(Name = "tax")]
            public double Tax { get; set; }

            /// <summary>
            ///     The owner
            /// </summary>
            /// <value>The owner.</value>
            [DataMember(Name = "owner")]
            public LinkedEntity<dynamic> Owner { get; set; }

            /// <summary>
            ///     The facility type
            /// </summary>
            /// <value>The type.</value>
            [DataMember(Name = "type")]
            public LinkedEntity<dynamic> Type { get; set; }
        }
    }
}