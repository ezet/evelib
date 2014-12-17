using System;
using System.Collections.Generic;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules {
    public static class CrestVersions {
        static CrestVersions() {
            Register = new Dictionary<Type, string> {
                {typeof (CrestRoot), "application/vnd.ccp.eve.Api-v3+json"},
            };
        }


        public static Dictionary<Type, string> Register { get; private set; }

        public static void GetModel(string contentType) {
        }

        public static string Get<T>() where T : ICrestResource {
            // TODO optional throw on missing version
            return Activator.CreateInstance<T>().Version;
            
            string version;
            Register.TryGetValue(typeof (T), out version);
            return version;
        }
    }
}