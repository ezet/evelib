using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoCorporation {
        [DataMember(Name = "corporation_id")]
        public long CorporationId { get; set; }

        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ticker")]
        public string Ticker { get; set; }

        [DataMember(Name = "member_count")]
        public int MemberCount { get; set; }

        [DataMember(Name = "is_npc_corp")]
        public string IsNpcCorporationString {
            set { IsNpcCorporation = value == "1"; }
        }

        public bool IsNpcCorporation { get; set; }

        [DataMember(Name = "avg_sec_status")]
        public double AvgSecurityStatus { get; set; }

        [DataMember(Name = "active")]
        public string IsActiveString {
            set { IsActive = value == "1"; }
        }

        public bool IsActive { get; set; }

        [DataMember(Name = "ceoID")]
        public long CeoId { get; set; }

        [DataMember(Name = "taxrate")]
        public double TaxRate { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}