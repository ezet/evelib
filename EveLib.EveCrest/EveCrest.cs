// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 08-09-2015
//
// Last Modified By : larsd
// Last Modified On : 03-23-2016
// ***********************************************************************
// <copyright file="EveCrest.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveAuthModule;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using eZet.EveLib.EveCrestModule.RequestHandlers;
using eZet.EveLib.EveCrestModule.RequestHandlers.eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.EveCrestModule {
    /// <summary>
    /// Enum EveCrest Access Mode
    /// </summary>
    public enum CrestMode {
        /// <summary>
        /// Public CREST
        /// </summary>
        Public,

        /// <summary>
        /// Authenticated CREST. This requires a valid AccessToken or a valid RefreshToken and EncryptedKey
        /// </summary>
        Authenticated
    }


    /// <summary>
    /// Provides access to the Eve Online CREST API.
    /// </summary>
    public class EveCrest {
        /// <summary>
        /// The default URI used to access the public CREST API. This can be overridded by setting the Host.
        /// </summary>
        public const string DefaultPublicHost = "https://public-crest.eveonline.com/";

        /// <summary>
        /// The default URI used to access the authenticated CREST API. This can be overridded by setting the Host.
        /// </summary>
        public const string DefaultAuthHost = "https://crest-tq.eveonline.com/";

        /// <summary>
        /// The obsolete message
        /// </summary>
        private const string ObsoleteMessage =
            "This method uses statically typed links, and is not how CREST is meant to be used. Please use GetRoot() or GetRootAsync() and navigate from there.";

        /// <summary>
        /// The _trace
        /// </summary>
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        /// The _host
        /// </summary>
        private string _host;

        /// <summary>
        /// The CREST root if cached
        /// </summary>
        private CrestRoot _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="EveCrest" /> class, in Public mode.
        /// </summary>
        public EveCrest() {
            RequestHandler = new CachedCrestRequestHandler(new JsonSerializer("yyyy.MM.dd HH:mm:ss"));
            ImageRequestHandler = new ImageRequestHandler();
            ApiPath = "/";
            Host = DefaultPublicHost;
            Mode = CrestMode.Public;
            EnableRootCache = true;
            EnableAutomaticPaging = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EveCrest" /> class, in Authenticated mode.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public EveCrest(string accessToken)
            : this() {
            AccessToken = accessToken;
            Host = DefaultAuthHost;
            Mode = CrestMode.Authenticated;
            EveAuth = new EveAuth();
            EnableAutomaticTokenRefresh = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EveCrest" /> class, in Authenticated mode.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="encodedKey">The encoded key.</param>
        public EveCrest(string refreshToken, string encodedKey)
            : this() {
            RefreshToken = refreshToken;
            AccessToken = "";
            EncodedKey = encodedKey;
            Host = DefaultAuthHost;
            Mode = CrestMode.Authenticated;
            EveAuth = new EveAuth();
            EnableAutomaticTokenRefresh = true;
        }


        /// <summary>
        /// Gets or sets the host used to access the EveCrest API.
        /// </summary>
        /// <value>The base public URI.</value>
        public string Host {
            get { return _host; }
            set { _host = value.TrimEnd('/', '\\'); }
        }

        /// <summary>
        /// Gets or sets the IEveAuth instance used for Eve SSO.
        /// </summary>
        /// <value>The eve sso.</value>
        public IEveAuth EveAuth { get; set; }


        /// <summary>
        /// Gets or sets the CREST Access Token
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the encoded key. This is required to refresh access tokens.
        /// </summary>
        /// <value>The encoded key.</value>
        public string EncodedKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether EveCrest is allowed to cache the CrestRoot object. This is enabled by
        /// default.
        /// </summary>
        /// <value><c>true</c> if [allow root cache]; otherwise, <c>false</c>.</value>
        public bool EnableRootCache { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow the library to automatically refresh the access token. This
        /// requires a valid RefreshToken and EncryptedKey to be set. This is enabled by default if using the RefreshToken
        /// ctor.
        /// </summary>
        /// <value><c>true</c> if [allow automatic refresh]; otherwise, <c>false</c>.</value>
        public bool EnableAutomaticTokenRefresh { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow Query() methods to allow automatic paging. This may perform
        /// additional web requests.
        /// </summary>
        /// <value><c>true</c> if [allow automatic paging]; otherwise, <c>false</c>.</value>
        public bool EnableAutomaticPaging { get; set; }

        /// <summary>
        /// Gets the CREST access mode.
        /// </summary>
        /// <value>The mode.</value>
        public CrestMode Mode { get; }

        /// <summary>
        /// Gets or sets the request handler.
        /// </summary>
        /// <value>The request handler.</value>
        public ICachedCrestRequestHandler RequestHandler { get; set; }

        /// <summary>
        /// Gets or sets the image request handler.
        /// </summary>
        /// <value>The image request handler.</value>
        public IImageRequestHandler ImageRequestHandler { get; set; }

        /// <summary>
        /// Gets or sets the path to the API root relative to the host.
        /// </summary>
        /// <value>The API path.</value>
        public string ApiPath { get; set; }

        /// <summary>
        /// Refreshes the access token. This requires a valid RefreshToken and EncodedKey to have been set.
        /// The EveCrest instance is updated with the new access token.
        /// </summary>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> RefreshAccessTokenAsync() {
            var response = await EveAuth.RefreshAsync(EncodedKey, RefreshToken).ConfigureAwait(false);
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
            return response;
        }

        /// <summary>
        /// Refreshes the access token. This requires a valid RefreshToken and EncodedKey to have been set.
        /// The EveCrest instance is updated with the new access token.
        /// </summary>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public AuthResponse RefreshAccessToken() {
            var response = EveAuth.RefreshAsync(EncodedKey, RefreshToken).Result;
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
            return response;
        }


        ///// <summary>
        ///// Queries the head asynchronous.
        ///// </summary>
        ///// <param name="uri">The URI.</param>
        ///// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        //public Task<WebHeaderCollection> QueryHeadAsync(string uri) {
        //    return headAsync(uri);
        //}

        ///// <summary>
        ///// Queries the head.
        ///// </summary>
        ///// <param name="uri">The URI.</param>
        ///// <returns>WebHeaderCollection.</returns>
        //public WebHeaderCollection QueryHead(string uri) {
        //    return QueryHeadAsync(uri).Result;
        //}


        /// <summary>
        /// Queries the head asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        public Task<WebHeaderCollection> QueryHeadAsync<T>(ICrestResource<T> resource) where T : class, ICrestResource<T> {
            return headAsync(resource.Uri.ToString());
        }

        /// <summary>
        /// Queries the head.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The resource.</param>
        /// <returns>WebHeaderCollection.</returns>
        public WebHeaderCollection QueryHead<T>(ICrestResource<T> resource) where T : class, ICrestResource<T> {
            return QueryHeadAsync(resource).Result;
        }

        /// <summary>
        /// Queries the head asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="href">The href.</param>
        /// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        public Task<WebHeaderCollection> QueryHeadAsync<T>(Href<T> href) {
            return headAsync(href.Uri);
        }

        /// <summary>
        /// Queries the head.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="href">The href.</param>
        /// <returns>WebHeaderCollection.</returns>
        public WebHeaderCollection QueryHead<T>(Href<T> href) {
            return QueryHeadAsync(href).Result;
        }

        /// <summary>
        /// Queries the head asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;WebHeaderCollection&gt;.</returns>
        public Task<WebHeaderCollection> QueryHeadAsync<T>(ILinkedEntity<T> entity) {
            return headAsync(entity.Href.Uri);
        }

        /// <summary>
        /// Queries the head.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>WebHeaderCollection.</returns>
        public WebHeaderCollection QueryHead<T>(ILinkedEntity<T> entity) {
            return QueryHeadAsync(entity).Result;
        }

        ///// <summary>
        ///// Queries the options asynchronous.
        ///// </summary>
        ///// <param name="uri">The URI.</param>
        ///// <returns>Task&lt;CrestOptions&gt;.</returns>
        //public Task<CrestOptions> QueryOptionsAsync(string uri) {
        //    return optionsAsync(uri);
        //}

        ///// <summary>
        ///// Queries the options.
        ///// </summary>
        ///// <param name="uri">The URI.</param>
        ///// <returns>CrestOptions.</returns>
        //public CrestOptions QueryOptions(string uri) {
        //    return QueryOptionsAsync(uri).Result;
        //}

        /// <summary>
        /// Queries the options asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="href">The href.</param>
        /// <returns>Task&lt;CrestOptions&gt;.</returns>
        public Task<CrestOptions> QueryOptionsAsync<T>(ICrestResource<T> href) where T : class, ICrestResource<T> {
            return optionsAsync(href.Uri.ToString());
        }

        /// <summary>
        /// Queries the options.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="href">The href.</param>
        /// <returns>CrestOptions.</returns>
        public CrestOptions QueryOptions<T>(ICrestResource<T> href) where T : class, ICrestResource<T> {
            return QueryOptionsAsync(href).Result;
        }

        /// <summary>
        /// Queries the options asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="href">The href.</param>
        /// <returns>Task&lt;CrestOptions&gt;.</returns>
        public Task<CrestOptions> QueryOptionsAsync<T>(Href<T> href) {
            return optionsAsync(href.Uri);
        }

        /// <summary>
        /// Queries the options.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="href">The href.</param>
        /// <returns>CrestOptions.</returns>
        public CrestOptions QueryOptions<T>(Href<T> href) {
            return QueryOptionsAsync(href).Result;
        }

        /// <summary>
        /// Queries the options asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;CrestOptions&gt;.</returns>
        public Task<CrestOptions> QueryOptionsAsync<T>(ILinkedEntity<T> entity) {
            return optionsAsync(entity.Href.Uri);
        }

        /// <summary>
        /// Queries the options.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>CrestOptions.</returns>
        public CrestOptions QueryOptions<T>(ILinkedEntity<T> entity) {
            return QueryOptionsAsync(entity).Result;
        }

        /// <summary>
        /// Loads the image asynchronous.
        /// </summary>
        /// <param name="link">The image link.</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        public Task<byte[]> LoadImageAsync(ImageHref link) {
            return ImageRequestHandler.RequestImageDataAsync(new Uri(link.Uri));
        }

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <param name="link">The image link</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        public byte[] LoadImage(ImageHref link) {
            return LoadImageAsync(link).Result;
        }


        /// <summary>
        /// Loads the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TParam">The type of the t parameter.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T, TParam>(Href<T> uri, IQueryParameter<TParam> param) where T : class, ICrestResource<T> {
            return uri == null
                ? Task.FromResult(default(T))
                : getAsync<T>((createQueryString(uri.Uri, QueryParameters.GetParameterName<TParam>(), param.Uri.ToString())));
        }

        /// <summary>
        /// Loads the specified URI.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TParam">The type of the t parameter.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>T.</returns>
        public T Load<T, TParam>(Href<T> uri, IQueryParameter<TParam> param) where T : class, ICrestResource<T> {
            return LoadAsync(uri, param).Result;
        }

        /// <summary>
        /// Loads the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TParam">The type of the t parameter.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T, TParam>(Href<T> uri, LinkedEntity<TParam> param) where T : class, ICrestResource<T> where TParam : IQueryParameter<TParam> {
            return uri == null
                ? Task.FromResult(default(T))
                : getAsync<T>((createQueryString(uri.Uri, QueryParameters.GetParameterName<TParam>(), param.Href.ToString())));
        }

        /// <summary>
        /// Loads the specified URI.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TParam">The type of the t parameter.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>T.</returns>
        public T Load<T, TParam>(Href<T> uri, LinkedEntity<TParam> param) where T : class, ICrestResource<T> where TParam : IQueryParameter<TParam> {
            return LoadAsync(uri, param).Result;
        }

        /// <summary>
        /// Loads a Href async.
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="uri">The Href that should be loaded</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T>(Href<T> uri, params string[] parameters) where T : class, ICrestResource<T> {
            return uri == null
                ? Task.FromResult(default(T))
                : getAsync<T>((createQueryString(uri.Uri, parameters)));
        }

        /// <summary>
        /// Loads a Href
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="uri">The Href that should be loaded</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public T Load<T>(Href<T> uri, params string[] parameters) where T : class, ICrestResource<T> {
            return LoadAsync(uri, parameters).Result;
        }

        /// <summary>
        /// Loads a ILinkedEntity async
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="entity">The items that should be loaded</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T>(ILinkedEntity<T> entity, params string[] parameters)
            where T : class, ICrestResource<T> {
            return entity == null ? Task.FromResult(default(T)) : LoadAsync(entity.Href, parameters);
        }

        /// <summary>
        /// Loads a ILinkedEntity
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="entity">The items that should be loaded</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public T Load<T>(ILinkedEntity<T> entity, params string[] parameters) where T : class, ICrestResource<T> {
            return LoadAsync(entity, parameters).Result;
        }

        /// <summary>
        /// Loads a ILinkedEntity collection async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public Task<IEnumerable<T>> LoadAsync<T>(IEnumerable<ILinkedEntity<T>> items, params string[] parameters)
            where T : class, ICrestResource<T> {
            if (items == null) return Task.FromResult(new List<T>().AsEnumerable());
            return LoadAsync(items.Select(r => r.Href), parameters);
        }

        /// <summary>
        /// Loads a ILinkedEntity collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public IEnumerable<T> Load<T>(IEnumerable<ILinkedEntity<T>> items, params string[] parameters)
            where T : class, ICrestResource<T> {
            return LoadAsync(items, parameters).Result;
        }


        /// <summary>
        /// Loads a Href collection async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public Task<IEnumerable<T>> LoadAsync<T>(IEnumerable<Href<T>> items, params string[] parameters)
            where T : class, ICrestResource<T> {
            if (items == null) return Task.FromResult(new List<T>().AsEnumerable());
            var list = items.Select(self => LoadAsync(self, parameters)).ToList();
            return Task.WhenAll(list).ContinueWith(task => task.Result.AsEnumerable());
        }

        /// <summary>
        /// Loads a Href collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public IEnumerable<T> Load<T>(IEnumerable<Href<T>> items, params string[] parameters)
            where T : class, ICrestResource<T> {
            return LoadAsync(items, parameters).Result;
        }

        /// <summary>
        /// Returns the CREST root
        /// </summary>
        /// <returns>Task&lt;CrestRoot&gt;.</returns>
        public async Task<CrestRoot> GetRootAsync() {
            if (_root == null || !EnableRootCache)
                _root = await getAsync<CrestRoot>(Host).ConfigureAwait(false);
            return _root;
        }

        /// <summary>
        /// Returns the CREST root
        /// </summary>
        /// <returns>CrestRoot.</returns>
        public CrestRoot GetRoot() {
            return GetRootAsync().Result;
        }


        /// <summary>
        /// save entity as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="forcePostRequest">if set to <c>true</c> [force post request].</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> SaveEntityAsync(IEditableEntity entity, bool forcePostRequest = false) {
            if (!forcePostRequest && entity.Href != null) return UpdateEntityAsync(entity);
            return AddEntityAsync(entity);
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="forcePostRequest">if set to <c>true</c> [force post request].</param>
        /// <returns>System.Boolean.</returns>
        public bool SaveEntity(IEditableEntity entity, bool forcePostRequest = false) {
            return SaveEntityAsync(entity, forcePostRequest).Result;
        }


        /// <summary>
        /// Deletes the entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> DeleteEntityAsync(IEditableEntity entity) {
            return deleteAsync(entity);
        }


        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Boolean.</returns>
        public bool DeleteEntity(IEditableEntity entity) {
            return DeleteEntityAsync(entity).Result;
        }

        /// <summary>
        /// Updates the entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Boolean&gt;.</returns>
        public Task<bool> UpdateEntityAsync(IEditableEntity entity) {
            return putAsync(entity);
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Boolean.</returns>
        public bool UpdateEntity(IEditableEntity entity) {
            return UpdateEntityAsync(entity).Result;
        }

        /// <summary>
        /// Adds the entity asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> AddEntityAsync(IEditableEntity entity) {
            var uri = await postAsync(entity).ConfigureAwait(false);
            if (uri != null) entity.PostUri = uri;
            return true;
        }

        /// <summary>
        /// Adds the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Boolean.</returns>
        public bool AddEntity(IEditableEntity entity) {
            return AddEntityAsync(entity).Result;
        }



        /// <summary>
        /// Returns data on the specified killmail.
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public Task<Killmail> GetKillmailAsync(long id, string hash) {
            var uri = Host + "/killmails/" + id + "/" + hash + "/";
            return getAsync<Killmail>(uri);
        }

        /// <summary>
        /// Returns data on the specified killmail.
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public Killmail GetKillmail(long id, string hash) {
            return GetKillmailAsync(id, hash).Result;
        }

        /// <summary>
        /// Gets the character stats.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Threading.Tasks.Task&lt;eZet.EveLib.EveCrestModule.Models.CharacterStats&gt;.</returns>
        public Task<CharacterStats> GetCharacterStats(long id) {
            var uri = "https://characterstats.tech.ccp.is/v1/" + id + "/";
            return getAsync<CharacterStats>(uri);
        }

        #region Obsolete
        /// <summary>
        /// Returns a list of all active incursions.
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IncursionCollection> GetIncursionsAsync() {
            string relPath = Host + "/incursions/";
            return getAsync<IncursionCollection>(relPath);
        }

        /// <summary>
        /// Returns a list of all active incursions.
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        [Obsolete(ObsoleteMessage)]
        public IncursionCollection GetIncursions() {
            return GetIncursionsAsync().Result;
        }

        /// <summary>
        /// Returns a list of all alliances.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the response.</param>
        /// <returns>A list of all alliances.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<AllianceCollection> GetAlliancesAsync(int page = 1) {
            var relPath = Host + "alliances/?page=" + page;
            return getAsync<AllianceCollection>(relPath);
        }

        /// <summary>
        /// Returns a list of all alliances.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all alliances.</returns>
        [Obsolete(ObsoleteMessage)]
        public AllianceCollection GetAlliances(int page = 1) {
            return GetAlliancesAsync(page).Result;
        }

        /// <summary>
        /// Returns data about a specific alliance.
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<Alliance> GetAllianceAsync(long allianceId) {
            var relPath = Host + "alliances/" + allianceId + "/";
            return getAsync<Alliance>(relPath);
        }

        /// <summary>
        /// Returns data about a specific alliance.
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        [Obsolete(ObsoleteMessage)]
        public Alliance GetAlliance(long allianceId) {
            return GetAllianceAsync(allianceId).Result;
        }

        /// <summary>
        /// Returns daily price and volume history for a specific region and item type.
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        //[Obsolete(ObsoleteMessage)]
        public Task<MarketHistoryCollection> GetMarketHistoryAsync(int regionId, int typeId) {
            var relPath = Host + "/market/" + regionId + "/types/" + typeId + "/history/";
            return getAsync<MarketHistoryCollection>(relPath);
        }

        /// <summary>
        /// Returns daily price and volume history for a specific region and item type.
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        //[Obsolete(ObsoleteMessage)]
        public MarketHistoryCollection GetMarketHistory(int regionId, int typeId) {
            return GetMarketHistoryAsync(regionId, typeId).Result;
        }

        /// <summary>
        /// Returns the average and adjusted values for all items
        /// </summary>
        /// <returns>Task&lt;MarketTypePriceCollection&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<MarketTypePriceCollection> GetMarketPricesAsync() {
            string relpath = Host + "/market/prices/";
            return getAsync<MarketTypePriceCollection>(relpath);
        }

        /// <summary>
        /// Returns the average and adjusted values for all items
        /// </summary>
        /// <returns>MarketTypePriceCollection.</returns>
        [Obsolete(ObsoleteMessage)]
        public MarketTypePriceCollection GetMarketPrices() {
            return GetMarketPricesAsync().Result;
        }

        /// <summary>
        /// Returns a list of all wars.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<WarCollection> GetWarsAsync(int page = 1) {
            var relPath = Host + "/wars/?page=" + page;
            return getAsync<WarCollection>(relPath);
        }

        /// <summary>
        /// Returns a list of all wars.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        [Obsolete(ObsoleteMessage)]
        public WarCollection GetWars(int page = 1) {
            return GetWarsAsync(page).Result;
        }

        /// <summary>
        /// Returns data for a specific war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>Data for the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<War> GetWarAsync(int warId) {
            var relPath = Host +  "/wars/" + warId + "/";
            return getAsync<War>(relPath);
        }

        /// <summary>
        /// Returns data for a specific war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>Data for the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public War GetWar(int warId) {
            return GetWarAsync(warId).Result;
        }

        /// <summary>
        /// Returns a list of all killmails related to a specified war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<KillmailCollection> GetWarKillmailsAsync(int warId) {
            var relPath = Host + "/wars/" + warId + "/killmails/all/";
            return getAsync<KillmailCollection>(relPath);
        }

        /// <summary>
        /// Returns a list of all killmails related to a specified war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public KillmailCollection GetWarKillmails(int warId) {
            return GetWarKillmailsAsync(warId).Result;
        }


        /// <summary>
        /// Returns a list of industry systems and prices
        /// </summary>
        /// <returns>Task&lt;IndustrySystemCollection&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustrySystemCollection> GetIndustrySystemsAsync() {
            string relPath = Host + "/industry/systems/";
            return getAsync<IndustrySystemCollection>(relPath);
        }

        /// <summary>
        /// Returns a list of industry systems and prices
        /// </summary>
        /// <returns>IndustrySystemCollection.</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustrySystemCollection GetIndustrySystems() {
            return GetIndustrySystemsAsync().Result;
        }


        /// <summary>
        /// Returns a collection of all industry facilities
        /// </summary>
        /// <returns>Task&lt;IndustryFacilityCollection&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustryFacilityCollection> GetIndustryFacilitiesAsync() {
            string relPath = Host + "/industry/facilities/";
            return getAsync<IndustryFacilityCollection>(relPath);
        }

        /// <summary>
        /// Returns a collection of all industry facilities
        /// </summary>
        /// <returns>IndustryFacilityCollection.</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustryFacilityCollection GetIndustryFacilities() {
            return GetIndustryFacilitiesAsync().Result;
        }
        #endregion

        /// <summary>
        /// Tries the refresh token asynchronous.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        private Task tryRefreshTokenAsync(EveCrestException e) {
            if (!EnableAutomaticTokenRefresh) throw e;
            var error = e.WebException.Response as HttpWebResponse;
            if (error == null || error.StatusCode != HttpStatusCode.Unauthorized) throw e;
            return RefreshAccessTokenAsync();
        }


        /// <summary>
        /// put as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        private async Task<bool> putAsync(IEditableEntity entity) {
            if (string.IsNullOrEmpty(entity.Href)) return await Task.FromResult(false);
            var data = RequestHandler.Serializer.Serialize(entity);
            try {
                return
                    await RequestHandler.PutAsync(new Uri(entity.Href), AccessToken, data).ConfigureAwait(false);
            }
            catch (EveCrestException e) {
                await tryRefreshTokenAsync(e).ConfigureAwait(false);
                return
                    await RequestHandler.PutAsync(new Uri(entity.Href), AccessToken, data).ConfigureAwait(false);
            }
        }


        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        private async Task<bool> deleteAsync(IEditableEntity entity) {
            if (string.IsNullOrEmpty(entity.Href)) return await Task.FromResult(false);
            bool ret;
            try {
                ret = await RequestHandler.DeleteAsync(new Uri(entity.Href), AccessToken).ConfigureAwait(false);
            }
            catch (EveCrestException e) {
                await tryRefreshTokenAsync(e).ConfigureAwait(false);
                ret = await RequestHandler.DeleteAsync(new Uri(entity.Href), AccessToken).ConfigureAwait(false);
            }
            entity.Href = null;
            return ret;
        }


        /// <summary>
        /// post as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        private async Task<string> postAsync(IEditableEntity entity) {
            var data = RequestHandler.Serializer.Serialize(entity);
            try {
                return
                    await RequestHandler.PostAsync(new Uri(entity.PostUri), AccessToken, data).ConfigureAwait(false);
            }
            catch (EveCrestException e) {
                await tryRefreshTokenAsync(e).ConfigureAwait(false);
                return
                    await RequestHandler.PostAsync(new Uri(entity.PostUri), AccessToken, data).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///     Optionses the asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;CrestOptions&gt;.</returns>
        private async Task<CrestOptions> optionsAsync(string url) {
            var uri = new Uri(url);
            CrestOptions response;
            if (Mode == CrestMode.Authenticated) {
                try {
                    response =
                        await RequestHandler.OptionsAsync(uri).ConfigureAwait(false);
                }
                catch (EveCrestException e) {
                    await tryRefreshTokenAsync(e).ConfigureAwait(false);
                    response =
                        await RequestHandler.OptionsAsync(uri).ConfigureAwait(false);
                }
            }
            else {
                response = await RequestHandler.OptionsAsync(uri).ConfigureAwait(false);
            }
            response?.Inject(this);
            return response;
        }

        private async Task<WebHeaderCollection> headAsync(string url) {
            var uri = new Uri(url);
            if (Mode == CrestMode.Authenticated) {
                try {
                    return await RequestHandler.HeadAsync(uri, AccessToken).ConfigureAwait(false);
                }
                catch (EveCrestException e) {
                    await tryRefreshTokenAsync(e).ConfigureAwait(false);

                    return await RequestHandler.HeadAsync(uri, AccessToken).ConfigureAwait(false);
                }
            }
            return await RequestHandler.HeadAsync(uri, null).ConfigureAwait(false);
        }

        /// <summary>
        ///     Gets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The path.</param>
        /// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
        private async Task<T> getAsync<T>(string url) where T : class, ICrestResource<T> {
            T response;
            //url = string.IsNullOrEmpty(url) ? Host : url;
            var uri = new Uri(url);
            if (Mode == CrestMode.Authenticated) {
                try {
                    response =
                        await RequestHandler.GetAsync<T>(uri, AccessToken).ConfigureAwait(false);
                }
                catch (EveCrestException e) {
                    await tryRefreshTokenAsync(e).ConfigureAwait(false);
                    response =
                        await RequestHandler.GetAsync<T>(uri, AccessToken).ConfigureAwait(false);
                }
            }
            else {
                response = await RequestHandler.GetAsync<T>(uri, null).ConfigureAwait(false);
            }
            response?.Inject(this);
            return response;
        }

        /// <summary>
        ///     Creates the query string.
        /// </summary>
        /// <param name="uriBase">The URI base.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.String.</returns>
        private static string createQueryString(string uriBase, params string[] parameters) {
            var p = uriBase.Contains('?') ? "&" : "?";
            var iter = parameters.GetEnumerator();
            while (iter.MoveNext()) {
                p += iter.Current;
                iter.MoveNext();
                p += "=" + iter.Current + "&";
            }
            return uriBase + p;
        }

        #region Deprecated Industry endpoints

        ///// <summary>
        /////     Returns a list of all industry specialities
        ///// </summary>
        ///// <returns>A list of all industry specialities</returns>
        //[Obsolete(ObsoleteMessage)]
        //public Task<IndustrySpecialityCollection> GetSpecialitiesAsync() {
        //    const string relPath = "industry/specialities/";
        //    return getAsync<IndustrySpecialityCollection>(relPath);
        //}

        ///// <summary>
        /////     Returns a list of all industry specialities
        ///// </summary>
        ///// <returns>A list of all industry specialities</returns>
        //[Obsolete(ObsoleteMessage)]
        //public IndustrySpecialityCollection GetSpecialities() {
        //    return GetSpecialitiesAsync().Result;
        //}

        ///// <summary>
        /////     Returns details for the requested speciality
        ///// </summary>
        ///// <param name="specialityId">Speciality ID</param>
        ///// <returns>Task&lt;IndustrySpeciality&gt;.</returns>
        //[Obsolete(ObsoleteMessage)]
        //public Task<IndustrySpeciality> GetSpecialityAsync(int specialityId) {
        //    string relPath = "industry/specialities/" + specialityId + "/";
        //    return getAsync<IndustrySpeciality>(relPath);
        //}

        ///// <summary>
        /////     Returns details for the requested speciality
        ///// </summary>
        ///// <param name="specialityId">Speciality ID</param>
        ///// <returns>IndustrySpeciality.</returns>
        //[Obsolete(ObsoleteMessage)]
        //public IndustrySpeciality GetSpeciality(int specialityId) {
        //    return GetSpecialityAsync(specialityId).Result;
        //}


        ///// <summary>
        /////     Returns a list of all industry teams
        ///// </summary>
        ///// <returns>A list of all industry teams</returns>
        //[Obsolete(ObsoleteMessage)]
        //public Task<IndustryTeamCollection> GetIndustryTeamsAsync() {
        //    const string relPath = "industry/teams/";
        //    return getAsync<IndustryTeamCollection>(relPath);
        //}

        ///// <summary>
        /////     Returns a list of all industry teams
        ///// </summary>
        ///// <returns>A list of all industry teams</returns>
        //[Obsolete(ObsoleteMessage)]
        //public IndustryTeamCollection GetIndustryTeams() {
        //    return GetIndustryTeamsAsync().Result;
        //}

        ///// <summary>
        /////     Returns data for the specified industry team
        ///// </summary>
        ///// <param name="teamId">The team ID</param>
        ///// <returns>Task&lt;IndustryTeam&gt;.</returns>
        //[Obsolete(ObsoleteMessage)]
        //public Task<IndustryTeam> GetIndustryTeamAsync(int teamId) {
        //    string relPath = "industry/teams/" + teamId + "/";
        //    return getAsync<IndustryTeam>(relPath);
        //}

        ///// <summary>
        /////     Returns data for the specified industry team
        ///// </summary>
        ///// <param name="teamId">The team ID</param>
        ///// <returns>IndustryTeam.</returns>
        //[Obsolete(ObsoleteMessage)]
        //public IndustryTeam GetIndustryTeam(int teamId) {
        //    return GetIndustryTeamAsync(teamId).Result;
        //}

        ///// <summary>
        /////     Returns a list of all current industry team auctions
        ///// </summary>
        ///// <returns>A list of all current industry team auctions</returns>
        //[Obsolete(ObsoleteMessage)]
        //public Task<IndustryTeamCollection> GetIndustryTeamAuctionsAsync() {
        //    const string relPath = "industry/teams/auction/";
        //    return getAsync<IndustryTeamCollection>(relPath);
        //}

        ///// <summary>
        /////     Returns a list of all current industry team auctions
        ///// </summary>
        ///// <returns>A list of all current industry team auctions</returns>
        //[Obsolete(ObsoleteMessage)]
        //public IndustryTeamCollection GetIndustryTeamAuction() {
        //    return GetIndustryTeamAuctionsAsync().Result;
        //}

        #endregion
    }
}