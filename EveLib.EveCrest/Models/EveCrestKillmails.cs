using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveCrestKillmails : EveCrestCollectionResponse {
        [DataMember(Name = "items")]
        public IList<EveCrestEntity> Killmails { get; set; }
    }
}