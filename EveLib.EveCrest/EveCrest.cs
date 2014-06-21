using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.RequestHandlers;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to the Eve Online CREST API.
    /// </summary>
    public class EveCrest : EveLibApiBase {
        /// <summary>
        ///     The default URI used to access the CREST API. This can be overridded by setting the BaseUri.
        /// </summary>
        public const string DefaultUri = "http://public-crest.eveonline.com/";

        /// <summary>
        ///     Creates a new EveCrest object with a default request handler
        /// </summary>
        public EveCrest() {
            RequestHandler = new EveCrestRequestHandler(new DynamicJsonSerializer());
            BaseUri = new Uri(DefaultUri);
        }

        /// <summary>
        ///     Returns data on the specified killmail.
        ///     Path: /killmails/$warId/$hash/
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public Task<CrestKillmail> GetKillmailAsync(long id, string hash) {
            string relPath = "killmails/" + id + "/" + hash + "/";
            return requestAsync<CrestKillmail>(relPath);
        }

        /// <summary>
        ///     Returns data on the specified killmail.
        ///     Path: /killmails/$warId/$hash/
        /// </summary>
        /// <param name="id">Killmail ID</param>
        /// <param name="hash">Killmail hash</param>
        /// <returns>Returns data for the specified killmail.</returns>
        public CrestKillmail GetKillmail(long id, string hash) {
            return GetKillmailAsync(id, hash).Result;
        }

        /// <summary>
        ///     Returns a list of all active incursions.
        ///     Path: /incursions/
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        public Task<CrestIncursions> GetIncursionsAsync() {
            const string relPath = "incursions/";
            return requestAsync<CrestIncursions>(relPath);
        }

        /// <summary>
        ///     Returns a list of all active incursions.
        ///     Path: /incursions/
        /// </summary>
        /// <returns>A list of all active incursions.</returns>
        public CrestIncursions GetIncursions() {
            return GetIncursionsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all alliances.
        ///     Path: /alliances/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all alliances.</returns>
        public Task<CrestAlliances> GetAlliancesAsync(int page = 1) {
            string relPath = "alliances/?page=" + page;
            return requestAsync<CrestAlliances>(relPath);
        }

        /// <summary>
        ///     Returns a list of all alliances.
        ///     Path: /alliances/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all alliances.</returns>
        public CrestAlliances GetAlliances(int page = 1) {
            return GetAlliancesAsync(page).Result;
        }

        /// <summary>
        ///     Returns data about a specific alliance.
        ///     Path: /alliances/$allianceId/
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        public Task<CrestAlliance> GetAllianceAsync(long allianceId) {
            string relPath = "alliances/" + allianceId + "/";
            return requestAsync<CrestAlliance>(relPath);
        }

        /// <summary>
        ///     Returns data about a specific alliance.
        ///     Path: /alliances/$allianceId/
        /// </summary>
        /// <param name="allianceId">A valid alliance ID</param>
        /// <returns>Data for specified alliance</returns>
        public CrestAlliance GetAlliance(long allianceId) {
            return GetAllianceAsync(allianceId).Result;
        }

        /// <summary>
        ///     Returns daily price and volume history for a specific region and item type.
        ///     Path: /market/$regionId/types/$typeId/history/
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        public Task<CrestMarketHistory> GetMarketHistoryAsync(int regionId, int typeId) {
            string relPath = "market/" + regionId + "/types/" + typeId + "/history/";
            return requestAsync<CrestMarketHistory>(relPath);
        }

        /// <summary>
        ///     Returns daily price and volume history for a specific region and item type.
        ///     Path: /market/$regionId/types/$typeId/history/
        /// </summary>
        /// <param name="regionId">Region ID</param>
        /// <param name="typeId">Type ID</param>
        /// <returns>Market history for the specified region and type.</returns>
        public CrestMarketHistory GetMarketHistory(int regionId, int typeId) {
            return GetMarketHistoryAsync(regionId, typeId).Result;
        }

        /// <summary>
        ///     Returns a list of all wars.
        ///     Path: /wars/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        public Task<CrestWars> GetWarsAsync(int page = 1) {
            string relPath = "/wars/?page=" + page;
            return requestAsync<CrestWars>(relPath);
        }

        /// <summary>
        ///     Returns a list of all wars.
        ///     Path: /wars/
        /// </summary>
        /// <param name="page">The 1-indexed page to return. Number of total pages is available in the repsonse.</param>
        /// <returns>A list of all wars.</returns>
        public CrestWars GetWars(int page = 1) {
            return GetWarsAsync().Result;
        }

        /// <summary>
        ///     Returns data for a specific war.
        ///     Path: /wars/$warId/
        /// </summary>
        /// <param name="warId">CrestWar ID</param>
        /// <returns>Data for the specified war.</returns>
        public Task<CrestWar> GetWarAsync(int warId) {
            string relPath = "/wars/" + warId + "/";
            return requestAsync<CrestWar>(relPath);
        }

        /// <summary>
        ///     Returns data for a specific war.
        ///     Path: /wars/$warId/
        /// </summary>
        /// <param name="warId">CrestWar ID</param>
        /// <returns>Data for the specified war.</returns>
        public CrestWar GetWar(int warId) {
            return GetWarAsync(warId).Result;
        }

        /// <summary>
        ///     Returns a list of all killmails related to a specified war.
        ///     Path: /wars/$warId/killmails/all/
        /// </summary>
        /// <param name="warId">CrestWar ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        public Task<CrestKillmails> GetWarKillmailsAsync(int warId) {
            string relPath = "/wars/" + warId + "/killmails/all/";
            return requestAsync<CrestKillmails>(relPath);
        }

        /// <summary>
        ///     Returns a list of all killmails related to a specified war.
        ///     Path: /wars/$warId/killmails/all/
        /// </summary>
        /// <param name="warId">CrestWar ID</param>
        /// <returns>A list of all killmails related to the specified war.</returns>
        public CrestKillmails GetWarKillmails(int warId) {
            return GetWarKillmailsAsync(warId).Result;
        }

        /// <summary>
        /// Returns a list of all industry specialities
        /// Path: /industry/specialities/
        /// </summary>
        /// <returns>A list of all industry specialities</returns>
        public Task<CrestSpecialities> GetSpecialitiesAsync() {
            const string relPath = "/industry/specialities/";
            return requestAsync<CrestSpecialities>(relPath);
        }

        /// <summary>
        /// Returns a list of all industry specialities
        /// Path: /industry/specialities/
        /// </summary>
        /// <returns>A list of all industry specialities</returns>
        public CrestSpecialities GetSpecialities() {
            return GetSpecialitiesAsync().Result;
        }

        /// <summary>
        /// Returns a list of all industry teams
        /// </summary>
        /// <returns>A list of all industry teams</returns>
        public Task<CrestIndustryTeams> GetIndustryTeamsAsync() {
            const string relPath = "/industry/teams/";
            return requestAsync<CrestIndustryTeams>(relPath);
        }

        /// <summary>
        /// Returns a list of all industry teams
        /// </summary>
        /// <returns>A list of all industry teams</returns>
        public CrestIndustryTeams GetIndustryTeams() {
            return GetIndustryTeamsAsync().Result;
        }
    }
}