using System;

namespace eZet.Eve.EveLib.Util {
    /// <summary>
    ///     Interface for performing requests against the Eve API.
    /// </summary>
    public interface IRequestHandler {
        /// <summary>
        ///     A serializer used to serialize/deserialize T objects in the Request method.
        /// </summary>
        ISerializer Serializer { get; set; }

        /// <summary>
        ///     Performs a request on the uri, deserializes the response to type T, and returns it.
        /// </summary>
        /// <typeparam name="T">Type of response.</typeparam>
        /// <param name="uri">The uri to request.</param>
        /// <returns></returns>
        T Request<T>(Uri uri);
    }
}