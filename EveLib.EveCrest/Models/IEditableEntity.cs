using System.Threading.Tasks;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    ///     Interface IEditableEntity
    /// </summary>
    public interface IEditableEntity {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        //bool SaveAsNew { get; set; }

        /// <summary>
        ///     Gets or sets the eve crest.
        /// </summary>
        /// <value>The eve crest.</value>
        EveCrest EveCrest { get; set; }

   
        string PostUri { get; set; }

        string Href { get; set; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="forcePostRequest">if set to <c>true</c> [force post request].</param>
        /// <returns>Task.</returns>
        Task<bool> SaveAsync(bool forcePostRequest = false);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <param name="forcePostRequest">if set to <c>true</c> [force post request].</param>
        /// <returns>System.Boolean.</returns>
        bool Save(bool forcePostRequest = false);

        /// <summary>
        ///     Deletes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        Task<bool> DeleteAsync();

        /// <summary>
        ///     Deletes this instance.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        bool Delete();
    }
}