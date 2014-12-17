using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Class TournamentCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentCollection : CollectionResource<TournamentCollection> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentCollection" /> class.
        /// </summary>
        public TournamentCollection() {
            Version = "application/vnd.ccp.eve.TournamentCollection-v1+json";
        }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<LinkedEntity<Tournament>> Items { get; set; }
    }
}