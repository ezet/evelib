using System.Collections.Generic;
using System.Linq;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides a set of configurable options for EveCentral requests.
    /// </summary>
    public class EveCentralOptions {
        /// <summary>
        ///     Creates a new options object.
        /// </summary>
        public EveCentralOptions() {
            Items = new List<int>();
            Regions = new List<int>();
        }

        /// <summary>
        ///     Gets or sets a collection of type IDs.
        /// </summary>
        public ICollection<int> Items { get; set; }

        /// <summary>
        ///     Gets or sets a collection of region IDs.
        /// </summary>
        public ICollection<int> Regions { get; set; }

        /// <summary>
        ///     Gets or sets an age limit for data in the response, specified in hours.
        /// </summary>
        public int HourLimit { get; set; }

        /// <summary>
        ///     Gets or sets the minimum quantity limit for data to be included in the response.
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        ///     Gets or sets a system ID.
        /// </summary>
        public int System { get; set; }

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
            return Regions.Count == 0
                ? ""
                : Regions.Aggregate("", (current, region) => current + (paramName + "=" + region + "&"));
        }

        internal string GetHourQuery(string paramName) {
            return HourLimit == 0 ? "" : paramName + "=" + HourLimit + "&";
        }

        internal string GetMinQuantityQuery(string paramName) {
            return MinQuantity == 0 ? "" : paramName + "=" + MinQuantity + "&";
        }

        internal string GetSystemQuery(string paramName) {
            return System == 0 ? "" : paramName + "=" + System + "&";
        }
    }
}