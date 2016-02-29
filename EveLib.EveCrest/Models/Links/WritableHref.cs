using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    public class WritableHref<T, TCollection> : Href<T> where T : CollectionResource<T, TCollection>, IEditableCollectionResource<T, TCollection> where TCollection : IEditableEntity, new() {

        public EveCrest EveCrest { get; set; }

        public WritableHref(string href) : base(href) {

        }

        public TCollection Create() {
            return new TCollection {CollectionHref = Uri, IsNew = true, EveCrest = EveCrest};
        }

    }
}