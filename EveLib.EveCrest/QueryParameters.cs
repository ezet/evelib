using System;
using System.Collections.Generic;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;

namespace eZet.EveLib.EveCrestModule {
    /// <summary>
    /// Class QueryParameters.
    /// </summary>
    public static class QueryParameters {

        /// <summary>
        /// The map
        /// </summary>
        private static Dictionary<Type, string> map = new Dictionary<Type, string> {
            {typeof (ItemType), "type"},
            {typeof(MarketGroup), "group" }
        };

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.String.</returns>
        public static string GetParameterName<T>() {
            return map[typeof(T)];
        }
    }
}