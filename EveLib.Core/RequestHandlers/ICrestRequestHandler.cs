using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    /// Interface ICrestRequestHandler
    /// </summary>
    public interface ICrestRequestHandler {

        /// <summary>
        /// Requests a URI asynchronously, and returns the deserialized content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>T.</returns>
        Task<T> RequestAsync<T>(Uri uri);
    }
}
