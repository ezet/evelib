// ***********************************************************************
// Assembly         : EveLib.EveWho
// Author           : Lars Kristian
// Created          : 06-19-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="EveWho.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveWhoModule.Models;

namespace eZet.EveLib.EveWhoModule {
    /// <summary>
    ///     Class EveWho.
    /// </summary>
    public class EveWho : EveLibApiBase {
        /// <summary>
        ///     The default URI used to access the EveWho API.
        /// </summary>
        public const string DefaultHost = "http://www.evewho.com";

        /// <summary>
        ///     The default relative path to the API base.
        /// </summary>
        public const string DefaultApiPath = "/api.php";

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveWho" /> class.
        /// </summary>
        public EveWho() {
            RequestHandler = new RequestHandler(new JsonSerializer());
            Host = DefaultHost;
            ApiPath = DefaultApiPath;
        }

        /// <summary>
        ///     Gets the character asynchronous.
        /// </summary>
        /// <param name="characterId">The character identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>Task&lt;EveWhoResponse&lt;CharacterResponse&gt;&gt;.</returns>
        public Task<CharacterResponse> GetCharacterAsync(long characterId, int page = 0) {
            string relPath = "?type=character&id=" + characterId + "&page=" + page;
            return requestAsync<CharacterResponse>(relPath);
        }

        /// <summary>
        ///     Gets the character.
        /// </summary>
        /// <param name="characterId">The character identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>EveWhoResponse&lt;CharacterResponse&gt;.</returns>
        public CharacterResponse GetCharacter(long characterId, int page) {
            return GetCharacterAsync(characterId, page).Result;
        }

        /// <summary>
        ///     Gets the corporation asynchronous.
        /// </summary>
        /// <param name="corporationId">The corporation identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>Task&lt;EveWhoResponse&lt;CorporationResponse&gt;&gt;.</returns>
        public Task<CorporationResponse> GetCorporationAsync(long corporationId, int page = 0) {
            string relPath = "?type=corporation&id=" + corporationId + "&page=" + page;
            return requestAsync<CorporationResponse>(relPath);
        }

        /// <summary>
        ///     Gets the corporation.
        /// </summary>
        /// <param name="corporationId">The corporation identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>EveWhoResponse&lt;CorporationResponse&gt;.</returns>
        public CorporationResponse GetCorporation(long corporationId, int page = 0) {
            return GetCorporationAsync(corporationId, page).Result;
        }

        /// <summary>
        ///     Gets the corporation members asynchronous.
        /// </summary>
        /// <param name="corporationId">The corporation identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>Task&lt;EveWhoResponse&lt;CorporationMembersResponse&gt;&gt;.</returns>
        public Task<CorporationMembersResponse> GetCorporationMembersAsync(long corporationId,
            int page = 0) {
            string relPath = "?type=corplist&id=" + corporationId + "&page=" + page;
            return requestAsync<CorporationMembersResponse>(relPath);
        }

        /// <summary>
        ///     Gets the corporation members.
        /// </summary>
        /// <param name="corporationId">The corporation identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>EveWhoResponse&lt;CorporationMembersResponse&gt;.</returns>
        public CorporationMembersResponse GetCorporationMembers(long corporationId, int page = 0) {
            return GetCorporationMembersAsync(corporationId, page).Result;
        }

        /// <summary>
        ///     Gets the alliance asynchronous.
        /// </summary>
        /// <param name="allianceId">The alliance identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>Task&lt;EveWhoResponse&lt;AllianceResponse&gt;&gt;.</returns>
        public Task<AllianceResponse> GetAllianceAsync(long allianceId, int page = 0) {
            string relPath = "?type=alliance&id=" + allianceId + "&page=" + page;
            return requestAsync<AllianceResponse>(relPath);
        }

        /// <summary>
        ///     Gets the alliance.
        /// </summary>
        /// <param name="allianceId">The alliance identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>EveWhoResponse&lt;AllianceResponse&gt;.</returns>
        public AllianceResponse GetAlliance(long allianceId, int page = 0) {
            return GetAllianceAsync(allianceId, page).Result;
        }

        /// <summary>
        ///     Gets the alliance members asynchronous.
        /// </summary>
        /// <param name="allianceId">The alliance identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>Task&lt;EveWhoResponse&lt;AllianceMembersResponse&gt;&gt;.</returns>
        public Task<AllianceMembersResponse> GetAllianceMembersAsync(long allianceId, int page = 0) {
            string relPath = "?type=allilist&id=" + allianceId + "&page=" + page;
            return requestAsync<AllianceMembersResponse>(relPath);
        }

        /// <summary>
        ///     Gets the alliance members.
        /// </summary>
        /// <param name="allianceId">The alliance identifier.</param>
        /// <param name="page">The page.</param>
        /// <returns>EveWhoResponse&lt;AllianceMembersResponse&gt;.</returns>
        public AllianceMembersResponse GetAllianceMembers(long allianceId, int page = 0) {
            return GetAllianceMembersAsync(allianceId, page).Result;
        }
    }
}