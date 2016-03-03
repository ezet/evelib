using System.Threading.Tasks;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    /// Interface IEditableEntity
    /// </summary>
    public interface IEditableEntity {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        bool SaveAsNew { get; set; }

        /// <summary>
        /// Gets or sets the eve crest.
        /// </summary>
        /// <value>The eve crest.</value>
        EveCrest EveCrest { get; set; }

        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        /// <value>The href.</value>
        string Href { get; set; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Task.</returns>
        Task<bool> SaveAsync();

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        Task<bool> DeleteAsync();


    }
}