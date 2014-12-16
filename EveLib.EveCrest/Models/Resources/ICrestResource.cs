namespace eZet.EveLib.Modules.Models.Resources {
    public interface ICrestResource {
        bool IsDeprecated { get; set; }

        string Version { get; }
    }
}