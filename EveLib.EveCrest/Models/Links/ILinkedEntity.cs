namespace eZet.EveLib.EveCrestModule.Models.Links {
    public interface ILinkedEntity<T> {
        Href<T> Href { get; set; }
    }
}