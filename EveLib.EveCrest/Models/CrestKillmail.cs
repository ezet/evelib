using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class CrestKillmail {
        [DataMember(Name = "solarSystem")]
        public CrestNamedEntity SolarSystem { get; set; }

        [DataMember(Name = "killID")]
        public long KillId { get; set; }

        [DataMember(Name = "killTime")]
        public DateTime KillTime { get; set; }

        [DataMember(Name = "attackers")]
        public IList<KillmailAttacker> Attackers { get; set; }

        [DataMember(Name = "attackerCount")]
        public int AttackerCount { get; set; }

        [DataMember(Name = "victim")]
        public KillmailVictim Victim { get; set; }

        [DataMember(Name = "war")]
        public CrestEntity War { get; set; }


        [DataContract]
        public class Item : CrestIconEntity {
            [DataMember(Name = "singleton")]
            public bool Singleton { get; set; }

            [DataMember(Name = "flag")]
            public int Flag { get; set; }

            [DataMember(Name = "quantityDestroyed")]
            public int QuantityDestroyed { get; set; }
        }

        [DataContract]
        public class KillmailAttacker : KillmailEntity {
            [DataMember(Name = "damageDone")]
            public int DamageDone { get; set; }

            [DataMember(Name = "weaponType")]
            public CrestIconEntity WeaponType { get; set; }

            [DataMember(Name = "finalBlow")]
            public bool FinalBlow { get; set; }

            [DataMember(Name = "securityStatus")]
            public double SecurityStatus { get; set; }
        }


        [DataContract]
        public abstract class KillmailEntity {
            [DataMember(Name = "character")]
            public CrestIconEntity Character { get; set; }

            [DataMember(Name = "corporation")]
            public CrestIconEntity Corporation { get; set; }

            [DataMember(Name = "alliance")]
            public CrestIconEntity Alliance { get; set; }

            [DataMember(Name = "shipType")]
            public CrestIconEntity ShipType { get; set; }
        }

        [DataContract]
        public class KillmailVictim : KillmailEntity {
            [DataMember(Name = "damageTaken")]
            public int DamageTaken { get; set; }

            [DataMember(Name = "items")]
            public IList<Item> Items { get; set; }
        }
    }
}