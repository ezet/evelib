using System;
using System.Collections.Generic;

namespace eZet.Eve.EoLib.Util.EveApi {

    /// <summary>
    /// Interface for CacheExpiratoinRegisters
    /// </summary>
    public interface ICacheExpirationRegister : IEnumerable<KeyValuePair<string, DateTime>> {

        /// <summary>
        /// Restores a saved entry to the register.
        /// </summary>
        /// <param name="key">The stored file key.</param>
        /// <param name="value">The stored cachedUntil vlaue.</param>
        /// <returns></returns>
        bool Restore(string key, DateTime value);

        /// <summary>
        /// Adds or updates an existing entry with a new CachedUntil date.
        /// </summary>
        /// <param name="uri">A uri to add or update.</param>
        /// <param name="cachedUntil">The cachedUntil date for this uri.</param>
        void AddOrUpdate(Uri uri, DateTime cachedUntil);

        /// <summary>
        /// Attempts to get the CachedUntil date for a uri.
        /// </summary>
        /// <param name="uri">The uri to look up.</param>
        /// <param name="value">A DateTime instance to store the date in.</param>
        /// <returns>True if an entry was retrieved, otherwise false.</returns>
        bool TryGetValue(Uri uri, out DateTime value);

    }
}
