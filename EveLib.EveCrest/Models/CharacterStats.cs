using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    /// Class CharacterStats.
    /// </summary>
    public sealed class CharacterStats : CrestResource<CharacterStats> {

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterStats" /> class.
        /// </summary>
        public CharacterStats() {
            ContentType = "default";
        }

        /// <summary>
        /// Gets or sets the character identifier.
        /// </summary>
        /// <value>The character identifier.</value>
        [DataMember(Name = "characterID")]
        public long CharacterId { get; set; }

        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        /// <value>The name of the character.</value>
        [DataMember(Name = "characterName")]
        public string CharacterName { get; set; }

        /// <summary>
        /// Gets or sets the aggregate years.
        /// </summary>
        /// <value>The aggregate years.</value>
        [DataMember(Name = "aggregateYears")]
        public Dictionary<int, ExpandoObject> AggregateYears { get; set; }

    }
}