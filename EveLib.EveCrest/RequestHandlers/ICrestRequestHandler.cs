// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 08-09-2015
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="ICrestRequestHandler.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCrestModule.Models;

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
        ///     Gets the request asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>T.</returns>
        Task<T> GetRequestAsync<T>(Uri uri, string accessToken) where T : class, ICrestResource<T>;

        /// <summary>
        ///     Posts the request asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="accesstoken">The accesstoken.</param>
        /// <param name="postData">The post data.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PostRequestAsync(Uri uri, string accesstoken, string postData);

        /// <summary>
        ///     Puts the request asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="accesstoken">The accesstoken.</param>
        /// <param name="postData">The post data.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> PutRequestAsync(Uri uri, string accesstoken, string postData);

        /// <summary>
        ///     Deletes the request asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> DeleteRequestAsync(Uri uri, string accessToken);

        Task<CrestOptions> OptionsRequestAsync(Uri uri);
    }
}