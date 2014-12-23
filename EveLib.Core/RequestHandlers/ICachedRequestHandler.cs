using eZet.EveLib.Core.Cache;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    ///     Interface for a cache enabled request handler
    /// </summary>
    public interface ICachedRequestHandler : IRequestHandler {
        /// <summary>
        ///     Gets or sets the cache used by this request handler
        /// </summary>
        IEveLibCache Cache { get; set; }

        /// <summary>
        ///     Gets or sets the cache level.
        /// </summary>
        /// <value>The cache level.</value>
        CacheLevel CacheLevel { get; set; }
    }
}