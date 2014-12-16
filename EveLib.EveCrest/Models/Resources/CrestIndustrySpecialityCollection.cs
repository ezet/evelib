using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST /industry/specialities/ response
    /// </summary>
    [DataContract]
    public sealed class CrestIndustrySpecialityCollection : CrestCollectionResource<CrestIndustrySpecialityCollection> {
        public CrestIndustrySpecialityCollection() {
            Version = "application/vnd.ccp.eve.IndustrySpecialityCollection-v1+json";
        }

        /// <summary>
        ///     A list of specializations
        /// </summary>
        [DataMember(Name = "items")]
        public IReadOnlyList<CrestIndustrySpeciality> Specialities { get; set; }
    }
}