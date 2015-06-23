// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CollectionResource.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a CREST collection response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCollection">The type of items in the collection</typeparam>
    [DataContract]
    public abstract class CollectionResource<T, TCollection> : CrestResource<T>
        where T : CollectionResource<T, TCollection>, ICrestResource<T> {
        /// <summary>
        ///     The total number of items in the collection
        /// </summary>
        /// <value>The total count.</value>
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        ///     The items on this page in the collection
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name = "items")]
        public IReadOnlyList<TCollection> Items { get; set; }

        /// <summary>
        ///     The number of pages in the collection
        /// </summary>
        /// <value>The page count.</value>
        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

        /// <summary>
        ///     Gets or sets the next page.
        /// </summary>
        /// <value>The next.</value>
        [DataMember(Name = "next")]
        public Href<T> Next { get; set; }

        /// <summary>
        ///     Gets or sets the previous page.
        /// </summary>
        /// <value>The previous.</value>
        [DataMember(Name = "previous")]
        public Href<T> Previous { get; set; }


        /// <summary>
        /// Gets all items in the collection as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;TCollection&gt;&gt;.</returns>
        public async Task<IEnumerable<TCollection>> AllItemsAsync() {
            CollectionResource<T, TCollection> collection = this;
            List<TCollection> list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            return list;
        }


        /// <summary>
        /// Gets all the items in the collection.
        /// </summary>
        /// <returns>IEnumerable&lt;TCollection&gt;.</returns>
        public IEnumerable<TCollection> AllItems() {
            return AllItemsAsync().Result;
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<IEnumerable<TOut>> QueryAsync<TOut>(
            Func<IEnumerable<TCollection>, IEnumerable<ILinkedEntity<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            CollectionResource<T, TCollection> collection = this;
            List<TCollection> list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            IEnumerable<ILinkedEntity<TOut>> items = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(items).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public IEnumerable<TOut> Query<TOut>(Func<IEnumerable<TCollection>, IEnumerable<ILinkedEntity<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<IEnumerable<TOut>> QueryAsync<TOut>(
            Func<IEnumerable<TCollection>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            CollectionResource<T, TCollection> collection = this;
            List<TCollection> list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            IEnumerable<Href<TOut>> item = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(item).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public IEnumerable<TOut> Query<TOut>(Func<IEnumerable<TCollection>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<TOut> QueryAsync<TOut>(Func<IEnumerable<TCollection>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            CollectionResource<T, TCollection> collection = this;
            List<TCollection> list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            Href<TOut> item = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(item).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public TOut Query<TOut>(Func<IEnumerable<TCollection>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<TOut> QueryAsync<TOut>(Func<IEnumerable<TCollection>, ILinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            CollectionResource<T, TCollection> collection = this;
            List<TCollection> list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            ILinkedEntity<TOut> item = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(item).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a single item.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public TOut Query<TOut>(Func<IEnumerable<TCollection>, ILinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }
    }
}