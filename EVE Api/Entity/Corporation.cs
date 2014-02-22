using System;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Character;
using eZet.Eve.EoLib.Dto.EveApi.Corporation;
using FactionWarfareStats = eZet.Eve.EoLib.Dto.EveApi.Corporation.FactionWarfareStats;
using StandingsList = eZet.Eve.EoLib.Dto.EveApi.Corporation.StandingsList;
using ContactList = eZet.Eve.EoLib.Dto.EveApi.Corporation.ContactList;

namespace eZet.Eve.EoLib.Entity {

    /// <summary>
    /// Provides access to all API calls relating to a specific corporation, that is, all API calls prefixed with /corp in CCPs API.
    /// </summary>
    public class Corporation : BaseEntity {

        /// <summary>
        /// The base URI for all requests by this entity
        /// </summary>
        protected override sealed string UriBase { get; set; }

        /// <summary>
        /// The API key used for this character.
        /// </summary>
        public ApiKey Key { get; private set; }


        private string _corporationName;

        /// <summary>
        /// The corporation name.
        /// </summary>
        public string CorporationName {
            get {
                if (_corporationName == null)
                    load();
                return _corporationName;
            }
            private set { _corporationName = value; }
        }


        public long CorporationId { get; private set; }

        /// <summary>
        /// The itemId of this character.
        /// </summary>
        public long CharacterId { get; set; }

        /// <summary>
        /// Created a new instance
        /// </summary>
        /// <param name="key"></param>
        /// <param name="characterId"></param>
        /// <param name="corporationId"></param>
        public Corporation(ApiKey key, long characterId, long corporationId) {
            Key = key;
            CharacterId = characterId;
            CorporationId = corporationId;
            UriBase = "https://api.eveonline.com";

        }

        /// <summary>
        /// Returns the ISK balance of a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AccountBalance> GetAccountBalance() {
            const string relPath = "/corp/AccountBalance.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new AccountBalance(), postString);
        }

