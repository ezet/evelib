using eZet.EveLib.Core.Cache;

namespace eZet.EveLib.Core.RequestHandlers {
    public interface ICachedRequestHandler : IRequestHandler {
        IEveLibCache Cache { get; set; }

        bool EnableCacheLoad { get; set; }

        bool EnableCacheStore { get; set; }
    }
}
