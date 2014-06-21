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
    /// Class for accessing the ZKillboard API
    /// </summary>
    public class ZKillboard {
        /// <summary>
        /// Default base URI.
        /// </summary>
        public const string DefaultUri = "https://zkillboard.com";

        /// <summary>
        /// Default constructor
        /// </summary>
        public ZKillboard() {
            RequestHandler = new ZkbRequestHandler(new JsonSerializer(), new EveLibFileCache());
            BaseUri = new Uri(DefaultUri);
        }

        /// <summary>
        ///     Gets or sets whether data can be loaded from the cache.
        /// </summary>
        public bool EnableCacheLoad {
            get { return cachedRequestHandler() != null && cachedRequestHandler().EnableCacheLoad; }
            set { if (cachedRequestHandler() != null) cachedRequestHandler().EnableCacheLoad = value; }
        }

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
        /// Gets or sets the default base URI
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets the request handler
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        private ICachedRequestHandler cachedRequestHandler() {
            return RequestHandler as ICachedRequestHandler;
        }

        /// <summary>
        /// Returns kill mails
        /// </summary>
        /// <param name="options">ZKillboard options</param>
        /// <returns>Kill mails</returns>
        public ZkbResponse GetKills(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetKillsAsync(options).Result;
        }

        /// <summary>
        /// Returns kill mails
        /// </summary>
        /// <param name="options">ZKillboard options</param>
        /// <returns>Kill mails</returns>
        public Task<ZkbResponse> GetKillsAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api/kills";
            relPath = options.GetQueryString(relPath);
            return requestAsync<ZkbResponse>(new Uri(BaseUri, relPath));
        }

        /// <summary>
        /// Returns loss mails
        /// </summary>
        /// <param name="options">ZKillboard options</param>
        /// <returns>Loss mails</returns>
        public ZkbResponse GetLosses(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetLossesAsync(options).Result;
        }

        /// <summary>
        /// Returns loss mails
        /// </summary>
        /// <param name="options">ZKillboard options</param>
        /// <returns>Loss mails</returns>
        public Task<ZkbResponse> GetLossesAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api/losses";
            relPath = options.GetQueryString(relPath);
            return requestAsync<ZkbResponse>(new Uri(BaseUri, relPath));
        }

        /// <summary>
        /// Returns both Kill and loss mails
        /// </summary>
        /// <param name="options">ZKillboard options</param>
        /// <returns>Kill and loss mails</returns>
        public ZkbResponse GetAll(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetAllAsync(options).Result;
        }

        /// <summary>
        /// Returns both Kill and loss mails
        /// </summary>
        /// <param name="options">ZKillboard options</param>
        /// <returns>Kill and loss mails</returns>
        public Task<ZkbResponse> GetAllAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api";
            relPath = options.GetQueryString(relPath);
            return requestAsync<ZkbResponse>(new Uri(BaseUri, relPath));
        }

        private Task<T> requestAsync<T>(Uri uri) {
            return RequestHandler.RequestAsync<T>(uri);
        }
    }
}