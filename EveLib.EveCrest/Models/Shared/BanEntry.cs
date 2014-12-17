using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.Models.Shared {
    /// <summary>
    /// Class BanEntry.
    /// </summary>
    [DataContract]
    public class BanEntry {

        // TODO Verify type
        /// <summary>
        /// Gets or sets the type bans.
        /// </summary>
        /// <value>The type bans.</value>
        [DataMember(Name = "typeBans")]
        public IReadOnlyList<CrestLinkedEntity<CrestItemType>> TypeBans { get; set; }

        /// <summary>
        /// Gets or sets the banned by.
        /// </summary>
        /// <value>The banned by.</value>
        [DataMember(Name = "bannedBy")]
        public CrestHref<CrestTournamentTeam> BannedBy { get; set; }

    }
}
