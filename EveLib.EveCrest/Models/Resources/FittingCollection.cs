using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {

    [DataContract]
    public sealed class FittingCollection : CollectionResource<FittingCollection, FittingCollection.Fitting> {

        public FittingCollection() {
            ContentType = "application/vnd.ccp.eve.FittingCollection-v1+json";

        }

        [DataContract]
        public class Fitting {

            [DataMember(Name = "description")]
            public string Description { get; set; }

            [DataMember(Name = "fittingID")]
            public long FittingId { get; set; }

            [DataMember(Name = "items")]
            public IReadOnlyCollection<FittingItem> Items { get; set; }
        }

        [DataContract]
        public class FittingItem {

            [DataMember(Name = "flag")]
            public int Flag { get; set; }

            [DataMember(Name = "quantity")]
            public int Quantity { get; set; }

            [DataMember(Name = "type")]
            public LinkedEntity<ItemType> Type { get; set; }
        }
    }


}
