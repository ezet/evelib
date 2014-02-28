using System;
using eZet.Eve.EveLib.Properties;

namespace eZet.Eve.EveLib.Util {
    /// <summary>
    /// Interface for performing requests against the Eve API.
    /// </summary>
    public interface IRequestHandler {

        IXmlSerializer Serializer { get; set; }

        /// <summary>
        /// Performs a request using the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of response.</typeparam>
        /// <param name="type">An object of the response type.</param>
        /// <param name="uri">The uri to request.</param>
        /// <returns></returns>
        T Request<T>(Uri uri);
    }
}
