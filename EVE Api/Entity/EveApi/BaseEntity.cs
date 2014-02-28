using System;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Util;
using eZet.Eve.EveLib.Util.EveApi;

namespace eZet.Eve.EveLib.Entity.EveApi {
    public abstract class BaseEntity {

        /// <summary>
        /// The base url for entity requests
        /// </summary>
        protected Uri BaseUri { get; set; }

        protected BaseEntity() {
            BaseUri = new Uri("https://api.eveonline.com");
            RequestHandler = new IeCachedRequestHandler(new XmlSerializerWrapper());
        }

        /// <summary>
        /// The requester this entity uses to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relUri, params object[] args) where T : new() {
            var uri = new Uri(BaseUri, relUri + generateQueryString(null, args));
            return RequestHandler.Request<XmlResponse<T>>(uri);
        }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relUri, ApiKey key) where T : new() {
            var uri = new Uri(BaseUri, relUri + generateQueryString(key));
            return RequestHandler.Request<XmlResponse<T>>(uri);
        }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relUri, ApiKey key, params object[] args) where T : new() {
            var uri = new Uri(BaseUri, relUri + generateQueryString(key, args));
            return RequestHandler.Request<XmlResponse<T>>(uri);
        }

        /// <summary>
        /// Generates a query string from the Api key and supplied arguments
        /// </summary>
        /// <param name="key">Optional; api key to generate query from</param>
        /// <param name="args">Optional; arguments to generate query from</param>
        /// <returns></returns>
        protected string generateQueryString(ApiKey key = null, params object[] args) {
            var queryString = "?";
            if (key != null)
                queryString = "?keyID=" + key.KeyId + "&vCode=" + key.VCode + "&";
            for (var i = 0; i < args.Length; i += 2) {
                queryString += args[i] + "=" + args[i + 1] + "&";
            }
            return queryString;
        }
    }
}
