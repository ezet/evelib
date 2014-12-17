using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /killmails/ response
    /// </summary>
    [DataContract]
    public sealed class KillmailCollection : CollectionResource<KillmailCollection> {
        public KillmailCollection() {
            Version = "application/vnd.ccp.eve.WarKillmails-v1+json";
        }


        /// <summary>
        ///     A list of killmails
        /// </summary>
        [DataMember(Name = "items")]
        public IReadOnlyList<LinkedEntity<Killmail>> Killmails { get; set; }
    }
}