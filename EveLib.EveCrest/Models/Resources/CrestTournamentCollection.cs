using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {

    /// <summary>
    /// Class CrestTournamentCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class CrestTournamentCollection : CrestCollectionResource<CrestTournamentCollection> {

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestTournamentCollection"/> class.
        /// </summary>
        public CrestTournamentCollection() {
            Version = "application/vnd.ccp.eve.TournamentCollection-v1+json";
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<CrestLinkedEntity<CrestTournament>> Items { get; set; }


    }
}
