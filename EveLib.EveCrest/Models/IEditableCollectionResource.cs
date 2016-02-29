using eZet.EveLib.Core.Properties;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models {
    public interface IEditableCollectionResource<T, TCollection> : ICollectionResource<T, TCollection> where T : CollectionResource<T, TCollection> {

       

    }

}