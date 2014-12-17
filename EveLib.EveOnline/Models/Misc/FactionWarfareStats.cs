// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="FactionWarfareStats.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveOnlineModule.Util;

namespace eZet.EveLib.EveOnlineModule.Models.Misc {
    /// <summary>
    ///     Class FactionWarfareStats.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class FactionWarfareStats : IXmlSerializable {
        /// <summary>
        ///     Gets or sets the totals.
        /// </summary>
        /// <value>The totals.</value>
        [XmlElement("totals")]
        public FactionWarfareTotals Totals { get; set; }

        /// <summary>
        ///     Gets or sets the factions.
        /// </summary>
        /// <value>The factions.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<FactionWarfareEntry> Factions { get; set; }

        /// <summary>
        ///     Gets or sets the faction wars.
        /// </summary>
        /// <value>The faction wars.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<FactionWarfareEntry> FactionWars { get; set; }


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
            Totals = xml.deserialize<FactionWarfareTotals>("totals");
            Factions = xml.deserializeRowSet<FactionWarfareEntry>("factions");
            FactionWars = xml.deserializeRowSet<FactionWarfareEntry>("factionWars");
        }

        /// <summary>
        ///     Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Class FactionWarfareEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class FactionWarfareEntry {
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
            ///     Gets or sets the pilots.
            /// </summary>
            /// <value>The pilots.</value>
            [XmlAttribute("pilots")]
            public int Pilots { get; set; }

            /// <summary>
            ///     Gets or sets the systems controlled.
            /// </summary>
            /// <value>The systems controlled.</value>
            [XmlAttribute("systemControlled")]
            public int SystemsControlled { get; set; }

            /// <summary>
            ///     Gets or sets the kills yesterday.
            /// </summary>
            /// <value>The kills yesterday.</value>
            [XmlAttribute("killsYesterday")]
            public int KillsYesterday { get; set; }

            /// <summary>
            ///     Gets or sets the kills last week.
            /// </summary>
            /// <value>The kills last week.</value>
            [XmlAttribute("killsLastWeek")]
            public int KillsLastWeek { get; set; }

            /// <summary>
            ///     Gets or sets the kills total.
            /// </summary>
            /// <value>The kills total.</value>
            [XmlAttribute("killsTotal")]
            public int KillsTotal { get; set; }

            /// <summary>
            ///     Gets or sets the victory points yesterday.
            /// </summary>
            /// <value>The victory points yesterday.</value>
            [XmlElement("vicoryPointsYesterday")]
            public int VictoryPointsYesterday { get; set; }

            /// <summary>
            ///     Gets or sets the victory points last week.
            /// </summary>
            /// <value>The victory points last week.</value>
            [XmlElement("victoryPointsLastWeek")]
            public int VictoryPointsLastWeek { get; set; }

            /// <summary>
            ///     Gets or sets the victory points total.
            /// </summary>
            /// <value>The victory points total.</value>
            [XmlElement("victoryPointsTotal")]
            public int VictoryPointsTotal { get; set; }

            /// <summary>
            ///     Gets or sets the against identifier.
            /// </summary>
            /// <value>The against identifier.</value>
            [XmlAttribute("againstID")]
            public long AgainstId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the against.
            /// </summary>
            /// <value>The name of the against.</value>
            [XmlAttribute("againstName")]
            public string AgainstName { get; set; }
        }

        /// <summary>
        ///     Class FactionWarfareTotals.
        /// </summary>
        [Serializable]
        [XmlRoot("totals")]
        public class FactionWarfareTotals {
            /// <summary>
            ///     Gets or sets the kills yesterday.
            /// </summary>
            /// <value>The kills yesterday.</value>
            [XmlElement("killsYesterday")]
            public int KillsYesterday { get; set; }

            /// <summary>
            ///     Gets or sets the kills last week.
            /// </summary>
            /// <value>The kills last week.</value>
            [XmlElement("killsLastWeek")]
            public int KillsLastWeek { get; set; }

            /// <summary>
            ///     Gets or sets the kills total.
            /// </summary>
            /// <value>The kills total.</value>
            [XmlElement("killsTotal")]
            public int KillsTotal { get; set; }

            /// <summary>
            ///     Gets or sets the victory points yesterday.
            /// </summary>
            /// <value>The victory points yesterday.</value>
            [XmlElement("vicoryPointsYesterday")]
            public int VictoryPointsYesterday { get; set; }

            /// <summary>
            ///     Gets or sets the victory points last week.
            /// </summary>
            /// <value>The victory points last week.</value>
            [XmlElement("victoryPointsLastWeek")]
            public int VictoryPointsLastWeek { get; set; }

            /// <summary>
            ///     Gets or sets the victory points total.
            /// </summary>
            /// <value>The victory points total.</value>
            [XmlElement("victoryPointsTotal")]
            public int VictoryPointsTotal { get; set; }
        }
    }
}