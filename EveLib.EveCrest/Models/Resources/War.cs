using System;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST war
    /// </summary>
    [DataContract]
    public sealed class War : CrestResource<War> {
        public War() {
            Version = "application/vnd.ccp.eve.War-v1+json";
        }

        /// <summary>
        ///     The war ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     The time the war was declared
        /// </summary>
        [DataMember(Name = "timeDeclared")]
        public DateTime TimeDeclared { get; set; }

        /// <summary>
        ///     The time the war started
        /// </summary>
        [DataMember(Name = "timeStarted")]
        public DateTime TimeStarted { get; set; }

        /// <summary>
        ///     The time the war finished
        /// </summary>
        [DataMember(Name = "timeFinished")]
        public DateTime TimeFinished { get; set; }

        /// <summary>
        ///     True if the war is open for allies
        /// </summary>
        [DataMember(Name = "openForAllies")]
        public bool OpenForAllies { get; set; }


        /// <summary>
        ///     The number of allied entities
        /// </summary>
        [DataMember(Name = "allyCount")]
        public int AllyCount { get; set; }

        /// <summary>
        ///     True if the war is mutual
        /// </summary>
        [DataMember(Name = "mutual")]
        public bool Mutual { get; set; }

        /// <summary>
        ///     The defending entity
        /// </summary>
        [DataMember(Name = "defender")]
        public WarEntity Defender { get; set; }

        /// <summary>
        ///     The aggressing entity
        /// </summary>
        [DataMember(Name = "aggressor")]
        public WarEntity Aggressor { get; set; }

        /// <summary>
        ///     Represents an entity in a war
        /// </summary>
        public class WarEntity : LinkedIconEntity<NotImplemented> {
            /// <summary>
            ///     The number of ships killed
            /// </summary>
            [DataMember(Name = "shipsKilled")]
            public int ShipsKilled { get; set; }

            /// <summary>
            ///     The amount of isk killed
            /// </summary>
            [DataMember(Name = "iskKilled")]
            public double IskKilled { get; set; }
        }
    }
}