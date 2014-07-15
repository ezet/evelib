using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.RequestHandlers;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides base properties and methods for Eve Online API classes.
    /// </summary>
    public abstract class BaseEntity {
        private const string DefaultUri = "https://api.eveonline.com";

        /// <summary>
        /// Default construcor
        /// </summary>
        protected BaseEntity() {
            var handler = new EveOnlineRequestHandler();
            handler.Serializer = new XmlSerializer();
            handler.Cache = new EveLibFileCache();
            RequestHandler = handler;
            BaseUri = DefaultUri;
            EnableCacheLoad = true;
            EnableCacheStore = true;
        }

        /// <summary>
        ///     Gets or sets whether data can be loaded from the cache.
        /// </summary>
        public bool EnableCacheLoad {
            get { return cachedRequestHandler() != null && cachedRequestHandler().EnableCacheLoad; }
            set { if (cachedRequestHandler() != null) cachedRequestHandler().EnableCacheLoad = value; }
        }

        public CacheType CacheType { get; set; }

        /// <summary>
        ///     Gets or sets whether data can be stored in the cache.
        /// </summary>
        public bool EnableCacheStore {
            get { return cachedRequestHandler() != null && cachedRequestHandler().EnableCacheStore; }
            set { if (cachedRequestHandler() != null) cachedRequestHandler().EnableCacheStore = value; }
        }

        /// <summary>
        ///     Returns true if the current request handler supports caching.
        /// </summary>
        public bool IsCacheHandler {
            get { return cachedRequestHandler() != null; }
        }

        /// <summary>
        ///     Gets or sets the base url for entity requests
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the requester this entity uses to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        private ICachedRequestHandler cachedRequestHandler() {
            return RequestHandler as ICachedRequestHandler;
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected Task<EveApiResponse<T>> requestAsync<T>(string relUri, params object[] args) where T : new() {
            Contract.Requires(BaseUri != null);
            Contract.Requires(args != null);
            var uri = new Uri(BaseUri + relUri + generateQueryString(null, args));
            return RequestHandler.RequestAsync<EveApiResponse<T>>(uri);
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <returns></returns>
        protected Task<EveApiResponse<T>> requestAsync<T>(string relUri, ApiKey key) where T : new() {
            Contract.Requires(BaseUri != null);
            var uri = new Uri(BaseUri + relUri + generateQueryString(key));
            return RequestHandler.RequestAsync<EveApiResponse<T>>(uri);
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected Task<EveApiResponse<T>> requestAsync<T>(string relUri, ApiKey key, params object[] args)
            where T : new() {
            Contract.Requires(BaseUri != null);
            Contract.Requires(args != null);
            var uri = new Uri(BaseUri + relUri + generateQueryString(key, args));
            return RequestHandler.RequestAsync<EveApiResponse<T>>(uri);
        }

        /// <summary>
        ///     Generates a query string from the Api key and supplied arguments
        /// </summary>
        /// <param name="key">Optional; api key to generate query from</param>
        /// <param name="args">Optional; arguments to generate query from</param>
        /// <returns></returns>
        protected string generateQueryString(ApiKey key = null, params object[] args) {
            Contract.Requires(args != null);
            string queryString = "?";
            if (key != null)
                queryString = "?keyID=" + key.KeyId + "&vCode=" + key.VCode + "&";
            for (int i = 0; i < args.Length; i += 2) {
                queryString += args[i] + "=" + args[i + 1] + "&";
            }
            return queryString;
        }
    }
}