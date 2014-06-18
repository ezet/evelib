using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class AllianceCollection : EveCrestCollection {
        [DataMember(Name = "items")]
        public IList<EveCrestHref<EveCrestIconEntity>> Alliances { get; set; }
    }
}