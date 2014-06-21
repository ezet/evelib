using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;

namespace eZet.EveLib.Core.RequestHandlers {

    /// <summary>
    /// Interface for Request Handlers
    /// </summary>
    public interface IRequestHandler {
        /// <summary>
        /// Gets or sets the serializer used to deserialize data
        /// </summary>
        ISerializer Serializer { get; set; }

        /// <summary>
        /// Performs a request and returns the deserialized response content
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="uri">URI to request</param>
        /// <returns>Deserialized response</returns>
        Task<T> RequestAsync<T>(Uri uri);
    }
}