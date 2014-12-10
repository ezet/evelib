using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a team worker
    /// </summary>
    public class CrestIndustryTeamWorker {
        /// <summary>
        ///     Represents the worker bonus types
        /// </summary>
        public enum BonusType {
            /// <summary>
            ///     Material Efficency Bonus
            /// </summary>
            [EnumMember(Value = "ME")]
            Me,

            /// <summary>
            ///     Production Efficiency Bonus
            /// </summary>
            [EnumMember(Value = "TE")]
            Te
        }

        /// <summary>
        ///     The worker bonus
        /// </summary>
        [DataMember(Name = "bonus")]
        public WorkerBonus Bonus { get; set; }

        /// <summary>
        ///     The worker specialization
        /// </summary>
        [DataMember(Name = "specialization")]
        public CrestLinkedEntity Specialization { get; set; }


        /// <summary>
        ///     Represents a worker bonus
        /// </summary>
        public class WorkerBonus {
            /// <summary>
            ///     The bonus ID
            /// </summary>
            [DataMember(Name = "id")]
            public int Id { get; set; }

            /// <summary>
            ///     The bonus value
            /// </summary>
            [DataMember(Name = "value")]
            public float Value { get; set; }

            /// <summary>
            ///     The bonus type
            /// </summary>
            [JsonProperty("bonusType")]
            [JsonConverter(typeof(StringEnumConverter))]
            public BonusType Type { get; set; }
        }
    }
}