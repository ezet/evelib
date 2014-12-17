namespace eZet.EveLib.EveCrestModule.Models.Resources {
    public interface ICrestResource {
        bool IsDeprecated { get; set; }

        string Version { get; }
    }
}