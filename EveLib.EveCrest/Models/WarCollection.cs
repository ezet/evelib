using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    
    [DataContract]
    public class WarCollection : EveCrestCollection {

        [DataMember(Name = "items")]
        public IList<WarCollectionEntry> Wars { get; set; }

        public class WarCollectionEntry {
            
            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "href")]
            public string Href { get; set; }
        }

    }
}
