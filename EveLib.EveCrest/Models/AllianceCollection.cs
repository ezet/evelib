using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    [DataContract]
    public class AllianceCollection : EveCrestCollection {

        [DataMember(Name = "items")]
        public IList<EveCrestHref<AllianceCollectionEntry>> Alliances { get; set; }

        [DataContract]
        public class AllianceCollectionEntry : EveCrestNamedEntity {

            [DataMember(Name = "shortName")]
            public string ShortName { get; set; }
        }

    }
}
