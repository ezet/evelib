using System.Linq;
using eZet.Eve.EveLib.Entity;
using eZet.Eve.EveLib.Entity.EveApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {

    [TestClass]
    public class CharacterKey_ValidKeyTests {

        private const int KeyId = 3120814;

        private const string VCode = "L7jbIZe6EPxRgz0kIv64jym4zvwNAmEf36zMZlRA2c8obMlWC9DFEmdytdQP4N0l";

        private readonly CharacterKey validKey = EveLib.GetCharacterKey(KeyId, VCode);

        [TestMethod]
        public void Characters_NoExceptions() {
            Assert.IsNotNull(validKey.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetAccountStatus_ValidRequest_HasResult() {
            var res = validKey.GetAccountStatus();
            Assert.IsNotNull(res.Result.CreationDateAsString);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetCharacterInfo();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetAssetList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetCalendarEventAttendees_InvalidId_HasError() {
            var res = validKey.Characters[0].GetCalendarEventAttendees(0);
            Assert.IsNotNull(res.Error, "Returns http 200 and empty result instead of 403 with error.");
            // BUG Returns http 200 and empty rowset on invalid ID
            // TODO Add valid ID test
            // TODO Add error handling
        }

        [TestMethod]
        public void GetCharacterSheet_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetCharacterSheet();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactNotifications_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetContactNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContractItems_InvalidRequest_HasError() {
            var res = validKey.Characters[0].GetContractItems(0);
            Assert.IsNotNull(res.Error, "Returns HTTP 500 instead of HTTP 403 with error.");
            // BUG Returns http 500 on invalid id
            // TODO Add error handling
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetFactionWarfareStats_InvalidRequest_HasError() {
            var res = validKey.Characters[0].GetFactionWarfareStats();
            Assert.IsNotNull(res.Error);
        }

        [TestMethod]
        public void GetIndustryJobs_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetIndustryJobs();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetKillLog() {
            // BUG Returns 000 OK when exhausted
            var res = validKey.Characters[0].GetKillLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetLocations_InvalidId_HasError() {
            var res = validKey.Characters[0].GetLocations(0);
            Assert.IsNotNull(res.Error);
        }

        [TestMethod]
        public void GetMailBodies_InvalidId_HasMissingMessageIds() {
            var res = validKey.Characters[0].GetMailBodies(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingMessageIds);
        }

        [TestMethod]
        public void GetMailingLists_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetMailingLists();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMailMessages_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetMailMessages();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotifications_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetNotifications();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetNotificationTexts_InvalidId_HasMissingIds() {
            var res = validKey.Characters[0].GetNotificationTexts(0);
            Assert.AreNotEqual(string.Empty, res.Result.MissingIds);
        }

        [TestMethod]
        public void GetResearch_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetResearch();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillQueue_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetSkillQueue();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetSkillTraining_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetSkillTraining();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetUpcomingCalendarEvents();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetWalletJournal();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            var res = validKey.Characters[0].GetWalletTransactions();
            Assert.IsNotNull(res.Result);
        }

    }
}
