// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="KillLog.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class KillLog.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class KillLog {
        /// <summary>
        ///     Gets or sets the kills.
        /// </summary>
        /// <value>The kills.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Kill> Kills { get; set; }

        /// <summary>
        ///     Class Attacker.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Attacker {
            /// <summary>
            ///     Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the corporation.
            /// </summary>
            /// <value>The name of the corporation.</value>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the alliance.
            /// </summary>
            /// <value>The name of the alliance.</value>
            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            /// <summary>
            ///     Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the faction.
            /// </summary>
            /// <value>The name of the faction.</value>
            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            /// <summary>
            ///     Gets or sets the damage done.
            /// </summary>
            /// <value>The damage done.</value>
            [XmlAttribute("damageDone")]
            public int DamageDone { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether [final blow].
            /// </summary>
            /// <value><c>true</c> if [final blow]; otherwise, <c>false</c>.</value>
            [XmlAttribute("finalBlow")]
            public bool FinalBlow { get; set; }

            /// <summary>
            ///     Gets or sets the security status.
            /// </summary>
            /// <value>The security status.</value>
            [XmlAttribute("securityStatus")]
            public float SecurityStatus { get; set; }

            /// <summary>
            ///     Gets or sets the weapon type identifier.
            /// </summary>
            /// <value>The weapon type identifier.</value>
            [XmlAttribute("weaponTypeID")]
            public long WeaponTypeId { get; set; }
        }

        /// <summary>
        ///     Class Item.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Item {
            /// <summary>
            ///     Gets or sets the f lag.
            /// </summary>
            /// <value>The f lag.</value>
            [XmlAttribute("flag")]
            public int FLag { get; set; }

            /// <summary>
            ///     Gets or sets the qty dropped.
            /// </summary>
            /// <value>The qty dropped.</value>
            [XmlAttribute("tqyDropped")]
            public int QtyDropped { get; set; }

            /// <summary>
            ///     Gets or sets the qty destroyed.
            /// </summary>
            /// <value>The qty destroyed.</value>
            [XmlAttribute("qtyDestroyed")]
            public int QtyDestroyed { get; set; }

            /// <summary>
            ///     Gets or sets the type identifier.
            /// </summary>
            /// <value>The type identifier.</value>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            ///     Gets or sets the singleton.
            /// </summary>
            /// <value>The singleton.</value>
            [XmlAttribute("singleton")]
            public int Singleton { get; set; }

            /// <summary>
            ///     Gets or sets the items.
            /// </summary>
            /// <value>The items.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Item> Items { get; set; }
        }

        /// <summary>
        ///     Class Kill.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Kill : IXmlSerializable {
            /// <summary>
            ///     Gets or sets the kill identifier.
            /// </summary>
            /// <value>The kill identifier.</value>
            [XmlAttribute("killID")]
            public long KillId { get; set; }

            /// <summary>
            ///     Gets or sets the solar system identifier.
            /// </summary>
            /// <value>The solar system identifier.</value>
            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            /// <summary>
            ///     Gets the kill time.
            /// </summary>
            /// <value>The kill time.</value>
            [XmlIgnore]
            public DateTime KillTime { get; private set; }

            /// <summary>
            ///     Gets or sets the kill time as string.
            /// </summary>
            /// <value>The kill time as string.</value>
            [XmlAttribute("killTime")]
            public string KillTimeAsString {
                get { return KillTime.ToString(XmlHelper.DateFormat); }
                set { KillTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
            }

            /// <summary>
            ///     Gets or sets the moon identifier.
            /// </summary>
            /// <value>The moon identifier.</value>
            [XmlAttribute("moonID")]
            public long MoonId { get; set; }

            /// <summary>
            ///     Gets or sets the victim.
            /// </summary>
            /// <value>The victim.</value>
            [XmlElement("victim")]
            public Victim Victim { get; set; }

            /// <summary>
            ///     Gets or sets the attackers.
            /// </summary>
            /// <value>The attackers.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Attacker> Attackers { get; set; }

            /// <summary>
            ///     Gets or sets the items.
            /// </summary>
            /// <value>The items.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Item> Items { get; set; }

            /// <summary>
            ///     This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return
            ///     null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the
            ///     <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
            /// </summary>
            /// <returns>
            ///     An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is
            ///     produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method
            ///     and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" />
            ///     method.
            /// </returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Generates an object from its XML representation.
            /// </summary>
            /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                KillId = xml.getLongAttribute("killID");
                SolarSystemId = xml.getIntAttribute("solarSystemID");
                KillTimeAsString = xml.getStringAttribute("killTime");
                MoonId = xml.getLongAttribute("moonID");
                Victim = xml.deserialize<Victim>("victim");
                Attackers = xml.deserializeRowSet<Attacker>("attackers");
                Items = xml.deserializeRowSet<Item>("items");
            }

            /// <summary>
            ///     Converts an object into its XML representation.
            /// </summary>
            /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Class Victim.
        /// </summary>
        [Serializable]
        [XmlRoot("victim")]
        public class Victim {
            /// <summary>
            ///     Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the corporation.
            /// </summary>
            /// <value>The name of the corporation.</value>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the alliance.
            /// </summary>
            /// <value>The name of the alliance.</value>
            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            /// <summary>
            ///     Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the faction.
            /// </summary>
            /// <value>The name of the faction.</value>
            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            /// <summary>
            ///     Gets or sets the ship type identifier.
            /// </summary>
            /// <value>The ship type identifier.</value>
            [XmlAttribute("shipTypeID")]
            public long ShipTypeId { get; set; }

            /// <summary>
            ///     Gets or sets the damage taken.
            /// </summary>
            /// <value>The damage taken.</value>
            [XmlAttribute("damageTaken")]
            public int DamageTaken { get; set; }
        }
    }
}