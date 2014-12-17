using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Entities;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Shared {
    /// <summary>
    ///     Class BanEntry.
    /// </summary>
    [DataContract]
    public class BanEntry {
        // TODO Verify type
        /// <summary>
        ///     Gets or sets the type bans.
        /// </summary>
        /// <value>The type bans.</value>
        [DataMember(Name = "typeBans")]
        public IReadOnlyList<LinkedEntity<ItemType>> TypeBans { get; set; }

        /// <summary>
        ///     Gets or sets the banned by.
        /// </summary>
        /// <value>The banned by.</value>
        [DataMember(Name = "bannedBy")]
        public Href<TournamentTeam> BannedBy { get; set; }
    }
}