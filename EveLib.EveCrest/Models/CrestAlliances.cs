using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestAlliances : CrestCollectionResponse {
        [DataMember(Name = "items")]
        public IList<CrestHref<CrestIconEntity>> Alliances { get; set; }
    }
}