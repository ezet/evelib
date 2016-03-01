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
    public sealed class ContactCollection : EditableCollectionResource<ContactCollection, ContactCollection.ContactItem> {
        /// <summary>
        /// Enum ContactType
        /// </summary>
        public enum ContactType {
            [EnumMember(Value = "character")]
            Character,
            [EnumMember(Value = "corporation")]
            Corporation,
            [EnumMember(Value = "alliance")]
            Alliance
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactCollection" /> class.
        /// </summary>
        public ContactCollection() {
            ContentType = "application/vnd.ccp.eve.ContactCollection-v3+json";
        }

        /// <summary>
        ///     Class ContactItem.
        /// </summary>
        [DataContract]
        // TODO: Add generic type for Contact property
        public class ContactItem : EditableEntity {

            public ContactItem() {
                Contact = new LinkedEntity<string>();
            }

            public bool ShouldSerializeCharacter() => false;

            public bool ShouldSerializeAlliance() => false;

            public bool ShouldSerializeCorporation() => false;

            public bool ShouldSerializeBlocked() => false;

            public bool ShouldSerializeContactType() => false;

            //public bool ShouldSerializeWatched() => false;

            /// <summary>
            ///     Gets or sets the standing.
            /// </summary>
            /// <value>The standing.</value>
            [DataMember(Name = "standing")]
            public long Standing { get; set; }

            /// <summary>
            ///     Gets or sets the character.
            /// </summary>
            /// <value>The character.</value>
            [DataMember(Name = "character")]
            public CharacterEntry Character { get; set; }

            /// <summary>
            /// Gets or sets the alliance.
            /// </summary>
            /// <value>The alliance.</value>
            [DataMember(Name = "alliance")]
            public LinkedEntity<Alliance> Alliance { get; set; }

            /// <summary>
            /// Gets or sets the alliance.
            /// </summary>
            /// <value>The alliance.</value>
            [DataMember(Name = "corporation")]
            public CorporationEntry Corporation { get; set; }

            /// <summary>
            ///     Gets or sets the contact.
            /// </summary>
            /// <value>The contact.</value>
            /// TODO: Implement Contact properly, as LinkedEntity
            [DataMember(Name = "contact")]
            public LinkedEntity<string> Contact { get; set; }

            /// <summary>
            ///     Gets or sets the type of the contact.
            /// </summary>
            /// <value>The type of the contact.</value>
            [DataMember(Name = "contactType")]
            public ContactType ContactType { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="ContactItem" /> is watched.
            /// </summary>
            /// <value><c>true</c> if watched; otherwise, <c>false</c>.</value>
            [DataMember(Name = "watched")]
            public bool Watched { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this <see cref="ContactItem" /> is blocked.
            /// </summary>
            /// <value><c>true</c> if blocked; otherwise, <c>false</c>.</value>
            [DataMember(Name = "blocked")]
            public bool Blocked { get; set; }

            /// <summary>
            /// Class ContactData.
            /// </summary>
            [DataContract]
            public class ContactData {

                public bool ShouldSerializeName() => false;

                public bool ShouldSerializeId() => false;

                /// <summary>
                /// Gets or sets the identifier.
                /// </summary>
                /// <value>The identifier.</value>
                [DataMember(Name = "id")]
                public long Id { get; set; }

                /// <summary>
                /// Gets or sets the href.
                /// </summary>
                /// <value>The href.</value>
                [DataMember(Name = "href")]
                public string Href { get; set; }

                /// <summary>
                /// Gets or sets the name.
                /// </summary>
                /// <value>The name.</value>
                [DataMember(Name = "name")]
                public string Name { get; set; }

            }
        }
    }
}
