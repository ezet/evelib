using System;
using System.Diagnostics.Contracts;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Model.EveApi.Core;

namespace eZet.Eve.EveLib.Entity.EveApi {
    /// <summary>
    ///     Provides access to API calls that do not require a valid API key or character id. That is, all URIs prefixed with
    ///     /eve, /server and /api.
    /// </summary>
    public class Core : BaseEntity {
        /// <summary>
        ///     Creates a new object.
        /// </summary>
        internal Core() {
            BaseUri = new Uri("https://api.eveonline.com");
        }

        /// <summary>
        ///     Returns a list of alliances in eve.
        /// </summary>
        /// <param name="extended">Optional; If true, includes corporations.</param>
        /// <returns></returns>
        public EveApiResponse<AllianceList> GetAllianceList(bool extended = false) {
            const string relPath = "/eve/AllianceList.xml.aspx";
            return extended
                ? request<AllianceList>(relPath)
                : request<AllianceList>(relPath, "version", 1);
        }

        /// <summary>
        ///     Returns a list of certificates in eve.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CertificateTree> GetCertificateTree() {
            const string relPath = "/eve/CertificateTree.xml.aspx";
            return request<CertificateTree>(relPath);
        }

        /// <summary>
        ///     Returns the characterName, characterID, corporationName, corporationID, allianceName, allianceID, factionName,
        ///     factionID for the given list of IDs.
        /// </summary>
        /// <param name="list">A list of character ids.</param>
        /// <returns></returns>
        public EveApiResponse<CharacterAffiliation> GetCharacterAffiliation(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/CharacterAffiliation.xml.aspx";
            string ids = String.Join(",", list);
            return request<CharacterAffiliation>(relPath, "IDs", ids);
        }

        /// <summary>
        ///     Returns the ownerID for a given character, faction, alliance or corporation name, or the typeID for other objects
        ///     such as stations, solar systems, planets, etc.
        /// </summary>
        /// <param name="list">A list of ids.</param>
        /// <returns></returns>
        public EveApiResponse<CharacterNameId> GetCharacterId(params string[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/CharacterID.xml.aspx";
            string names = String.Join(",", list);
            return request<CharacterNameId>(relPath, "names", names);
        }

        /// <summary>
        ///     Returns the same data as a show info call on the character would do in the client. For the extended API key
        ///     version, see Character.GetCharacterInfo.
        /// </summary>
        /// <param name="id">The character id.</param>
        /// <returns></returns>
        public EveApiResponse<CharacterInfo> GetCharacterInfo(long id) {
            const string relPath = "/eve/CharacterInfo.xml.aspx";
            return request<CharacterInfo>(relPath, "characterID", id);
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
        public EveApiResponse<CharacterNameId> GetCharacterName(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/CharacterName.xml.aspx";
            string ids = String.Join(",", list);
            return request<CharacterNameId>(relPath, "IDs", ids);
        }

        /// <summary>
        ///     Returns a list of conquerable stations
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ConquerableStations> GetConquerableStations() {
            const string relPath = "/eve/ConquerableStationList.xml.aspx";
            return request<ConquerableStations>(relPath);
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
        public EveApiResponse<ErrorList> GetErrorList() {
            const string relPath = "/eve/ErrorList.xml.aspx";
            return request<ErrorList>(relPath);
        }

        /// <summary>
        ///     Returns global stats on the factions in factional warfare
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<FactionWarfareStats> GetFactionWarfareStats() {
            const string relPath = "/eve/FacWarStats.xml.aspx";
            return request<FactionWarfareStats>(relPath);
        }

        /// <summary>
        ///     Returns Factional Warfare Top 100 Stats
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<FactionWarTopStats> GetFactionWarfareTopList() {
            const string relPath = "/eve/FacWarTopStats.xml.aspx";
            return request<FactionWarTopStats>(relPath);
        }

        /// <summary>
        ///     Returns the transaction types used in GetWalletJournal calls.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ReferenceTypes> GetReferenceTypes() {
            const string relPath = "/eve/RefTypes.xml.aspx";
            return request<ReferenceTypes>(relPath);
        }

        /// <summary>
        ///     Returns the current in-game skills (including unpublished skills).
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<SkillTree> GetSkillTree() {
            const string relPath = "/eve/SkillTree.xml.aspx";
            return request<SkillTree>(relPath);
        }

        /// <summary>
        ///     Returns the name associated with a typeID.
        /// </summary>
        /// <param name="list">A list of type ids.</param>
        /// <returns></returns>
        public EveApiResponse<TypeName> GetTypeName(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/eve/TypeName.xml.aspx";
            string ids = String.Join(",", list);
            return request<TypeName>(relPath, "IDs", ids);
        }

        /// <summary>
        ///     Returns current Tranquility status and number of players online.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ServerStatus> GetServerStatus() {
            const string relPath = "/server/ServerStatus.xml.aspx";
            return request<ServerStatus>(relPath);
        }

        /// <summary>
        ///     Returns the mask and groupings for calls under the new Customizable API Keys authentication method.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CallList> GetCallList() {
            const string relPath = "/api/calllist.xml.aspx";
            return request<CallList>(relPath);
        }
    }
}