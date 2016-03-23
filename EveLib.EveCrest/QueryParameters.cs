using System;
using System.Collections.Generic;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;

namespace eZet.EveLib.EveCrestModule {
    public static class QueryParameters {

        private static Dictionary<Type, string> map = new Dictionary<Type, string> {
            {typeof (ItemType), "type"},
            {typeof(MarketGroup), "group" }
        };

        public static string GetParameterName<T>() {
            return map[typeof (T)];
        }
    }
}