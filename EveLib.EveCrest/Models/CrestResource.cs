// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="CrestResource.cs" company="Lars Kristian Dahl">
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
    ///     Base class for all CREST resouces.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CrestResource<T> : ICrestResource<T> where T : class, ICrestResource<T> {
        /// <summary>
        ///     Gets or sets the crest instance used to query resources.
        /// </summary>
        /// <value>The crest instance</value>
        public EveCrest EveCrest { get; set; }

        /// <summary>
        ///     Gets or sets the response headers.
        /// </summary>
        /// <value>The response headers.</value>
        public WebHeaderCollection ResponseHeaders { get; set; }

        /// <summary>
        ///     Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is from cache.
        /// </summary>
        /// <value><c>true</c> if this instance is from cache; otherwise, <c>false</c>.</value>
        public bool IsFromCache { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this resource is deprecated.
        /// </summary>
        /// <value><c>true</c> if this instance is deprecated; otherwise, <c>false</c>.</value>
        public virtual bool IsDeprecated { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public virtual string ContentType { get; protected set; }

        /// <summary>
        ///     Injects the specified crest.
        /// </summary>
        /// <param name="crest">The crest.</param>
        public virtual void Inject(EveCrest crest) {
            EveCrest = crest;
        }


        ///// <summary>
        /////     Gets the options asynchronous.
        ///// </summary>
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        //public Task<CrestOptions> QueryOptionsAsync() {
        //    return EveCrest.QueryOptionsAsync(new Href<string>(Uri.ToString()));
        //}

        ///// <summary>
        /////     Gets the options.
        ///// </summary>
        ///// <returns>CrestOptions.</returns>
        //public CrestOptions QueryOptions() {
        //    return QueryOptionsAsync().Result;
        //}

        ///// <summary>
        /////     Queries the head asynchronous.
        ///// </summary>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //public Task<WebHeaderCollection> QueryHeadAsync() {
        //    return EveCrest.QueryHeadAsync(new Href<string>(Uri.ToString()));
        //}

        ///// <summary>
        /////     Queries the head.
        ///// </summary>
        ///// <returns>WebHeaderCollection.</returns>
        //public WebHeaderCollection QueryHead() {
        //    return QueryHeadAsync().Result;
        //}

        /// <summary>
        ///     Queries the resource asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public Task<TOut> QueryAsync<TOut>(Func<T, Href<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            return EveCrest.LoadAsync(objFunc.Invoke(this as T), parameters);
        }

        /// <summary>
        ///     Queries the resource.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public virtual TOut Query<TOut>(Func<T, Href<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            return EveCrest.Load(objFunc.Invoke(this as T), parameters);
        }

        /// <summary>
        ///     Queries the resource asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public Task<TOut> QueryAsync<TOut>(Func<T, ILinkedEntity<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            return EveCrest.LoadAsync(objFunc.Invoke(this as T));
        }

        /// <summary>
        ///     Queries the resource.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public virtual TOut Query<TOut>(Func<T, ILinkedEntity<TOut>> objFunc, params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            return EveCrest.Load(objFunc.Invoke(this as T), parameters);
        }

        /// <summary>
        ///     Queries a collection of resources asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public virtual Task<IEnumerable<TOut>> QueryAsync<TOut>(Func<T, IEnumerable<Href<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(this as T);
            return EveCrest.LoadAsync(items, parameters);
        }

        /// <summary>
        ///     Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public virtual IEnumerable<TOut> Query<TOut>(Func<T, IEnumerable<Href<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(this as T);
            return EveCrest.Load(items, parameters);
        }

        /// <summary>
        ///     Queries a collection of resources asynchronously.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public virtual Task<IEnumerable<TOut>> QueryAsync<TOut>(Func<T, IEnumerable<ILinkedEntity<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(this as T);
            return EveCrest.LoadAsync(items, parameters);
        }

        /// <summary>
        ///     Queries a collection of resources.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public virtual IEnumerable<TOut> Query<TOut>(Func<T, IEnumerable<ILinkedEntity<TOut>>> objFunc,
            params string[] parameters)
            where TOut : class, ICrestResource<TOut> {
            var items = objFunc.Invoke(this as T);
            return EveCrest.Load(items, parameters);
        }

        //    return EveCrest.QueryOptions(objFunc.Invoke(this as T));
        //    where TOut : class, ICrestResource<TOut> {
        //public virtual CrestOptions QueryOptions<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        ///// <returns>CrestOptions.</returns>
        ///// <param name="objFunc">The object function.</param>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// </summary>
        ///// Queries the options.

        ///// <summary>
        //}
        //    return EveCrest.QueryOptionsAsync(objFunc.Invoke(this as T));
        //    where TOut : class, ICrestResource<TOut> {
        //public Task<CrestOptions> QueryOptionsAsync<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        ///// <param name="objFunc">The object function.</param>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// </summary>
        ///// Queries the options asynchronous.

        ///// <summary>
        //}

        ///// <summary>
        ///// Queries the options asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        //public Task<CrestOptions> QueryOptionsAsync<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut> {
        //    return EveCrest.QueryOptionsAsync(objFunc.Invoke(this as T));
        //}

        ///// <summary>
        ///// Queries the options.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>CrestOptions.</returns>
        //public virtual CrestOptions QueryOptions<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut> {
        //    return EveCrest.QueryOptions(objFunc.Invoke(this as T));
        //}


        ///// <summary>
        ///// Queries the head asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //public Task<WebHeaderCollection> QueryHeadAsync<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut> {
        //    return EveCrest.QueryHeadAsync(objFunc.Invoke(this as T));
        //}


        ///// <summary>
        ///// Queries the head.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>WebHeaderCollection.</returns>
        //public virtual WebHeaderCollection QueryHead<TOut>(Func<ICrestResource<T>, Href<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut> {
        //    return EveCrest.QueryHead(objFunc.Invoke(this as T));
        //}


        ///// <summary>
        ///// Queries the head asynchronous.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //public Task<WebHeaderCollection> QueryHeadAsync<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut> {
        //    return EveCrest.QueryHeadAsync(objFunc.Invoke(this as T));
        //}


        ///// <summary>
        ///// Queries the head.
        ///// </summary>
        ///// <typeparam name="TOut">The type of the t out.</typeparam>
        ///// <param name="objFunc">The object function.</param>
        ///// <returns>WebHeaderCollection.</returns>
        //public virtual WebHeaderCollection QueryHead<TOut>(Func<ICrestResource<T>, ILinkedEntity<TOut>> objFunc)
        //    where TOut : class, ICrestResource<TOut> {
        //    return EveCrest.QueryHead(objFunc.Invoke(this as T));
        //}
    }
}