using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.Models.Corporation;
using eZet.EveLib.EveXmlModule.Models.Misc;
using FactionWarfareStats = eZet.EveLib.EveXmlModule.Models.Misc.FactionWarfareStats;

namespace eZet.EveLib.EveXmlModule {
    /// <summary>
    ///     Provides access to API calls that do not require a valid API key or character/corporation ID, and are not covered
    ///     by Image or Map. Paths: /eve, /misc, /server, /api
    /// </summary>
    public class Eve : BaseEntity {
        /// <summary>
        ///     Returns a list of alliances in eve.
        /// </summary>
        /// <param name="extended">Optional; If true, includes corporations.</param>
        /// <returns></returns>
        public EveXmlResponse<AllianceList> GetAllianceList(bool extended = false) {
            return GetAllianceListAsync(extended).Result;
        }


        /// <summary>
        ///     Returns a list of alliances in eve.
        /// </summary>
        /// <param name="extended">Optional; If true, includes corporations.</param>
        /// <returns></returns>
        public Task<EveXmlResponse<AllianceList>> GetAllianceListAsync(bool extended = false) {
            const string relPath = "/eve/AllianceList.xml.aspx";
            return extended
                ? requestAsync<AllianceList>(relPath)
                : requestAsync<AllianceList>(relPath, "version", 1);
        }

        /// <summary>
        ///     Returns a list of certificates in eve.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<CertificateTree> GetCertificateTree() {
            return GetCertificateTreeAsync().Result;
        }

