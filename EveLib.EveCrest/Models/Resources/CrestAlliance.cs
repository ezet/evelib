using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Represents a CREST /allliances/$allianceId/ reponse
    /// </summary>
    [DataContract]
    public sealed class CrestAlliance : CrestResource {
        public CrestAlliance() {
            Version = "application/vnd.ccp.eve.Alliance-v1+json";
        }

        /// <summary>
        ///     The alliance ID
        /// </summary>
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        ///     The alliance name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }


        /// <summary>
        ///     The alliance ticker
        /// </summary>
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        /// <summary>
        ///     The alliance creation date
        /// </summary>
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }


        /// <summary>
        ///     The number of corporations in the alliance
        /// </summary>
        [DataMember(Name = "corporationsCount")]
        public int CorporationsCount { get; set; }

        /// <summary>
        ///     The alliance description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     True if the alliance is deleted, otherwise false
        /// </summary>
        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        ///     The alliance URL, if any
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        ///     The alliance executor corporation
        /// </summary>
        [DataMember(Name = "executorCorporation")]
        public CrestLinkedEntity<CrestPlaceholderModel> ExecutorCorporation { get; set; }

        /// <summary>
        ///     The alliance creator corporation
        /// </summary>
        [DataMember(Name = "creatorCorporation")]
        public CrestLinkedEntity<CrestPlaceholderModel> CreatorCorporation { get; set; }

        /// <summary>
        ///     The alliance creator character
        /// </summary>
        [DataMember(Name = "creatorCharacter")]
        public Character CreatorCharacter { get; set; }

        /// <summary>
        ///     A list of all corporations in the alliance
        /// </summary>
        [DataMember(Name = "corporations")]
        public IList<Corporation> Corporations { get; set; }

        [DataContract]
        public class Character : CrestLinkedEntity<CrestPlaceholderModel> {
            [DataMember(Name = "isNPC")]
            public bool IsNpc { get; set; }

            [DataMember(Name = "capsuleer")]
            public CrestLinkedEntity<CrestPlaceholderModel> Capsuleer { get; set; }

            [DataMember(Name = "portrait")]
            public CrestImageLink Portraits { get; set; }
        }

        [DataContract]
        public class Corporation : CrestLinkedEntity<CrestPlaceholderModel> {
            [DataMember(Name = "isNPC")]
            public bool IsNpc { get; set; }

            [DataMember(Name = "logo")]
            public CrestImageLink Logo { get; set; }
        }
    }
}