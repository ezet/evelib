// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="StandingsList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    ///     Class StandingsList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class StandingsList {
        /// <summary>
        ///     Gets or sets the character standings.
        /// </summary>
        /// <value>The character standings.</value>
        [XmlElement("characterNPCStandings")]
        public StandingType CharacterStandings { get; set; }


        /// <summary>
        ///     Class StandingEntry.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class StandingEntry {
            /// <summary>
            ///     Gets or sets from identifier.
            /// </summary>
            /// <value>From identifier.</value>
            [XmlAttribute("fromID")]
            public long FromId { get; set; }

            /// <summary>
            ///     Gets or sets from name.
            /// </summary>
            /// <value>From name.</value>
            [XmlAttribute("fromName")]
            public string FromName { get; set; }

            /// <summary>
            ///     Gets or sets the standing.
            /// </summary>
            /// <value>The standing.</value>
            [XmlAttribute("standing")]
            public float Standing { get; set; }
        }

        /// <summary>
        ///     Class StandingType.
        /// </summary>
        public class StandingType : IXmlSerializable {
            /// <summary>
            ///     Gets or sets the agents.
            /// </summary>
            /// <value>The agents.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<StandingEntry> Agents { get; set; }

            /// <summary>
            ///     Gets or sets the corporations.
            /// </summary>
            /// <value>The corporations.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<StandingEntry> Corporations { get; set; }

            /// <summary>
            ///     Gets or sets the factions.
            /// </summary>
            /// <value>The factions.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<StandingEntry> Factions { get; set; }

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
                Agents = xml.deserializeRowSet<StandingEntry>("agents");
                Corporations = xml.deserializeRowSet<StandingEntry>("NPCCorporations");
                Factions = xml.deserializeRowSet<StandingEntry>("factions");
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
    }
}