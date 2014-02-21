using System;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Core;
using CharacterInfo = eZet.Eve.EoLib.Dto.EveApi.Core.CharacterInfo;

namespace eZet.Eve.EoLib.Entity {
    public class Core : BaseEntity {

        /// <summary>
        /// The base URI for all requests by this entity
        /// </summary>
        protected override sealed string UriBase { get; set; }

        internal Core() {
            UriBase = "https://api.eveonline.com";
        }

        /// <summary>
        /// Returns a list of alliances in eve.
        /// </summary>
        /// <param name="extended">Optional; If true, includes corporations.</param>
        /// <returns></returns>
        public XmlResponse<AllianceList> GetAllianceList(bool extended = false) {
            const string path = "/eve/AllianceList.xml.aspx";
            var postString = extended ? "version=2" : "version=1";
            return request(path, new AllianceList(), postString);
        }

        /// <summary>
        /// Returns a list of certificates in eve.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CertificateTree> GetCertificateTree() {
            const string path = "/eve/CertificateTree.xml.aspx";
            return request(path, new CertificateTree());
        }

        /// <summary>
        /// Returns the characterName, characterID, corporationName, corporationID, allianceName, allianceID, factionName, factionID for the given list of IDs.
        /// </summary>
        /// <param name="list">A list of character ids.</param>
        /// <returns></returns>
        public XmlResponse<CharacterAffiliation> GetCharacterAffiliation(params long[] list) {
            const string path = "/eve/CharacterAffiliation.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("ids", ids);
            return request(path, new CharacterAffiliation(), postString);
        }

        /// <summary>
        /// Returns the ownerID for a given character, faction, alliance or corporation name, or the typeID for other objects such as stations, solar systems, planets, etc.
        /// </summary>
        /// <param name="list">A list of ids.</param>
        /// <returns></returns>
        public XmlResponse<CharacterNameId> GetCharacterId(params string[] list) {
            const string path = "/eve/CharacterID.xml.aspx";
            var names = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("names", names);
            return request(path, new CharacterNameId(), postString);
        }

        /// <summary>
        /// Returns the same data as a show info call on the character would do in the client. For the extended API key version, see Character.GetCharacterInfo.
        /// </summary>
        /// <param name="id">The character id.</param>
        /// <returns></returns>
        public XmlResponse<CharacterInfo> GetCharacterInfo(long id) {
            const string path = "/eve/CharacterInfo.xml.aspx";
            var postString = RequestHelper.GeneratePostString("characterID", id);
            return request(path, new CharacterInfo(), postString);
        }

        /// <summary>
        /// Returns the name associated with an ownerID.
        /// <para></para>
        /// A hard maximum of 250 IDs passed in. Might change in the future depending on live results.
        /// Any instances of repeated ids in the string will throw immediate errors with no returns.
        /// If an ID is passed into the call that does not resolve the call will not return any results regardless of the validity of other ids.
        /// </summary>
        /// <param name="list">List of ownerIDs (characterID, agentID, corporationID, allianceID, or factionID) and typeIDs to query.</param>
        /// <returns></returns>
        public XmlResponse<CharacterNameId> GetCharacterName(params long[] list) {
            const string path = "/eve/CharacterName.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("ids", ids);
            return request(path, new CharacterNameId(), postString);
        }

        /// <summary>
        /// Returns a list of conquerable stations
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ConquerableStations> GetConquerableStations() {
            const string path = "/eve/ConquerableStationList.xml.aspx";
            return request(path, new ConquerableStations());
        }

        /// <summary>
        /// Returns a list of error codes that can be returned by the EVE API servers. Error types are broken into the following categories according to their first digit:
        /// 1xx - user input
        /// 2xx - authentication
        /// 5xx - server
        /// 9xx - miscellaneous
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ErrorList> GetErrorList() {
            const string path = "/eve/ErrorList.xml.aspx";
            return request(path, new ErrorList());
        }

        /// <summary>
        /// Returns global stats on the factions in factional warfare
        /// </summary>
        /// <returns></returns>
        public XmlResponse<FactionWarfareStats> GetFactionWarfareStats() {
            // TODO Separate Factions and FactionWars
            const string path = "/eve/FacWarStats.xml.aspx";
            return request(path, new FactionWarfareStats());
        }

        /// <summary>
        /// Returns Factional Warfare Top 100 Stats
        /// </summary>
        /// <returns></returns>
        public XmlResponse<FactionWarfareTopList> GetFactionWarfareTopList() {
            // TODO Find a way to separate rowsets
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the transaction types used in GetWalletJournal calls.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ReferenceTypes> GetReferenceTypes() {
            const string path = "/eve/RefTypes.xml.aspx";
            return request(path, new ReferenceTypes());
        }

        /// <summary>
        /// Returns the current in-game skills (including unpublished skills).
        /// </summary>
        /// <returns></returns>
        public XmlResponse<SkillTree> GetSkillTree() {
            // TODO Separate rowsets
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name associated with a typeID.
        /// </summary>
        /// <param name="list">A list of type ids.</param>
        /// <returns></returns>
        public XmlResponse<TypeName> GetTypeName(params long[] list) {
            const string path = "/eve/TypeName.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("ids", ids);
            return request(path, new TypeName(), postString);
        }

        /// <summary>
        /// Returns current Tranquility status and number of players online.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ServerStatus> GetServerStatus() {
            const string path = "/server/ServerStatus.xml.aspx";
            return request(path, new ServerStatus());
        }

        /// <summary>
        /// Returns the mask and groupings for calls under the new Customizable API Keys authentication method.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CallList> GetCallList() {
            // TODO Separate rowsets
            const string path = "/api/calllist.xml.aspx";
            return request(path, new CallList());
        }
    }
}
