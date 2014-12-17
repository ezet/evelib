using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    ///     Represents a CREST killmail
    /// </summary>
    [DataContract]
    public sealed class CrestKillmail : CrestResource {
        public CrestKillmail() {
            Version = "application/vnd.ccp.eve.Killmail-v1+json";
        }

        /// <summary>
        ///     The solar system
        /// </summary>
        [DataMember(Name = "solarSystem")]
        public CrestLinkedEntity<CrestSolarSystem> SolarSystem { get; set; }

        /// <summary>
        ///     The kill ID
        /// </summary>
        [DataMember(Name = "killID")]
        public long KillId { get; set; }

        /// <summary>
        ///     The time of the event
        /// </summary>
        [DataMember(Name = "killTime")]
        public DateTime KillTime { get; set; }

        /// <summary>
        ///     A list of attackers
        /// </summary>
        [DataMember(Name = "attackers")]
        public IList<KillmailAttacker> Attackers { get; set; }

        /// <summary>
        ///     The number of attackers
        /// </summary>
        [DataMember(Name = "attackerCount")]
        public int AttackerCount { get; set; }

        /// <summary>
        ///     The victim
        /// </summary>
        [DataMember(Name = "victim")]
        public KillmailVictim Victim { get; set; }

        /// <summary>
        ///     The war this kill is related to
        /// </summary>
        [DataMember(Name = "war")]
        public CrestLinkedEntity<CrestWar> War { get; set; }

        /// <summary>
        ///     Represents a killmail item
        /// </summary>
        [DataContract]
        public class Item : CrestLinkedIconEntity<CrestItemType> {
            /// <summary>
            ///     True if this item was a singleton
            /// </summary>
            [DataMember(Name = "singleton")]
            public bool Singleton { get; set; }

            /// <summary>
            ///     The item flag
            /// </summary>
            [DataMember(Name = "flag")]
            public int Flag { get; set; }

            /// <summary>
            ///     The quantity that was destroyed
            /// </summary>
            [DataMember(Name = "quantityDestroyed")]
            public int QuantityDestroyed { get; set; }
        }

        /// <summary>
        ///     Represents a killmail attacker
        /// </summary>
        [DataContract]
        public class KillmailAttacker : KillmailEntity {
            /// <summary>
            ///     The amount of damage done by this entity
            /// </summary>
            [DataMember(Name = "damageDone")]
            public int DamageDone { get; set; }

            /// <summary>
            ///     The weapon type used
            /// </summary>
            [DataMember(Name = "weaponType")]
            public CrestLinkedIconEntity<CrestItemType> WeaponType { get; set; }

            /// <summary>
            ///     True if this entity had the final  blow
            /// </summary>
            [DataMember(Name = "finalBlow")]
            public bool FinalBlow { get; set; }

            /// <summary>
            ///     The security status
            /// </summary>
            [DataMember(Name = "securityStatus")]
            public double SecurityStatus { get; set; }
        }

        /// <summary>
        ///     Base class for killmail entities
        /// </summary>
        [DataContract]
        public abstract class KillmailEntity {
            /// <summary>
            ///     The character
            /// </summary>
            [DataMember(Name = "character")]
            public CrestLinkedIconEntity<CrestNotImplemented> Character { get; set; }

            /// <summary>
            ///     The corporation
            /// </summary>
            [DataMember(Name = "corporation")]
            public CrestLinkedIconEntity<CrestNotImplemented> Corporation { get; set; }

            /// <summary>
            ///     The alliance
            /// </summary>
            [DataMember(Name = "alliance")]
            public CrestLinkedIconEntity<CrestAlliance> Alliance { get; set; }

            /// <summary>
            ///     The ship type
            /// </summary>
            [DataMember(Name = "shipType")]
            public CrestLinkedIconEntity<CrestItemType> ShipType { get; set; }
        }

        /// <summary>
        ///     Represents a killmail victim
        /// </summary>
        [DataContract]
        public class KillmailVictim : KillmailEntity {
            /// <summary>
            ///     The amount of damage taken
            /// </summary>
            [DataMember(Name = "damageTaken")]
            public int DamageTaken { get; set; }

            /// <summary>
            ///     A list of items the victim held
            /// </summary>
            [DataMember(Name = "items")]
            public IList<Item> Items { get; set; }
        }
    }
}