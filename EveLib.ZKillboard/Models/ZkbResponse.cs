using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public class ZkbResponse : Collection<ZkbResponse.ZkbKill> {
        [DataContract]
        public class ZkbAttacker {
            [DataMember(Name = "damageDone")]
            public int DamageDone { get; set; }

            [DataMember(Name = "securityStatus")]
            public double SecurityStatus { get; set; }

            [DataMember(Name = "finalBlow")]
            public string FinalBlowString {
                set { FinalBlow = value == "1"; }
            }

            public bool FinalBlow { get; set; }

            [DataMember(Name = "weaponTypeID")]
            public int WeaponTypeId { get; set; }

            [DataMember(Name = "shipTypeID")]
            public int ShipTypeId { get; set; }
        }


        [DataContract]
        public abstract class ZkbEntity {
            [DataMember(Name = "shipTypeId")]
            public int ShipTypeId { get; set; }

            [DataMember(Name = "characterID")]
            public long CharacterId { get; set; }

            [DataMember(Name = "characterName")]
            public string CharacterName { get; set; }

            [DataMember(Name = "corporationID")]
            public long CorporationId { get; set; }

            [DataMember(Name = "corporationName")]
            public string CorporationName { get; set; }

            [DataMember(Name = "allianceID")]
            public int AllianceId { get; set; }

            [DataMember(Name = "allianceName")]
            public string AllianceName { get; set; }

            [DataMember(Name = "factionID")]
            public int FactionId { get; set; }

            [DataMember(Name = "factionName")]
            public string FactionName { get; set; }
        }

        [DataContract]
        public class ZkbItem {
            [DataMember(Name = "typeID")]
            public int TypeId { get; set; }

            [DataMember(Name = "flag")]
            public int Flag { get; set; }

            [DataMember(Name = "qtyDropped")]
            public int QuantityDropped { get; set; }

            [DataMember(Name = "qtyDestroyed")]
            public int QuantityDestroyed { get; set; }

            [DataMember(Name = "singleton")]
            public string SingletonString {
                set { Singleton = value == "1"; }
            }

            public bool Singleton { get; set; }
        }

        [DataContract]
        public class ZkbKill {
            [DataMember(Name = "killID")]
            public long KillId { get; set; }

            [DataMember(Name = "solarSystemID")]
            public int SolarSystemId { get; set; }

            [DataMember(Name = "killTime")]
            public DateTime KillTime { get; set; }

            [DataMember(Name = "moonID")]
            public int MoonId { get; set; }

            [DataMember(Name = "victim")]
            public ZkbVictim Victim { get; set; }

            [DataMember(Name = "attackers")]
            public IList<ZkbAttacker> Attackers { get; set; }

            [DataMember(Name = "items")]
            public IList<ZkbItem> Items { get; set; }

            [DataMember(Name = "zkb")]
            public ZkbStats Stats { get; set; }
        }

        [DataContract]
        public class ZkbStats {
            [DataMember(Name = "totalValue")]
            public decimal TotalValue { get; set; }

            [DataMember(Name = "points")]
            public int Points { get; set; }
        }

        [DataContract]
        public class ZkbVictim : ZkbEntity {
            [DataMember(Name = "damageTaken")]
            public int DamageTaken { get; set; }

            [DataMember(Name = "victim")]
            public string Victim { get; set; }
        }
    }
}