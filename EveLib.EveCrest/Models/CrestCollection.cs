using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    /// Class CrestCollection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CrestCollection<T> : ReadOnlyCollection<T> {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrestCollection{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public CrestCollection(IList<T> list) : base(list) {
        }

 
    }
}
