using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST /industry/teams/ response
    /// </summary>
    public sealed class IndustryTeamCollection : CollectionResource<IndustryTeamCollection> {
        public IndustryTeamCollection() {
            Version = "application/vnd.ccp.eve.IndustryTeamCollection-v1+json";
        }

        /// <summary>
        ///     A list of the teams
        /// </summary>
        [DataMember(Name = "items")]
        public IList<IndustryTeam> Items { get; set; }
    }
}