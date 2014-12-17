// ***********************************************************************
// Assembly         : EveLib.EveAuth
// Author           : Lars Kristian
// Created          : 12-17-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="VerifyResponse.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveAuthModule {
    /// <summary>
    ///     Class VerifyResponse.
    /// </summary>
    [DataContract]
    public class VerifyResponse {
        /// <summary>
        ///     Gets or sets the character identifier.
        /// </summary>
        /// <value>The character identifier.</value>
        [DataMember(Name = "characterID")]
        public int CharacterId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the character.
        /// </summary>
        /// <value>The name of the character.</value>
        [DataMember(Name = "characterName")]
        public string CharacterName { get; set; }

        /// <summary>
        ///     Gets or sets the expires on.
        /// </summary>
        /// <value>The expires on.</value>
        [DataMember(Name = "expiresOn")]
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        ///     Gets or sets the scopes.
        /// </summary>
        /// <value>The scopes.</value>
        [DataMember(Name = "scopes")]
        public string Scopes { get; set; }

        /// <summary>
        ///     Gets or sets the character owner hash.
        /// </summary>
        /// <value>The character owner hash.</value>
        [DataMember(Name = "characterOwnerHash")]
        public string CharacterOwnerHash { get; set; }
    }
}