using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    public class EditableCollectionResource<T, TCollection> : CollectionResource<T, TCollection>, IEditableCollectionResource<T, TCollection> where T : CollectionResource<T, TCollection> where TCollection : class, IEditableEntity, new() {
  

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context) {
            foreach (var item in Items) {
                item.EveCrest = EveCrest;
                item.IsNew = false;
            } 
        }

    }
}