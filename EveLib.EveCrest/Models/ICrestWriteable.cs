using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models {
    public interface ICrestWriteable {

        void Delete();

        void Update();

        string Href { get; set; }

    }
}