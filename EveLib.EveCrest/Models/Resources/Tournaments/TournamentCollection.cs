using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Tournaments {
    /// <summary>
    ///     Class TournamentCollection. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TournamentCollection : CollectionResource<TournamentCollection, LinkedEntity<Tournament>> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TournamentCollection" /> class.
        /// </summary>
        public TournamentCollection() {
            ContentType = "application/vnd.ccp.eve.TournamentCollection-v1+json";
        }
    }
}