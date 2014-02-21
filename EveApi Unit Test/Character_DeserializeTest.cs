using System.Linq;
using eZet.Eve.EolNet.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EolNet.Test {
    [TestClass]
    public class Character_DeserializeTest {

        private readonly Character api;

        public Character_DeserializeTest() {
            api = new Character(default(ApiKey), 0, 0);
            api.RequestHelper = new TestRequestHelper();
        }

        [TestMethod]
        public void GetAccountBalance() {
            var xml = api.GetAccountBalance();
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            var xml = api.GetAssetList();
            Assert.AreEqual(150354641, xml.Result.Assets.First().ItemId);
        }

        [TestMethod]
        public void GetCalendarEventAttendees() {
            var xml = api.GetCalendarEventAttendees(0);
            Assert.AreEqual(123456789, xml.Result.Attendees.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterSheet() {
            var xml = api.GetCharacterSheet();
            Assert.AreEqual(150337897, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetContactList() {
            var xml = api.GetContactList();
            Assert.AreEqual(3010913, xml.Result.PersonalContacts.First().ContactId);
            Assert.AreEqual(797400947, xml.Result.CorporationContacts.First().ContactId);
            Assert.AreEqual(797400947, xml.Result.AllianceContacts.First().ContactId);
        }

        [TestMethod]
        public void GetContactNotifications() {
            var xml = api.GetContactNotifications();
            Assert.AreEqual(308734131, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetContracts() {
            var xml = api.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetContractItems() {
            var xml = api.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            var xml = api.GetContractBids(0);
            // TODO get samle
        }

        [TestMethod]
        public void GetFactionWarfareStats() {
            var xml = api.GetFactionWarfareStats();
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            var xml = api.GetIndustryJobs();
            Assert.AreEqual(23264063, xml.Result.Jobs.First().JobId);
        }

        [TestMethod]
        public void GetKillLog() {
            // TODO Something strange with RowSets here
            var xml = api.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
        }

        [TestMethod]
        public void getLocations() {
            var xml = api.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMailBodies() {
            var xml = api.GetMailBodies(0);
            Assert.AreEqual(297023723, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMailingLists() {
            var xml = api.GetMailingLists();
            Assert.AreEqual(128250439, xml.Result.Lists.First().ListId);
        }

        [TestMethod]
        public void GetMailMessages() {
            var xml = api.GetMailMessages();
            Assert.AreEqual(290285276, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            var xml = api.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            var xml = api.GetMedals();
            Assert.AreEqual(95079, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetNotifications() {
            var xml = api.GetNotifications();
            Assert.AreEqual(304084087, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetNotificationTexts() {
            var xml = api.GetNotificationTexts(0);
            Assert.AreEqual(374044083, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetResearch() {
            var xml = api.GetResearch();
            Assert.AreEqual(3011113, xml.Result.Entries.First().AgentId);
        }

        [TestMethod]
        public void GetSkillQueue() {
            var xml = api.GetSkillQueue();
            Assert.AreEqual(11441, xml.Result.Queue.First().TypeId);
        }

        [TestMethod]
        public void GetSkillTraining() {
            var xml = api.GetSkillTraining();
            Assert.AreEqual(3305, xml.Result.TypeId);
        }

        [TestMethod]
        public void GetStandings() {
            var xml = api.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CharacterStandings.Agents.First().FromId);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents() {
            var xml = api.GetUpcomingCalendarEvents();
            Assert.AreEqual(93264, xml.Result.Events.First().EventId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            var xml = api.GetWalletJournal();
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            var xml = api.GetWalletTransactions();
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }
    }
}
