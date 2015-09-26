using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.Models.Account;
using eZet.EveLib.EveXmlModule.Models.Character;
using eZet.EveLib.EveXmlModule.Models.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactionWarfareStats = eZet.EveLib.EveXmlModule.Models.Character.FactionWarfareStats;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CharacterKey_ValidKeyTests {
        private const int KeyId = 3361423;
        private const string VCode = "g0BIlsWkwyr592n0QCh8FNoxnU8ddMHVc2APpv9FmICb3n4lAljMPfvYuS7oTzU7";


        private readonly CharacterKey _piKey = new CharacterKey(3460081,
            "wpzj1BPcUMrSGj9L4YmkHLtoRWXCOsIipMECdUDElUiA3GUWvC67cy5xUZltyYoI");

        private readonly CharacterKey _validKey = new CharacterKey(KeyId, VCode);

        [TestMethod]
        public void Characters_NoExceptions() {
            Assert.IsNotNull(_validKey.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetAccountStatus_ValidRequest_HasResult() {
            EveXmlResponse<AccountStatus> res = _validKey.GetAccountStatus();
            Assert.IsNotNull(res.Result.CreationDateAsString);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidRequest_HasResult() {
            EveXmlResponse<CharacterInfo> res = _validKey.Characters[0].GetCharacterInfo();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            EveXmlResponse<AccountBalance> res = _validKey.Characters[0].GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            EveXmlResponse<AssetList> res = _validKey.Characters[0].GetAssetList();
            IEnumerable<AssetList.Item> list = res.Result.Flatten();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetCalendarEventAttendees_InvalidId_NoException() {
            EveXmlResponse<CalendarEventAttendees> res = _validKey.Characters[0].GetCalendarEventAttendees(1);
        }

        [TestMethod]
        public void GetCharacterSheet_ValidRequest_HasResult() {
            EveXmlResponse<CharacterSheet> res = _validKey.Characters[0].GetCharacterSheet();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            EveXmlResponse<ContactList> res = _validKey.Characters[0].GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactNotifications_ValidRequest_HasResult() {
            EveXmlResponse<ContactNotifications> res = _validKey.Characters[0].GetContactNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            EveXmlResponse<ContractList> res = _validKey.Characters[0].GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetContractItems_InvalidRequest_InvalidRequestException() {
            EveXmlResponse<ContractItems> res = _validKey.Characters[0].GetContractItems(0);
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            EveXmlResponse<ContractBids> res = _validKey.Characters[0].GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetFactionWarfareStats_InvalidRequest_InvalidRequestException() {
            EveXmlResponse<FactionWarfareStats> res = _validKey.Characters[0].GetFactionWarfareStats();
        }

        [TestMethod]
        public async Task GetIndustryJobs_NoErrors() {
            EveXmlResponse<IndustryJobs> data = await _validKey.Characters.First().GetIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetIndustryJobsHistory_NoErrors() {
            EveXmlResponse<IndustryJobs> data = await _validKey.Characters.First().GetIndustryJobsAsync();
        }

        [TestMethod]
        public void GetKillLog() {
            // BUG Returns 000 OK when exhausted
            EveXmlResponse<KillLog> res = _validKey.Characters[0].GetKillLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetLocations_InvalidId_InvalidRequestException() {
            EveXmlResponse<Locations> res = _validKey.Characters[0].GetLocations(0);
        }

        [TestMethod]
        public void GetMailBodies_InvalidId_HasMissingMessageIds() {
            EveXmlResponse<MailBodies> res = _validKey.Characters[0].GetMailBodies(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingMessageIds);
        }

        [TestMethod]
        public void GetMailingLists_ValidRequest_HasResult() {
            EveXmlResponse<MailingLists> res = _validKey.Characters[0].GetMailingLists();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMailMessages_ValidRequest_HasResult() {
            EveXmlResponse<MailMessages> res = _validKey.Characters[0].GetMailMessages();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            EveXmlResponse<MarketOrders> res = _validKey.Characters[0].GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            EveXmlResponse<MedalList> res = _validKey.Characters[0].GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotifications_ValidRequest_HasResult() {
            EveXmlResponse<NotificationList> res = _validKey.Characters[0].GetNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotificationTexts_InvalidId_HasMissingIds() {
            EveXmlResponse<NotificationTexts> res = _validKey.Characters[0].GetNotificationTexts(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingIds);
        }

        [TestMethod]
        public void GetResearch_ValidRequest_HasResult() {
            EveXmlResponse<Research> res = _validKey.Characters[0].GetResearch();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillQueue_ValidRequest_HasResult() {
            EveXmlResponse<SkillQueue> res = _validKey.Characters[0].GetSkillQueue();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillTraining_ValidRequest_HasResult() {
            EveXmlResponse<SkillTraining> res = _validKey.Characters[0].GetSkillTraining();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            EveXmlResponse<StandingsList> res = _validKey.Characters[0].GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents_ValidRequest_HasResult() {
            EveXmlResponse<UpcomingCalendarEvents> res = _validKey.Characters[0].GetUpcomingCalendarEvents();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            EveXmlResponse<WalletJournal> res = _validKey.Characters[0].GetWalletJournal();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournalUntil_ValidRequest_HasResult() {
            List<WalletJournal.JournalEntry> res = _validKey.Characters[0].GetWalletJournalUntil(0);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            EveXmlResponse<WalletTransactions> res = _validKey.Characters[0].GetWalletTransactions();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletTransactionsUntil_ValidRequest_HasResult() {
            List<WalletTransactions.Transaction> res = _validKey.Characters[0].GetWalletTransactionsUntil(0);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetPlanetaryColonies_ValidRequest_HasResult() {
            EveXmlResponse<PlanetaryColonies> res = _piKey.Characters[0].GetPlanetaryColonies();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public async Task GetPlanetaryPins_ValidRequest_HasResult() {
            EveXmlResponse<PlanetaryPins> res = await _piKey.Characters[0].GetPlanetaryPinsAsync(40003660);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetPlanetaryRoutes_ValidRequest_HasResult() {
            EveXmlResponse<PlanetaryRoutes> res = _piKey.Characters[0].GetPlanetaryRoutes(40003660);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetPlanetaryLinks_ValidRequest_HasResult() {
            EveXmlResponse<PlanetaryLinks> res = _piKey.Characters[0].GetPlanetaryLinks(40003660);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public async Task GetBlueprints_ValidRequest_HasResult() {
            BlueprintList res = (await _validKey.Characters[0].GetBlueprintsAsync()).Result;
        }

        [TestMethod]
        public void GetChatChannels_ValidRequest_Hasresult() {
            var res = _validKey.Characters[0].GetChatChannels();

        }
    }
}