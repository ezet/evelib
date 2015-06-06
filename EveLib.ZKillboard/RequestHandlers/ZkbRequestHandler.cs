// ***********************************************************************
// Assembly         : EveLib.ZKillboard
// Author           : Lars Kristian
// Created          : 06-18-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-02-2014
// ***********************************************************************
// <copyright file="ZkbRequestHandler.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.ZKillboardModule.Models;

namespace eZet.EveLib.ZKillboardModule.RequestHandlers {
    /// <summary>
    ///     Class ZkbRequestHandler.
    /// </summary>
    public class ZkbRequestHandler : ICachedRequestHandler {
        /// <summary>
        ///     The _trace
        /// </summary>
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Initializes a new instance of the <see cref="ZkbRequestHandler" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <param name="cache">The cache.</param>
        public ZkbRequestHandler(ISerializer serializer, IEveLibCache cache) {
            Serializer = serializer;
            Cache = cache;
        }

        /// <summary>
        ///     Gets or sets the serializer used to deserialize data
        /// </summary>
        /// <value>The serializer.</value>
        public ISerializer Serializer { get; set; }


        /// <summary>
        ///     Request as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> RequestAsync<T>(Uri uri) {
            _trace.TraceEvent(TraceEventType.Start, 0, "ZkbRequestHandler.RequestAsync(): {0}", uri);
            string data = null;
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.CacheOnly)
                data = await Cache.LoadAsync(uri).ConfigureAwait(false);
            bool isCached = data != null;
            if (isCached)
                return Serializer.Deserialize<T>(data);

            if (CacheLevel == CacheLevel.CacheOnly) return default(T);
            DateTime cacheTime;
            int requestCount, maxRequests;
            HttpWebRequest request = HttpRequestHelper.CreateRequest(uri);

            using (
                HttpWebResponse response = await HttpRequestHelper.GetResponseAsync(request).ConfigureAwait(false)) {
                data = await HttpRequestHelper.GetResponseContentAsync(response).ConfigureAwait(false);
                cacheTime = DateTime.Parse(response.GetResponseHeader("Expires"));
                int.TryParse(response.GetResponseHeader("X-Bin-Request-Count"), out requestCount);
                int.TryParse(response.GetResponseHeader("X-Bin-Max-Requests"), out maxRequests);
            }
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.Refresh)
                await Cache.StoreAsync(uri, cacheTime.ToUniversalTime(), data).ConfigureAwait(false);
            _trace.TraceEvent(TraceEventType.Stop, 0, "ZkbRequestHandler.RequestAsync()", uri);
            var result = Serializer.Deserialize<T>(data);
            var zkbResponse = result as ZkbResponse;
            if (zkbResponse != null) {
                zkbResponse.RequestCount = requestCount;
                zkbResponse.MaxRequests = maxRequests;
            }
            return result;
        }

        /// <summary>
        ///     Gets or sets the cache used by this request handler
        /// </summary>
        /// <value>The cache.</value>
        public IEveLibCache Cache { get; set; }

        /// <summary>
        ///     Gets or sets the cache level.
        /// </summary>
        /// <value>The cache level.</value>
        public CacheLevel CacheLevel { get; set; }
    }
}