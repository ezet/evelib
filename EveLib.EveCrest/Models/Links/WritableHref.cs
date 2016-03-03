namespace eZet.EveLib.EveCrestModule.Models.Links {
    /// <summary>
    /// Class WritableHref.
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    /// <typeparam name="TEditable">The type of the t collection.</typeparam>
    public class WritableHref<TResource, TEditable> : Href<TResource>
        where TEditable : IEditableEntity, new() {
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
        public TEditable Create() {
            return new TEditable {Href = Uri, SaveAsNew = true, EveCrest = EveCrest};
        }
    }
}