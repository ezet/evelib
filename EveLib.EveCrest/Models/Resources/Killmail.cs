// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="Killmail.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST killmail
    /// </summary>
    [DataContract]
    public sealed class Killmail : CrestResource<Killmail> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Killmail" /> class.
        /// </summary>
        public Killmail() {
            ContentType = "application/vnd.ccp.eve.Killmail-v1+json";
        }

        /// <summary>
        ///     The solar system
        /// </summary>
        /// <value>The solar system.</value>
        [DataMember(Name = "solarSystem")]
        public LinkedEntity<SolarSystem> SolarSystem { get; set; }

        /// <summary>
        ///     The kill ID
        /// </summary>
        /// <value>The kill identifier.</value>
        [DataMember(Name = "killID")]
        public long KillId { get; set; }

        /// <summary>
        ///     The time of the event
        /// </summary>
        /// <value>The kill time.</value>
        [DataMember(Name = "killTime")]
        public DateTime KillTime { get; set; }

        /// <summary>
        ///     A list of attackers
        /// </summary>
        /// <value>The attackers.</value>
        [DataMember(Name = "attackers")]
        public IReadOnlyList<KillmailAttacker> Attackers { get; set; }

        /// <summary>
        ///     The number of attackers
        /// </summary>
        /// <value>The attacker count.</value>
        [DataMember(Name = "attackerCount")]
        public int AttackerCount { get; set; }

        /// <summary>
        ///     The victim
        /// </summary>
        /// <value>The victim.</value>
        [DataMember(Name = "victim")]
        public KillmailVictim Victim { get; set; }

        /// <summary>
        ///     The war this kill is related to
        /// </summary>
        /// <value>The war.</value>
        [DataMember(Name = "war")]
        public LinkedEntity<War> War { get; set; }

        /// <summary>
        ///     Represents a killmail item
        /// </summary>
        [DataContract]
        public class Item : LinkedIconEntity<ItemType> {
            /// <summary>
            ///     True if this item was a singleton
            /// </summary>
            /// <value><c>true</c> if singleton; otherwise, <c>false</c>.</value>
            [DataMember(Name = "singleton")]
            public bool Singleton { get; set; }

            /// <summary>
            ///     The item flag
            /// </summary>
            /// <value>The flag.</value>
            [DataMember(Name = "flag")]
            public int Flag { get; set; }

            /// <summary>
            ///     The quantity that was destroyed
            /// </summary>
            /// <value>The quantity destroyed.</value>
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
            /// <value>The damage done.</value>
            [DataMember(Name = "damageDone")]
            public int DamageDone { get; set; }

            /// <summary>
            ///     The weapon type used
            /// </summary>
            /// <value>The type of the weapon.</value>
            [DataMember(Name = "weaponType")]
            public LinkedIconEntity<ItemType> WeaponType { get; set; }

            /// <summary>
            ///     True if this entity had the final  blow
            /// </summary>
            /// <value><c>true</c> if [final blow]; otherwise, <c>false</c>.</value>
            [DataMember(Name = "finalBlow")]
            public bool FinalBlow { get; set; }

            /// <summary>
            ///     The security status
            /// </summary>
            /// <value>The security status.</value>
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
            /// <value>The character.</value>
            [DataMember(Name = "character")]
            public LinkedIconEntity<NotImplemented> Character { get; set; }

            /// <summary>
            ///     The corporation
            /// </summary>
            /// <value>The corporation.</value>
            [DataMember(Name = "corporation")]
            public LinkedIconEntity<NotImplemented> Corporation { get; set; }

            /// <summary>
            ///     The alliance
            /// </summary>
            /// <value>The alliance.</value>
            [DataMember(Name = "alliance")]
            public LinkedIconEntity<Alliance> Alliance { get; set; }

            /// <summary>
            ///     The ship type
            /// </summary>
            /// <value>The type of the ship.</value>
            [DataMember(Name = "shipType")]
            public LinkedIconEntity<ItemType> ShipType { get; set; }
        }

        /// <summary>
        ///     Represents a killmail victim
        /// </summary>
        [DataContract]
        public class KillmailVictim : KillmailEntity {
            /// <summary>
            ///     The amount of damage taken
            /// </summary>
            /// <value>The damage taken.</value>
            [DataMember(Name = "damageTaken")]
            public int DamageTaken { get; set; }

            /// <summary>
            ///     A list of items the victim held
            /// </summary>
            /// <value>The items.</value>
            [DataMember(Name = "items")]
            public IReadOnlyList<Item> Items { get; set; }
        }
    }
}