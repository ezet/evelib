using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    /// Class WritableHref.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCollection">The type of the t collection.</typeparam>
    public class WritableHref<T, TCollection> : Href<T>
        where T : CollectionResource<T, TCollection>, IEditableCollectionResource<T, TCollection>
        where TCollection : IEditableEntity, new() {
        /// <summary>
        /// Initializes a new instance of the <see cref="Href{T}" /> class.
        /// </summary>
        /// <param name="href">The href.</param>
        public WritableHref(string href) : base(href) {
        }

        /// <summary>
        /// Gets or sets the eve crest.
        /// </summary>
        /// <value>The eve crest.</value>
        public EveCrest EveCrest { get; set; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>TCollection.</returns>
        public TCollection Create() {
            return new TCollection {Href = Uri, IsNew = true, EveCrest = EveCrest};
        }
    }
}