using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /industry/specialities/ response
    /// </summary>
    [DataContract]
    public sealed class IndustrySpecialityCollection : CollectionResource<IndustrySpecialityCollection> {
        public IndustrySpecialityCollection() {
            Version = "application/vnd.ccp.eve.IndustrySpecialityCollection-v1+json";
        }

        /// <summary>
        ///     A list of specializations
        /// </summary>
        [DataMember(Name = "items")]
        public IReadOnlyList<IndustrySpeciality> Specialities { get; set; }
    }
}