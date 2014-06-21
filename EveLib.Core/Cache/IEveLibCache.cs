using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Cache {
    /// <summary>
    ///     Interface for CacheExpiratoinRegisters
    /// </summary>
    public interface IEveLibCache {

        /// <summary>
        /// Stores data to the cache
        /// </summary>
        /// <param name="uri">The uri this caches</param>
        /// <param name="cacheTime">The cache expiry time</param>
        /// <param name="data">The data to cache</param>
        /// <returns></returns>
        Task StoreAsync(Uri uri, DateTime cacheTime, string data);

        /// <summary>
        /// Loads data from cache
        /// </summary>
        /// <param name="uri">The uri to load cache for</param>
        /// <returns>The cached data</returns>
        Task<string> LoadAsync(Uri uri);

        /// <summary>
        ///     Attempts to get the CachedUntil date for a uri.
        /// </summary>
        /// <param name="uri">The uri to look up.</param>
        /// <param name="value">A DateTime instance to store the date in.</param>
        /// <returns>True if an entry was retrieved, otherwise false.</returns>
        bool TryGetExpirationDate(Uri uri, out DateTime value);
    }
}