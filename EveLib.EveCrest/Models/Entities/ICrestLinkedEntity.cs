namespace eZet.EveLib.Modules.Models.Entities {
    public interface ICrestLinkedEntity<T> {
        CrestHref<T> Href { get; set; }
    }
}