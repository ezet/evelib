using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Misc;
using FactionWarfareStats = eZet.EveLib.Modules.Models.Character.FactionWarfareStats;

[assembly: InternalsVisibleTo("EveLib.Test")]

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to all API calls relating to a specific character, that is, URIs prefixed with /char in CCPs API.
    /// </summary>
    public class Character : LazyLoadEntity {
        /// <summary>
        ///     The Wallet identifier. For characters this is always 1000.
        /// </summary>
        public const int AccountKey = 1000;

        private long _allianceId;
        private string _allianceName;

        private string _characterName;
        private long _corporationId;
        private string _corporationName;
        private long _factionId;
        private string _factionName;

        internal Character(CharacterKey apiKey, ApiKeyInfo.ApiKeyEntity entity) {
            ApiKey = apiKey;
            CharacterId = entity.CharacterId;
            CharacterName = entity.CharacterName;
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
        ///     Creates a new Character using the provided key data and character id.
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <param name="characterId">Eve Character ID</param>
        public Character(int keyId, string vCode, long characterId) {
            ApiKey = new CharacterKey(keyId, vCode);
            CharacterId = characterId;
        }

        /// <summary>
        ///     Creates a new Character. If the CharacterKey is initialized, the Character will also be initialized with data from
        ///     the Key.
        /// </summary>
        /// <param name="apiKey">A valid CharacterKey</param>
        /// <param name="characterId">A valid Eve Online Character ID</param>
        public Character(CharacterKey apiKey, long characterId) {
            Contract.Requires(apiKey != null);
            ApiKey = apiKey;
            CharacterId = characterId;
            if (ApiKey.IsInitialized)
                ensureInitialized();
        }

        /// <summary>
        ///     Gets the CharacterKey for this Character.
        /// </summary>
        public CharacterKey ApiKey { get; private set; }

        /// <summary>
        ///     Gets the Character ID.
        /// </summary>
        public long CharacterId { get; private set; }

        /// <summary>
        ///     Gets the name of this character. Note: If this object has not already been initialized, this will send a web
        ///     request to the API.
        /// </summary>
        public string CharacterName {
            get {
                if (!_isInitialized) Init();
                return _characterName;
            }
            private set { _characterName = value; }
        }

        /// <summary>
        ///     Gets the Corporation ID. Note: Note: If this object has not already been initialized, this will send a web request
        ///     to the API.
        /// </summary>
        public long CorporationId {
            get {
                if (!_isInitialized) Init();
                return _corporationId;
            }
            private set { _corporationId = value; }
        }

        /// <summary>
        ///     Gets the corporation name. Note: If this object has not already been initialized, this will send a web request to
        ///     the API.
        /// </summary>
        public string CorporationName {
            get {
                if (!_isInitialized) Init();
                return _corporationName;
            }
            private set { _corporationName = value; }
        }

        /// <summary>
        ///     Gets the Alliance ID. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public long AllianceId {
            get {
                if (!_isInitialized) Init();
                return _allianceId;
            }
            private set { _allianceId = value; }
        }

        /// <summary>
        ///     Gets the Alliance name. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public string AllianceName {
            get {
                if (!_isInitialized) Init();
                return _allianceName;
            }
            private set { _allianceName = value; }
        }

        /// <summary>
        ///     Gets the Faction ID. Note: If this object has not already been initialized, this will send a web request to the
        ///     API.
        /// </summary>
        public long FactionId {
            get {
                if (!_isInitialized) Init();
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
                if (!_isInitialized) Init();
                return _factionName;
            }
            private set { _factionName = value; }
        }

        /// <summary>
        ///     Resets the properties for this Character and it's CharacterKey, allowing new data to be fethed with Init() or
        ///     InitAsync().
        /// </summary>
        public void Reset() {
            IsInitialized = false;
            ApiKey.Reset();
        }

        /// <summary>
        ///     Initializes this Characters properties with values fetched from the API. Returns immediately if this character is
        ///     already initialized.
        /// </summary>
        /// <returns>This Character</returns>
        public Character Init() {
            if (IsInitialized) return this;
            ApiKey.Init();
            ensureInitialized();
            return this;
        }

        /// <summary>
        ///     Initializes this Characters properties with values fetched from the API. Returns immediately if this character is
        ///     already initialized.
        /// </summary>
        /// <returns>This Character</returns>
        public async Task<Character> InitAsync() {
            if (IsInitialized) return this;
            await ApiKey.InitAsync().ConfigureAwait(false);
            ensureInitialized();
            return this;
        }

        private void ensureInitialized() {
            if (_isInitialized) return;
            lock (_lazyLoadLock) {
                if (_isInitialized) return;
                Character character = ApiKey.Characters.Single(c => c.CharacterId == CharacterId);
                _characterName = character.CharacterName;
                _corporationId = character.CorporationId;
                _corporationName = character.CorporationName;
                _allianceId = character.AllianceId;
                _allianceName = character.AllianceName;
                _factionId = character.FactionId;
                _factionName = character.FactionName;
                _isInitialized = true;
            }
        }

        /// <summary>
        ///     Returns general information about the character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CharacterInfo> GetCharacterInfo() {
            return GetCharacterInfoAsync().Result;
        }

        /// <summary>
        ///     Returns general information about the character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<CharacterInfo>> GetCharacterInfoAsync() {
            const string relPath = "/eve/CharacterInfo.xml.aspx";
            return requestAsync<CharacterInfo>(relPath, ApiKey, "characterID", CharacterId);
        }

        /// <summary>
        ///     Returns the ISK balance of a character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<AccountBalance> GetAccountBalance() {
            return GetAccountBalanceAsync().Result;
        }

        /// <summary>
        ///     Returns the ISK balance of a character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<AccountBalance>> GetAccountBalanceAsync() {
            const string relPath = "/char/AccountBalance.xml.aspx";
            return requestAsync<AccountBalance>(relPath, ApiKey, "characterID", CharacterId);
        }

        /// <summary>
        ///     Returns a list of assets owned by a character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<AssetList> GetAssetList() {
            return GetAssetListAsync().Result;
        }

        /// <summary>
        ///     Returns a list of assets owned by a character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<AssetList>> GetAssetListAsync() {
            const string relPath = "/char/AssetList.xml.aspx";
            return requestAsync<AssetList>(relPath, ApiKey, "characterID", CharacterId);
        }


        /// <summary>
        ///     Returns a list of all invited attendees for a given event.
        ///     <para> </para>
        ///     NOTE: A call to Upcoming Calendar Events must be made prior to calling this API. Otherwise you will receive an
        ///     error:
        ///     <para> </para>
        ///     216: Calendar Event List not populated with upcoming events. You cannot request any random eventID.
        /// </summary>
        /// <param name="eventId">The id of the event.</param>
        /// <returns></returns>
        public EveApiResponse<CalendarEventAttendees> GetCalendarEventAttendees(long eventId) {
            return GetCalendarEventAttendeesAsync(eventId).Result;
        }

        /// <summary>
        ///     Returns a list of all invited attendees for a given event.
        ///     <para> </para>
        ///     NOTE: A call to Upcoming Calendar Events must be made prior to calling this API. Otherwise you will receive an
        ///     error:
        ///     <para> </para>
        ///     216: Calendar Event List not populated with upcoming events. You cannot request any random eventID.
        /// </summary>
        /// <param name="eventId">The id of the event.</param>
        /// <returns></returns>
        public Task<EveApiResponse<CalendarEventAttendees>> GetCalendarEventAttendeesAsync(long eventId) {
            const string relPath = "/char/CalendarEventAttendees.xml.aspx";
            return requestAsync<CalendarEventAttendees>(relPath, ApiKey, "characterID", CharacterId, "EventIDs", eventId);
        }


        /// <summary>
        ///     Returns attributes relating to a specific character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CharacterSheet> GetCharacterSheet() {
            return GetCharacterSheetAsync().Result;
        }

        /// <summary>
        ///     Returns attributes relating to a specific character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<CharacterSheet>> GetCharacterSheetAsync() {
            const string relPath = "/char/CharacterSheet.xml.aspx";
            return requestAsync<CharacterSheet>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the character's contact and watch lists, incl. agents and respective standings set by the character. Also
        ///     includes that character's corporation and/or alliance contacts.
        ///     <para></para>
        ///     See the Standings API for standings towards the character from agents and NPC entities.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContactList> GetContactList() {
            return GetContactListAsync().Result;
        }

        /// <summary>
        ///     Returns the character's contact and watch lists, incl. agents and respective standings set by the character. Also
        ///     includes that character's corporation and/or alliance contacts.
        ///     <para></para>
        ///     See the Standings API for standings towards the character from agents and NPC entities.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContactList>> GetContactListAsync() {
            const string relPath = "/char/ContactList.xml.aspx";
            return requestAsync<ContactList>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Lists the notifications received about having been added to someone's contact list.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContactNotifications> GetContactNotifications() {
            return GetContactNotificationsAsync().Result;
        }

        /// <summary>
        ///     Lists the notifications received about having been added to someone's contact list.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContactNotifications>> GetContactNotificationsAsync() {
            const string relPath = "/char/ContactNotifications.xml.aspx";
            return requestAsync<ContactNotifications>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Lists the personal contracts for a character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ContractList> GetContracts() {
            return GetContractsAsync().Result;
        }

        /// <summary>
        ///     Lists the personal contracts for a character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ContractList>> GetContractsAsync() {
            const string relPath = "/char/Contracts.xml.aspx";
            return requestAsync<ContractList>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract id.</param>
        /// <returns></returns>
        public EveApiResponse<ContractItems> GetContractItems(long contractId) {
            return GetContractItemsAsync(contractId).Result;
        }

        /// <summary>
        ///     Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract id.</param>
        /// <returns></returns>
        public Task<EveApiResponse<ContractItems>> GetContractItemsAsync(long contractId) {
            const string relPath = "/char/ContractItems.xml.aspx";
            return requestAsync<ContractItems>(relPath, ApiKey, "characterId", CharacterId, "contractID", contractId);
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
            const string relPath = "/char/ContractBids.xml.aspx";
            return requestAsync<ContractBids>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     If the character is enlisted in Factional Warfare, this will return statistics regarding factional warfare for this
        ///     character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<FactionWarfareStats> GetFactionWarfareStats() {
            return GetFactionWarfareStatsAsync().Result;
        }

        /// <summary>
        ///     If the character is enlisted in Factional Warfare, this will return statistics regarding factional warfare for this
        ///     character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<FactionWarfareStats>> GetFactionWarfareStatsAsync() {
            const string relPath = "/char/FacWarStats.xml.aspx";
            return requestAsync<FactionWarfareStats>(relPath, ApiKey, "characterId", CharacterId);
        }

  /// <summary>
        ///     Returns the currently running industry jobs.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<IndustryJobs>> GetIndustryJobsAsync() {
            const string relPath = "/char/IndustryJobs.xml.aspx";
            return requestAsync<IndustryJobs>(relPath, ApiKey, "characterId", CharacterId);
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
            const string relPath = "/char/IndustryJobsHistory.xml.aspx";
            return requestAsync<IndustryJobs>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns currently running and ended industry jobs.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<IndustryJobs> GetIndustryJobsHistory() {
            return GetIndustryJobsHistoryAsync().Result;
        }

        /// <summary>
        ///     Returns a list of kills where this character received the final blow and losses of this character.
        ///     <para></para>
        ///     Returns the 25 most recent kills. You can walk back with the killId parameter.
        /// </summary>
        /// <param name="killId">Optional; if present, return the most recent kills before the specified killID.</param>
        /// <returns></returns>
        public EveApiResponse<KillLog> GetKillLog(long killId = 0) {
            return GetKillLogAsync(killId).Result;
        }

        /// <summary>
        ///     Returns a list of kills where this character received the final blow and losses of this character.
        ///     <para></para>
        ///     Returns the 25 most recent kills. You can walk back with the killId parameter.
        /// </summary>
        /// <param name="killId">Optional; if present, return the most recent kills before the specified killID.</param>
        /// <returns></returns>
        public Task<EveApiResponse<KillLog>> GetKillLogAsync(long killId = 0) {
            // TODO Add walking
            const string relPath = "/char/KillLog.xml.aspx";
            return killId != 0
                ? requestAsync<KillLog>(relPath, ApiKey, "characterId", CharacterId, "beforeKillId", killId)
                : requestAsync<KillLog>(relPath, ApiKey, "characterId", CharacterId);
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
            const string relPath = "/char/Locations.xml.aspx";
            string ids = String.Join(",", list);
            return requestAsync<Locations>(relPath, ApiKey, "characterId", CharacterId, "IDs", ids);
        }

        /// <summary>
        ///     Returns the bodies of headers that have already been fetched with the MailMessages call.
        ///     <para></para>
        ///     It will also return a list of missing IDs that could not be accessed. Bodies cannot be accessed if you have not
        ///     called for their headers recently.
        /// </summary>
        /// <param name="list">A list of message ids from GetMailMessages.</param>
        /// <returns></returns>
        public EveApiResponse<MailBodies> GetMailBodies(params long[] list) {
            Contract.Requires(list != null);
            return GetMailBodiesAsync(list).Result;
        }

        /// <summary>
        ///     Returns the bodies of headers that have already been fetched with the MailMessages call.
        ///     <para></para>
        ///     It will also return a list of missing IDs that could not be accessed. Bodies cannot be accessed if you have not
        ///     called for their headers recently.
        /// </summary>
        /// <param name="list">A list of message ids from GetMailMessages.</param>
        /// <returns></returns>
        public Task<EveApiResponse<MailBodies>> GetMailBodiesAsync(params long[] list) {
            Contract.Requires(list != null);
            const string relPath = "/char/MailBodies.xml.aspx";
            string ids = String.Join(",", list);
            return requestAsync<MailBodies>(relPath, ApiKey, "characterId", CharacterId, "IDs", ids);
        }

        /// <summary>
        ///     Returns an XML document listing all mailing lists the character is currently a member of.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MailingLists> GetMailingLists() {
            return GetMailingListsAsync().Result;
        }

        /// <summary>
        ///     Returns an XML document listing all mailing lists the character is currently a member of.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MailingLists>> GetMailingListsAsync() {
            const string relPath = "/char/mailinglists.xml.aspx";
            return requestAsync<MailingLists>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the message headers for mail.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MailMessages> GetMailMessages() {
            return GetMailMessagesAsync().Result;
        }

        /// <summary>
        ///     Returns the message headers for mail.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MailMessages>> GetMailMessagesAsync() {
            const string relPath = "/char/MailMessages.xml.aspx";
            return requestAsync<MailMessages>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns a list of market orders for your character.
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public EveApiResponse<MarketOrders> GetMarketOrders(long orderId = 0) {
            return GetMarketOrdersAsync(orderId).Result;
        }

        /// <summary>
        ///     Returns a list of market orders for your character.
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public Task<EveApiResponse<MarketOrders>> GetMarketOrdersAsync(long orderId = 0) {
            const string relPath = "/char/MarketOrders.xml.aspx";
            return orderId == 0
                ? requestAsync<MarketOrders>(relPath, ApiKey, "characterId", CharacterId)
                : requestAsync<MarketOrders>(relPath, ApiKey, "characterId", CharacterId, "orderID", orderId);
        }

        /// <summary>
        ///     Returns a list of medals the character has.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<MedalList> GetMedals() {
            return GetMedalsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of medals the character has.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<MedalList>> GetMedalsAsync() {
            const string relPath = "/char/Medals.xml.aspx";
            return requestAsync<MedalList>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the message headers for notifications.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<NotificationList> GetNotifications() {
            return GetNotificationsAsync().Result;
        }

        /// <summary>
        ///     Returns the message headers for notifications.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<NotificationList>> GetNotificationsAsync() {
            const string relPath = "/char/Notifications.xml.aspx";
            return requestAsync<NotificationList>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the message bodies for notifications. Headers need to be requested with GetNotifications first.
        /// </summary>
        /// <param name="ids">A list of notification ids obtained from GetNotifications.</param>
        /// <returns></returns>
        public EveApiResponse<NotificationTexts> GetNotificationTexts(params long[] ids) {
            Contract.Requires(ids != null);
            return GetNotificationTextsAsync(ids).Result;
        }


        /// <summary>
        ///     Returns the message bodies for notifications. Headers need to be requested with GetNotifications first.
        /// </summary>
        /// <param name="ids">A list of notification ids obtained from GetNotifications.</param>
        /// <returns></returns>
        public Task<EveApiResponse<NotificationTexts>> GetNotificationTextsAsync(params long[] ids) {
            Contract.Requires(ids != null);
            const string relPath = "/char/NotificationTexts.xml.aspx";
            string idList = string.Join(",", ids);
            return requestAsync<NotificationTexts>(relPath, ApiKey, "characterId", CharacterId, "IDs", idList);
        }

        /// <summary>
        ///     Returns information about agents character is doing research with.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Research> GetResearch() {
            return GetResearchAsync().Result;
        }

        /// <summary>
        ///     Returns information about agents character is doing research with.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<Research>> GetResearchAsync() {
            const string relPath = "/char/Research.xml.aspx";
            return requestAsync<Research>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the skill the character is currently training.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<SkillTraining> GetSkillTraining() {
            return GetSkillTrainingAsync().Result;
        }

        /// <summary>
        ///     Returns the skill the character is currently training.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<SkillTraining>> GetSkillTrainingAsync() {
            const string relPath = "/char/SkillInTraining.xml.aspx";
            return requestAsync<SkillTraining>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the skill queue of the character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<SkillQueue> GetSkillQueue() {
            return GetSkillQueueAsync().Result;
        }

        /// <summary>
        ///     Returns the skill queue of the character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<SkillQueue>> GetSkillQueueAsync() {
            const string relPath = "/char/SkillQueue.xml.aspx";
            return requestAsync<SkillQueue>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns the standings towards a character from agents, NPC corporations and factions.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<StandingsList> GetStandings() {
            return GetStandingsAsync().Result;
        }

        /// <summary>
        ///     Returns the standings towards a character from agents, NPC corporations and factions.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<StandingsList>> GetStandingsAsync() {
            const string relPath = "/char/Standings.xml.aspx";
            return requestAsync<StandingsList>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns a list of all upcoming calendar events for a given character.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<UpcomingCalendarEvents> GetUpcomingCalendarEvents() {
            return GetUpcomingCalendarEventsAsync().Result;
        }


        /// <summary>
        ///     Returns a list of all upcoming calendar events for a given character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<UpcomingCalendarEvents>> GetUpcomingCalendarEventsAsync() {
            const string relPath = "/char/UpcomingCalendarEvents.xml.aspx";
            return requestAsync<UpcomingCalendarEvents>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns a list of journal transactions for the character.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public EveApiResponse<WalletJournal> GetWalletJournal(int count = 50, long fromId = 0) {
            return GetWalletJournalAsync(count, fromId).Result;
        }


        /// <summary>
        ///     Returns a list of journal transactions for the character.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public Task<EveApiResponse<WalletJournal>> GetWalletJournalAsync(int count = 50, long fromId = 0) {
            const string relPath = "/char/WalletJournal.xml.aspx";
            return fromId == 0
                ? requestAsync<WalletJournal>(relPath, ApiKey, "characterId", CharacterId, "rowCount", count)
                : requestAsync<WalletJournal>(relPath, ApiKey, "characterId", CharacterId, "rowCount", count, "fromID",
                    fromId);
        }

        /// <summary>
        ///     Returns market transactions for the character.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public EveApiResponse<WalletTransactions> GetWalletTransactions(int count = 1000, long fromId = 0) {
            return GetWalletTransactionsAsync(count, fromId).Result;
        }

        /// <summary>
        ///     Returns market transactions for the character.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public Task<EveApiResponse<WalletTransactions>> GetWalletTransactionsAsync(int count = 1000, long fromId = 0) {
            const string relPath = "/char/WalletTransactions.xml.aspx";
            return fromId == 0
                ? requestAsync<WalletTransactions>(relPath, ApiKey, "characterId", CharacterId, "rowCount", count)
                : requestAsync<WalletTransactions>(relPath, ApiKey, "characterId", CharacterId, "rowCount", count,
                    "fromID",
                    fromId);
        }

        /// <summary>
        ///     Returns planetary colonies.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<PlanetaryColonies> GetPlanetaryColonies() {
            return GetPlanetaryColoniesAsync().Result;
        }

        /// <summary>
        ///     Returns planetary colonies.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<PlanetaryColonies>> GetPlanetaryColoniesAsync() {
            const string relPath = "/char/PlanetaryColonies.xml.aspx";
            return requestAsync<PlanetaryColonies>(relPath, ApiKey, "characterId", CharacterId);
        }

        /// <summary>
        ///     Returns planetary pins for a planet.
        /// </summary>
        /// <param name="planetId">Planet ID</param>
        /// <returns></returns>
        public EveApiResponse<PlanetaryPins> GetPlanetaryPins(long planetId) {
            return GetPlanetaryPinsAsync(planetId).Result;
        }

        /// <summary>
        ///     Returns planetary pins for a planet.
        /// </summary>
        /// <param name="planetId">Planet ID</param>
        /// <returns></returns>
        public Task<EveApiResponse<PlanetaryPins>> GetPlanetaryPinsAsync(long planetId) {
            const string relPath = "/char/PlanetaryPins.xml.aspx";
            return requestAsync<PlanetaryPins>(relPath, ApiKey, "characterId", CharacterId, "planetId", planetId);
        }

        /// <summary>
        ///     Returns planetary routes for a planet.
        /// </summary>
        /// <param name="planetId">Planet ID</param>
        /// <returns></returns>
        public EveApiResponse<PlanetaryRoutes> GetPlanetaryRoutes(long planetId) {
            return GetPlanetaryRoutesAsync(planetId).Result;
        }


        /// <summary>
        ///     Returns planetary routes for a planet.
        /// </summary>
        /// <param name="planetId">Planet ID</param>
        /// <returns></returns>
        public Task<EveApiResponse<PlanetaryRoutes>> GetPlanetaryRoutesAsync(long planetId) {
            const string relPath = "/char/PlanetaryRoutes.xml.aspx";
            return requestAsync<PlanetaryRoutes>(relPath, ApiKey, "characterId", CharacterId, "planetId", planetId);
        }

        /// <summary>
        ///     Returns planetary links for a planet.
        /// </summary>
        /// <param name="planetId">Planet ID</param>
        /// <returns></returns>
        public EveApiResponse<PlanetaryLinks> GetPlanetaryLinks(long planetId) {
            return GetPlanetaryLinksAsync(planetId).Result;
        }

        /// <summary>
        ///     Returns planetary links for a planet.
        /// </summary>
        /// <param name="planetId">Planet ID</param>
        /// <returns></returns>
        public Task<EveApiResponse<PlanetaryLinks>> GetPlanetaryLinksAsync(long planetId) {
            const string relPath = "/char/PlanetaryLinks.xml.aspx";
            return requestAsync<PlanetaryLinks>(relPath, ApiKey, "characterId", CharacterId, "planetId", planetId);
        }

        /// <summary>
        ///  Returns the blueprints owned by this character.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<BlueprintList>> GetBlueprintsAsync() {
            const string relPath = "/char/Blueprints.xml.aspx";
            return requestAsync<BlueprintList>(relPath, ApiKey, "characterID", CharacterId);
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