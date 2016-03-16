using System.Linq;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.Test.EveXml.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Character_StaticDeserializationTests {
        private readonly Character _character;

        public Character_StaticDeserializationTests() {
            _character = new Character(new CharacterKey(0, ""), 0);
            _character.RequestHandler = new StaticXmlRequestHandler(new XmlSerializer());
        }

        [TestMethod]
        public void GetCharacterInfo() {
            var xml = _character.GetCharacterInfoAsync().Result;
            Assert.AreEqual(99999999, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetAccountBalance() {
            var xml = _character.GetAccountBalanceAsync().Result;
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            var xml = _character.GetAssetListAsync().Result;
            Assert.AreEqual(150354641, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetCalendarEventAttendees() {
            var xml = _character.GetCalendarEventAttendees(0);
            Assert.AreEqual(123456789, xml.Result.Attendees.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterSheet() {
            var xml = _character.GetCharacterSheet();
            Assert.AreEqual(150337897, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetContactList() {
            var xml = _character.GetContactList();
            Assert.AreEqual(90000002, xml.Result.PersonalContacts.First().ContactId);
            Assert.AreEqual(90000002, xml.Result.CorporationContacts.First().ContactId);
            Assert.AreEqual(90000002, xml.Result.AllianceContacts.First().ContactId);
        }

        [TestMethod]
        public void GetContactNotifications() {
            var xml = _character.GetContactNotifications();
            Assert.AreEqual(308734131, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetContracts() {
            var xml = _character.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetContractItems() {
            var xml = _character.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            var xml = _character.GetContractBids();
            Assert.AreEqual(123123123, xml.Result.Bids.First().BidId);
        }

        [TestMethod]
        public void GetFactionWarfareStats() {
            var xml = _character.GetFactionWarfareStats();
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            var xml = _character.GetIndustryJobs();
            Assert.AreEqual(23264063, xml.Result.Jobs.First().JobId);
        }

        [TestMethod]
        public void GetKillLog() {
            var xml = _character.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
            Assert.AreEqual(150340823, xml.Result.Kills.First().Victim.CharacterId);
            Assert.AreEqual(1000127, xml.Result.Kills.First().Attackers.First().CorporationId);
        }

        [TestMethod]
        public void getLocations() {
            var xml = _character.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMailBodies() {
            var xml = _character.GetMailBodies(0);
            Assert.AreEqual(297023723, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMailingLists() {
            var xml = _character.GetMailingLists();
            Assert.AreEqual(128250439, xml.Result.Lists.First().ListId);
        }

        [TestMethod]
        public void GetMailMessages() {
            var xml = _character.GetMailMessages();
            Assert.AreEqual(290285276, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            var xml = _character.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            var xml = _character.GetMedals();
            Assert.AreEqual(95079, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetNotifications() {
            var xml = _character.GetNotifications();
            Assert.AreEqual(304084087, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetNotificationTexts() {
            var xml = _character.GetNotificationTexts(0);
            Assert.AreEqual(374044083, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetResearch() {
            var xml = _character.GetResearch();
            Assert.AreEqual(3011113, xml.Result.Entries.First().AgentId);
        }

        [TestMethod]
        public void GetSkillQueue() {
            var xml = _character.GetSkillQueue();
            Assert.AreEqual(11441, xml.Result.Queue.First().TypeId);
        }

        [TestMethod]
        public void GetSkillTraining() {
            var xml = _character.GetSkillTraining();
            Assert.AreEqual(3305, xml.Result.TypeId);
        }

        [TestMethod]
        public void GetStandings() {
            var xml = _character.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CharacterStandings.Agents.First().FromId);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents() {
            var xml = _character.GetUpcomingCalendarEvents();
            Assert.AreEqual(93264, xml.Result.Events.First().EventId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            var xml = _character.GetWalletJournal();
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            var xml = _character.GetWalletTransactions();
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }

        [TestMethod]
        public void GetChatChannels_ValidRequest_Hasresult() {
            var res = _character.GetChatChannels();
            Assert.AreEqual(92168909, res.Result.Channels.First().Operators.First().AccessorId);
        }

        [TestMethod]
        public void GetBookmarks_ValidRequest_Hasresult() {
            var res = _character.GetBookmarks();
            Assert.AreEqual(0, res.Result.Folders.First().FolderId);
        }
    }
}