using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Loyalty Store Offers
    /// </summary>
    /// <seealso cref="eZet.EveLib.EveCrestModule.Models.CrestResource{eZet.EveLib.EveCrestModule.Models.Resources.LoyaltyStoreOffersCollection}" />
    /// <seealso cref="Models.CrestResource{LoyaltyStoreOffersCollection}" />
    public sealed class LoyaltyStoreOffersCollection : CrestResource<LoyaltyStoreOffersCollection> {

        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyStoreOffersCollection"/> class.
        /// </summary>
        public LoyaltyStoreOffersCollection() {
            ContentType = "application/vnd.ccp.eve.LoyaltyStoreOffersCollection-v1+json";
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [DataMember(Name = "items")]
        public IReadOnlyList<LoyaltyStoreItem> Items { get; set; }

        /// <summary>
        /// Loyalty Store Item
        /// </summary>
        public class LoyaltyStoreItem {

            /// <summary>
            /// Gets or sets the isk cost.
            /// </summary>
            /// <value>
            /// The isk cost.
            /// </value>
            [DataMember(Name = "iskCost")]
            public double IskCost { get; set; }

            /// <summary>
            /// Gets or sets the lp cost.
            /// </summary>
            /// <value>
            /// The lp cost.
            /// </value>
            [DataMember(Name = "lpCost")]
            public double LpCost { get; set; }

            /// <summary>
            /// Gets or sets the required items.
            /// </summary>
            /// <value>
            /// The required items.
            /// </value>
            [DataMember(Name = "requiredItems")]
            public IReadOnlyList<RequiredItem> RequiredItems { get; set; }

        }

        /// <summary>
        /// Required Item
        /// </summary>
        public class RequiredItem {

            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>
            /// The item.
            /// </value>
            [DataMember(Name = "item")]
            public LinkedEntity<ItemType> Item { get; set; }

            /// <summary>
            /// Gets or sets the quantity.
            /// </summary>
            /// <value>
            /// The quantity.
            /// </value>
            [DataMember(Name = "quantity")]
            public long Quantity { get; set; }

        }
    }

 
}