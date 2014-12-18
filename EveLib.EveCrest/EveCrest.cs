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
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveAuthModule;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using eZet.EveLib.EveCrestModule.RequestHandlers;

namespace eZet.EveLib.EveCrestModule {
    /// <summary>
    ///     Enum Crest Access Mode
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
        ///     The default URI used to access the public CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string DefaultPublicUri = "https://public-crest.eveonline.com/";


        /// <summary>
        ///     The default URI used to access the authenticated CREST API. This can be overridded by setting the BaseAuthUri.
        /// </summary>
        public const string DefaultAuthUri = "https://crest-tq.eveonline.com/";

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="publicUri"></param>
        /// <param name="requestHandler"></param>
        protected EveCrest(string publicUri, ICrestRequestHandler requestHandler) {
            RequestHandler = requestHandler;
            BasePublicUri = publicUri;
        }

        /// <summary>
        ///     Creates a new EveCrest object with default configuration
        /// </summary>
        public EveCrest() {
            Serializer = new JsonSerializer();
            RequestHandler = new CrestRequestHandler(Serializer);
            EveAuth = new EveAuth();
            BasePublicUri = DefaultPublicUri;
            BaseAuthUri = DefaultAuthUri;

        }


        /// <summary>
        ///     Gets or sets the root URI used to access the public CREST API. This should include a trailing backslash.
        /// </summary>
        /// <value>The base public URI.</value>
        public string BasePublicUri { get; set; }

        /// <summary>
        ///     Gets or sets the root URI used to access the authed CREST API. This should include a trailing backslash.
        /// </summary>
        /// <value>The base authentication URI.</value>
        public string BaseAuthUri { get; set; }

        /// <summary>
        ///     Gets or sets the eve sso.
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
        ///     Gets or sets a value indicating whether to allow the library to automatically refresh the access token. This requires a valid RefreshToken and EncryptedKey to be set.
        /// </summary>
        /// <value><c>true</c> if [allow automatic refresh]; otherwise, <c>false</c>.</value>
        public bool AllowAutomaticTokenRefresh { get; set; }


        /// <summary>
        ///     Gets or sets the CREST access mode.
        /// </summary>
        /// <value>The mode.</value>
        public CrestMode Mode { get; set; }

        /// <summary>
        ///     Gets or sets the request handler used by this instance
        /// </summary>
        /// <value>The request handler.</value>
        public ICrestRequestHandler RequestHandler { get; set; }

        /// <summary>
        /// Gets or sets the serializer used to deserialize CREST data.
        /// </summary>
        /// <value>The serializer.</value>
        public ISerializer Serializer { get; set; }


        /// <summary>
        ///     Gets or sets the relative path to the API base.
        /// </summary>
        /// <value>The API path.</value>
        public string ApiPath { get; set; }

