using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST /industry/specialities/ response
    /// </summary>
    [DataContract]
    public class CrestIndustrySpecialities : CrestCollectionResponse {
        /// <summary>
        ///     A list of specializations
        /// </summary>
        [DataMember(Name = "items")]
        public IList<CrestIndustrySpeciality> Specialities { get; set; }
    }
}