using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    ///     Eve CREST Industry Facilities
    /// </summary>
    [DataContract]
    public sealed class CrestIndustryFacilityCollection : CrestCollectionResource<CrestIndustryFacilityCollection> {
        public CrestIndustryFacilityCollection() {
            // TODO Why are these entities not linked in CREST?
            Version = "application/vnd.ccp.eve.IndustryFacilityCollection-v1+json";
        }

        /// <summary>
        ///     A list of facilities
        /// </summary>
        [DataMember(Name = "items")]
        public List<Facility> Facilities { get; set; }

        /// <summary>
        ///     Represents an industry facility
        /// </summary>
        public class Facility {
            /// <summary>
            ///     The facility ID
            /// </summary>
            [DataMember(Name = "facilityID")]
            public int FacilityId { get; set; }

            /// <summary>
            ///     The facility name
            /// </summary>
            [DataMember(Name = "name")]
            public string Name { get; set; }

            /// <summary>
            ///     The solar system
            /// </summary>
            [DataMember(Name = "solarSystem")]
            public CrestLinkedEntity<dynamic> SolarSystem { get; set; }

            /// <summary>
            ///     The region
            /// </summary>
            [DataMember(Name = "region")]
            public CrestLinkedEntity<dynamic> Region { get; set; }

            /// <summary>
            ///     The facility tax
            /// </summary>
            [DataMember(Name = "tax")]
            public double Tax { get; set; }

            /// <summary>
            ///     The owner
            /// </summary>
            [DataMember(Name = "owner")]
            public CrestLinkedEntity<dynamic> Owner { get; set; }

            /// <summary>
            ///     The facility type
            /// </summary>
            [DataMember(Name = "type")]
            public CrestLinkedEntity<dynamic> Type { get; set; }
        }
    }
}