using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {

    namespace eZet.EveLib.Core.RequestHandlers {
        /// <summary>
        ///     Interface for a cache enabled request handler
        /// </summary>
        public interface ICachedCrestRequestHandler : ICrestRequestHandler {

            /// <summary>
            /// Gets or sets the cache mode.
            /// </summary>
            /// <value>The cache mode.</value>
            CacheLevel CacheLevel { get; set; }

            /// <summary>
            ///     Gets or sets the cache used by this request handler
            /// </summary>
            IEveLibCache Cache { get; set; }

            ///// <summary>
            ///// Gets or sets a value indicating whether [enable cache].
            ///// </summary>
            ///// <value><c>true</c> if [enable cache]; otherwise, <c>false</c>.</value>
            //bool EnableCache { get; set; }
        }
    }

}
