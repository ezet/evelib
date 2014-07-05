using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a CREST /industry/specialities/ response
    /// </summary>
    [DataContract]
    public class CrestIndstrySpecialities : CrestCollectionResponse {

        /// <summary>
        /// A list of specializations
        /// </summary>
        public IList<CrestIndustrySpeciality> Specializations { get; set; }

    }
}
