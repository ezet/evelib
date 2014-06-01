using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Corporation;
using ContactList = eZet.EveLib.Modules.Models.Corporation.ContactList;
using FactionWarfareStats = eZet.EveLib.Modules.Models.Corporation.FactionWarfareStats;
using MedalList = eZet.EveLib.Modules.Models.Corporation.MedalList;
using StandingsList = eZet.EveLib.Modules.Models.Corporation.StandingsList;

[assembly: InternalsVisibleTo("EveLib.Test")]

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to all API calls relating to a specific corporation, that is, all API calls prefixed with /corp in
    ///     CCPs API.
    /// </summary>
    public class Corporation : BaseEntity {
        /// <summary>
        ///     Created a new instance
        /// </summary>
        /// <param name="key"></param>
        /// <param name="corporationId"></param>
        /// <param name="corporationName"></param>
        internal Corporation(ApiKey key, long corporationId, string corporationName) {
            Key = key;
            CorporationId = corporationId;
            CorporationName = corporationName;
            BaseUri = new Uri("https://api.eveonline.com");
        }

        internal Corporation(ApiKey key, ApiKeyInfo.ApiKeyEntity entity) {
            Key = key;
            CharacterId = entity.CharacterId;
            CharacterName = entity.CharacterName;
            CorporationId = entity.CorporationId;
            CorporationName = entity.CorporationName;
            AllianceId = entity.AllianceId;
            AllianceName = entity.AllianceName;
            FactionId = entity.FactionId;
            FactionName = entity.FactionName;
            BaseUri = new Uri("https://api.eveonline.com");
        }

        /// <summary>
        ///     The API key used for this Corporation
        /// </summary>
        public ApiKey Key { get; private set; }

        /// <summary>
        ///     Gets the Character ID.
        /// </summary>
        public long CharacterId { get; private set; }

        /// <summary>
        ///     Gets the name of this character.
        /// </summary>
        public string CharacterName { get; private set; }


        /// <summary>
        /// Gets the Corporation ID.
        /// </summary>
        public long CorporationId { get; private set; }

        /// <summary>
        /// Gets the corporation name.
        /// </summary>
        public string CorporationName { get; private set; }

        /// <summary>
        /// Gets the Alliance ID.
        /// </summary>
        public long AllianceId { get; private set; }

        /// <summary>
        /// Gets the Alliance name.
        /// </summary>
        public string AllianceName { get; private set; }

        /// <summary>
        /// Gets the Faction ID.
        /// </summary>
        public long FactionId { get; private set; }

        /// <summary>
        /// Gets the Faction name.
        /// </summary>
        public string FactionName { get; private set; }

        /// <summary>
        ///     Returns the ISK balance of a corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<AccountBalance> GetAccountBalance() {
            return GetAccountBalanceAsync().Result;
        }

        /// <summary>
        ///     Returns the ISK balance of a corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<AccountBalance>> GetAccountBalanceAsync() {
            const string relPath = "/corp/AccountBalance.xml.aspx";
            return requestAsync<AccountBalance>(relPath, Key);
        }

        /// <summary>
        ///     Returns a list of assets owned by a corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<AssetList> GetAssetList() {
            return GetAssetListAsync().Result;
        }

        /// <summary>
        ///     Returns a list of assets owned by a corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<AssetList>> GetAssetListAsync() {
            const string relPath = "/corp/AssetList.xml.aspx";
            return requestAsync<AssetList>(relPath, Key);
        }

        /// <summary>
        ///     Returns the corporation and the alliance contact lists. This is accessible by any character in any corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContactList> GetContactList() {
            return GetContactListAsync().Result;
        }


        /// <summary>
        ///     Returns the corporation and the alliance contact lists. This is accessible by any character in any corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContactList>> GetContactListAsync() {
            const string relPath = "/corp/ContactList.xml.aspx";
            return requestAsync<ContactList>(relPath, Key);
        }

        /// <summary>
        ///     Shows corporation container audit log.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContainerLog> GetContainerLog() {
            return GetContainerLogAsync().Result;
        }

        /// <summary>
        ///     Shows corporation container audit log.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContainerLog>> GetContainerLogAsync() {
            const string relPath = "/corp/ContainerLog.xml.aspx";
            return requestAsync<ContainerLog>(relPath, Key);
        }

        /// <summary>
        ///     Lists the contracts for the corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContractList> GetContracts() {
            return GetContractsAsync().Result;
        }

        /// <summary>
        ///     Lists the contracts for the corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContractList>> GetContractsAsync() {
            const string relPath = "/corp/Contracts.xml.aspx";
            return requestAsync<ContractList>(relPath, Key);
        }

        /// <summary>
        ///     Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract itemId.</param>
        /// <returns></returns>
        public EveApiResponse<ContractItems> GetContractItems(long contractId) {
            return GetContractItemsAsync(contractId).Result;
        }

        /// <summary>
        ///     Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract itemId.</param>
        /// <returns></returns>
        public Task<EveApiResponse<ContractItems>> GetContractItemsAsync(long contractId) {
            const string relPath = "/corp/ContractItems.xml.aspx";
            return requestAsync<ContractItems>(relPath, Key, "contractID", contractId);
        }

        /// <summary>
        ///     Lists the latest bids that have been made to any recent auctions.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContractBids> GetContractBids() {
            return GetContractBidsAsync().Result;
        }


        /// <summary>
        ///     Lists the latest bids that have been made to any recent auctions.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContractBids>> GetContractBidsAsync() {
            const string relPath = "/corp/ContractBids.xml.aspx";
            return requestAsync<ContractBids>(relPath, Key);
        }

        /// <summary>
        ///     Returns attributes relating to a specific corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CorporationSheet> GetCorporationSheet() {
            return GetCorporationSheetAsync().Result;
        }


        /// <summary>
        ///     Returns attributes relating to a specific corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<CorporationSheet>> GetCorporationSheetAsync() {
            const string relPath = "/corp/CorporationSheet.xml.aspx";
            return requestAsync<CorporationSheet>(relPath, Key);
        }

        /// <summary>
        ///     If the corporation is enlisted in Factional Warfare, this will return the faction warfare statistics.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<FactionWarfareStats> GetFactionWarfareStats() {
            return GetFactionWarfareStatsAsync().Result;
        }


        /// <summary>
        ///     If the corporation is enlisted in Factional Warfare, this will return the faction warfare statistics.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<FactionWarfareStats>> GetFactionWarfareStatsAsync() {
            const string relPath = "/corp/FacWarStats.xml.aspx";
            return requestAsync<FactionWarfareStats>(relPath, Key);
        }

        /// <summary>
        ///     Returns the corporation industry jobs.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<IndustryJobs> GetIndustryJobs() {
            return GetIndustryJobsAsync().Result;
        }


        /// <summary>
        ///     Returns the corporation industry jobs.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<IndustryJobs>> GetIndustryJobsAsync() {
            const string relPath = "/corp/IndustryJobs.xml.aspx";
            return requestAsync<IndustryJobs>(relPath, Key);
        }

        /// <summary>
        ///     Returns a list of kills where this corporation received the final blow and losses of this corporation.
        ///     <para></para>
        ///     Returns the 100 most recent kills. You can scroll back with the killId parameter.
        /// </summary>
        /// <param name="killId">Optional; if present, return the most recent kills before the specified killID.</param>
        /// <returns></returns>
        public EveApiResponse<KillLog> GetKillLog(long killId = 0) {
            return GetKillLogAsync(killId).Result;
        }

        /// <summary>
        ///     Returns a list of kills where this corporation received the final blow and losses of this corporation.
        ///     <para></para>
        ///     Returns the 100 most recent kills. You can scroll back with the killId parameter.
        /// </summary>
        /// <param name="killId">Optional; if present, return the most recent kills before the specified killID.</param>
        /// <returns></returns>
        public Task<EveApiResponse<KillLog>> GetKillLogAsync(long killId = 0) {
            // TODO Add walking
            const string relPath = "/corp/Killlog.xml.aspx";
            return killId == 0
                ? requestAsync<KillLog>(relPath, Key)
                : requestAsync<KillLog>(relPath, Key, "beforeKillID", killId);
        }

        /// <summary>
        ///     Call will return the items name (or its type name if no user defined name exists) as well as their x,y,z
        ///     coordinates.
        ///     <para></para>
        ///     Coordinates should all be 0 for valid locations located inside of stations.
        /// </summary>
        /// <param name="list">A list of item ids.</param>
        /// <returns></returns>
        public EveApiResponse<Locations> GetLocations(params long[] list) {
            return GetLocationsAsync(list).Result;
        }

        /// <summary>
        ///     Call will return the items name (or its type name if no user defined name exists) as well as their x,y,z
        ///     coordinates.
        ///     <para></para>
        ///     Coordinates should all be 0 for valid locations located inside of stations.
        /// </summary>
        /// <param name="list">A list of item ids.</param>
        /// <returns></returns>
        public Task<EveApiResponse<Locations>> GetLocationsAsync(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/corp/Locations.xml.aspx";
            string ids = String.Join(",", list);
            return requestAsync<Locations>(relPath, Key, "IDs", ids);
        }

        /// <summary>
        ///     Returns a list of market orders that are either not expired or have expired in the past week (at most).
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public EveApiResponse<MarketOrders> GetMarketOrders(long orderId = 0) {
            return GetMarketOrdersAsync(orderId).Result;
        }


        /// <summary>
        ///     Returns a list of market orders that are either not expired or have expired in the past week (at most).
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public Task<EveApiResponse<MarketOrders>> GetMarketOrdersAsync(long orderId = 0) {
            const string relPath = "/corp/MarketOrders.xml.aspx";
            return orderId == 0
                ? requestAsync<MarketOrders>(relPath, Key)
                : requestAsync<MarketOrders>(relPath, Key, "orderID", orderId);
        }

        /// <summary>
        ///     Returns a list of medals created by this corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MedalList> GetMedals() {
            return GetMedalsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of medals created by this corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MedalList>> GetMedalsAsync() {
            const string relPath = "/corp/Medals.xml.aspx";
            return requestAsync<MedalList>(relPath, Key);
        }

        /// <summary>
        ///     Returns a list of medals issued to members.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MemberMedals> GetMemberMedals() {
            return GetMemberMedalsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of medals issued to members.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MemberMedals>> GetMemberMedalsAsync() {
            const string relPath = "/corp/MemberMedals.xml.aspx";
            return requestAsync<MemberMedals>(relPath, Key);
        }

        /// <summary>
        ///     Returns the security roles of members in a corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MemberSecurity> GetMemberSecurity() {
            return GetMemberSecurityAsync().Result;
        }

        /// <summary>
        ///     Returns the security roles of members in a corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MemberSecurity>> GetMemberSecurityAsync() {
            const string relPath = "/corp/MemberSecurity.xml.aspx";
            return requestAsync<MemberSecurity>(relPath, Key);
        }

        /// <summary>
        ///     Returns info about corporation role changes for members and who did it.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MemberSecurityLog> GetMemberSecurityLog() {
            return GetMemberSecurityLogAsync().Result;
        }

        /// <summary>
        ///     Returns info about corporation role changes for members and who did it.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MemberSecurityLog>> GetMemberSecurityLogAsync() {
            const string relPath = "/corp/MemberSecurityLog.xml.aspx";
            return requestAsync<MemberSecurityLog>(relPath, Key);
        }

        /// <summary>
        ///     Returns information about all members in a corporation.
        /// </summary>
        /// <param name="extended">Optional; true for extended version</param>
        /// <returns></returns>
        public EveApiResponse<MemberTracking> GetMemberTracking(bool extended = false) {
            return GetMemberTrackingAsync(extended).Result;
        }

        /// <summary>
        ///     Returns information about all members in a corporation.
        /// </summary>
        /// <param name="extended">Optional; true for extended version</param>
        /// <returns></returns>
        public Task<EveApiResponse<MemberTracking>> GetMemberTrackingAsync(bool extended = false) {
            const string relPath = "/corp/MemberTracking.xml.aspx";
            return extended
                ? requestAsync<MemberTracking>(relPath, Key, "extended", 1)
                : requestAsync<MemberTracking>(relPath, Key);
        }

        /// <summary>
        ///     Returns information about the corporation's outposts.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<OutpostList> GetOutpostList() {
            return GetOutpostListAsync().Result;
        }

        /// <summary>
        ///     Returns information about the corporation's outposts.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<OutpostList>> GetOutpostListAsync() {
            // TODO Link to OutpostServiceDetails
            const string relPath = "/corp/OutpostList.xml.aspx";
            return requestAsync<OutpostList>(relPath, Key);
        }

        /// <summary>
        ///     Returns detailed information about a specific corporation outpost.
        /// </summary>
        /// <param name="itemId">Item ID of an outpost listed in OutpostList API call.</param>
        /// <returns></returns>
        public EveApiResponse<OutpostServiceDetails> GetOutpostServiceDetails(long itemId) {
            return GetOutpostServiceDetailsAsync(itemId).Result;
        }


        /// <summary>
        ///     Returns detailed information about a specific corporation outpost.
        /// </summary>
        /// <param name="itemId">Item ID of an outpost listed in OutpostList API call.</param>
        /// <returns></returns>
        public Task<EveApiResponse<OutpostServiceDetails>> GetOutpostServiceDetailsAsync(long itemId) {
            const string relPath = "/corp/OutpostServiceDetail.xml.aspx";
            return requestAsync<OutpostServiceDetails>(relPath, Key, "itemID", itemId);
        }

        /// <summary>
        ///     Returns the character and corporation share holders of a corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ShareholderList> GetShareholders() {
            return GetShareholdersAsync().Result;
        }


        /// <summary>
        ///     Returns the character and corporation share holders of a corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ShareholderList>> GetShareholdersAsync() {
            const string relPath = "/corp/Shareholders.xml.aspx";
            return requestAsync<ShareholderList>(relPath, Key);
        }

        /// <summary>
        ///     Returns the standings from NPC corporations and factions as well as agents.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<StandingsList> GetStandings() {
            return GetStandingsAsync().Result;
        }


        /// <summary>
        ///     Returns the standings from NPC corporations and factions as well as agents.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<StandingsList>> GetStandingsAsync() {
            const string relPath = "/corp/Standings.xml.aspx";
            return requestAsync<StandingsList>(relPath, Key);
        }

        /// <summary>
        ///     Returns the settings and fuel status of a POS.
        /// </summary>
        /// <param name="itemId">itemId of a starbase from StarbaseList</param>
        /// <returns></returns>
        public EveApiResponse<StarbaseDetails> GetStarbaseDetails(long itemId) {
            return GetStarbaseDetailsAsync(itemId).Result;
        }

        /// <summary>
        ///     Returns the settings and fuel status of a POS.
        /// </summary>
        /// <param name="itemId">itemId of a starbase from StarbaseList</param>
        /// <returns></returns>
        public Task<EveApiResponse<StarbaseDetails>> GetStarbaseDetailsAsync(long itemId) {
            // TODO CombatSettings
            const string relPath = "/corp/StarbaseDetail.xml.aspx";
            return requestAsync<StarbaseDetails>(relPath, Key, "itemID", itemId);
        }

        /// <summary>
        ///     Returns the list and states of POS'es.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<StarbaseList> GetStarbaseList() {
            return GetStarbaseListAsync().Result;
        }


        /// <summary>
        ///     Returns the list and states of POS'es.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<StarbaseList>> GetStarbaseListAsync() {
            const string relPath = "/corp/StarbaseList.xml.aspx";
            return requestAsync<StarbaseList>(relPath, Key);
        }

        /// <summary>
        ///     Returns the titles in the corporation.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<TitleList> GetTitles() {
            return GetTitlesAsync().Result;
        }

        /// <summary>
        ///     Returns the titles in the corporation.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<TitleList>> GetTitlesAsync() {
            const string relPath = "/corp/Titles.xml.aspx";
            return requestAsync<TitleList>(relPath, Key);
        }

        /// <summary>
        ///     Returns a list of journal transactions for the corporation.
        /// </summary>
        /// <param name="division">Optional; Wallet Division used for request. Default is Master Wallet.</param>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public EveApiResponse<WalletJournal> GetWalletJournal(int division = 1000, int count = 50, long fromId = 0) {
            return GetWalletJournalAsync(division, count, fromId).Result;
        }


        /// <summary>
        ///     Returns a list of journal transactions for the corporation.
        /// </summary>
        /// <param name="division">Optional; Wallet Division used for request. Default is Master Wallet.</param>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public Task<EveApiResponse<WalletJournal>> GetWalletJournalAsync(int division = 1000, int count = 50, long fromId = 0) {
            const string relPath = "/corp/WalletJournal.xml.aspx";
            return fromId == 0
                ? requestAsync<WalletJournal>(relPath, Key, "accountKey", division, "rowCount", count)
                : requestAsync<WalletJournal>(relPath, Key, "accountKey", division, "rowCount", count, "fromID", fromId);
        }

        /// <summary>
        ///     Returns market transactions for the corporation.
        /// </summary>
        /// <param name="division">Optional; Wallet Division used for request. Default is Master Wallet.</param>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public EveApiResponse<WalletTransactions> GetWalletTransactions(int division = 1000, int count = 1000,
            long fromId = 0) {
            return GetWalletTransactionsAsync(division, count, fromId).Result;
        }

        /// <summary>
        ///     Returns market transactions for the corporation.
        /// </summary>
        /// <param name="division">Optional; Wallet Division used for request. Default is Master Wallet.</param>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public Task<EveApiResponse<WalletTransactions>> GetWalletTransactionsAsync(int division = 1000, int count = 1000,
            long fromId = 0) {
            const string relPath = "/corp/WalletTransactions.xml.aspx";
            return fromId == 0
                ? requestAsync<WalletTransactions>(relPath, Key, "accountKey", division, "rowCount", count)
                : requestAsync<WalletTransactions>(relPath, Key, "accountKey", division, "rowCount", count, "fromID", fromId);
        }
    }
}