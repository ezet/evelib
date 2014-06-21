using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestKillmails : CrestCollectionResponse {
        [DataMember(Name = "items")]
        public IList<CrestEntity> Killmails { get; set; }
    }
}