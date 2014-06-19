using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoAlliance {
        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        [DataMember(Name = "faction_id")]
        public long FactionId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ticker")]
        public string Ticker { get; set; }

        [DataMember(Name = "member_count")]
        public int MemberCount { get; set; }

        [DataMember(Name = "avg_sec_status")]
        public double AvgSecurityStatus { get; set; }

        [DataMember(Name = "executor_corp")]
        public long ExecutorCorporation { get; set; }
    }
}