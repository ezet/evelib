// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 11-03-2014
// ***********************************************************************
// <copyright file="BaseEntity.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.Core;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.RequestHandlers;

namespace eZet.EveLib.EveXmlModule {
    /// <summary>
    ///     Provides base properties and methods for Eve Online API classes.
    /// </summary>
    public abstract class BaseEntity {
        /// <summary>
        ///     The default URI
        /// </summary>
        private const string DefaultUri = "https://api.eveonline.com";

        /// <summary>
        ///     Default constructor
        /// </summary>
        protected BaseEntity() {
            var handler = new EveXmlRequestHandler();
            handler.Serializer = new XmlSerializer();
            handler.Cache = Config.CacheFactory("EveXml");
            RequestHandler = handler;
            BaseUri = DefaultUri;
        }

        /// <summary>
        ///     Gets or sets the type of the cache.
        /// </summary>
        /// <value>The type of the cache.</value>
        public CacheType CacheType { get; set; }

        /// <summary>
        ///     Returns true if the current request handler supports caching.
        /// </summary>
        /// <value><c>true</c> if this instance is cache handler; otherwise, <c>false</c>.</value>
        public bool IsCacheHandler {
            get { return cachedRequestHandler() != null; }
        }

        /// <summary>
        ///     Gets or sets the base url for entity requests
        /// </summary>
        /// <value>The base URI.</value>
        public string BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the requester this entity uses to perform requests.
        /// </summary>
        /// <value>The request handler.</value>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Cacheds the request handler.
        /// </summary>
        /// <returns>ICachedRequestHandler.</returns>
        private ICachedRequestHandler cachedRequestHandler() {
            return RequestHandler as ICachedRequestHandler;
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns>Task&lt;EveXmlResponse&lt;T&gt;&gt;.</returns>
        protected Task<EveXmlResponse<T>> requestAsync<T>(string relUri, params object[] args) where T : new() {
            Contract.Requires(BaseUri != null);
            Contract.Requires(args != null);
            var uri = new Uri(BaseUri + relUri + generateQueryString(null, args));
            return RequestHandler.RequestAsync<EveXmlResponse<T>>(uri);
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <returns>Task&lt;EveXmlResponse&lt;T&gt;&gt;.</returns>
        protected Task<EveXmlResponse<T>> requestAsync<T>(string relUri, ApiKey key) where T : new() {
            Contract.Requires(BaseUri != null);
            var uri = new Uri(BaseUri + relUri + generateQueryString(key));
            return RequestHandler.RequestAsync<EveXmlResponse<T>>(uri);
        }

        /// <summary>
        ///     Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="relUri">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns>Task&lt;EveXmlResponse&lt;T&gt;&gt;.</returns>
        protected Task<EveXmlResponse<T>> requestAsync<T>(string relUri, ApiKey key, params object[] args)
            where T : new() {
            Contract.Requires(BaseUri != null);
            Contract.Requires(args != null);
            var uri = new Uri(BaseUri + relUri + generateQueryString(key, args));
            return RequestHandler.RequestAsync<EveXmlResponse<T>>(uri);
        }

        /// <summary>
        ///     Generates a query string from the Api key and supplied arguments
        /// </summary>
        /// <param name="key">Optional; api key to generate query from</param>
        /// <param name="args">Optional; arguments to generate query from</param>
        /// <returns>System.String.</returns>
        protected string generateQueryString(ApiKey key = null, params object[] args) {
            Contract.Requires(args != null);
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