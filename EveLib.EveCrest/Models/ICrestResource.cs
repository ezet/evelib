// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="ICrestResource.cs" company="Lars Kristian Dahl">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    /// Interface ICrestResource
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrestResource<out T> {
        /// <summary>
        /// Gets or sets the crest instance used to query resources.
        /// </summary>
        /// <value>The crest instance</value>
        EveCrest EveCrest { get; set; }

        /// <summary>
        /// Gets or sets the response headers.
        /// </summary>
        /// <value>The response headers.</value>
        WebHeaderCollection ResponseHeaders { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is from cache.
        /// </summary>
        /// <value><c>true</c> if this instance is from cache; otherwise, <c>false</c>.</value>
        bool IsFromCache { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this resource is deprecated.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated; otherwise, <c>false</c>.</value>
        bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        string ContentType { get; }

        /// <summary>
        /// Injects the specified crest.
        /// </summary>
        /// <param name="crest">The crest.</param>
        void Inject(EveCrest crest);

        ///// <summary>
        ///// Gets the options asynchronous.
        ///// </summary>
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        //Task<CrestOptions> QueryOptionsAsync();

        ///// <summary>
        ///// Gets the options.
        ///// </summary>
        ///// <returns>CrestOptions.</returns>
        //CrestOptions QueryOptions();

        ///// <summary>
        ///// Queries the head asynchronous.
        ///// </summary>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //Task<WebHeaderCollection> QueryHeadAsync();

        ///// <summary>
        ///// Queries the head.
        ///// </summary>
        ///// <returns>WebHeaderCollection.</returns>
        //WebHeaderCollection QueryHead();

        /// <summary>
        /// Queries the resource asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> QueryAsync<TOut>(Func<T, Href<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries the resource.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        TOut Query<TOut>(Func<T, Href<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries the resource asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> QueryAsync<TOut>(Func<T, ILinkedEntity<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries the resource.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        TOut Query<TOut>(Func<T, ILinkedEntity<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries a collection of resources asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<IEnumerable<TOut>> QueryAsync<TOut>(Func<T, IEnumerable<Href<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        IEnumerable<TOut> Query<TOut>(Func<T, IEnumerable<Href<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries a collection of resources asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<IEnumerable<TOut>> QueryAsync<TOut>(Func<T, IEnumerable<ILinkedEntity<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        /// Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        IEnumerable<TOut> Query<TOut>(Func<T, IEnumerable<ILinkedEntity<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the options asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        //Task<CrestOptions> QueryOptionsAsync<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the options.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>CrestOptions.</returns>
        //CrestOptions QueryOptions<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the options asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        //Task<CrestOptions> QueryOptionsAsync<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the options.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>CrestOptions.</returns>
        //CrestOptions QueryOptions<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the head asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //Task<WebHeaderCollection> QueryHeadAsync<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the head.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>WebHeaderCollection.</returns>
        //WebHeaderCollection QueryHead<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the head asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //Task<WebHeaderCollection> QueryHeadAsync<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;

        ///// <summary>
        ///// Queries the head.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>WebHeaderCollection.</returns>
        //WebHeaderCollection QueryHead<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut>;
    }
}