using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactionWarfareStats = eZet.EveLib.Modules.Models.Character.FactionWarfareStats;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CharacterKey_ValidKeyTests {
        private const int KeyId = 3120814;

        private const string VCode = "L7jbIZe6EPxRgz0kIv64jym4zvwNAmEf36zMZlRA2c8obMlWC9DFEmdytdQP4N0l";


        private readonly CharacterKey _piKey = new CharacterKey(3460081,
            "wpzj1BPcUMrSGj9L4YmkHLtoRWXCOsIipMECdUDElUiA3GUWvC67cy5xUZltyYoI");

        private readonly CharacterKey _validKey = new CharacterKey(KeyId, VCode);

        [TestMethod]
        public void Characters_NoExceptions() {
            Assert.IsNotNull(_validKey.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetAccountStatus_ValidRequest_HasResult() {
            EveApiResponse<AccountStatus> res = _validKey.GetAccountStatus();
            Assert.IsNotNull(res.Result.CreationDateAsString);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidRequest_HasResult() {
            EveApiResponse<CharacterInfo> res = _validKey.Characters[0].GetCharacterInfo();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            EveApiResponse<AccountBalance> res = _validKey.Characters[0].GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            EveApiResponse<AssetList> res = _validKey.Characters[0].GetAssetList();
            IEnumerable<AssetList.Item> list = res.Result.Flatten();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetCalendarEventAttendees_InvalidId_NoException() {
            EveApiResponse<CalendarEventAttendees> res = _validKey.Characters[0].GetCalendarEventAttendees(1);
        }

        [TestMethod]
        public void GetCharacterSheet_ValidRequest_HasResult() {
            EveApiResponse<CharacterSheet> res = _validKey.Characters[0].GetCharacterSheet();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            EveApiResponse<ContactList> res = _validKey.Characters[0].GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactNotifications_ValidRequest_HasResult() {
            EveApiResponse<ContactNotifications> res = _validKey.Characters[0].GetContactNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            EveApiResponse<ContractList> res = _validKey.Characters[0].GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetContractItems_InvalidRequest_InvalidRequestException() {
            EveApiResponse<ContractItems> res = _validKey.Characters[0].GetContractItems(0);
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            EveApiResponse<ContractBids> res = _validKey.Characters[0].GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetFactionWarfareStats_InvalidRequest_InvalidRequestException() {
            EveApiResponse<FactionWarfareStats> res = _validKey.Characters[0].GetFactionWarfareStats();
        }

        [TestMethod]
        public async Task GetIndustryJobs_NoErrors() {
            EveApiResponse<IndustryJobs> data = await _validKey.Characters.First().GetIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetIndustryJobsHistory_NoErrors() {
            EveApiResponse<IndustryJobs> data = await _validKey.Characters.First().GetIndustryJobsAsync();
        }

        [TestMethod]
        public void GetKillLog() {
            // BUG Returns 000 OK when exhausted
            EveApiResponse<KillLog> res = _validKey.Characters[0].GetKillLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetLocations_InvalidId_InvalidRequestException() {
            EveApiResponse<Locations> res = _validKey.Characters[0].GetLocations(0);
        }

        [TestMethod]
        public void GetMailBodies_InvalidId_HasMissingMessageIds() {
            EveApiResponse<MailBodies> res = _validKey.Characters[0].GetMailBodies(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingMessageIds);
        }

        [TestMethod]
        public void GetMailingLists_ValidRequest_HasResult() {
            EveApiResponse<MailingLists> res = _validKey.Characters[0].GetMailingLists();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMailMessages_ValidRequest_HasResult() {
            EveApiResponse<MailMessages> res = _validKey.Characters[0].GetMailMessages();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            EveApiResponse<MarketOrders> res = _validKey.Characters[0].GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            EveApiResponse<MedalList> res = _validKey.Characters[0].GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotifications_ValidRequest_HasResult() {
            EveApiResponse<NotificationList> res = _validKey.Characters[0].GetNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotificationTexts_InvalidId_HasMissingIds() {
            EveApiResponse<NotificationTexts> res = _validKey.Characters[0].GetNotificationTexts(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingIds);
        }

        [TestMethod]
        public void GetResearch_ValidRequest_HasResult() {
            EveApiResponse<Research> res = _validKey.Characters[0].GetResearch();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillQueue_ValidRequest_HasResult() {
            EveApiResponse<SkillQueue> res = _validKey.Characters[0].GetSkillQueue();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillTraining_ValidRequest_HasResult() {
            EveApiResponse<SkillTraining> res = _validKey.Characters[0].GetSkillTraining();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            EveApiResponse<StandingsList> res = _validKey.Characters[0].GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents_ValidRequest_HasResult() {
            EveApiResponse<UpcomingCalendarEvents> res = _validKey.Characters[0].GetUpcomingCalendarEvents();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            EveApiResponse<WalletJournal> res = _validKey.Characters[0].GetWalletJournal();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            EveApiResponse<WalletTransactions> res = _validKey.Characters[0].GetWalletTransactions();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetPlanetaryColonies_ValidRequest_HasResult() {
            EveApiResponse<PlanetaryColonies> res = _piKey.Characters[0].GetPlanetaryColonies();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public async Task GetPlanetaryPins_ValidRequest_HasResult() {
            EveApiResponse<PlanetaryPins> res = await _piKey.Characters[0].GetPlanetaryPinsAsync(40003660);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetPlanetaryRoutes_ValidRequest_HasResult() {
            EveApiResponse<PlanetaryRoutes> res = _piKey.Characters[0].GetPlanetaryRoutes(40003660);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetPlanetaryLinks_ValidRequest_HasResult() {
            EveApiResponse<PlanetaryLinks> res = _piKey.Characters[0].GetPlanetaryLinks(40003660);
            Assert.IsNotNull(res.Result);
        }
    }
}