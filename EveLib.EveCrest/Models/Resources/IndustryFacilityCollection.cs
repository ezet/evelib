using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Eve CREST Industry Facilities
    /// </summary>
    [DataContract]
    public sealed class IndustryFacilityCollection : CollectionResource<IndustryFacilityCollection> {
        public IndustryFacilityCollection() {
            Version = "application/vnd.ccp.eve.IndustryFacilityCollection-v1+json";
        }

        /// <summary>
        ///     A list of facilities
        /// </summary>
        [DataMember(Name = "items")]
        public List<FacilityEntry> Facilities { get; set; }

        /// <summary>
        ///     Represents an industry facility
        /// </summary>
        public class FacilityEntry {
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
            public LinkedEntity<dynamic> SolarSystem { get; set; }

            /// <summary>
            ///     The region
            /// </summary>
            [DataMember(Name = "region")]
            public LinkedEntity<dynamic> Region { get; set; }

            /// <summary>
            ///     The facility tax
            /// </summary>
            [DataMember(Name = "tax")]
            public double Tax { get; set; }

            /// <summary>
            ///     The owner
            /// </summary>
            [DataMember(Name = "owner")]
            public LinkedEntity<dynamic> Owner { get; set; }

            /// <summary>
            ///     The facility type
            /// </summary>
            [DataMember(Name = "type")]
            public LinkedEntity<dynamic> Type { get; set; }
        }
    }
}