using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    ///     Represents a speciality
    /// </summary>
    [DataContract]
    public sealed class CrestIndustrySpeciality : CrestResource {
        public CrestIndustrySpeciality() {
            Version = "application/vnd.ccp.eve.IndustrySpeciality-v1+json";
        }

        /// <summary>
        ///     The speciality ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     The speciality name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     A list of the spezialization groups
        /// </summary>
        [DataMember(Name = "groups")]
        public IList<Group> Groups { get; set; }
    }

    /// <summary>
    ///     Represents a speciality group
    /// </summary>
    [DataContract]
    public class Group {
        /// <summary>
        ///     The group ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}