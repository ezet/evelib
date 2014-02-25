using System;
using System.Runtime.CompilerServices;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Character;
using eZet.Eve.EoLib.Dto.EveApi.Corporation;
using FactionWarfareStats = eZet.Eve.EoLib.Dto.EveApi.Corporation.FactionWarfareStats;
using StandingsList = eZet.Eve.EoLib.Dto.EveApi.Corporation.StandingsList;
using ContactList = eZet.Eve.EoLib.Dto.EveApi.Corporation.ContactList;

[assembly: InternalsVisibleTo("EoLib.Tests")]

namespace eZet.Eve.EoLib.Entity {

    /// <summary>
    /// Provides access to all API calls relating to a specific corporation, that is, all API calls prefixed with /corp in CCPs API.
    /// </summary>
    public class Corporation : EveApiEntity {

        /// <summary>
        /// The base URI for all requests by this entity
        /// </summary>
        protected override sealed Uri UriBase { get; set; }

        /// <summary>
        /// The API key used for this character.
        /// </summary>
        public ApiKey Key { get; private set; }

        /// <summary>
        /// The corporation ID.
        /// </summary>
        public long CorporationId { get; private set; }

        /// <summary>
        /// The corporation name.
        /// </summary>
        public string CorporationName { get; private set; }

        /// <summary>
        /// Created a new instance
        /// </summary>
        /// <param name="key"></param>
        /// <param name="corporationId"></param>
        /// <param name="corporationName"></param>
        internal Corporation(ApiKey key, long corporationId, string corporationName) {
            Key = key;
            CorporationId = corporationId;
            CorporationName = corporationName;
            UriBase = new Uri("https://api.eveonline.com");

        }

        /// <summary>
        /// Returns the ISK balance of a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AccountBalance> GetAccountBalance() {
            const string relPath = "/corp/AccountBalance.xml.aspx";
            return request(new AccountBalance(), relPath, Key);
        }

