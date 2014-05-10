using System;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Interface for CacheExpiratoinRegisters
    /// </summary>
    public interface IEveApiCache {

        void Store(Uri uri, DateTime cacheTime, string data);

        void Store(Uri uri, DateTime cacheTime);

        bool TryGet(Uri uri, out string data);

        /// <summary>
        ///     Attempts to get the CachedUntil date for a uri.
        /// </summary>
        /// <param name="uri">The uri to look up.</param>
        /// <param name="value">A DateTime instance to store the date in.</param>
        /// <returns>True if an entry was retrieved, otherwise false.</returns>
        bool TryGetExpirationDate(Uri uri, out DateTime value);
    }
}