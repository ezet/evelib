using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a CREST /industry/teams/ response
    /// </summary>
    public class CrestIndustryTeams : CrestCollectionResponse {

        /// <summary>
        /// A list of the teams
        /// </summary>
        [DataMember(Name = "items")]
        public IList<CrestIndustryTeam> Teams { get; set; }
   
    }
}
