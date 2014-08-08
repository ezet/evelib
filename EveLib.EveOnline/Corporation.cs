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
    ///     Provides access to all API calls relating to a specific corporation, that is, all API paths starting with /corp in
    ///     CCPs API.
    /// </summary>
    public class Corporation : LazyLoadEntity {
        private long _allianceId;
        private string _allianceName;
        private string _corporationName;
        private long _factionId;
        private string _factionName;

        /// <summary>
        ///     Creates a new Corporation, preserving the initialized data and key from the passed in entity
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="entity"></param>
        internal Corporation(CorporationKey apiKey, ApiKeyInfo.ApiKeyEntity entity) {
            ApiKey = apiKey;
            CorporationId = entity.CorporationId;
            CorporationName = entity.CorporationName;
            AllianceId = entity.AllianceId;
            AllianceName = entity.AllianceName;
            FactionId = entity.FactionId;
            FactionName = entity.FactionName;
            BaseUri = apiKey.BaseUri;
            IsInitialized = true;
        }

        /// <summary>
        ///     Creates a new Corporation. If the Key is initialized, the Corporation will also be initialized with data from the
        ///     Key.
        /// </summary>
        /// <param name="apiKey">A CorporationKey</param>
        /// <param name="corporationId">A valid Eve Online Corporation ID</param>
        public Corporation(CorporationKey apiKey, long corporationId) {
            Contract.Requires(apiKey != null);
            ApiKey = apiKey;
            CorporationId = corporationId;
            if (ApiKey.IsInitialized)
                ensureInitialized();
        }

        /// <summary>
        ///     Creates a new corporation. This object will not be initialized.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        /// <param name="corporationId"></param>
        public Corporation(int keyId, string vCode, long corporationId) {
            ApiKey = new CorporationKey(keyId, vCode);
            CorporationId = corporationId;
        }

        /// <summary>
        ///     Gets the CorporationKey for this Corporation.
        /// </summary>
        public CorporationKey ApiKey { get; private set; }


        /// <summary>
        ///     Gets the Corporation ID.
        /// </summary>
        public long CorporationId { get; private set; }

        /// <summary>
        ///     Gets the Corporation name. Note: If this object has not already been initialized, this will send a web request to
        ///     the API.
        /// </summary>
        public string CorporationName {
            get {
                if (!IsInitialized) Init();
                return _corporationName;
            }
            private set { _corporationName = value; }
        }

        /// <summary>
        ///     Gets the Alliance name. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public string AllianceName {
            get {
                if (!IsInitialized) Init();
                return _allianceName;
            }
            private set { _allianceName = value; }
        }

        /// <summary>
        ///     Gets the Alliance ID. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public long AllianceId {
            get {
                if (!IsInitialized) Init();
                return _allianceId;
            }
            private set { _allianceId = value; }
        }

        /// <summary>
        ///     Gets the Faction ID. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public long FactionId {
            get {
                if (!IsInitialized) Init();
                return _factionId;
            }
            private set { _factionId = value; }
        }

        /// <summary>
        ///     Gets the Faction name. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public string FactionName {
            get {
                if (!IsInitialized) Init();
                return _factionName;
            }
            private set { _factionName = value; }
        }


        /// <summary>
        ///     Resets the properties for this Corporation and it's CorporationKey, allowing new data to be fethed with Init() or
        ///     InitAsync().
        /// </summary>
        public void Reset() {
            IsInitialized = false;
            ApiKey.Reset();
        }


        /// <summary>
        ///     Initializes this Corporations properties with values fetched from the API. Returns immediately if this Corporation
        ///     is already initialized.
        /// </summary>
        /// <returns>This corporation</returns>
        public Corporation Init() {
            if (IsInitialized) return this;
            ApiKey.Init();
            ensureInitialized();
            return this;
        }

        /// <summary>
        ///     Initializes this Corporations properties with values fetched from the API. Returns immediately if this Corporation
        ///     is already initialized.
        /// </summary>
        /// <returns>This corporation</returns>
        public async Task<Corporation> InitAsync() {
            if (IsInitialized) return this;
            await ApiKey.InitAsync().ConfigureAwait(false);
            ensureInitialized();
            return this;
        }

        private void ensureInitialized() {
            if (_isInitialized) return;
            lock (_lazyLoadLock) {
                if (_isInitialized) return;
                Corporation corp = ApiKey.Corporation;
                _corporationName = corp.CorporationName;
                _allianceId = corp.AllianceId;
                _allianceName = corp.AllianceName;
                _factionId = corp.FactionId;
                _factionName = corp.FactionName;
                _isInitialized = true;
            }
        }

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
            return requestAsync<AccountBalance>(relPath, ApiKey);
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
            return requestAsync<AssetList>(relPath, ApiKey);
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
            return requestAsync<ContactList>(relPath, ApiKey);
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
            return requestAsync<ContainerLog>(relPath, ApiKey);
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
            return requestAsync<ContractList>(relPath, ApiKey);
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
            return requestAsync<ContractItems>(relPath, ApiKey, "contractID", contractId);
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
            return requestAsync<ContractBids>(relPath, ApiKey);
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
            return requestAsync<CorporationSheet>(relPath, ApiKey);
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
            return requestAsync<FactionWarfareStats>(relPath, ApiKey);
        }

        /// <summary>
        ///     Returns the currently running industry jobs.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<IndustryJobs>> GetIndustryJobsAsync() {
            const string relPath = "/corp/IndustryJobs.xml.aspx";
            return requestAsync<IndustryJobs>(relPath, ApiKey);
        }

        /// <summary>
        ///     Returns the currently running industry jobs.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<IndustryJobs> GetIndustryJobs() {
            return GetIndustryJobsAsync().Result;
        }

        /// <summary>
        ///     Returns currently running and ended industry jobs.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<IndustryJobs>> GetIndustryJobsHistoryAsync() {
            const string relPath = "/corp/IndustryJobsHistory.xml.aspx";
            return requestAsync<IndustryJobs>(relPath, ApiKey);
        }

        /// <summary>
        ///     Returns currently running and ended industry jobs.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<IndustryJobs> GetIndustryHistoryJobs() {
            return GetIndustryJobsHistoryAsync().Result;
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
                ? requestAsync<KillLog>(relPath, ApiKey)
                : requestAsync<KillLog>(relPath, ApiKey, "beforeKillID", killId);
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
            Contract.Requires(list != null);
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
            return requestAsync<Locations>(relPath, ApiKey, "IDs", ids);
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
                ? requestAsync<MarketOrders>(relPath, ApiKey)
                : requestAsync<MarketOrders>(relPath, ApiKey, "orderID", orderId);
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
            return requestAsync<MedalList>(relPath, ApiKey);
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
            return requestAsync<MemberMedals>(relPath, ApiKey);
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
            return requestAsync<MemberSecurity>(relPath, ApiKey);
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
            return requestAsync<MemberSecurityLog>(relPath, ApiKey);
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
                ? requestAsync<MemberTracking>(relPath, ApiKey, "extended", 1)
                : requestAsync<MemberTracking>(relPath, ApiKey);
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
            return requestAsync<OutpostList>(relPath, ApiKey);
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
            return requestAsync<OutpostServiceDetails>(relPath, ApiKey, "itemID", itemId);
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
            return requestAsync<ShareholderList>(relPath, ApiKey);
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
            return requestAsync<StandingsList>(relPath, ApiKey);
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
            return requestAsync<StarbaseDetails>(relPath, ApiKey, "itemID", itemId);
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
            return requestAsync<StarbaseList>(relPath, ApiKey);
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
            return requestAsync<TitleList>(relPath, ApiKey);
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
        public Task<EveApiResponse<WalletJournal>> GetWalletJournalAsync(int division = 1000, int count = 50,
            long fromId = 0) {
            const string relPath = "/corp/WalletJournal.xml.aspx";
            return fromId == 0
                ? requestAsync<WalletJournal>(relPath, ApiKey, "accountKey", division, "rowCount", count)
                : requestAsync<WalletJournal>(relPath, ApiKey, "accountKey", division, "rowCount", count, "fromID",
                    fromId);
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
                ? requestAsync<WalletTransactions>(relPath, ApiKey, "accountKey", division, "rowCount", count)
                : requestAsync<WalletTransactions>(relPath, ApiKey, "accountKey", division, "rowCount", count, "fromID",
                    fromId);
        }

        /// <summary>
        ///     Returns a list of owned Customs Offices
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<CustomsOffices>> GetCustomsOfficesAsync() {
            const string relPath = "/corp/CustomsOffices.xml.aspx";
            return requestAsync<CustomsOffices>(relPath, ApiKey);
        }

        /// <summary>
        ///     Returns a list of owned Customs Offices
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CustomsOffices> GetCustomsOffices() {
            return GetCustomsOfficesAsync().Result;
        }

        /// <summary>
        ///     Returns a listing all of a corporations facilities, including POS and Outposts.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<Facilities>> GetFacilitiesAsync() {
            const string relPath = "/corp/Facilities.xml.aspx";
            return requestAsync<Facilities>(relPath, ApiKey);
        }

        /// <summary>
        ///     Returns a listing all of a corporations facilities, including POS and Outposts.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Facilities> GetFacilities() {
            return GetFacilitiesAsync().Result;
        }

        /// <summary>
        ///  Returns the blueprints owned by this character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<BlueprintList>> GetBlueprintsAsync() {
            const string relPath = "/corp/Blueprints.xml.aspx";
            return requestAsync<BlueprintList>(relPath, ApiKey, "characterID", CorporationId);
        }

        /// <summary>
        ///  Returns the blueprints owned by this character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<BlueprintList> GetBlueprints() {
            return GetBlueprintsAsync().Result;
        }
    }
}