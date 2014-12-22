// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="CharacterNameId.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.EveOnlineModule.Models.Misc {
    /// <summary>
    ///     Class CharacterNameId.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CharacterNameId {
        /// <summary>
        ///     Gets or sets the characters.
        /// </summary>
        /// <value>The characters.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<CharacterData> Characters { get; set; }

        /// <summary>
        ///     Class CharacterData.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class CharacterData {
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
        }
    }
}