        /// <summary>
        ///     Refreshes the access token. This requires a valid RefreshToken and EncodedKey to have been set.
        /// </summary>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> RefreshAccessTokenAsync() {
            AuthResponse response = await EveAuth.RefreshAsync(EncodedKey, RefreshToken).ConfigureAwait(false);
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
            return response;
        }

        /// <summary>
        ///     Loads a CREST resource async.
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="uri">The Href that should be loaded</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T>(Href<T> uri) where T : class, ICrestResource<T> {
            return requestAsync<T>(new Uri(uri.Uri));
        }

        /// <summary>
        ///     Loads a CREST resource async.
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="uri">The Href that should be loaded</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public T Load<T>(Href<T> uri) where T : class, ICrestResource<T> {
            return requestAsync<T>(new Uri(uri.Uri)).Result;
        }

        /// <summary>
        ///     Loads a crest resource
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="entity">The items that should be loaded</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public Task<T> LoadAsync<T>(ILinkedEntity<T> entity) where T : class, ICrestResource<T> {
            return requestAsync<T>(new Uri(entity.Href.Uri));
        }

        /// <summary>
        ///     Loads a crest resource
        /// </summary>
        /// <typeparam name="T">The resource type, usually inferred from the parameter</typeparam>
        /// <param name="entity">The items that should be loaded</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public T Load<T>(ILinkedEntity<T> entity) where T : class, ICrestResource<T> {
            return requestAsync<T>(new Uri(entity.Href.Uri)).Result;
        }


        /// <summary>
        /// Loads a crest resource collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public Task<IEnumerable<T>> LoadAsync<T>(IEnumerable<ILinkedEntity<T>> items) where T : class, ICrestResource<T> {
            var list = items.Select(LoadAsync).ToList();
            return Task.WhenAll(list).ContinueWith(task => task.Result.AsEnumerable());
        }

        /// <summary>
        /// Loads a crest resource collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public IEnumerable<T> Load<T>(IEnumerable<ILinkedEntity<T>> items) where T : class, ICrestResource<T> {
            var list = items.Select(LoadAsync).ToList();
            return Task.WhenAll(list).Result.AsEnumerable();
        }


        /// <summary>
        /// Loads a crest resource collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public Task<IEnumerable<T>> LoadAsync<T>(IEnumerable<Href<T>> items) where T : class, ICrestResource<T> {
            var list = items.Select(LoadAsync).ToList();
            return Task.WhenAll(list).ContinueWith(task => task.Result.AsEnumerable());
        }

        /// <summary>
        /// Loads a crest resource collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>Task&lt;T[]&gt;.</returns>
        public IEnumerable<T> Load<T>(IEnumerable<Href<T>> items) where T : class, ICrestResource<T> {
            var list = items.Select(LoadAsync).ToList();
            return Task.WhenAll(list).Result.AsEnumerable();
        }


        /// <summary>
        ///     Returns the CREST root
        ///     Path: /
        /// </summary>
        /// <returns>Task&lt;CrestRoot&gt;.</returns>
        public Task<CrestRoot> GetRootAsync() {
            const string relPath = "";
            return requestAsync<CrestRoot>(relPath);
        }

        /// <summary>
        ///     Returns the CREST root
        ///     Path: /
        /// </summary>
        /// <returns>CrestRoot.</returns>
        public CrestRoot GetRoot() {
            return GetRootAsync().Result;
        }

        /// <summary>
        ///     Returns data on the specified killmail.
        ///     Path: /killmails/$warId/$hash/
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
        ///     Path: /killmails/$warId/$hash/
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public Killmail GetKillmail(long id, string hash) {
            return GetKillmailAsync(id, hash).Result;
        }

        /// <summary>
        ///     Returns a list of all active incursions.
        ///     Path: /incursions/
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        public Task<IncursionCollection> GetIncursionsAsync() {
            const string relPath = "incursions/";
            return requestAsync<IncursionCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all active incursions.
        ///     Path: /incursions/
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        public IncursionCollection GetIncursions() {
            return GetIncursionsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all alliances.
        ///     Path: /alliances/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all alliances.</returns>
        public Task<AllianceCollection> GetAlliancesAsync(int page = 1) {
            string relPath = "alliances/?page=" + page;
            return requestAsync<AllianceCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all alliances.
        ///     Path: /alliances/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all alliances.</returns>
        public AllianceCollection GetAlliances(int page = 1) {
            return GetAlliancesAsync(page).Result;
        }

        /// <summary>
        ///     Returns data about a specific alliance.
        ///     Path: /alliances/$allianceId/
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        public Task<Alliance> GetAllianceAsync(long allianceId) {
            string relPath = "alliances/" + allianceId + "/";
            return requestAsync<Alliance>(relPath);
        }

        /// <summary>
        ///     Returns data about a specific alliance.
        ///     Path: /alliances/$allianceId/
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        public Alliance GetAlliance(long allianceId) {
            return GetAllianceAsync(allianceId).Result;
        }

        /// <summary>
        ///     Returns daily price and volume history for a specific region and item type.
        ///     Path: /market/$regionId/types/$typeId/history/
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        public Task<MarketHistory> GetMarketHistoryAsync(int regionId, int typeId) {
            string relPath = "market/" + regionId + "/types/" + typeId + "/history/";
            return requestAsync<MarketHistory>(relPath);
        }

        /// <summary>
        ///     Returns daily price and volume history for a specific region and item type.
        ///     Path: /market/$regionId/types/$typeId/history/
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        public MarketHistory GetMarketHistory(int regionId, int typeId) {
            return GetMarketHistoryAsync(regionId, typeId).Result;
        }

        /// <summary>
        ///     Returns the average and adjusted values for all items
        ///     Path: /market/prices/
        /// </summary>
        /// <returns>Task&lt;MarketTypePriceCollection&gt;.</returns>
        public Task<MarketTypePriceCollection> GetMarketPricesAsync() {
            const string relpath = "market/prices/";
            return requestAsync<MarketTypePriceCollection>(relpath);
        }

        /// <summary>
        ///     Returns the average and adjusted values for all items
        ///     Path: /market/prices/
        /// </summary>
        /// <returns>MarketTypePriceCollection.</returns>
        public MarketTypePriceCollection GetMarketPrices() {
            return GetMarketPricesAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all wars.
        ///     Path: /wars/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        public Task<WarCollection> GetWarsAsync(int page = 1) {
            string relPath = "/wars/?page=" + page;
            return requestAsync<WarCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all wars.
        ///     Path: /wars/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        public WarCollection GetWars(int page = 1) {
            return GetWarsAsync(page).Result;
        }

        /// <summary>
        ///     Returns data for a specific war.
        ///     Path: /wars/$warId/
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>Data for the specified war.</returns>
        public Task<War> GetWarAsync(int warId) {
            string relPath = "wars/" + warId + "/";
            return requestAsync<War>(relPath);
        }

        /// <summary>
        ///     Returns data for a specific war.
        ///     Path: /wars/$warId/
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>Data for the specified war.</returns>
        public War GetWar(int warId) {
            return GetWarAsync(warId).Result;
        }

        /// <summary>
        ///     Returns a list of all killmails related to a specified war.
        ///     Path: /wars/$warId/killmails/all/
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        public Task<KillmailCollection> GetWarKillmailsAsync(int warId) {
            string relPath = "wars/" + warId + "/killmails/all/";
            return requestAsync<KillmailCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all killmails related to a specified war.
        ///     Path: /wars/$warId/killmails/all/
        /// </summary>
        /// <param name="warId">War ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        public KillmailCollection GetWarKillmails(int warId) {
            return GetWarKillmailsAsync(warId).Result;
        }

        /// <summary>
        ///     Returns a list of all industry specialities
        ///     Path: /industry/specialities/
        /// </summary>
        /// <returns>A list of all industry specialities</returns>
        public Task<IndustrySpecialityCollection> GetSpecialitiesAsync() {
            const string relPath = "industry/specialities/";
            return requestAsync<IndustrySpecialityCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all industry specialities
        ///     Path: /industry/specialities/
        /// </summary>
        /// <returns>A list of all industry specialities</returns>
        public IndustrySpecialityCollection GetSpecialities() {
            return GetSpecialitiesAsync().Result;
        }

        /// <summary>
        ///     Returns details for the requested speciality
        /// </summary>
        /// <param name="specialityId">Speciality ID</param>
        /// <returns>Task&lt;IndustrySpeciality&gt;.</returns>
        public Task<IndustrySpeciality> GetSpecialityAsync(int specialityId) {
            string relPath = "industry/specialities/" + specialityId + "/";
            return requestAsync<IndustrySpeciality>(relPath);
        }

        /// <summary>
        ///     Returns details for the requested speciality
        /// </summary>
        /// <param name="specialityId">Speciality ID</param>
        /// <returns>IndustrySpeciality.</returns>
        public IndustrySpeciality GetSpeciality(int specialityId) {
            return GetSpecialityAsync(specialityId).Result;
        }


        /// <summary>
        ///     Returns a list of all industry teams
        /// </summary>
        /// <returns>A list of all industry teams</returns>
        public Task<IndustryTeamCollection> GetIndustryTeamsAsync() {
            const string relPath = "industry/teams/";
            return requestAsync<IndustryTeamCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all industry teams
        /// </summary>
        /// <returns>A list of all industry teams</returns>
        public IndustryTeamCollection GetIndustryTeams() {
            return GetIndustryTeamsAsync().Result;
        }

        /// <summary>
        ///     Returns data for the specified industry team
        /// </summary>
        /// <param name="teamId">The team ID</param>
        /// <returns>Task&lt;IndustryTeam&gt;.</returns>
        public Task<IndustryTeam> GetIndustryTeamAsync(int teamId) {
            string relPath = "industry/teams/" + teamId + "/";
            return requestAsync<IndustryTeam>(relPath);
        }

        /// <summary>
        ///     Returns data for the specified industry team
        /// </summary>
        /// <param name="teamId">The team ID</param>
        /// <returns>IndustryTeam.</returns>
        public IndustryTeam GetIndustryTeam(int teamId) {
            return GetIndustryTeamAsync(teamId).Result;
        }


        /// <summary>
        ///     Returns a list of industry systems and prices
        /// </summary>
        /// <returns>Task&lt;IndustrySystemCollection&gt;.</returns>
        public Task<IndustrySystemCollection> GetIndustrySystemsAsync() {
            const string relPath = "industry/systems/";
            return requestAsync<IndustrySystemCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of industry systems and prices
        /// </summary>
        /// <returns>IndustrySystemCollection.</returns>
        public IndustrySystemCollection GetIndustrySystems() {
            return GetIndustrySystemsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all current industry team auctions
        /// </summary>
        /// <returns>A list of all current industry team auctions</returns>
        public Task<IndustryTeamCollection> GetIndustryTeamAuctionsAsync() {
            const string relPath = "industry/teams/auction/";
            return requestAsync<IndustryTeamCollection>(relPath);
        }

        /// <summary>
        ///     Returns a list of all current industry team auctions
        /// </summary>
        /// <returns>A list of all current industry team auctions</returns>
        public IndustryTeamCollection GetIndustryTeamAuction() {
            return GetIndustryTeamAuctionsAsync().Result;
        }

        /// <summary>
        ///     Returns a collection of all industry facilities
        /// </summary>
        /// <returns>Task&lt;IndustryFacilityCollection&gt;.</returns>
        public Task<IndustryFacilityCollection> GetIndustryFacilitiesAsync() {
            const string relPath = "industry/facilities/";
            return requestAsync<IndustryFacilityCollection>(relPath);
        }

        /// <summary>
        ///     Returns a collection of all industry facilities
        /// </summary>
        /// <returns>IndustryFacilityCollection.</returns>
        public IndustryFacilityCollection GetIndustryFacilities() {
            return GetIndustryFacilitiesAsync().Result;
        }

        /// <summary>
        ///     Performs a request using the request handler.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="relPath">Relative path</param>
        /// <returns></returns>
        protected Task<T> requestAsync<T>(string relPath) where T : class, ICrestResource<T> {
            var uri = Mode == CrestMode.Authenticated ? BaseAuthUri : BasePublicUri;

            return requestAsync<T>(new Uri(uri + ApiPath + relPath));
        }

        /// <summary>
        ///     Performs a request using the request handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        protected async Task<T> requestAsync<T>(Uri uri) where T : class, ICrestResource<T> {
            string data = null;
            if (Mode == CrestMode.Authenticated) {
                var retry = false;
                try {
                    data =
                        await RequestHandler.RequestAsync<T>(uri, AccessToken);

                } catch (EveCrestException e) {
                    if (AllowAutomaticTokenRefresh) {
                        var error = e.WebException.Response as HttpWebResponse;
                        if (error != null && error.StatusCode == HttpStatusCode.Unauthorized)
                            retry = true;
                    } else throw;
                }

                if (retry) {
                    _trace.TraceEvent(TraceEventType.Information, 0,
                        "Invalid AccessToken: Attempting refresh");
                    await RefreshAccessTokenAsync();
                    _trace.TraceEvent(TraceEventType.Information, 0,
                        "Token refreshed");
                    data =
                        await RequestHandler.RequestAsync<T>(uri, AccessToken);
                }
            } else {
                data = await RequestHandler.RequestAsync<T>(uri, null);
            }
            var response = Serializer.Deserialize<T>(data);
            response.Crest = this;
            return response;
        }
    }
}