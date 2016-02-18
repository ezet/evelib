using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCrestModule.Models.Resources;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
    /// <summary>
    ///     Interface ICrestRequestHandler
    /// </summary>
    public interface ICrestRequestHandler {
        /// <summary>
        ///     Gets or sets a value indicating whether to throw an exception when requesting a deprecated resource
        /// </summary>
        /// <value><c>true</c> if [throw on deprecated]; otherwise, <c>false</c>.</value>
        bool ThrowOnDeprecated { get; set; }

        /// <summary>
        ///     Sets or gets whether to throw a DeprecatedResourceException when requesting a deprecated resource
        /// </summary>
        bool ThrowOnMissingContentType { get; set; }

        /// <summary>
        ///     Gets or sets the serializer used to deserialize CREST errors.
        /// </summary>
        /// <value>The serializer.</value>
        ISerializer Serializer { get; set; }

        /// <summary>
        ///     Gets or sets the size of the public burst.
        /// </summary>
        /// <value>The size of the public burst.</value>
        int PublicMaxConcurrentRequests { get; set; }

        /// <summary>
        ///     Gets or sets the size of the authed burst.
        /// </summary>
        /// <value>The size of the authed burst.</value>
        int AuthedMaxConcurrentRequests { get; set; }

        /// <summary>
        ///     Gets or sets the x requested with.
        /// </summary>
        /// <value>The x requested with.</value>
        string XRequestedWith { get; set; }

        /// <summary>
        ///     Gets or sets the user agent.
        /// </summary>
        /// <value>The user agent.</value>
        string UserAgent { get; set; }

        /// <summary>
        ///     Gets or sets the charset.
        /// </summary>
        /// <value>The charset.</value>
        string Charset { get; set; }

        /// <summary>
        /// Requests a URI asynchronously, and returns the response content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The CREST access accessToken</param>
        /// <param name="method">The method.</param>
        /// <param name="postData">The post data.</param>
        /// <returns>T.</returns>
        Task<T> RequestAsync<T>(Uri uri, string accessToken, string method = "GET", string postData = null) where T : class, ICrestResource<T>;
    }
}