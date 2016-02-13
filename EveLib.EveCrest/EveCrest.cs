// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : Lars Kristian
// Created          : 05-05-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="EveCrest.cs" company="">
//     Copyright (c) . All rights reserved.
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
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using eZet.EveLib.EveCrestModule.RequestHandlers;
using eZet.EveLib.EveCrestModule.RequestHandlers.eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.EveCrestModule {
    /// <summary>
    ///     Enum EveCrest Access Mode
    /// </summary>
    public enum CrestMode {
        /// <summary>
        ///     Public CREST
        /// </summary>
        Public,

        /// <summary>
        ///     Authenticated CREST. This requires a valid AccessToken or a valid RefreshToken and EncryptedKey
        /// </summary>
        Authenticated
    }


    /// <summary>
    ///     Provides access to the Eve Online CREST API.
    /// </summary>
    public class EveCrest {
        /// <summary>
        ///     The default URI used to access the public CREST API. This can be overridded by setting the Host.
        /// </summary>
        public const string DefaultPublicHost = "https://public-crest.eveonline.com/";

        /// <summary>
        ///     The default URI used to access the authenticated CREST API. This can be overridded by setting the Host.
        /// </summary>
        public const string DefaultAuthHost = "https://crest-tq.eveonline.com/";

        private const string ObsoleteMessage =
            "This method uses statically typed links, and is not how CREST is meant to be used. Please use GetRoot() or GetRootAsync() and navigate from there.";

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        private string _host;

        /// <summary>
        ///     The CREST root if cached
        /// </summary>
        private CrestRoot _root;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveCrest" /> class, in Public mode.
        /// </summary>
        public EveCrest() {
            RequestHandler = new CachedCrestRequestHandler(new JsonSerializer());
            ImageRequestHandler = new ImageRequestHandler();
            ApiPath = "/";
            Host = DefaultPublicHost;
            Mode = CrestMode.Public;
            EnableRootCache = true;
            EnableAutomaticPaging = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveCrest" /> class, in Authenticated mode.
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
        ///     Initializes a new instance of the <see cref="EveCrest" /> class, in Authenticated mode.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="encodedKey">The encoded key.</param>
        public EveCrest(string refreshToken, string encodedKey)
            : this() {
            RefreshToken = refreshToken;
            EncodedKey = encodedKey;
            Host = DefaultAuthHost;
            Mode = CrestMode.Authenticated;
            EveAuth = new EveAuth();
            EnableAutomaticTokenRefresh = true;
        }


        /// <summary>
        ///     Gets or sets the host used to access the EveCrest API.
        /// </summary>
        /// <value>The base public URI.</value>
        public string Host {
            get { return _host; }
            set { _host = value.TrimEnd('/', '\\'); }
        }

        /// <summary>
        ///     Gets or sets the IEveAuth instance used for Eve SSO.
        /// </summary>
        /// <value>The eve sso.</value>
        public IEveAuth EveAuth { get; set; }


        /// <summary>
        ///     Gets or sets the CREST Access Token
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the refresh token.
        /// </summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Gets or sets the encoded key. This is required to refresh access tokens.
        /// </summary>
        /// <value>The encoded key.</value>
        public string EncodedKey { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether EveCrest is allowed to cache the CrestRoot object. This is enabled by
        ///     default.
        /// </summary>
        /// <value><c>true</c> if [allow root cache]; otherwise, <c>false</c>.</value>
        public bool EnableRootCache { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to allow the library to automatically refresh the access token. This
        ///     requires a valid RefreshToken and EncryptedKey to be set. This is enabled by default if using the RefreshToken
        ///     ctor.
        /// </summary>
        /// <value><c>true</c> if [allow automatic refresh]; otherwise, <c>false</c>.</value>
        public bool EnableAutomaticTokenRefresh { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to allow Query() methods to allow automatic paging. This may perform
        ///     additional web requests.
        /// </summary>
        /// <value><c>true</c> if [allow automatic paging]; otherwise, <c>false</c>.</value>
        public bool EnableAutomaticPaging { get; set; }

        /// <summary>
        ///     Gets the CREST access mode.
        /// </summary>
        /// <value>The mode.</value>
        public CrestMode Mode { get; private set; }

        /// <summary>
        ///     Gets or sets the request handler.
        /// </summary>
        /// <value>The request handler.</value>
        public ICachedCrestRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Gets or sets the image request handler.
        /// </summary>
        /// <value>The image request handler.</value>
        public IImageRequestHandler ImageRequestHandler { get; set; }

        /// <summary>
        ///     Gets or sets the path to the API root relative to the host.
        /// </summary>
        /// <value>The API path.</value>
        public string ApiPath { get; private set; }

        /// <summary>
        ///     Refreshes the access token. This requires a valid RefreshToken and EncodedKey to have been set.
        ///     The EveCrest instance is updated with the new access token.
        /// </summary>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> RefreshAccessTokenAsync() {
            AuthResponse response = await EveAuth.RefreshAsync(EncodedKey, RefreshToken).ConfigureAwait(false);
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
            return response;
        }

        /// <summary>
        ///     Refreshes the access token. This requires a valid RefreshToken and EncodedKey to have been set.
        ///     The EveCrest instance is updated with the new access token.
        /// </summary>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public AuthResponse RefreshAccessToken() {
            AuthResponse response = EveAuth.RefreshAsync(EncodedKey, RefreshToken).Result;
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
            return response;
        }

        /// <summary>
        ///     Loads the image asynchronous.
        /// </summary>
        /// <param name="link">The image link.</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        public Task<byte[]> LoadImageAsync(ImageHref link) {
            return ImageRequestHandler.RequestImageDataAsync(new Uri(link.Uri));
        }

        /// <summary>
        ///     Loads the image.
        /// </summary>
        /// <param name="link">The image link</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        public byte[] LoadImage(ImageHref link) {
            return LoadImageAsync(link).Result;
        }

        /// <summary>
        /// Loads a Href async.
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="uri">The Href that should be loaded</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T>(Href<T> uri, params string[] parameters) where T : class, ICrestResource<T> {
            return uri == null ? Task.FromResult(default(T)) : requestAsync<T>(new Uri(uri.Uri + getQueryString(parameters)));
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
        public Task<T> LoadAsync<T>(ILinkedEntity<T> entity, params string[] parameters) where T : class, ICrestResource<T> {
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
        public Task<IEnumerable<T>> LoadAsync<T>(IEnumerable<ILinkedEntity<T>> items, params string[] parameters) where T : class, ICrestResource<T> {
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
        public IEnumerable<T> Load<T>(IEnumerable<ILinkedEntity<T>> items, params string[] parameters) where T : class, ICrestResource<T> {
            return LoadAsync(items, parameters).Result;
        }


        /// <summary>
        /// Loads a Href collection async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public Task<IEnumerable<T>> LoadAsync<T>(IEnumerable<Href<T>> items, params string[] parameters) where T : class, ICrestResource<T> {
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
        public IEnumerable<T> Load<T>(IEnumerable<Href<T>> items, params string[] parameters) where T : class, ICrestResource<T> {
            return LoadAsync(items, parameters).Result;
        }

        /// <summary>
        ///     Returns the CREST root
        /// </summary>
        /// <returns>Task&lt;CrestRoot&gt;.</returns>
        public async Task<CrestRoot> GetRootAsync() {
            const string relPath = "";
            if (_root == null || !EnableRootCache)
                _root = await requestAsync<CrestRoot>(relPath).ConfigureAwait(false);
            return _root;
        }

        /// <summary>
        ///     Returns the CREST root
        /// </summary>
        /// <returns>CrestRoot.</returns>
        public CrestRoot GetRoot() {
            return GetRootAsync().Result;
        }

        /// <summary>
        ///     Returns data on the specified killmail.
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public Task<Killmail> GetKillmailAsync(long id, string hash) {
            string relPath = "killmails/" + id + "/" + hash + "/";
            return requestAsync<Killmail>(relPath);
        }

        /// <summary>
        ///     Returns data on the specified killmail.
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public Killmail GetKillmail(long id, string hash) {
            return GetKillmailAsync(id, hash).Result;
        }

        /// <summary>
        ///     Returns a list of all active incursions.
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IncursionCollection> GetIncursionsAsync() {
            const string relPath = "incursions/";
            return requestAsync<IncursionCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all active incursions.
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        [Obsolete(ObsoleteMessage)]
        public IncursionCollection GetIncursions() {
            return GetIncursionsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all alliances.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the response.</param>
        /// <returns>A list of all alliances.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<AllianceCollection> GetAlliancesAsync(int page = 1) {
            string relPath = "alliances/?page=" + page;
            return requestAsync<AllianceCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all alliances.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all alliances.</returns>
        [Obsolete(ObsoleteMessage)]
        public AllianceCollection GetAlliances(int page = 1) {
            return GetAlliancesAsync(page).Result;
        }

        /// <summary>
        ///     Returns data about a specific alliance.
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<Alliance> GetAllianceAsync(long allianceId) {
            string relPath = "alliances/" + allianceId + "/";
            return requestAsync<Alliance>(relPath);
        }

        /// <summary>
        ///     Returns data about a specific alliance.
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        [Obsolete(ObsoleteMessage)]
        public Alliance GetAlliance(long allianceId) {
            return GetAllianceAsync(allianceId).Result;
        }

        /// <summary>
        ///     Returns daily price and volume history for a specific region and item type.
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<MarketHistoryCollection> GetMarketHistoryAsync(int regionId, int typeId) {
            string relPath = "market/" + regionId + "/types/" + typeId + "/history/";
            return requestAsync<MarketHistoryCollection>(relPath);
        }

        /// <summary>
        ///     Returns daily price and volume history for a specific region and item type.
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        [Obsolete(ObsoleteMessage)]
        public MarketHistoryCollection GetMarketHistory(int regionId, int typeId) {
            return GetMarketHistoryAsync(regionId, typeId).Result;
        }

        /// <summary>
        ///     Returns the average and adjusted values for all items
        /// </summary>
        /// <returns>Task&lt;MarketTypePriceCollection&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<MarketTypePriceCollection> GetMarketPricesAsync() {
            const string relpath = "market/prices/";
            return requestAsync<MarketTypePriceCollection>(relpath);
        }

        /// <summary>
        ///     Returns the average and adjusted values for all items
        /// </summary>
        /// <returns>MarketTypePriceCollection.</returns>
        [Obsolete(ObsoleteMessage)]
        public MarketTypePriceCollection GetMarketPrices() {
            return GetMarketPricesAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all wars.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<WarCollection> GetWarsAsync(int page = 1) {
            string relPath = "wars/?page=" + page;
            return requestAsync<WarCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all wars.
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        [Obsolete(ObsoleteMessage)]
        public WarCollection GetWars(int page = 1) {
            return GetWarsAsync(page).Result;
        }

        /// <summary>
        ///     Returns data for a specific war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>Data for the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<War> GetWarAsync(int warId) {
            string relPath = "wars/" + warId + "/";
            return requestAsync<War>(relPath);
        }

        /// <summary>
        ///     Returns data for a specific war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>Data for the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public War GetWar(int warId) {
            return GetWarAsync(warId).Result;
        }

        /// <summary>
        ///     Returns a list of all killmails related to a specified war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<KillmailCollection> GetWarKillmailsAsync(int warId) {
            string relPath = "wars/" + warId + "/killmails/all/";
            return requestAsync<KillmailCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all killmails related to a specified war.
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        [Obsolete(ObsoleteMessage)]
        public KillmailCollection GetWarKillmails(int warId) {
            return GetWarKillmailsAsync(warId).Result;
        }

        /// <summary>
        ///     Returns a list of all industry specialities
        /// </summary>
        /// <returns>A list of all industry specialities</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustrySpecialityCollection> GetSpecialitiesAsync() {
            const string relPath = "industry/specialities/";
            return requestAsync<IndustrySpecialityCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all industry specialities
        /// </summary>
        /// <returns>A list of all industry specialities</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustrySpecialityCollection GetSpecialities() {
            return GetSpecialitiesAsync().Result;
        }

        /// <summary>
        ///     Returns details for the requested speciality
        /// </summary>
        /// <param name="specialityId">Speciality ID</param>
        /// <returns>Task&lt;IndustrySpeciality&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustrySpeciality> GetSpecialityAsync(int specialityId) {
            string relPath = "industry/specialities/" + specialityId + "/";
            return requestAsync<IndustrySpeciality>(relPath);
        }

        /// <summary>
        ///     Returns details for the requested speciality
        /// </summary>
        /// <param name="specialityId">Speciality ID</param>
        /// <returns>IndustrySpeciality.</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustrySpeciality GetSpeciality(int specialityId) {
            return GetSpecialityAsync(specialityId).Result;
        }


        /// <summary>
        ///     Returns a list of all industry teams
        /// </summary>
        /// <returns>A list of all industry teams</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustryTeamCollection> GetIndustryTeamsAsync() {
            const string relPath = "industry/teams/";
            return requestAsync<IndustryTeamCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all industry teams
        /// </summary>
        /// <returns>A list of all industry teams</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustryTeamCollection GetIndustryTeams() {
            return GetIndustryTeamsAsync().Result;
        }

        /// <summary>
        ///     Returns data for the specified industry team
        /// </summary>
        /// <param name="teamId">The team ID</param>
        /// <returns>Task&lt;IndustryTeam&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustryTeam> GetIndustryTeamAsync(int teamId) {
            string relPath = "industry/teams/" + teamId + "/";
            return requestAsync<IndustryTeam>(relPath);
        }

        /// <summary>
        ///     Returns data for the specified industry team
        /// </summary>
        /// <param name="teamId">The team ID</param>
        /// <returns>IndustryTeam.</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustryTeam GetIndustryTeam(int teamId) {
            return GetIndustryTeamAsync(teamId).Result;
        }

        /// <summary>
        ///     Returns a list of industry systems and prices
        /// </summary>
        /// <returns>Task&lt;IndustrySystemCollection&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustrySystemCollection> GetIndustrySystemsAsync() {
            const string relPath = "industry/systems/";
            return requestAsync<IndustrySystemCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of industry systems and prices
        /// </summary>
        /// <returns>IndustrySystemCollection.</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustrySystemCollection GetIndustrySystems() {
            return GetIndustrySystemsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all current industry team auctions
        /// </summary>
        /// <returns>A list of all current industry team auctions</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustryTeamCollection> GetIndustryTeamAuctionsAsync() {
            const string relPath = "industry/teams/auction/";
            return requestAsync<IndustryTeamCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all current industry team auctions
        /// </summary>
        /// <returns>A list of all current industry team auctions</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustryTeamCollection GetIndustryTeamAuction() {
            return GetIndustryTeamAuctionsAsync().Result;
        }

        /// <summary>
        ///     Returns a collection of all industry facilities
        /// </summary>
        /// <returns>Task&lt;IndustryFacilityCollection&gt;.</returns>
        [Obsolete(ObsoleteMessage)]
        public Task<IndustryFacilityCollection> GetIndustryFacilitiesAsync() {
            const string relPath = "industry/facilities/";
            return requestAsync<IndustryFacilityCollection>(relPath);
        }

        /// <summary>
        ///     Returns a collection of all industry facilities
        /// </summary>
        /// <returns>IndustryFacilityCollection.</returns>
        [Obsolete(ObsoleteMessage)]
        public IndustryFacilityCollection GetIndustryFacilities() {
            return GetIndustryFacilitiesAsync().Result;
        }

        /// <summary>
        ///     Performs a request using the request handler.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="relPath">Relative path</param>
        /// <returns></returns>
        private Task<T> requestAsync<T>(string relPath) where T : class, ICrestResource<T> {
            return requestAsync<T>(new Uri(_host + ApiPath + relPath));
        }

        /// <summary>
        ///     Performs a request using the request handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        private async Task<T> requestAsync<T>(Uri uri) where T : class, ICrestResource<T> {
            T response = null;
            if (Mode == CrestMode.Authenticated) {
                var retry = false;
                try {
                    response =
                        await RequestHandler.RequestAsync<T>(uri, AccessToken).ConfigureAwait(false);
                }
                catch (EveCrestException e) {
                    if (EnableAutomaticTokenRefresh) {
                        var error = e.WebException.Response as HttpWebResponse;
                        if (error != null && error.StatusCode == HttpStatusCode.Unauthorized) retry = true;
                        else throw;
                    }
                    else throw;
                }
                if (retry) {
                    _trace.TraceEvent(TraceEventType.Information, 0,
                        "Invalid AccessToken: Attempting refresh");
                    await RefreshAccessTokenAsync().ConfigureAwait(false);
                    _trace.TraceEvent(TraceEventType.Information, 0,
                        "Token refreshed");
                    response =
                        await RequestHandler.RequestAsync<T>(uri, AccessToken).ConfigureAwait(false);
                }
            }
            else {
                response = await RequestHandler.RequestAsync<T>(uri, null).ConfigureAwait(false);
            }
            if (response != null) {
                response.EveCrest = this;
            }
            return response;
        }
        private string getQueryString(params string[] parameters) {
            var p = "?";
            var iter = parameters.GetEnumerator();

            while (iter.MoveNext()) {
                p += iter.Current;
                iter.MoveNext();
                p += "=" + iter.Current;
            }
            return p;
        }
    }
}