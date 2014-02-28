using System.Collections.Generic;
using System.Linq;

namespace eZet.Eve.EveLib.Entity.EveCentral {
    public class EveCentralOptions {
        public IList<long> Types { get; set; }

        public IList<long> Regions { get; set; }
        
        public int HourLimit { get; set; }

        public int MinQuality { get; set; }


        public int System { get; set; }

        public EveCentralOptions(int hourLimit = 0, int minQuality = 0, int system = 0) {
            HourLimit = hourLimit;
            MinQuality = minQuality;
            System = system;
            Types = new List<long>();
            Regions = new List<long>();
        }

        internal string TypeQuery(string paramName) {
            return Types.Count == 0 ? "" : Types.Aggregate("", (current, type) => current + (paramName + "=" + type + "&"));
        }

        internal string RegionQuery(string paramName) {
            return Regions.Count == 0 ? "" : Regions.Aggregate("", (current, region) => current + (paramName + "=" + region + "&"));
        }

        internal string HourQuery(string paramName) {
            return HourLimit == 0 ? "" : paramName + "=" + HourLimit + "&";
        }

        internal string QualityQuery(string paramName) {
            return MinQuality == 0 ? "" : paramName + "=" + MinQuality + "&";
        }

        internal string SystemQuery(string paramName) {
            return System == 0 ? "" : paramName + "=" + System + "&";
        }
    }
}
