using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.Models {
    [DataContract]
    public sealed class Empty : CrestResource<Empty> {

        public Empty() {
            ContentType = "empty";
        }

    }
}