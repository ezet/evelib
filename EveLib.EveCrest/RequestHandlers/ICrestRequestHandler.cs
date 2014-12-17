using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
    /// <summary>
    ///     Interface ICrestRequestHandler
    /// </summary>
    public interface ICrestRequestHandler {
        bool ThrowOnDeprecated { get; set; }

        ISerializer Serializer { get; set; }

        /// <summary>
        ///     Requests a URI asynchronously, and returns the deserialized content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The CREST access accessToken</param>
        /// <returns>T.</returns>
        Task<T> RequestAsync<T>(Uri uri, string accessToken) where T : ICrestResource;
    }
}