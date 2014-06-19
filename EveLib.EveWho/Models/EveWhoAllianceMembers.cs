using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoAllianceMembers {
        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "memberCount")]
        public int MemberCount { get; set; }

        [DataMember(Name = "characters")]
        public IList<EveWhoMember> Members { get; set; }
    }
}