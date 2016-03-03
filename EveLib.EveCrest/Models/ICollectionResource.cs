// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 03-03-2016
//
// Last Modified By : larsd
// Last Modified On : 03-03-2016
// ***********************************************************************
// <copyright file="ICollectionResource.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Interface ICollectionResource
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCollection">The type of the t collection.</typeparam>
    public interface ICollectionResource<T, TCollection> where T : CollectionResource<T, TCollection>, ICrestResource<T> {
        /// <summary>
        ///     The total number of items in the collection
        /// </summary>
        /// <value>The total count.</value>
        int TotalCount { get; set; }

        /// <summary>
        ///     The items on this page in the collection
        /// </summary>
        /// <value>The items.</value>
        IReadOnlyList<TCollection> Items { get; set; }

        /// <summary>
        ///     The number of pages in the collection
        /// </summary>
        /// <value>The page count.</value>
        int PageCount { get; set; }

        /// <summary>
        ///     Gets or sets the next page.
        /// </summary>
        /// <value>The next.</value>
        Href<T> Next { get; set; }

        /// <summary>
        ///     Gets or sets the previous page.
        /// </summary>
        /// <value>The previous.</value>
        Href<T> Previous { get; set; }

        /// <summary>
        ///     Gets or sets the crest instance used to query resources.
        /// </summary>
        /// <value>The crest instance</value>
        EveCrest EveCrest { get; set; }

        /// <summary>
        ///     Gets or sets the response headers.
        /// </summary>
        /// <value>The response headers.</value>
        WebHeaderCollection ResponseHeaders { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is from cache.
        /// </summary>
        /// <value><c>true</c> if this instance is from cache; otherwise, <c>false</c>.</value>
        bool IsFromCache { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this resource is deprecated.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated; otherwise, <c>false</c>.</value>
        bool IsDeprecated { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        string ContentType { get; }

        /// <summary>
        ///     Gets all items in the collection as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;TCollection&gt;&gt;.</returns>
        Task<IEnumerable<TCollection>> AllItemsAsync();

        /// <summary>
        ///     Gets all the items in the collection.
        /// </summary>
        /// <returns>IEnumerable&lt;TCollection&gt;.</returns>
        IEnumerable<TCollection> AllItems();

        /// <summary>
        ///     Queries a collection resource for a collection of items, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<IEnumerable<TOut>> QueryAsync<TOut>(
            Func<IEnumerable<TCollection>, IEnumerable<ILinkedEntity<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a collection of items.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        IEnumerable<TOut> Query<TOut>(Func<IEnumerable<TCollection>, IEnumerable<ILinkedEntity<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a collection of items, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<IEnumerable<TOut>> QueryAsync<TOut>(
            Func<IEnumerable<TCollection>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a collection of items.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        IEnumerable<TOut> Query<TOut>(Func<IEnumerable<TCollection>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<TOut> QueryAsync<TOut>(Func<IEnumerable<TCollection>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        TOut Query<TOut>(Func<IEnumerable<TCollection>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<TOut> QueryAsync<TOut>(Func<IEnumerable<TCollection>, ILinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection resource for a single item.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        TOut Query<TOut>(Func<IEnumerable<TCollection>, ILinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries the resource asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> QueryAsync<TOut>(Func<T, Href<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries the resource.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        TOut Query<TOut>(Func<T, Href<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries the resource asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> QueryAsync<TOut>(Func<T, ILinkedEntity<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries the resource.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        TOut Query<TOut>(Func<T, ILinkedEntity<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection of resources asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<IEnumerable<TOut>> QueryAsync<TOut>(Func<T, IEnumerable<Href<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        IEnumerable<TOut> Query<TOut>(Func<T, IEnumerable<Href<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection of resources asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        Task<IEnumerable<TOut>> QueryAsync<TOut>(Func<T, IEnumerable<ILinkedEntity<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;

        /// <summary>
        ///     Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        IEnumerable<TOut> Query<TOut>(Func<T, IEnumerable<ILinkedEntity<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut>;
    }
}