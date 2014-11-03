// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-02-2014
// ***********************************************************************
// <copyright file="ApiKeyInfo.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Account {
    /// <summary>
    /// Class ApiKeyInfo.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ApiKeyInfo {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        [XmlElement("key")]
        public ApiKeyData Key { get; set; }

        /// <summary>
        /// Class ApiKeyData.
        /// </summary>
        public class ApiKeyData {
            /// <summary>
            /// Gets or sets the key entities.
            /// </summary>
            /// <value>The key entities.</value>
            [XmlElement("rowset")]
            public EveOnlineRowCollection<ApiKeyEntity> KeyEntities { get; set; }

            /// <summary>
            /// Gets or sets the access mask.
            /// </summary>
            /// <value>The access mask.</value>
            [XmlAttribute("accessMask")]
            public int AccessMask { get; set; }

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [XmlAttribute("type")]
            public ApiKeyType Type { get; set; }

            /// <summary>
            /// Gets the expire date.
            /// </summary>
            /// <value>The expire date.</value>
            [XmlIgnore]
            public DateTime ExpireDate { get; private set; }

            /// <summary>
            /// Gets or sets the expire date as string.
            /// </summary>
            /// <value>The expire date as string.</value>
            [XmlAttribute("expires")]
            public string ExpireDateAsString {
                get { return ExpireDate.ToString(XmlHelper.DateFormat); }
                set {
                    ExpireDate = value == "" ? DateTime.MinValue : DateTime.ParseExact(value, XmlHelper.DateFormat, null);
                }
            }
        }

        /// <summary>
        /// Class ApiKeyEntity.
        /// </summary>
        [Serializable]
        [XmlRoot("row", IsNullable = false)]
        public class ApiKeyEntity {
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
            /// Gets or sets the corporation identifier.
            /// </summary>
            /// <value>The corporation identifier.</value>
            [XmlAttribute("corporationID")]
            public long CorporationId { get; set; }

            /// <summary>
            /// Gets or sets the name of the corporation.
            /// </summary>
            /// <value>The name of the corporation.</value>
            [XmlAttribute("corporationName")]
            public string CorporationName { get; set; }

            /// <summary>
            /// Gets or sets the alliance identifier.
            /// </summary>
            /// <value>The alliance identifier.</value>
            [XmlAttribute("allianceID")]
            public long AllianceId { get; set; }

            /// <summary>
            /// Gets or sets the name of the alliance.
            /// </summary>
            /// <value>The name of the alliance.</value>
            [XmlAttribute("allianceName")]
            public string AllianceName { get; set; }

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
        }
    }
}