using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    /// Eve CREST Industry Facilities
    /// </summary>
    [DataContract]
    public class CrestIndustryFacilities : CrestCollectionResponse {

        /// <summary>
        /// A list of facilities
        /// </summary>
        [DataMember(Name = "items")]
        public List<Facility> Facilities { get; set; }

        /// <summary>
        /// Represents an industry facility
        /// </summary>
        public class Facility {

            /// <summary>
            /// The facility ID
            /// </summary>
            [DataMember(Name = "facilityID")]
            public int FacilityId { get; set; }

            /// <summary>
            /// The facility name
            /// </summary>
            [DataMember(Name = "name")]
            public string Name { get; set; }

            /// <summary>
            /// The solar system
            /// </summary>
            [DataMember(Name = "solarSystem")]
            public CrestEntity SolarSystem { get; set; }

            /// <summary>
            /// The region 
            /// </summary>
            [DataMember(Name = "region")]
            public CrestEntity Region { get; set; }

            /// <summary>
            /// The facility tax
            /// </summary>
            [DataMember(Name = "tax")]
            public double Tax { get; set; }

            /// <summary>
            /// The owner
            /// </summary>
            [DataMember(Name = "owner")]
            public CrestEntity Owner { get; set; }

            /// <summary>
            /// The facility type
            /// </summary>
            [DataMember(Name = "type")]
            public CrestEntity Type { get; set; }



        }

    }
}
