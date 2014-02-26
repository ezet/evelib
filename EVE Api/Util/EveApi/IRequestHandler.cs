using System;
using eZet.Eve.EoLib.Model.EveApi;

namespace eZet.Eve.EoLib.Util.EveApi {
    /// <summary>
    /// Interface for performing requests against the Eve API.
    /// </summary>
    public interface IRequestHandler {

        /// <summary>
        /// Performs a request using the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of XmlResponse.</typeparam>
        /// <param name="type">An object of the type to return in the response.</param>
        /// <param name="uri">The uri to request.</param>
        /// <returns></returns>
        XmlResponse<T> Request<T>(T type, Uri uri) where T : new();
    }
}
