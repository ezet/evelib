using System.Collections.Generic;
using System.Linq;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides a set of configurable options for EveCentral requests.
    /// </summary>
    public class Element43Options {
        /// <summary>
        ///     Creates a new options object.
        /// </summary>
        public Element43Options() {
            Items = new List<int>();
        }

        /// <summary>
        ///     Gets or sets a collection of type IDs.
        /// </summary>
        public ICollection<int> Items { get; set; }

        /// <summary>
        ///     Gets or sets a collection of region IDs.
        /// </summary>
        public long Region { get; set; }

        /// <summary>
        ///     Returns items in a query string format.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        internal string GetItemQuery(string paramName) {
            return Items.Count == 0
                ? ""
                : Items.Aggregate("", (current, type) => current + (paramName + "=" + type + "&"));
        }

        internal string GetRegionQuery(string paramName) {
            return Region != 0 ? paramName + "=" + Region + "&" : "";
        }
    }
}