using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Interface for CacheExpiratoinRegisters
    /// </summary>
    public interface IEveApiCache {

        Task StoreAsync(Uri uri, DateTime cacheTime, string data);

        //void StoreAsync(Uri uri, DateTime cacheTime);

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