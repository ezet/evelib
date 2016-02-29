// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 10-28-2015
//
// Last Modified By : larsd
// Last Modified On : 02-13-2016
// ***********************************************************************
// <copyright file="Character.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class Character. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class Character : CrestResource<Character> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Character" /> class.
        /// </summary>
        public Character() {
            ContentType = "application/vnd.ccp.eve.Character-v3+json";
        }

        /// <summary>
        /// Registers the specified crest.
        /// </summary>
        /// <param name="crest">The crest.</param>
        override public void Register(EveCrest crest) {
            base.Register(crest);
            Contacts.EveCrest = crest;
        }

        /// <summary>
        ///     Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        [DataMember(Name = "accounts")]
        public Href<NotImplemented> Accounts { get; set; }

        /// <summary>
        ///     Gets or sets the blocked.
        /// </summary>
        /// <value>The blocked.</value>
        [DataMember(Name = "blocked")]
        public Href<NotImplemented> Blocked { get; set; }

        /// <summary>
        ///     Gets or sets the blood line.
        /// </summary>
        /// <value>The blood line.</value>
        [DataMember(Name = "bloodLine")]
        public Href<NotImplemented> BloodLine { get; set; }

        /// <summary>
        ///     Gets or sets the capsuleer.
        /// </summary>
        /// <value>The capsuleer.</value>
        [DataMember(Name = "capsuleer")]
        public Href<NotImplemented> Capsuleer { get; set; }

        /// <summary>
        ///     Gets or sets the channels.
        /// </summary>
        /// <value>The channels.</value>
        [DataMember(Name = "channels")]
        public Href<NotImplemented> Channels { get; set; }

        /// <summary>
        ///     Gets or sets the contacts.
        /// </summary>
        /// <value>The contacts.</value>
        [DataMember(Name = "contacts")]
        public WritableHref<ContactCollection, ContactCollection.ContactItem> Contacts { get; set; }

    

        /// <summary>
        ///     Gets or sets the corporation.
        /// </summary>
        /// <value>The corporation.</value>
        [DataMember(Name = "corporation")]
        public CorporationEntry Corporation { get; set; }

        /// <summary>
        ///     Gets or sets the deposit.
        /// </summary>
        /// <value>The deposit.</value>
        [DataMember(Name = "deposit")]
        public Href<NotImplemented> Deposit { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the fittings.
        /// </summary>
        /// <value>The fittings.</value>
        [DataMember(Name = "fittings")]
        public Href<FittingCollection> Fittings { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [DataMember(Name = "gender")]
        public int Gender { get; set; }

        /// <summary>
        ///     Gets or sets the href.
        /// </summary>
        /// <value>The href.</value>
        [DataMember(Name = "href")]
        public Href<Character> Href { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        // TODO: Implement location
        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [DataMember(Name = "location")]
        public Href<CharacterLocation> Location { get; set; }

        /// <summary>
        ///     Gets or sets the mail.
        /// </summary>
        /// <value>The mail.</value>
        [DataMember(Name = "mail")]
        public Href<NotImplemented> Mail { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the notifications.
        /// </summary>
        /// <value>The notifications.</value>
        [DataMember(Name = "notifications")]
        public Href<NotImplemented> Notifications { get; set; }

        /// <summary>
        ///     Gets or sets the portrait.
        /// </summary>
        /// <value>The portrait.</value>
        [DataMember(Name = "portrait")]
        public ImageLinkCollection Portrait { get; set; }

        /// <summary>
        ///     Gets or sets the private.
        /// </summary>
        /// <value>The private.</value>
        [DataMember(Name = "private")]
        public Href<NotImplemented> Private { get; set; }

        /// <summary>
        ///     Gets or sets the race.
        /// </summary>
        /// <value>The race.</value>
        [DataMember(Name = "race")]
        public LinkedEntity<NotImplemented> Race { get; set; }

        /// <summary>
        ///     Gets or sets the standings.
        /// </summary>
        /// <value>The standings.</value>
        [DataMember(Name = "standings")]
        public Href<NotImplemented> Standings { get; set; }

        /// <summary>
        ///     Gets or sets the vivox.
        /// </summary>
        /// <value>The vivox.</value>
        [DataMember(Name = "vivox")]
        public Href<NotImplemented> Vivox { get; set; }

        // TODO Implement waypoints
        /// <summary>
        ///     Gets or sets the waypoints.
        /// </summary>
        /// <value>The waypoints.</value>
        [DataMember(Name = "waypoints")]
        public Href<NotImplemented> Waypoints { get; set; }
    }
}