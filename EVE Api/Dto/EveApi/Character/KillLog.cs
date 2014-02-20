using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class KillLog : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Kill> Kills { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Kill {

            [XmlAttribute("killID")]
            public long KillId { get; set; }

            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

            [XmlIgnore]
            public DateTime KillTime { get; private set; }

            [XmlAttribute("killTime")]
            public string KillTimeAsString {
                get { return KillTime.ToString(DateFormat); }
                set { KillTime = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("moonID")]
            public long MoonId { get; set; }

            [XmlElement("victim")]
            public Victim Victim { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Attacker> Attackers { get; set; }

            [XmlElement("rowset2")]
            public XmlRowSet<Item> Items { get; set; }

        }

        [Serializable]
        [XmlRoot("row")]
        public class Victim {

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            [XmlAttribute("shipTypeID")]
            public long ShipTypeId { get; set; }

            [XmlAttribute("damageTaken")]
            public int DamageTaken { get; set; }
        }

        [Serializable]
        [XmlRoot("row")]
        public class Attacker {

            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            [XmlAttribute("damageDone")]
            public int DamageDone { get; set; }

            [XmlAttribute("finalBlow")]
            public bool FinalBlow { get; set; }

            [XmlAttribute("securityStatus")]
            public float SecurityStatus { get; set; }

            [XmlAttribute("weaponTypeID")]
            public long WeaponTypeId { get; set; }

        }

        [Serializable]
        [XmlRoot("row")]
        public class Item {

            [XmlAttribute("flag")]
            public int FLag { get; set; }

            [XmlAttribute("tqyDropped")]
            public int QtyDropped { get; set; }

            [XmlAttribute("qtyDestroyed")]
            public int QtyDestroyed { get; set; }

            [XmlAttribute("typeID")]
            public long TypeId { get; set; }

            [XmlAttribute("singleton")]
            public int Singleton { get; set; }

            [XmlElement("rowset")]
            public XmlRowSet<Item> Items { get; set; }

        }

    }
}
