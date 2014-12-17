using System;
using System.Collections.Generic;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule {
    public static class CrestModel {
        static CrestModel() {
            Register = new Dictionary<Type, string> {
                {typeof (CrestRoot), "application/vnd.ccp.eve.Api-v3+json"},
            };
        }

        private static Dictionary<Type, string> Register { get; set; }

        public static string Get<T>() where T : ICrestResource {
            // TODO optional throw on missing version
            var instance = Activator.CreateInstance<T>();
            if (String.IsNullOrEmpty(instance.Version)) {
                throw new NotImplementedException();
            }
            return instance.Version;
        }
    }
}