        /// <summary>
        ///     Returns a list of certificates in eve.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<CertificateTree>> GetCertificateTreeAsync() {
            const string relPath = "/eve/CertificateTree.xml.aspx";
            return requestAsync<CertificateTree>(relPath);
        }

        /// <summary>
        ///     Returns the characterName, characterID, corporationName, corporationID, allianceName, allianceID, factionName,
        ///     factionID for the given list of IDs.
        /// </summary>
        /// <param name="list">A list of character ids.</param>
        /// <returns></returns>
        public EveXmlResponse<CharacterAffiliation> GetCharacterAffiliation(params long[] list) {
            Contract.Requires(list != null);
            return GetCharacterAffiliationAsync(list).Result;
        }

        /// <summary>
        ///     Returns the characterName, characterID, corporationName, corporationID, allianceName, allianceID, factionName,
        ///     factionID for the given list of IDs.
        /// </summary>
        /// <param name="list">A list of character ids.</param>
        /// <returns></returns>
        public Task<EveXmlResponse<CharacterAffiliation>> GetCharacterAffiliationAsync(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/CharacterAffiliation.xml.aspx";
            var ids = string.Join(",", list);
            return requestAsync<CharacterAffiliation>(relPath, "IDs", ids);
        }

        /// <summary>
        ///     Returns the ownerID for a given character, faction, alliance or corporation name, or the typeID for other objects
        ///     such as stations, solar systems, planets, etc.
        /// </summary>
        /// <param name="list">A list of ids.</param>
        /// <returns></returns>
        public EveXmlResponse<CharacterNameId> GetCharacterId(params string[] list) {
            Contract.Requires(list != null);
            return GetCharacterIdAsync(list).Result;
        }

        /// <summary>
        ///     Returns the ownerID for a given character, faction, alliance or corporation name, or the typeID for other objects
        ///     such as stations, solar systems, planets, etc.
        /// </summary>
        /// <param name="list">A list of ids.</param>
        /// <returns></returns>
        public Task<EveXmlResponse<CharacterNameId>> GetCharacterIdAsync(params string[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/CharacterID.xml.aspx";
            var names = string.Join(",", list);
            return requestAsync<CharacterNameId>(relPath, "names", names);
        }

        /// <summary>
        ///     Returns the same data as a show info call on the character would do in the client. For the extended API key
        ///     version, see Character.GetCharacterInfoAsync.
        /// </summary>
        /// <param name="id">The character id.</param>
        /// <returns></returns>
        public EveXmlResponse<CharacterInfo> GetCharacterInfo(long id) {
            return GetCharacterInfoAsync(id).Result;
        }


        /// <summary>
        ///     Returns the same data as a show info call on the character would do in the client. For the extended API key
        ///     version, see Character.GetCharacterInfoAsync.
        /// </summary>
        /// <param name="id">The character id.</param>
        /// <returns></returns>
        public Task<EveXmlResponse<CharacterInfo>> GetCharacterInfoAsync(long id) {
            const string relPath = "/eve/CharacterInfo.xml.aspx";
            return requestAsync<CharacterInfo>(relPath, "characterID", id);
        }

        /// <summary>
        ///     Returns the name associated with an ownerID.
        ///     <para></para>
        ///     A hard maximum of 250 IDs passed in. Might change in the future depending on live results.
        ///     Any instances of repeated ids in the string will throw immediate errors with no returns.
        ///     If an ID is passed into the call that does not resolve the call will not return any results regardless of the
        ///     validity of other ids.
        /// </summary>
        /// <param name="list">
        ///     List of ownerIDs (characterID, agentID, corporationID, allianceID, or factionID) and typeIDs to
        ///     query.
        /// </param>
        /// <returns></returns>
        public EveXmlResponse<CharacterNameId> GetCharacterName(params long[] list) {
            Contract.Requires(list != null);
            return GetCharacterNameAsync(list).Result;
        }


        /// <summary>
        ///     Returns the name associated with an ownerID.
        ///     <para></para>
        ///     A hard maximum of 250 IDs passed in. Might change in the future depending on live results.
        ///     Any instances of repeated ids in the string will throw immediate errors with no returns.
        ///     If an ID is passed into the call that does not resolve the call will not return any results regardless of the
        ///     validity of other ids.
        /// </summary>
        /// <param name="list">
        ///     List of ownerIDs (characterID, agentID, corporationID, allianceID, or factionID) and typeIDs to
        ///     query.
        /// </param>
        /// <returns></returns>
        public Task<EveXmlResponse<CharacterNameId>> GetCharacterNameAsync(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/CharacterName.xml.aspx";
            var ids = string.Join(",", list);
            return requestAsync<CharacterNameId>(relPath, "IDs", ids);
        }


        /// <summary>
        ///     Returns a list of conquerable stations
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<ConquerableStations> GetConquerableStations() {
            return GetConquerableStationsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of conquerable stations
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<ConquerableStations>> GetConquerableStationsAsync() {
            const string relPath = "/eve/ConquerableStationList.xml.aspx";
            return requestAsync<ConquerableStations>(relPath);
        }

        /// <summary>
        ///     Returns a list of error codes that can be returned by the EVE API servers. Error types are broken into the
        ///     following categories according to their first digit:
        ///     1xx - user input
        ///     2xx - authentication
        ///     5xx - server
        ///     9xx - miscellaneous
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<ErrorList> GetErrorList() {
            return GetErrorListAsync().Result;
        }

        /// <summary>
        ///     Returns a list of error codes that can be returned by the EVE API servers. Error types are broken into the
        ///     following categories according to their first digit:
        ///     1xx - user input
        ///     2xx - authentication
        ///     5xx - server
        ///     9xx - miscellaneous
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<ErrorList>> GetErrorListAsync() {
            const string relPath = "/eve/ErrorList.xml.aspx";
            return requestAsync<ErrorList>(relPath);
        }

        /// <summary>
        ///     Returns global stats on the factions in factional warfare
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<FactionWarfareStats> GetFactionWarfareStats() {
            return GetFactionWarfareStatsAsync().Result;
        }

        /// <summary>
        ///     Returns global stats on the factions in factional warfare
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<FactionWarfareStats>> GetFactionWarfareStatsAsync() {
            const string relPath = "/eve/FacWarStats.xml.aspx";
            return requestAsync<FactionWarfareStats>(relPath);
        }

        /// <summary>
        ///     Returns Factional Warfare Top 100 Stats
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<FactionWarTopStats> GetFactionWarfareTopList() {
            return GetFactionWarfareTopListAsync().Result;
        }

        /// <summary>
        ///     Returns Factional Warfare Top 100 Stats
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<FactionWarTopStats>> GetFactionWarfareTopListAsync() {
            const string relPath = "/eve/FacWarTopStats.xml.aspx";
            return requestAsync<FactionWarTopStats>(relPath);
        }

        /// <summary>
        ///     Returns the transaction types used in GetWalletJournal calls.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<ReferenceTypes> GetReferenceTypes() {
            return GetReferenceTypesAsync().Result;
        }

        /// <summary>
        ///     Returns the transaction types used in GetWalletJournal calls.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<ReferenceTypes>> GetReferenceTypesAsync() {
            const string relPath = "/eve/RefTypes.xml.aspx";
            return requestAsync<ReferenceTypes>(relPath);
        }

        /// <summary>
        ///     Returns the current in-game skills (including unpublished skills).
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<SkillTree> GetSkillTree() {
            return GetSkillTreeAsync().Result;
        }

        /// <summary>
        ///     Returns the current in-game skills (including unpublished skills).
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<SkillTree>> GetSkillTreeAsync() {
            const string relPath = "/eve/SkillTree.xml.aspx";
            return requestAsync<SkillTree>(relPath);
        }

        /// <summary>
        ///     Returns the name associated with a typeID.
        /// </summary>
        /// <param name="list">A list of type ids.</param>
        /// <returns></returns>
        public EveXmlResponse<TypeName> GetTypeName(params long[] list) {
            Contract.Requires(list != null);
            return GetTypeNameAsync(list).Result;
        }

        /// <summary>
        ///     Returns the name associated with a typeID.
        /// </summary>
        /// <param name="list">A list of type ids.</param>
        /// <returns></returns>
        public Task<EveXmlResponse<TypeName>> GetTypeNameAsync(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/TypeName.xml.aspx";
            var ids = string.Join(",", list);
            return requestAsync<TypeName>(relPath, "IDs", ids);
        }

        /// <summary>
        ///     Returns current Tranquility status and number of players online.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<ServerStatus> GetServerStatus() {
            return GetServerStatusAsync().Result;
        }

        /// <summary>
        ///     Returns current Tranquility status and number of players online.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<ServerStatus>> GetServerStatusAsync() {
            const string relPath = "/server/ServerStatus.xml.aspx";
            return requestAsync<ServerStatus>(relPath);
        }

        /// <summary>
        ///     Returns the mask and groupings for calls under the new Customizable API Keys authentication method.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<CallList> GetCallList() {
            return GetCallListAsync().Result;
        }

        /// <summary>
        ///     Returns the mask and groupings for calls under the new Customizable API Keys authentication method.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<CallList>> GetCallListAsync() {
            const string relPath = "/api/CallList.xml.aspx";
            return requestAsync<CallList>(relPath);
        }

        /// <summary>
        ///     Returns the owner name, id and group for an object.
        /// </summary>
        /// <param name="list">A list of names or IDs</param>
        /// <returns></returns>
        public EveXmlResponse<OwnerCollection> GetOwnerId(params string[] list) {
            Contract.Requires(list != null);
            return GetOwnerIdAsync(list).Result;
        }

        /// <summary>
        ///     Returns the owner name, id and group for an object.
        /// </summary>
        /// <param name="list">A list of names or IDs</param>
        /// <returns></returns>
        public Task<EveXmlResponse<OwnerCollection>> GetOwnerIdAsync(params string[] list) {
            Contract.Requires(list != null);
            const string relpath = "/eve/OwnerID.xml.aspx";
            var names = string.Join(",", list);
            return requestAsync<OwnerCollection>(relpath, "names", names);
        }

        /// <summary>
        ///     Returns public information about a corporation.
        /// </summary>
        /// <param name="corporationId">A corporation ID</param>
        /// <returns></returns>
        public EveXmlResponse<CorporationSheet> GetCorporationSheet(long corporationId) {
            return GetCorporationSheetAsync(corporationId).Result;
        }


        /// <summary>
        ///     Returns public information about a corporation.
        /// </summary>
        /// <param name="corporationId">A corporation ID</param>
        /// <returns></returns>
        public Task<EveXmlResponse<CorporationSheet>> GetCorporationSheetAsync(long corporationId) {
            const string relPath = "/corp/CorporationSheet.xml.aspx";
            return requestAsync<CorporationSheet>(relPath, null, "corporationId", corporationId);
        }
    }
}