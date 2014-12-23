namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    ///     Enum CacheLevel
    /// </summary>
    public enum CacheLevel {
        /// <summary>
        ///     Satisfies the request by using local cache if available, or by sending a request to the server if needed. New
        ///     requests may be stored in local cache.
        /// </summary>
        Default,

        /// <summary>
        ///     Bypasses cache complete. A new request will be sent to the server. No entries will be added to or removed from the
        ///     cache.
        /// </summary>
        BypassCache,

        /// <summary>
        ///     A request will be sent to the server. Outdated cache will be removed, and a new entry may be stored.
        /// </summary>
        Refresh,

        /// <summary>
        ///     Will serve the request from the local cache if any. If no cache is available, the request will return null.
        /// </summary>
        CacheOnly
    }
}