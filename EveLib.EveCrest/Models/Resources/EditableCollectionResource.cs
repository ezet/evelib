using System.Runtime.Serialization;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    public class EditableCollectionResource<T, TCollection> : CollectionResource<T, TCollection>, IEditableCollectionResource<T, TCollection> where T : CollectionResource<T, TCollection> where TCollection : class, IEditableEntity, new() {


        public override void Inject(EveCrest crest) {
            base.Inject(crest);
            foreach (var item in Items) {
                item.EveCrest = EveCrest;
                item.IsNew = false;
            }
        }
    }
}