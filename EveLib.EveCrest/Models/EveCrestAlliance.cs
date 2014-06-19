using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveCrestAlliance {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "corporationsCount")]
        public int CorporationsCount { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "executorCorporation")]
        public EveCrestEntity ExecutorCorporation { get; set; }

        [DataMember(Name = "creatorCorporation")]
        public EveCrestEntity CreatorCorporation { get; set; }

        [DataMember(Name = "creatorCharacter")]
        public EveCrestEntity CreatorCharacter { get; set; }

        [DataMember(Name = "corporations")]
        public IList<EveCrestEntity> Corporations { get; set; }
    }
}