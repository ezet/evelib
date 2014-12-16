using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST /industry/teams/ response
    /// </summary>
    public sealed class CrestIndustryTeamCollection : CrestCollectionResource<CrestIndustryTeamCollection> {
        public CrestIndustryTeamCollection() {
            Version = "application/vnd.ccp.eve.IndustryTeamCollection-v1+json";
        }

        /// <summary>
        ///     A list of the teams
        /// </summary>
        [DataMember(Name = "items")]
        public IList<CrestIndustryTeam> Items { get; set; }
    }
}