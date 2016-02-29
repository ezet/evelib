using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace eZet.EveLib.EveCrestModule.Models {

    [DataContract]
    public class EditableEntity : IEditableEntity {

        public bool IsNew { get; set; }

        public EveCrest EveCrest { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        public string CollectionHref { get; set; }

        public Task<bool> SaveAsync() {
            return EveCrest.SaveAsync(this);
        }

        public Task<bool> DeleteAsync() {
            return EveCrest.DeleteAsync(this);
        }

        public bool ShouldSerializeHref() => false;

    }

}