        /// <summary>
        /// Returns a list of assets owned by a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AssetList> GetAssetList() {
            const string relPath = "/corp/AssetList.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new AssetList(), postString);
        }

        /// <summary>
        /// Returns the corporation and the alliance contact lists. This is accessible by any character in any corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContactList> GetContactList() {
            const string relPath = "/corp/ContactList.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new ContactList(), postString);
        }

        /// <summary>
        /// Shows corporation container audit log.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContainerLog> GetContainerLog() {
            const string relPath = "/corp/ContainerLog.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new ContainerLog(), postString);
        }

        /// <summary>
        /// Lists the contracts for the corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContractList> GetContracts() {
            const string relPath = "/corp/Contracts.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new ContractList(), postString);
        }

        /// <summary>
        /// Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract itemId.</param>
        /// <returns></returns>
        public XmlResponse<ContractItems> GetContractItems(long contractId) {
            const string relPath = "/corp/ContractItems.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "contractID", contractId);
            return request(relPath, new ContractItems(), postString);
        }

        /// <summary>
        /// Lists the latest bids that have been made to any recent auctions.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContractBids> GetContractBids() {
            const string relPath = "/corp/ContractBids.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new ContractBids(), postString);
        }

        /// <summary>
        /// Returns attributes relating to a specific corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CorporationSheet> GetCorporationSheet() {
            const string relPath = "/corp/CorporationSheet.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            return request(relPath, new CorporationSheet(), postString);
        }

        /// <summary>
        /// If the corporation is enlisted in Factional Warfare, this will return the faction warfare statistics.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<FactionWarfareStats> GetFactionWarfareStats() {
            const string relPath = "/corp/FacWarStats.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new FactionWarfareStats(), postString);
        }

        /// <summary>
        /// Returns the corporation industry jobs.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<IndustryJobs> GetIndustryJobs() {
            const string relPath = "/corp/IndustryJobs.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new IndustryJobs(), postString);
        }

        /// <summary>
        /// Returns a list of kills where this corporation received the final blow and losses of this corporation. 
        /// <para></para>
        /// Returns the 100 most recent kills. You can scroll back with the killId parameter.
        /// </summary>
        /// <param name="killId">Optional; if present, return the most recent kills before the specified killID.</param>
        /// <returns></returns>
        public XmlResponse<KillLog> GetKillLog(long killId = 0) {
            // TODO Add walking
            const string relPath = "/corp/Killlog.xml.aspx";
            var postString = killId != 0 ? RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "beforeKillID", killId)
               : RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new KillLog(), postString);
        }

        /// <summary>
        /// Call will return the items name (or its type name if no user defined name exists) as well as their x,y,z coordinates.
        /// <para></para>
        /// Coordinates should all be 0 for valid locations located inside of stations.
        /// </summary>
        /// <param name="list">A list of item ids.</param>
        /// <returns></returns>
        public XmlResponse<Locations> GetLocations(params long[] list) {
            const string relPath = "/corp/Locations.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "IDs", ids);
            return request(relPath, new Locations(), postString);
        }

        /// <summary>
        /// Returns a list of market orders that are either not expired or have expired in the past week (at most).
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public XmlResponse<MarketOrders> GetMarketOrders(long orderId = 0) {
            const string relPath = "/corp/MarketOrders.xml.aspx";
            var postString = (orderId == 0) ? RequestHelper.GeneratePostString(Key, "characterId", CharacterId)
                : RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "orderID", orderId);
            return request(relPath, new MarketOrders(), postString);
        }

        /// <summary>
        /// Returns a list of medals created by this corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Dto.EveApi.Corporation.MedalList> GetMedals() {
            const string relPath = "/corp/Medals.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new Dto.EveApi.Corporation.MedalList(), postString);
        }

        /// <summary>
        /// Returns a list of medals issued to members.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MemberMedals> GetMemberMedals() {
            const string relPath = "/corp/MemberMedals.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new MemberMedals(), postString);
        }

        /// <summary>
        /// Returns the security roles of members in a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MemberSecurity> GetMemberSecurity() {
            // TODO Rowsets
            const string relPath = "/corp/MemberSecurity.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new MemberSecurity(), postString);
        }

        /// <summary>
        /// Returns info about corporation role changes for members and who did it.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MemberSecurityLog> GetMemberSecurityLog() {
            const string relPath = "/corp/MemberSecurityLog.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new MemberSecurityLog(), postString);
        }

        /// <summary>
        /// Returns information about all members in a corporation.
        /// </summary>
        /// <param name="extended">Optional; true for extended version</param>
        /// <returns></returns>
        public XmlResponse<MemberTracking> GetMemberTracking(bool extended = false) {
            const string relPath = "/corp/MemberTracking.xml.aspx";
            var ext = extended ? 1 : 0;
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "extended", ext);
            return request(relPath, new MemberTracking(), postString);
        }

        /// <summary>
        /// Returns information about the corporation's outposts.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<OutpostList> GetOutpostList() {
            // TODO Link to OutpostServiceDetails
            const string relPath = "/corp/OutpostList.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new OutpostList(), postString);
        }

        /// <summary>
        /// Returns detailed information about a specific corporation outpost.
        /// </summary>
        /// <param name="itemId">Item ID of an outpost listed in OutpostList API call.</param>
        /// <returns></returns>
        public XmlResponse<OutpostServiceDetails> GetOutpostServiceDetails(long itemId) {
            const string relPath = "/corp/OutpostServiceDetail.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "itemID", itemId);
            return request(relPath, new OutpostServiceDetails(), postString);
        }

        /// <summary>
        /// Returns the character and corporation share holders of a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ShareholderList> GetShareholders() {
            // TODO RowSet
            const string relPath = "/corp/Shareholders.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new ShareholderList(), postString);
        }

        /// <summary>
        /// Returns the standings from NPC corporations and factions as well as agents.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<StandingsList> GetStandings() {
            // TODO Rowset
            const string relPath = "/corp/Standings.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new StandingsList(), postString);
        }

        /// <summary>
        /// Returns the settings and fuel status of a POS.
        /// </summary>
        /// <param name="itemId">itemId of a starbase from StarbaseList</param>
        /// <returns></returns>
        public XmlResponse<StarbaseDetails> GetStarbaseDetails(long itemId) {
            // TODO CombatSettings
            const string relPath = "/corp/StarbaseDetail.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "itemID", itemId);
            return request(relPath, new StarbaseDetails(), postString);
        }

        /// <summary>
        /// Returns the list and states of POS'es.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<StarbaseList> GetStarbaseList() {
            const string relPath = "/corp/StarbaseList.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new StarbaseList(), postString);
        }

        /// <summary>
        /// Returns the titles in the corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<TitleList> GetTitles() {
            const string relPath = "/corp/Titles.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key, "characterId", CharacterId);
            return request(relPath, new TitleList(), postString);
        }

        /// <summary>
        /// Returns a list of journal transactions for the corporation.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public XmlResponse<WalletJournal> GetWalletJournal(int count = 50, long fromId = 0) {
            const string relPath = "/corp/WalletJournal.xml.aspx";
            var postString = fromId == 0
            ? RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "rowCount", count)
            : RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "rowCount", count, "fromID", fromId);
            return request(relPath, new WalletJournal(), postString);
        }

        /// <summary>
        /// Returns market transactions for the corporation.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public XmlResponse<WalletTransactions> GetWalletTransactions(int count = 1000, long fromId = 0) {
            const string relPath = "/corp/WalletTransactions.xml.aspx";
            var postString = fromId == 0
                           ? RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "rowCount", count)
                           : RequestHelper.GeneratePostString(Key, "characterId", CharacterId, "rowCount", count, "fromID", fromId);
            return request(relPath, new WalletTransactions(), postString);
        }

        private void load() {


        }

    }
}
