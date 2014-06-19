using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class EveWhoCharacter {
        [DataMember(Name = "character_id")]
        public long CharacterId { get; set; }

        [DataMember(Name = "corporation_id")]
        public long CorporationId { get; set; }

        [DataMember(Name = "alliance_id")]
        public long AllianceId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "sec_status")]
        public double SecurityStatus { get; set; }

        [DataMember(Name = "history")]
        public IList<EveWhoHistoryEntry> History { get; set; }

        [DataContract]
        public class EveWhoHistoryEntry {
            [DataMember(Name = "corporation_id")]
            public long CorporationId { get; set; }

            [DataMember(Name = "start_date")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "end_date")]
            public DateTime EndDate { get; set; }
        }
    }
}