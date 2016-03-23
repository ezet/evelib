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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using Newtonsoft.Json;

namespace eZet.EveLib.EveCrestModule.Models {
    /// <summary>
    ///     Represents a CREST collection response
    /// </summary>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TItem">The type of items in the collection</typeparam>
    [DataContract]
    [JsonObject]
    public abstract class CollectionResource<TCollection, TItem> : CrestResource<TCollection>, ICollectionResource<TCollection, TItem>, IEnumerable<TItem> where TCollection : CollectionResource<TCollection, TItem>, ICrestResource<TCollection> {
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
        public IReadOnlyList<TItem> Items { get; set; }

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
        public Href<TCollection> Next { get; set; }

        public CollectionResource<TCollection, TItem> NextResource { get; private set; }

            /// <summary>
        ///     Gets or sets the previous page.
        /// </summary>
        /// <value>The previous.</value>
        [DataMember(Name = "previous")]
        public Href<TCollection> Previous { get; set; }

        /// <summary>
        ///     Gets all items in the collection as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;TCollection&gt;&gt;.</returns>
        public async Task<IEnumerable<TItem>> AllItemsAsync() {
            // TODO: Store the items ?
            var collection = this;
            var list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            return list;
        }

        /// <summary>
        ///     Gets all the items in the collection.
        /// </summary>
        /// <returns>IEnumerable&lt;TCollection&gt;.</returns>
        public IEnumerable<TItem> AllItems() {
            return AllItemsAsync().Result;
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<IEnumerable<TOut>> QueryAsync<TOut>(
            Func<IEnumerable<TItem>, IEnumerable<ILinkedEntity<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var collection = this;
            var list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            var items = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(items).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public IEnumerable<TOut> Query<TOut>(Func<IEnumerable<TItem>, IEnumerable<ILinkedEntity<TOut>>> objFunc)
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
            Func<IEnumerable<TItem>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var collection = this;
            var list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            var item = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(item).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a collection of items.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public IEnumerable<TOut> Query<TOut>(Func<IEnumerable<TItem>, IEnumerable<Href<TOut>>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<TOut> QueryAsync<TOut>(Func<IEnumerable<TItem>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var collection = this;
            var list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            var item = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(item).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public TOut Query<TOut>(Func<IEnumerable<TItem>, Href<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }

        /// <summary>
        ///     Queries a collection resource for a single item, async.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public async Task<TOut> QueryAsync<TOut>(Func<IEnumerable<TItem>, ILinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            var collection = this;
            var list = collection.Items.ToList();
            if (EveCrest.EnableAutomaticPaging) {
                while (collection.Next != null) {
                    collection = await EveCrest.LoadAsync(collection.Next).ConfigureAwait(false);
                    list.AddRange(collection.Items);
                }
            }
            var item = objFunc.Invoke(list);
            return await EveCrest.LoadAsync(item).ConfigureAwait(false);
        }

        /// <summary>
        ///     Queries a collection resource for a single item.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="objFunc">The object function.</param>
        /// <returns>Task&lt;TOut[]&gt;.</returns>
        public TOut Query<TOut>(Func<IEnumerable<TItem>, ILinkedEntity<TOut>> objFunc)
            where TOut : class, ICrestResource<TOut> {
            return QueryAsync(objFunc).Result;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<TItem> GetEnumerator() {
            foreach (var item in Items) {
                yield return item;
            }
            if (Next == null) yield break;
            if (NextResource == null)
                NextResource = EveCrest.Load(Next);
            var iter = NextResource.GetEnumerator();
            while (iter.MoveNext())
                yield return iter.Current;

        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            foreach (var item in Items) {
                yield return item;
            }
            if (Next == null) yield break;
            if (NextResource == null)
                NextResource = EveCrest.Load(Next);
            var iter = NextResource.GetEnumerator();
            while (iter.MoveNext())
                yield return iter.Current;

        }
    }
}