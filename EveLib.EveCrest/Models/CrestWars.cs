using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestWars : CrestCollectionResponse {
        [DataMember(Name = "items")]
        public IList<War> Wars { get; set; }

        public class War {
            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "href")]
            public string Href { get; set; }
        }
    }
}