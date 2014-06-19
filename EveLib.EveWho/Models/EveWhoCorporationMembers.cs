using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoCorporationMembers {
        [DataMember(Name = "corporation_id")]
        public long CorporationId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "memberCount")]
        public int MemberCount { get; set; }

        [DataMember(Name = "characters")]
        public IList<EveWhoMember> Members { get; set; }
    }
}