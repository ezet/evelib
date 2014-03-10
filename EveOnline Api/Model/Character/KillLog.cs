using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnline.Model.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class KillLog : XmlElement {
        [XmlElement("rowset")]
        public RowCollection<Kill> Kills { get; set; }

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
            public RowCollection<Item> Items { get; set; }
        }

        [Serializable]
        [XmlRoot("row")]
        public class Kill : XmlElement, IXmlSerializable {
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
            public RowCollection<Attacker> Attackers { get; set; }

            [XmlElement("rowset")]
            public RowCollection<Item> Items { get; set; }

            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            public void ReadXml(XmlReader reader) {
                setRoot(reader);
                KillId = getLongAttribute("killID");
                SolarSystemId = getLongAttribute("solarSystemID");
                KillTimeAsString = getStringAttribute("killTime");
                MoonId = getLongAttribute("moonID");
                Victim = deserialize(getReader("victim"), new Victim());
                Attackers = deserializeRowSet(getRowSetReader("attackers"), new Attacker());
                Items = deserializeRowSet(getRowSetReader("items"), new Item());
            }

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

        [Serializable]
        [XmlRoot("victim")]
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
    }
}