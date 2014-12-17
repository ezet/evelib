using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Properties;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
    /// <summary>
    ///     Interface ICrestRequestHandler
    /// </summary>
    public interface ICrestRequestHandler {
        /// <summary>
        /// Gets or sets a value indicating whether [throw on deprecated].
        /// </summary>
        /// <value><c>true</c> if [throw on deprecated]; otherwise, <c>false</c>.</value>
        bool ThrowOnDeprecated { get; set; }

        /// <summary>
        /// Gets or sets the serializer.
        /// </summary>
        /// <value>The serializer.</value>
        ISerializer Serializer { get; set; }

        /// <summary>
        ///     Requests a URI asynchronously, and returns the deserialized content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The CREST access accessToken</param>
        /// <returns>T.</returns>
        Task<T> RequestAsync<T>(Uri uri, string accessToken) where T : class, ICrestResource<T>;
    }
}