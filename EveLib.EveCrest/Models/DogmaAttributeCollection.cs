using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models {

    [DataContract]
    public sealed class DogmaAttributeCollection : CollectionResource<DogmaAttributeCollection, LinkedEntity<DogmaAttribute>> {

        public DogmaAttributeCollection() {
            ContentType = "application/vnd.ccp.eve.DogmaAttributeCollection-v1+json";
        }
    }
}