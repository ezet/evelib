using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace eZet.EveLib.Modules.Models {
    [DataContract]
    public sealed class CrestItemCategoryCollection : CrestCollectionResource<CrestItemCategoryCollection> {
        public CrestItemCategoryCollection() {
            Version = "application/vnd.ccp.eve.ItemCategoryCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public ReadOnlyCollection<CrestLinkedEntity<CrestItemCategory>> Items { get; set; }
    }
}