        /// <summary>
        /// Returns a list of assets owned by a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AssetList> GetAssetList() {
            const string relPath = "/corp/AssetList.xml.aspx";
            return request(new AssetList(), relPath, Key);
        }

        /// <summary>
        /// Returns the corporation and the alliance contact lists. This is accessible by any character in any corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContactList> GetContactList() {
            const string relPath = "/corp/ContactList.xml.aspx";
            return request(new ContactList(), relPath, Key);
        }

        /// <summary>
        /// Shows corporation container audit log.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContainerLog> GetContainerLog() {
            const string relPath = "/corp/ContainerLog.xml.aspx";
            return request(new ContainerLog(), relPath, Key);
        }

        /// <summary>
        /// Lists the contracts for the corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContractList> GetContracts() {
            const string relPath = "/corp/Contracts.xml.aspx";
            return request(new ContractList(), relPath, Key);
        }

        /// <summary>
        /// Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract itemId.</param>
        /// <returns></returns>
        public XmlResponse<ContractItems> GetContractItems(long contractId) {
            const string relPath = "/corp/ContractItems.xml.aspx";
            return request(new ContractItems(), relPath, Key, "contractID", contractId);
        }

        /// <summary>
        /// Lists the latest bids that have been made to any recent auctions.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContractBids> GetContractBids() {
            const string relPath = "/corp/ContractBids.xml.aspx";
            return request(new ContractBids(), relPath, Key);
        }

        /// <summary>
        /// Returns attributes relating to a specific corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CorporationSheet> GetCorporationSheet() {
            const string relPath = "/corp/CorporationSheet.xml.aspx";
            return request(new CorporationSheet(), relPath, Key);
        }

        /// <summary>
        /// If the corporation is enlisted in Factional Warfare, this will return the faction warfare statistics.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<FactionWarfareStats> GetFactionWarfareStats() {
            const string relPath = "/corp/FacWarStats.xml.aspx";
            return request(new FactionWarfareStats(), relPath, Key);
        }

        /// <summary>
        /// Returns the corporation industry jobs.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<IndustryJobs> GetIndustryJobs() {
            const string relPath = "/corp/IndustryJobs.xml.aspx";
            return request(new IndustryJobs(), relPath, Key);
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
            return killId == 0
                ? request(new KillLog(), relPath, Key)
                : request(new KillLog(), relPath, Key, "beforeKillID", killId);
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
            return request(new Locations(), relPath, Key, "IDs", ids);
        }

        /// <summary>
        /// Returns a list of market orders that are either not expired or have expired in the past week (at most).
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public XmlResponse<MarketOrders> GetMarketOrders(long orderId = 0) {
            const string relPath = "/corp/MarketOrders.xml.aspx";
            return orderId == 0
                ? request(new MarketOrders(), relPath, Key)
                : request(new MarketOrders(), relPath, Key, "orderID", orderId);
        }

        /// <summary>
        /// Returns a list of medals created by this corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Dto.EveApi.Corporation.MedalList> GetMedals() {
            const string relPath = "/corp/Medals.xml.aspx";
            return request(new Dto.EveApi.Corporation.MedalList(), relPath, Key);
        }

        /// <summary>
        /// Returns a list of medals issued to members.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MemberMedals> GetMemberMedals() {
            const string relPath = "/corp/MemberMedals.xml.aspx";
            return request(new MemberMedals(), relPath, Key);
        }

        /// <summary>
        /// Returns the security roles of members in a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MemberSecurity> GetMemberSecurity() {
            const string relPath = "/corp/MemberSecurity.xml.aspx";
            return request(new MemberSecurity(), relPath, Key);
        }

        /// <summary>
        /// Returns info about corporation role changes for members and who did it.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MemberSecurityLog> GetMemberSecurityLog() {
            const string relPath = "/corp/MemberSecurityLog.xml.aspx";
            return request(new MemberSecurityLog(), relPath, Key);
        }

        /// <summary>
        /// Returns information about all members in a corporation.
        /// </summary>
        /// <param name="extended">Optional; true for extended version</param>
        /// <returns></returns>
        public XmlResponse<MemberTracking> GetMemberTracking(bool extended = false) {
            const string relPath = "/corp/MemberTracking.xml.aspx";
            return extended
                ? request(new MemberTracking(), relPath, Key, "extended", 1)
                : request(new MemberTracking(), relPath, Key);
        }

        /// <summary>
        /// Returns information about the corporation's outposts.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<OutpostList> GetOutpostList() {
            // TODO Link to OutpostServiceDetails
            const string relPath = "/corp/OutpostList.xml.aspx";
            return request(new OutpostList(), relPath, Key);
        }

        /// <summary>
        /// Returns detailed information about a specific corporation outpost.
        /// </summary>
        /// <param name="itemId">Item ID of an outpost listed in OutpostList API call.</param>
        /// <returns></returns>
        public XmlResponse<OutpostServiceDetails> GetOutpostServiceDetails(long itemId) {
            const string relPath = "/corp/OutpostServiceDetail.xml.aspx";
            return request(new OutpostServiceDetails(), relPath, Key, "itemID", itemId);
        }

        /// <summary>
        /// Returns the character and corporation share holders of a corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ShareholderList> GetShareholders() {
            const string relPath = "/corp/Shareholders.xml.aspx";
            return request(new ShareholderList(), relPath, Key);
        }

        /// <summary>
        /// Returns the standings from NPC corporations and factions as well as agents.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<StandingsList> GetStandings() {
            const string relPath = "/corp/Standings.xml.aspx";
            return request(new StandingsList(), relPath, Key);
        }

        /// <summary>
        /// Returns the settings and fuel status of a POS.
        /// </summary>
        /// <param name="itemId">itemId of a starbase from StarbaseList</param>
        /// <returns></returns>
        public XmlResponse<StarbaseDetails> GetStarbaseDetails(long itemId) {
            // TODO CombatSettings
            const string relPath = "/corp/StarbaseDetail.xml.aspx";
            return request(new StarbaseDetails(), relPath, Key, "itemID", itemId);
        }

        /// <summary>
        /// Returns the list and states of POS'es.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<StarbaseList> GetStarbaseList() {
            const string relPath = "/corp/StarbaseList.xml.aspx";
            return request(new StarbaseList(), relPath, Key);
        }

        /// <summary>
        /// Returns the titles in the corporation.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<TitleList> GetTitles() {
            const string relPath = "/corp/Titles.xml.aspx";
            return request(new TitleList(), relPath, Key);
        }

        /// <summary>
        /// Returns a list of journal transactions for the corporation.
        /// </summary>
        /// <param name="division">Optional; Wallet Division used for request. Default is Master Wallet.</param>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public XmlResponse<WalletJournal> GetWalletJournal(int division = 1000, int count = 50, long fromId = 0) {
            const string relPath = "/corp/WalletJournal.xml.aspx";
            var result = fromId == 0
                ? request(new WalletJournal(), relPath, Key, "accountKey", division, "rowCount", count)
                : request(new WalletJournal(), relPath, Key, "accountKey", division, "rowCount", count, "fromID", fromId);
            result.Result.CorpWalker = GetWalletJournal;
            result.Result.Division = division;
            return result;
        }

        /// <summary>
        /// Returns market transactions for the corporation.
        /// </summary>
        /// <param name="division">Optional; Wallet Division used for request. Default is Master Wallet.</param>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public XmlResponse<WalletTransactions> GetWalletTransactions(int division = 1000, int count = 1000, long fromId = 0) {
            const string relPath = "/corp/WalletTransactions.xml.aspx";
            var result = fromId == 0
                 ? request(new WalletTransactions(), relPath, Key, "accountKey", division, "rowCount", count)
                 : request(new WalletTransactions(), relPath, Key, "accountKey", division, "rowCount", count, "fromID", fromId);
            result.Result.CorpWalker = GetWalletTransactions;
            result.Result.Division = division;
            return result;
        }
    }
}
