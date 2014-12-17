using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveWhoModule.Models;

namespace eZet.EveLib.EveWhoModule {
    public class EveWho : EveLibApiBase {
        /// <summary>
        ///     The default URI used to access the EveWho API.
        /// </summary>
        public const string DefaultUri = "http://www.evewho.com/";

        /// <summary>
        ///     The default relative path to the API base.
        /// </summary>
        public const string DefaultApiPath = "api.php";

        public EveWho() {
            RequestHandler = new RequestHandler(new JsonSerializer());
            BaseUri = DefaultUri;
            ApiPath = DefaultApiPath;
        }

        public Task<EveWhoResponse<Character>> GetCharacterAsync(long characterId, int page = 0) {
            string relPath = "?type=character&id=" + characterId + "&page=" + page;
            return requestAsync<EveWhoResponse<Character>>(relPath);
        }

        public EveWhoResponse<Character> GetCharacter(long characterId, int page) {
            return GetCharacterAsync(characterId, page).Result;
        }

        public Task<EveWhoResponse<Corporation>> GetCorporationAsync(long corporationId, int page = 0) {
            string relPath = "?type=corporation&id=" + corporationId + "&page=" + page;
            return requestAsync<EveWhoResponse<Corporation>>(relPath);
        }

        public EveWhoResponse<Corporation> GetCorporation(long corporationId, int page = 0) {
            return GetCorporationAsync(corporationId, page).Result;
        }

        public Task<EveWhoResponse<CorporationMembers>> GetCorporationMembersAsync(long corporationId,
            int page = 0) {
            string relPath = "?type=corplist&id=" + corporationId + "&page=" + page;
            return requestAsync<EveWhoResponse<CorporationMembers>>(relPath);
        }

        public EveWhoResponse<CorporationMembers> GetCorporationMembers(long corporationId, int page = 0) {
            return GetCorporationMembersAsync(corporationId, page).Result;
        }

        public Task<EveWhoResponse<Alliance>> GetAllianceAsync(long allianceId, int page = 0) {
            string relPath = "?type=allilist&id=" + allianceId + "&page=" + page;
            return requestAsync<EveWhoResponse<Alliance>>(relPath);
        }

        public EveWhoResponse<Alliance> GetAlliance(long allianceId, int page = 0) {
            return GetAllianceAsync(allianceId, page).Result;
        }

        public Task<EveWhoResponse<AllianceMembers>> GetAllianceMembersAsync(long allianceId, int page = 0) {
            string relPath = "?type=allilist&id=" + allianceId + "&page=" + page;
            return requestAsync<EveWhoResponse<AllianceMembers>>(relPath);
        }

        public EveWhoResponse<AllianceMembers> GetAllianceMembers(long allianceId, int page = 0) {
            return GetAllianceMembersAsync(allianceId, page).Result;
        }
    }
}