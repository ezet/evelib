namespace eZet.EveLib.Modules.Models {
    public interface ICrestLinkedEntity<T> {
        CrestHref<T> Href { get; set; }
    }
}