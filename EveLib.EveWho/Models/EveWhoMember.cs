using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoMember {
        [DataMember(Name = "character_id")]
        public long CharacterId { get; set; }

        [DataMember(Name = "corporation_id")]
        public long CorporationId { get; set; }

        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}