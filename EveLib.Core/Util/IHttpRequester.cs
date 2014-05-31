using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     Interface for performing requests against the Eve API.
    /// </summary>
    public interface IHttpRequester {

        /// <summary>
        ///     Performs a request on the uri, deserializes the response to type T, and returns it.
        /// </summary>
        /// <typeparam name="T">Type of response.</typeparam>
        /// <param name="uri">The uri to request.</param>
        /// <returns></returns>
        Task<string> RequestAsync<T>(Uri uri);

    }
}