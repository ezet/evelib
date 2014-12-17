using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using eZet.EveLib.Modules.Models.Entities;

namespace eZet.EveLib.Modules.Models.Resources {
    [DataContract]
    public sealed class CrestItemCategoryCollection : CrestCollectionResource<CrestItemCategoryCollection> {
        public CrestItemCategoryCollection() {
            Version = "application/vnd.ccp.eve.ItemCategoryCollection-v1+json";
        }

        [DataMember(Name = "items")]
        public ReadOnlyCollection<CrestLinkedEntity<CrestItemCategory>> Items { get; set; }
    }
}