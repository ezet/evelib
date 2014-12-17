namespace eZet.EveLib.EveCrestModule.Models.Entities {
    public interface ILinkedEntity<T> {
        Href<T> Href { get; set; }
    }
}