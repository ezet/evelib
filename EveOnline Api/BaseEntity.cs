using System;
using System.Diagnostics.Contracts;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveOnline.Model;
using eZet.EveLib.EveOnline.Util;

namespace eZet.EveLib.EveOnline {
    public abstract class BaseEntity {
        protected BaseEntity() {
            BaseUri = new Uri("https://api.eveonline.com");
            RequestHandler = new CachedRequestHandler(new XmlSerializerWrapper());
        }

        /// <summary>
        ///     The base url for entity requests
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        ///     The requester this entity uses to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected EveApiResponse<T> request<T>(string relUri, params object[] args) where T : new() {
            Contract.Requires(BaseUri != null);
            Contract.Requires(args != null);
            var uri = new Uri(BaseUri, relUri + generateQueryString(null, args));
            return RequestHandler.Request<EveApiResponse<T>>(uri);
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <returns></returns>
        protected EveApiResponse<T> request<T>(string relUri, ApiKey key) where T : new() {
            Contract.Requires(BaseUri != null);
            var uri = new Uri(BaseUri, relUri + generateQueryString(key));
            return RequestHandler.Request<EveApiResponse<T>>(uri);
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected EveApiResponse<T> request<T>(string relUri, ApiKey key, params object[] args) where T : new() {
            Contract.Requires(BaseUri != null);
            Contract.Requires(args != null);
            var uri = new Uri(BaseUri, relUri + generateQueryString(key, args));
            return RequestHandler.Request<EveApiResponse<T>>(uri);
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