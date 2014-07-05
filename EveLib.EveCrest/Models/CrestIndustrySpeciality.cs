using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {

    /// <summary>
    /// Represents a speciality
    /// </summary>
    [DataContract]
    public class CrestIndustrySpeciality {

        /// <summary>
        /// The speciality ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The speciality name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A list of the spezialization groups
        /// </summary>
        [DataMember(Name = "groups")]
        public IList<Group> Groups { get; set; }
    }

    /// <summary>
    /// Represents a speciality group
    /// </summary>
    [DataContract]
    public class Group {

        /// <summary>
        /// The group ID
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

    }
}
