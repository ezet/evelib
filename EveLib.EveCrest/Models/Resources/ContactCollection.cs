// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-28-2015
//
// Last Modified By : larsd
// Last Modified On : 10-28-2015
// ***********************************************************************
// <copyright file="ContactCollection.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class ContactCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class ContactCollection : CollectionResource<ContactCollection, ContactCollection.ListItem> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactCollection" /> class.
        /// </summary>
        public ContactCollection() {
            ContentType = "application/vnd.ccp.eve.ContactCollection-v3+json";
        }

        /// <summary>
        ///     Class ListItem.
        /// </summary>
        [DataContract]
        public class ListItem {
            /// <summary>
            ///     Gets or sets the standing.
            /// </summary>
            /// <value>The standing.</value>
            [DataMember(Name = "standing")]
            public long Standing { get; set; }

            /// <summary>
            ///     Gets or sets the href.
            /// </summary>
            /// <value>The href.</value>
            [DataMember(Name = "href")]
            public Href<NotImplemented> Href { get; set; }

            /// <summary>
            ///     Gets or sets the character.
            /// </summary>
            /// <value>The character.</value>
            [DataMember(Name = "character")]
            public CharacterEntry Character { get; set; }

            /// <summary>
            ///     Gets or sets the contact.
            /// </summary>
            /// <value>The contact.</value>
            [DataMember(Name = "contact")]
            public LinkedEntity<Character> Contact { get; set; }

            /// <summary>
            ///     Gets or sets the type of the contact.
            /// </summary>
            /// <value>The type of the contact.</value>
            [DataMember(Name = "contactType")]
            public string ContactType { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="ListItem" /> is watched.
            /// </summary>
            /// <value><c>true</c> if watched; otherwise, <c>false</c>.</value>
            [DataMember(Name = "watched")]
            public bool Watched { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="ListItem" /> is blocked.
            /// </summary>
            /// <value><c>true</c> if blocked; otherwise, <c>false</c>.</value>
            [DataMember(Name = "blocked")]
            public bool Blocked { get; set; }
        }
    }
}