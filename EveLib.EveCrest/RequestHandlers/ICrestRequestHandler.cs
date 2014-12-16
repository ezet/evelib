using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.Models.Resources;

namespace eZet.EveLib.Modules.RequestHandlers {
    /// <summary>
    /// Interface ICrestRequestHandler
    /// </summary>
    public interface ICrestRequestHandler {
        /// <summary>
        /// Requests a URI asynchronously, and returns the deserialized content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The CREST access accessToken</param>
        /// <returns>T.</returns>
        Task<T> RequestAsync<T>(Uri uri, string accessToken) where T : ICrestResource;

        bool ThrowOnDeprecated { get; set; }

        ISerializer Serializer { get; set; }


    }
}
