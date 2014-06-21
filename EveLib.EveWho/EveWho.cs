using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public class EveWho : EveLibApiBase {
        /// <summary>
        ///     The default URI used to access the EveWho API.
        /// </summary>
        public const string DefaultUri = "http://www.evewho.com/";

        /// <summary>
        /// The default relative path to the API base.
        /// </summary>
        public const string DefaultApiPath = "api.php";

        public EveWho() {
            RequestHandler = new RequestHandler(new JsonSerializer());
            BaseUri = DefaultUri;
            ApiPath = DefaultApiPath;
        }

        public Task<EveWhoResponse<EveWhoCharacter>> GetCharacterAsync(long characterId, int page = 0) {
            string relPath = "?type=character&id=" + characterId + "&page=" + page;
            return requestAsync<EveWhoResponse<EveWhoCharacter>>(relPath);
        }

        public EveWhoResponse<EveWhoCharacter> GetCharacter(long characterId, int page) {
            return GetCharacterAsync(characterId, page).Result;
        }

        public Task<EveWhoResponse<EveWhoCorporation>> GetCorporationAsync(long corporationId, int page = 0) {
            string relPath = "?type=corporation&id=" + corporationId + "&page=" + page;
            return requestAsync<EveWhoResponse<EveWhoCorporation>>(relPath);
        }

        public EveWhoResponse<EveWhoCorporation> GetCorporation(long corporationId, int page = 0) {
            return GetCorporationAsync(corporationId, page).Result;
        }

        public Task<EveWhoResponse<EveWhoCorporationMembers>> GetCorporationMembersAsync(long corporationId,
            int page = 0) {
            string relPath = "?type=corplist&id=" + corporationId + "&page=" + page;
            return requestAsync<EveWhoResponse<EveWhoCorporationMembers>>(relPath);
        }

        public EveWhoResponse<EveWhoCorporationMembers> GetCorporationMembers(long corporationId, int page = 0) {
            return GetCorporationMembersAsync(corporationId, page).Result;
        }

        public Task<EveWhoResponse<EveWhoAlliance>> GetAllianceAsync(long allianceId, int page = 0) {
            string relPath = "?type=allilist&id=" + allianceId + "&page=" + page;
            return requestAsync<EveWhoResponse<EveWhoAlliance>>(relPath);
        }

        public EveWhoResponse<EveWhoAlliance> GetAlliance(long allianceId, int page = 0) {
            return GetAllianceAsync(allianceId, page).Result;
        }

        public Task<EveWhoResponse<EveWhoAllianceMembers>> GetAllianceMembersAsync(long allianceId, int page = 0) {
            string relPath = "?type=allilist&id=" + allianceId + "&page=" + page;
            return requestAsync<EveWhoResponse<EveWhoAllianceMembers>>(relPath);
        }

        public EveWhoResponse<EveWhoAllianceMembers> GetAllianceMembers(long allianceId, int page = 0) {
            return GetAllianceMembersAsync(allianceId, page).Result;
        }
    }
}