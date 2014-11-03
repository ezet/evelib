// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="FactionWarTopStats.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Misc {
    /// <summary>
    /// Class FactionWarTopStats.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarTopStats {
        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>The characters.</value>
        [XmlElement("characters")]
        public CharacterStats Characters { get; set; }

        /// <summary>
        /// Gets or sets the corporations.
        /// </summary>
        /// <value>The corporations.</value>
        [XmlElement("corporations")]
        public CharacterStats Corporations { get; set; }

        /// <summary>
        /// Class CharacterEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CharacterEntry {
            /// <summary>
            /// Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            /// Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [XmlAttribute("characterName")]
            public string CharacterName { get; set; }

            /// <summary>
            /// Gets or sets the kills.
            /// </summary>
            /// <value>The kills.</value>
            [XmlAttribute("kills")]
            public int Kills { get; set; }
        }

        /// <summary>
        /// Class CharacterStats.
        /// </summary>
        public class CharacterStats : IXmlSerializable {
            /// <summary>
            /// Gets or sets the kills yesterday.
            /// </summary>
            /// <value>The kills yesterday.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterEntry> KillsYesterday { get; set; }

            /// <summary>
            /// Gets or sets the kills last week.
            /// </summary>
            /// <value>The kills last week.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterEntry> KillsLastWeek { get; set; }

            /// <summary>
            /// Gets or sets the kills total.
            /// </summary>
            /// <value>The kills total.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterEntry> KillsTotal { get; set; }

            /// <summary>
            /// Gets or sets the victory points yesterday.
            /// </summary>
            /// <value>The victory points yesterday.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterEntry> VictoryPointsYesterday { get; set; }

            /// <summary>
            /// Gets or sets the victory points last week.
            /// </summary>
            /// <value>The victory points last week.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterEntry> VictoryPointsLastWeek { get; set; }

            /// <summary>
            /// Gets or sets the victory points total.
            /// </summary>
            /// <value>The victory points total.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CharacterEntry> VictoryPointsTotal { get; set; }

            /// <summary>
            /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
            /// </summary>
            /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Generates an object from its XML representation.
            /// </summary>
            /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                KillsYesterday = xml.deserializeRowSet<CharacterEntry>("KillsYesterday");
                KillsLastWeek = xml.deserializeRowSet<CharacterEntry>("KillsLastWeek");
                KillsTotal = xml.deserializeRowSet<CharacterEntry>("KillsTotal");
                VictoryPointsYesterday = xml.deserializeRowSet<CharacterEntry>("VictoryPointsYesterday");
                VictoryPointsLastWeek = xml.deserializeRowSet<CharacterEntry>("VictoryPointsLastWeek");
                VictoryPointsTotal = xml.deserializeRowSet<CharacterEntry>("VictoryPointsTotal");
            }

            /// <summary>
            /// Converts an object into its XML representation.
            /// </summary>
            /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Class CorporationEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CorporationEntry {
            /// <summary>
            /// Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [XmlAttribute("factionID")]
            public long FactionId { get; set; }

            /// <summary>
            /// Gets or sets the name of the faction.
            /// </summary>
            /// <value>The name of the faction.</value>
            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            /// <summary>
            /// Gets or sets the kills.
            /// </summary>
            /// <value>The kills.</value>
            [XmlAttribute("kills")]
            public string Kills { get; set; }
        }

        /// <summary>
        /// Class CorporationStats.
        /// </summary>
        public class CorporationStats : IXmlSerializable {
            /// <summary>
            /// Gets or sets the kills yesterday.
            /// </summary>
            /// <value>The kills yesterday.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CorporationEntry> KillsYesterday { get; set; }

            /// <summary>
            /// Gets or sets the kills last week.
            /// </summary>
            /// <value>The kills last week.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CorporationEntry> KillsLastWeek { get; set; }

            /// <summary>
            /// Gets or sets the kills total.
            /// </summary>
            /// <value>The kills total.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CorporationEntry> KillsTotal { get; set; }

            /// <summary>
            /// Gets or sets the victory points yesterday.
            /// </summary>
            /// <value>The victory points yesterday.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CorporationEntry> VictoryPointsYesterday { get; set; }

            /// <summary>
            /// Gets or sets the victory points last week.
            /// </summary>
            /// <value>The victory points last week.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CorporationEntry> VictoryPointsLastWeek { get; set; }

            /// <summary>
            /// Gets or sets the victory points total.
            /// </summary>
            /// <value>The victory points total.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<CorporationEntry> VictoryPointsTotal { get; set; }

            /// <summary>
            /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
            /// </summary>
            /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public XmlSchema GetSchema() {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Generates an object from its XML representation.
            /// </summary>
            /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                KillsYesterday = xml.deserializeRowSet<CorporationEntry>("KillsYesterday");
                KillsLastWeek = xml.deserializeRowSet<CorporationEntry>("KillsLastWeek");
                KillsTotal = xml.deserializeRowSet<CorporationEntry>("KillsTotal");
                VictoryPointsYesterday = xml.deserializeRowSet<CorporationEntry>("VictoryPointsYesterday");
                VictoryPointsLastWeek = xml.deserializeRowSet<CorporationEntry>("VictoryPointsLastWeek");
                VictoryPointsTotal = xml.deserializeRowSet<CorporationEntry>("VictoryPointsTotal");
            }

            /// <summary>
            /// Converts an object into its XML representation.
            /// </summary>
            /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }
}