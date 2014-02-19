using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveApi.Test {
    [TestClass]
    public class CharacterTest {

        private const int KeyId = 3053778;

        private const string VCode = "Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2";
        
        private const int CharacterId = 977615922;

        private readonly EveApi api = new EveApi(KeyId, VCode, CharacterId);


        [TestMethod]
        public void TestAccountBalance() {
            var xml = api.Character.GetAccountBalance();
            Assert.AreNotEqual(0, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void TestAssetList() {
            var xml = api.Character.GetAssetList();
            Assert.AreNotEqual(0, xml.Result.Assets.First().ItemId);
        }

        [TestMethod]
        public void TestCharacterSheet() {
            var xml = api.Character.GetCharacterSheet();
            Assert.AreEqual(CharacterId, xml.Result.CharacterId);
        }

        [TestMethod]
        public void TestCalendarEventAttendees() {
            // TODO Write test
        }

        [TestMethod]
        public void TestContactList() {
            var xml = api.Character.GetContactList();
        }

        [TestMethod]
        public void TestContactNotifications() {
            var xml = api.Character.GetContactNotifications();
        }

        [TestMethod]
        public void TestContracts() {
            var xml = api.Character.GetContracts();
        }

        [TestMethod]
        public void GetContractItems() {
            var xml = api.Character.GetContractItems(0);
        }

        [TestMethod]
        public void GetContractBids() {
            var xml = api.Character.GetContractBids();
        }

        [TestMethod]
        public void GetFactionWarfareStats() {
            var xml = api.Character.GetFactionWarfareStats();
        }

        [TestMethod]
        public void GetIndustryJobs() {
            var xml = api.Character.GetIndustryJobs();
        }

        [TestMethod]
        public void GetKillLog() {
            var xml = api.Character.GetKillLog();
        }

        [TestMethod]
        public void getLocations() {
            var xml = api.Character.GetLocations(0);
        }

        [TestMethod]
        public void GetMailBodies() {
            var xml = api.Character.GetMailBodies(0);
        }

        [TestMethod]
        public void GetMailingLists() {
            var xml = api.Character.GetMailingLists();
        }

        [TestMethod]
        public void GetMailMessages() {
            var xml = api.Character.GetMailMessages();
        }

        [TestMethod]
        public void GetMarketOrders() {
            var xml = api.Character.GetMarketorders();
        }

        [TestMethod]
        public void GetMedals() {
            var xml = api.Character.GetMedals();
        }

        [TestMethod]
        public void GetNotifications() {
            var xml = api.Character.GetNotifications();
        }

        [TestMethod]
        public void GetNotificationTexts() {
            var xml = api.Character.GetNotificationTexts();
        }

        [TestMethod]
        public void GetSkillQueue() {
            var xml = api.Character.GetSkillQueue();
        }

        [TestMethod]
        public void GetStandings() {
            var xml = api.Character.GetStandings();
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents() {
            var xml = api.Character.GetUpcomingCalendarEvents();
        }

















    }
}
