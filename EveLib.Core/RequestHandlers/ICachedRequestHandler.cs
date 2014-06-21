using eZet.EveLib.Core.Cache;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    /// Interface for a cache enabled request handler
    /// </summary>
    public interface ICachedRequestHandler : IRequestHandler {
        /// <summary>
        /// Gets or sets the cache used by this request handler
        /// </summary>
        IEveLibCache Cache { get; set; }

        /// <summary>
        /// Enables or disables loading from cache
        /// </summary>
        bool EnableCacheLoad { get; set; }

        /// <summary>
        /// Enables or disables storing to cache
        /// </summary>
        bool EnableCacheStore { get; set; }
    }
}