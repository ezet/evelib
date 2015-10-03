// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CharacterList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveXmlModule.Models.Account {
    /// <summary>
    ///     Class CharacterList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterList {
        /// <summary>
        ///     The characters
        /// </summary>
        [XmlElement("rowset")] public EveXmlRowCollection<CharacterInfo> Characters;

        /// <summary>
        ///     Class CharacterInfo.
        /// </summary>
        [Serializable]
        [XmlRoot("row", IsNullable = false)]
        public class CharacterInfo {
            /// <summary>
            ///     Gets or sets the name of the character.
            /// </summary>
            /// <value>The name of the character.</value>
            [XmlAttribute("name")]
            public string CharacterName { get; set; }

            /// <summary>
            ///     Gets or sets the character identifier.
            /// </summary>
            /// <value>The character identifier.</value>
            [XmlAttribute("characterID")]
            public long CharacterId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the corporation.
            /// </summary>
            /// <value>The name of the corporation.</value>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            ///     Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long corporationId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the alliance.
            /// </summary>
            /// <value>The name of the alliance.</value>
            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

            /// <summary>
            ///     Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [XmlAttribute("AllianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the faction.
            /// </summary>
            /// <value>The name of the faction.</value>
            [XmlAttribute("factionName")]
            public string FactionName { get; set; }

            /// <summary>
            ///     Gets or sets the faction identifier.
            /// </summary>
            /// <value>The faction identifier.</value>
            [XmlAttribute("factionID")]
            public long FactionId { get; set; }
        }
    }
}