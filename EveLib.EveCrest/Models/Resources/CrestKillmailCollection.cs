using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST /killmails/ response
    /// </summary>
    [DataContract]
    public sealed class CrestKillmailCollection : CrestCollectionResource<CrestKillmailCollection> {
        public CrestKillmailCollection() {
            Version = "application/vnd.ccp.eve.WarKillmails-v1+json";
        }


        /// <summary>
        ///     A list of killmails
        /// </summary>
        [DataMember(Name = "items")]
        public IReadOnlyList<CrestLinkedEntity<CrestKillmail>> Killmails { get; set; }
    }
}