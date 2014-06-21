using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a CREST /incursions/ response
    /// </summary>
    [DataContract]
    public class CrestIncursions : CrestCollectionResponse {
        /// <summary>
        /// Represens the incursion states
        /// </summary>
        public enum IncursionState {
            /// <summary>
            /// Established incursion
            /// </summary>
            [DataMember(Name = "Established")] Established,
            /// <summary>
            /// Mobilizing incursion
            /// </summary>
            [DataMember(Name = "Mobilizing")] Mobilizing,
            /// <summary>
            /// Withdrawing incursion
            /// </summary>
            [DataMember(Name = "Withdrawing")] Withdrawing,
        }

        /// <summary>
        /// A list of incursions
        /// </summary>
        [DataMember(Name = "items")]
        public IList<Incursion> Incursions { get; set; }

        /// <summary>
        /// Represents an incursion
        /// </summary>
        public class Incursion {
            /// <summary>
            /// The incursion influence
            /// </summary>
            [DataMember(Name = "influence")]
            public double Influence { get; set; }

            /// <summary>
            /// True if the incursion has a boss
            /// </summary>
            [DataMember(Name = "hasBoss")]
            public bool HasBoss { get; set; }

            /// <summary>
            /// The incursion state
            /// </summary>
            [DataMember(Name = "state")]
            public IncursionState State { get; set; }

            /// <summary>
            /// The incursion's staging system
            /// </summary>
            [DataMember(Name = "stagingSolarSystem")]
            public CrestNamedEntity StatingSolarSystem { get; set; }

            /// <summary>
            /// The constellation
            /// </summary>
            [DataMember(Name = "constellation")]
            public CrestNamedEntity Constellation { get; set; }
        }
    }
}