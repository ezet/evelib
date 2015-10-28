using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {

    [DataContract]
    public sealed class Character : CrestResource<Character> {

        public Character() {
            ContentType = "application/vnd.ccp.eve.Character-v3+json";
        }

        [DataMember(Name = "standings")]
        public Href<NotImplemented> Standings { get; set; }

        [DataMember(Name = "bloodLine")]
        public Href<NotImplemented> BloodLine { get; set; }

        [DataMember(Name = "gender")]
        public int Gender { get; set; }

        [DataMember(Name = "private")]
        public Href<NotImplemented> Private { get; set; }

        [DataMember(Name = "channels")]
        public Href<NotImplemented> Channels { get; set; }

        [DataMember(Name = "href")]
        public Href<Character> Href { get; set; }

        [DataMember(Name = "accounts")]
        public Href<NotImplemented> Accounts { get; set; }

        [DataMember(Name = "portrait")]
        public ImageLinkCollection Portrait { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "blocked")]
        public Href<NotImplemented> Blocked { get; set; }

        [DataMember(Name = "fittings")]
        public Href<FittingCollection> Fittings { get; set; }

        [DataMember(Name = "contacts")]
        public Href<NotImplemented> Contacts { get; set; }

        [DataMember(Name = "corporation")]
        public CorporationEntry Corporation { get; set; }

        [DataMember(Name = "mail")]
        public Href<NotImplemented> Mail { get; set; }

        [DataMember(Name = "capsuleer")]
        public Href<NotImplemented> Capsuleer { get; set; }

        [DataMember(Name = "vivox")]
        public Href<NotImplemented> Vivox { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "notifications")]
        public Href<NotImplemented> Notifications { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "race")]
        public LinkedEntity<NotImplemented> Race { get; set; }

        [DataMember(Name = "deposit")]
        public Href<NotImplemented> Deposit { get; set; }















        


    }

}
