// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-19-2014
// ***********************************************************************
// <copyright file="TokenDecode.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class TokenDecode. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TokenDecode : CrestResource<TokenDecode> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TokenDecode" /> class.
        /// </summary>
        public TokenDecode() {
            ContentType = "application/vnd.ccp.eve.TokenDecode-v1+json";
        }

        /// <summary>
        ///     Gets or sets the character.
        /// </summary>
        /// <value>The character.</value>
        [DataMember(Name = "character")]
        public Href<Character> Character { get; set; }
    }
}