using eZet.Eve.EveApi.Dto.EveApi;
using System;

using eZet.Eve.EveApi.Dto.EveApi.Character;

namespace eZet.Eve.EveApi.Entity {

    public class Character : EveApiEntity {

        public const int AccountKey = 1000;

        public string Name { get; private set; }

        public long Id { get; private set; }

        public Corporation Corporation { get; private set; }

        public Character(ApiKey key, long id) : base(key) {
            Id = id;
            load();
        }

        public Character(ApiKey key, string name, long id, string corporationName, long corporationId) : base(key) {
            Name = name;
            Id = id;
            Corporation = new Corporation(key, corporationName, corporationId);
        }

        public XmlResponse<AccountBalance> GetAccountBalance() {
            const string relPath = "/char/AccountBalance.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new AccountBalance(), postString);
        }

        public XmlResponse<AssetList> GetAssetList() {
            const string relPath = "/char/AssetList.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new AssetList(), postString);
        }

        public XmlResponse<CalendarEventAttendees> GetCalendarEventAttendees(long eventId) {
            const string relPath = "/char/CalendarEventAttendees.xml.aspx";
            var postString = WebHelper.GeneratePostString("EventIds", eventId);
            return request(relPath, new CalendarEventAttendees(), postString);
        }

        public XmlResponse<CharacterSheet> GetCharacterSheet() {
            const string relPath = "/char/CharacterSheet.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new CharacterSheet(), postString);
        }

        public XmlResponse<ContactList> GetContactList() {
            const string relPath = "/char/ContactList.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new ContactList(), postString);
        }

        public XmlResponse<ContactNotifications> GetContactNotifications() {
            const string relPath = "/char/ContactNotifications.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new ContactNotifications(), postString);
        }

        public XmlResponse<ContractList> GetContracts() {
            const string relPath = "/char/Contracts.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new ContractList(), postString);
        }

        public XmlResponse<ContractItems> GetContractItems(long contractId) {
            const string relPath = "/char/ContractItems.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "contractID", contractId);
            return request(relPath, new ContractItems(), postString);
        }

        public XmlResponse<ContractBids> GetContractBids() {
            const string relPath = "/char/ContractBids.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new ContractBids(), postString);
        }

        public XmlResponse<FactionWarfareStats> GetFactionWarfareStats() {
            const string relPath = "/char/FacWarStats.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new FactionWarfareStats(), postString);
        }

        public XmlResponse<IndustryJobs> GetIndustryJobs() {
            const string relPath = "char/IndustryJobs.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new IndustryJobs(), postString);
        }

        public XmlResponse<KillLog> GetKillLog(long killId = 0) {
            // TODO Add walking
            const string relPath = "/char/KillLog.xml.aspx";
            var postString = killId != 0 ? WebHelper.GeneratePostString(ApiKey, "characterId", Id, "beforeKillID", killId)
                : WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new KillLog(), postString);
        }

        public XmlResponse<Locations> GetLocations(params long[] list) {
            const string relPath = "/char/Locations.xml.aspx";
            var ids = String.Join(",", list);
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "IDs", ids);
            return request(relPath, new Locations(), postString);

        }

        public XmlResponse<MailBodies> GetMailBodies(params long[] list) {
            const string relPath = "/char/MailBodies.xml.aspx";
            var ids = String.Join(",", list);
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "IDs", ids);
            return request(relPath, new MailBodies(), postString);
        }

        public XmlResponse<MailingLists> GetMailingLists() {
            const string relPath = "/char/mailinglists.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new MailingLists(), postString);
        }

        public XmlResponse<MailMessages> GetMailMessages() {
            const string relPath = "/char/MailMessages.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new MailMessages(), postString);
        }

        public XmlResponse<MarketOrders> GetMarketorders() {
            const string relPath = "/char/MarketOrders.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new MarketOrders(), postString);
        }

        public XmlResponse<MedalList> GetMedals() {
            const string relPath = "/char/Medals.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new MedalList(), postString);
        }

        public XmlResponse<NotificationList> GetNotifications() {
            const string relPath = "/char/Notifications.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id);
            return request(relPath, new NotificationList(), postString);
        }



        public XmlResponse<NotificationTexts> GetNotificationTexts() {
            const string relPath = "/char/NotificationTexts.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new NotificationTexts(), postString);
        }

        public XmlResponse<Research> GetResearch() {
            const string relPath = "/char/Research.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new Research(), postString);
        }

        public XmlResponse<SkillTraining> GetSkillTraining() {
            const string relPath = "/char/SkillInTraining.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new SkillTraining(), postString);
        }

        public XmlResponse<SkillQueue> GetSkillQueue() {
            const string relPath = "/char/SkillQueue.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new SkillQueue(), postString);
        }

        public XmlResponse<StandingsList> GetStandings() {
            const string relPath = "/char/Standings.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new StandingsList(), postString);
        }


        public XmlResponse<UpcomingCalendarEvents> GetUpcomingCalendarEvents() {
            const string relPath = "/char/UpcomingCalendarEvents.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new UpcomingCalendarEvents(), postString);
        }


        public XmlResponse<WalletTransactions> GetWalletTransactions() {
            const string relPath = "/char/WalletTransactions.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", Id, "accountKey", AccountKey);
            return request(relPath, new WalletTransactions(), postString);
        }


        public override string ToString() {
            return String.Format("ID: {0}, CharacterName: {1}", Id, Name);
        }

        private void load() {
            var response = GetCharacterSheet();
            Corporation = new Corporation(ApiKey, response.Result.CorporationName, response.Result.CorporationId);
        }
    }
}
