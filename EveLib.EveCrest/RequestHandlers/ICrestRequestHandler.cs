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
        ///     Gets or sets the serializer used to deserialize CREST errors.
        /// </summary>
        /// <value>The serializer.</value>
        ISerializer Serializer { get; set; }

        ///// <summary>
        ///// Gets or sets the public rate per second.
        ///// </summary>
        ///// <value>The public rate per second.</value>
        //int PublicRatePerSecond { get; set; }

        ///// <summary>
        ///// Gets or sets the authed rate per second.
        ///// </summary>
        ///// <value>The authed rate per second.</value>
        //int AuthedRatePerSecond { get; set; }

        /// <summary>
        /// Gets or sets the size of the public burst.
        /// </summary>
        /// <value>The size of the public burst.</value>
        int PublicMaxConcurrentRequests { get; set; }

        /// <summary>
        /// Gets or sets the size of the authed burst.
        /// </summary>
        /// <value>The size of the authed burst.</value>
        int AuthedMaxConcurrentRequests { get; set; }

        /// <summary>
        ///     Requests a URI asynchronously, and returns the response content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The CREST access accessToken</param>
        /// <returns>T.</returns>
        Task<T> RequestAsync<T>(Uri uri, string accessToken) where T : class, ICrestResource<T>;
    }
}