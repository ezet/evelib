using System.Linq;
using eZet.Eve.EoLib.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EoLib.Test {
    [TestClass]
    public class Character_DeserializeTest {

        private readonly Character character;

        public Character_DeserializeTest() {
            character = new EoLib(new ApiKey(123123123, ""), 0).Character;
            character.RequestHelper = new TestRequestHelper();
        }

        [TestMethod]
        public void GetAccountBalance() {
            var xml = character.GetAccountBalance();
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            var xml = character.GetAssetList();
            Assert.AreEqual(150354641, xml.Result.Assets.First().ItemId);
        }

        [TestMethod]
        public void GetCalendarEventAttendees() {
            var xml = character.GetCalendarEventAttendees(0);
            Assert.AreEqual(123456789, xml.Result.Attendees.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterSheet() {
            var xml = character.GetCharacterSheet();
            Assert.AreEqual(150337897, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetContactList() {
            var xml = character.GetContactList();
            Assert.AreEqual(3010913, xml.Result.PersonalContacts.First().ContactId);
            Assert.AreEqual(797400947, xml.Result.CorporationContacts.First().ContactId);
            Assert.AreEqual(797400947, xml.Result.AllianceContacts.First().ContactId);
        }

        [TestMethod]
        public void GetContactNotifications() {
            var xml = character.GetContactNotifications();
            Assert.AreEqual(308734131, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetContracts() {
            var xml = character.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetContractItems() {
            var xml = character.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            var xml = character.GetContractBids();
            Assert.AreEqual(123123123, xml.Result.Bids.First().BidId);
        }

        [TestMethod]
        public void GetFactionWarfareStats() {
            var xml = character.GetFactionWarfareStats();
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            var xml = character.GetIndustryJobs();
            Assert.AreEqual(23264063, xml.Result.Jobs.First().JobId);
        }

        [TestMethod]
        public void GetKillLog() {
            var xml = character.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
            Assert.AreEqual(150340823, xml.Result.Kills.First().Victim.CharacterId);
            Assert.AreEqual(1000127, xml.Result.Kills.First().Attackers.First().CorporationId);
        }

        [TestMethod]
        public void getLocations() {
            var xml = character.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMailBodies() {
            var xml = character.GetMailBodies(0);
            Assert.AreEqual(297023723, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMailingLists() {
            var xml = character.GetMailingLists();
            Assert.AreEqual(128250439, xml.Result.Lists.First().ListId);
        }

        [TestMethod]
        public void GetMailMessages() {
            var xml = character.GetMailMessages();
            Assert.AreEqual(290285276, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            var xml = character.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            var xml = character.GetMedals();
            Assert.AreEqual(95079, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetNotifications() {
            var xml = character.GetNotifications();
            Assert.AreEqual(304084087, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetNotificationTexts() {
            var xml = character.GetNotificationTexts(0);
            Assert.AreEqual(374044083, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetResearch() {
            var xml = character.GetResearch();
            Assert.AreEqual(3011113, xml.Result.Entries.First().AgentId);
        }

        [TestMethod]
        public void GetSkillQueue() {
            var xml = character.GetSkillQueue();
            Assert.AreEqual(11441, xml.Result.Queue.First().TypeId);
        }

        [TestMethod]
        public void GetSkillTraining() {
            var xml = character.GetSkillTraining();
            Assert.AreEqual(3305, xml.Result.TypeId);
        }

        [TestMethod]
        public void GetStandings() {
            var xml = character.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CharacterStandings.Agents.First().FromId);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents() {
            var xml = character.GetUpcomingCalendarEvents();
            Assert.AreEqual(93264, xml.Result.Events.First().EventId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            var xml = character.GetWalletJournal();
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            var xml = character.GetWalletTransactions();
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }
    }
}
