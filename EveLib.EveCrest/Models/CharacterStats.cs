using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models {
    public sealed class CharacterStats : CrestResource<CharacterStats> {

        public CharacterStats() {
            ContentType = "test";
        }

        [DataMember(Name = "characterID")]
        public long CharacterId { get; set; }

        [DataMember(Name = "characterName")]
        public string CharacterName { get; set; }

        [DataMember(Name = "aggregateYears")]
        public Dictionary<int, dynamic> AggregateYears {get ; set; }
         
    }
}