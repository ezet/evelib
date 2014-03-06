using System.Collections.Generic;
using System.Linq;

namespace eZet.EveLib.EveCentralLib {
    public class EveCentralOptions {
        public EveCentralOptions() {
            Types = new List<long>();
            Regions = new List<long>();
        }

        public ICollection<long> Types { get; private set; }

        public ICollection<long> Regions { get; private set; }

        public int HourLimit { get; set; }

        public int MinQuantity { get; set; }


        public int System { get; set; }

        internal string TypeQuery(string paramName) {
            return Types.Count == 0
                ? ""
                : Types.Aggregate("", (current, type) => current + (paramName + "=" + type + "&"));
        }

        internal string RegionQuery(string paramName) {
            return Regions.Count == 0
                ? ""
                : Regions.Aggregate("", (current, region) => current + (paramName + "=" + region + "&"));
        }

        internal string HourQuery(string paramName) {
            return HourLimit == 0 ? "" : paramName + "=" + HourLimit + "&";
        }

        internal string MinQuantityQuery(string paramName) {
            return MinQuantity == 0 ? "" : paramName + "=" + MinQuantity + "&";
        }

        internal string SystemQuery(string paramName) {
            return System == 0 ? "" : paramName + "=" + System + "&";
        }
    }
}