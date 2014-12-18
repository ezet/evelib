using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources.Market {
    /// <summary>
    ///     Class MarketOrderCollection.
    /// </summary>
    [DataContract]
    public sealed class MarketOrderCollection : CollectionResource<MarketOrderCollection> {

        /// <summary>
        ///     Initializes a new instance of the <see cref="MarketOrderCollection" /> class.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public MarketOrderCollection() {
            ContentType = "application/vnd.ccp.eve.MarketOrderCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public IReadOnlyList<> 


    }
}