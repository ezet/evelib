using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// NPC Corporations Collection
    /// </summary>
    /// <seealso cref="eZet.EveLib.EveCrestModule.Models.CollectionResource{eZet.EveLib.EveCrestModule.Models.Resources.NpcCorporationsCollection, eZet.EveLib.EveCrestModule.Models.Resources.NpcCorporationsCollection.NpcCorporationData}" />
    public sealed class NpcCorporationsCollection : CollectionResource<NpcCorporationsCollection, NpcCorporationsCollection.NpcCorporationData> {

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcCorporationsCollection"/> class.
        /// </summary>
        public NpcCorporationsCollection() {
            ContentType = "application/vnd.ccp.eve.NPCCorporationsCollection-v1+json";
        }
        public class NpcCorporationData : LinkedEntity<NotImplemented> {

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>
            /// The description.
            /// </value>
            [DataMember(Name = "description")]
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the head quarters.
            /// </summary>
            /// <value>
            /// The head quarters.
            /// </value>
            [DataMember(Name = "headquarters")]
            public LinkedEntity<Station> HeadQuarters { get; set; }

            /// <summary>
            /// Gets or sets the loyalty store.
            /// </summary>
            /// <value>
            /// The loyalty store.
            /// </value>
            [DataMember(Name = "loyaltyStore")]
            public Href<LoyaltyStoreOffersCollection> LoyaltyStore { get; set; }

            /// <summary>
            /// Gets or sets the ticker.
            /// </summary>
            /// <value>
            /// The ticker.
            /// </value>
            [DataMember(Name = "ticker")]
            public string Ticker { get; set; }
                
        }
    }

 
}