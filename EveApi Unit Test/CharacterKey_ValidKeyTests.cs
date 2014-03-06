using System.Linq;
using eZet.EveLib.Common.Exception;
using eZet.EveLib.EveOnlineLib;
using eZet.EveLib.EveOnlineLib.Model;
using eZet.EveLib.EveOnlineLib.Model.Account;
using eZet.EveLib.EveOnlineLib.Model.Character;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CharacterInfo = eZet.EveLib.EveOnlineLib.Model.Core.CharacterInfo;

namespace eZet.Eve.EveLib.Test {
    [TestClass]
    public class CharacterKey_ValidKeyTests {
        private const int KeyId = 3120814;

        private const string VCode = "L7jbIZe6EPxRgz0kIv64jym4zvwNAmEf36zMZlRA2c8obMlWC9DFEmdytdQP4N0l";

        private readonly CharacterKey validKey = new CharacterKey(KeyId, VCode);

        [TestMethod]
        public void Characters_NoExceptions() {
            Assert.IsNotNull(validKey.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetAccountStatus_ValidRequest_HasResult() {
            EveApiResponse<AccountStatus> res = validKey.GetAccountStatus();
            Assert.IsNotNull(res.Result.CreationDateAsString);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidRequest_HasResult() {
            EveApiResponse<CharacterInfo> res = validKey.Characters[0].GetCharacterInfo();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            EveApiResponse<AccountBalance> res = validKey.Characters[0].GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            EveApiResponse<AssetList> res = validKey.Characters[0].GetAssetList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetCalendarEventAttendees_InvalidId_InvalidRequestException() {
            EveApiResponse<CalendarEventAttendees> res = validKey.Characters[0].GetCalendarEventAttendees(0);
            // BUG Returns http 200 and empty rowset on invalid ID
            // TODO Add valid ID test
            // TODO Add error handling
        }

        [TestMethod]
        public void GetCharacterSheet_ValidRequest_HasResult() {
            EveApiResponse<CharacterSheet> res = validKey.Characters[0].GetCharacterSheet();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            EveApiResponse<ContactList> res = validKey.Characters[0].GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactNotifications_ValidRequest_HasResult() {
            EveApiResponse<ContactNotifications> res = validKey.Characters[0].GetContactNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            EveApiResponse<ContractList> res = validKey.Characters[0].GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetContractItems_InvalidRequest_InvalidRequestException() {
            EveApiResponse<ContractItems> res = validKey.Characters[0].GetContractItems(0);
            // BUG Returns http 500 on invalid id
            // TODO Add error handling
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            EveApiResponse<ContractBids> res = validKey.Characters[0].GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetFactionWarfareStats_InvalidRequest_InvalidRequestException() {
            EveApiResponse<FactionWarfareStats> res = validKey.Characters[0].GetFactionWarfareStats();
        }

        [TestMethod]
        public void GetIndustryJobs_ValidRequest_HasResult() {
            EveApiResponse<IndustryJobs> res = validKey.Characters[0].GetIndustryJobs();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetKillLog() {
            // BUG Returns 000 OK when exhausted
            EveApiResponse<KillLog> res = validKey.Characters[0].GetKillLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetLocations_InvalidId_InvalidRequestException() {
            EveApiResponse<Locations> res = validKey.Characters[0].GetLocations(0);
        }

        [TestMethod]
        public void GetMailBodies_InvalidId_HasMissingMessageIds() {
            EveApiResponse<MailBodies> res = validKey.Characters[0].GetMailBodies(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingMessageIds);
        }

        [TestMethod]
        public void GetMailingLists_ValidRequest_HasResult() {
            EveApiResponse<MailingLists> res = validKey.Characters[0].GetMailingLists();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMailMessages_ValidRequest_HasResult() {
            EveApiResponse<MailMessages> res = validKey.Characters[0].GetMailMessages();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            EveApiResponse<MarketOrders> res = validKey.Characters[0].GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            EveApiResponse<MedalList> res = validKey.Characters[0].GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotifications_ValidRequest_HasResult() {
            EveApiResponse<NotificationList> res = validKey.Characters[0].GetNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotificationTexts_InvalidId_HasMissingIds() {
            EveApiResponse<NotificationTexts> res = validKey.Characters[0].GetNotificationTexts(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingIds);
        }

        [TestMethod]
        public void GetResearch_ValidRequest_HasResult() {
            EveApiResponse<Research> res = validKey.Characters[0].GetResearch();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillQueue_ValidRequest_HasResult() {
            EveApiResponse<SkillQueue> res = validKey.Characters[0].GetSkillQueue();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillTraining_ValidRequest_HasResult() {
            EveApiResponse<SkillTraining> res = validKey.Characters[0].GetSkillTraining();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            EveApiResponse<StandingsList> res = validKey.Characters[0].GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents_ValidRequest_HasResult() {
            EveApiResponse<UpcomingCalendarEvents> res = validKey.Characters[0].GetUpcomingCalendarEvents();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            EveApiResponse<WalletJournal> res = validKey.Characters[0].GetWalletJournal();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            EveApiResponse<WalletTransactions> res = validKey.Characters[0].GetWalletTransactions();
            Assert.IsNotNull(res.Result);
        }
    }
}