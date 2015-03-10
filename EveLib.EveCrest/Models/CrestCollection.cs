using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace eZet.EveLib.EveCrestModule.Models {
    public class CrestCollection<T> : ReadOnlyCollection<T> {
        public CrestCollection(IList<T> list) : base(list) {
        }

 
    }
}
