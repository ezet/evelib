using System.Linq;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Misc;
using eZet.EveLib.Modules.Util;
using eZet.EveLib.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactionWarfareStats = eZet.EveLib.Modules.Models.Character.FactionWarfareStats;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Character_StaticDeserializationTests {
        private readonly Character _character;

        public Character_StaticDeserializationTests() {
            _character = new Character(new CharacterKey(0, ""), 0, "");
            _character.RequestHandler = new RequestHandler(new StaticXmlRequester(), new SimpleXmlSerializer());
        }

        [TestMethod]
        public void GetCharacterInfo() {
            EveApiResponse<CharacterInfo> xml = _character.GetCharacterInfoAsync().Result;
            Assert.AreEqual(99999999, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetAccountBalance() {
            EveApiResponse<AccountBalance> xml = _character.GetAccountBalanceAsync().Result;
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            EveApiResponse<AssetList> xml = _character.GetAssetListAsync().Result;
            Assert.AreEqual(150354641, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetCalendarEventAttendees() {
            EveApiResponse<CalendarEventAttendees> xml = _character.GetCalendarEventAttendees(0).Result;
            Assert.AreEqual(123456789, xml.Result.Attendees.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterSheet() {
            EveApiResponse<CharacterSheet> xml = _character.GetCharacterSheet().Result;
            Assert.AreEqual(150337897, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetContactList() {
            EveApiResponse<ContactList> xml = _character.GetContactList().Result;
            Assert.AreEqual(3010913, xml.Result.PersonalContacts.First().ContactId);
            Assert.AreEqual(797400947, xml.Result.CorporationContacts.First().ContactId);
            Assert.AreEqual(797400947, xml.Result.AllianceContacts.First().ContactId);
        }

        [TestMethod]
        public void GetContactNotifications() {
            EveApiResponse<ContactNotifications> xml = _character.GetContactNotifications().Result;
            Assert.AreEqual(308734131, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetContracts() {
            EveApiResponse<ContractList> xml = _character.GetContracts().Result;
            // TODO Get sample
        }

        [TestMethod]
        public void GetContractItems() {
            EveApiResponse<ContractItems> xml = _character.GetContractItems(0).Result;
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            EveApiResponse<ContractBids> xml = _character.GetContractBids().Result;
            Assert.AreEqual(123123123, xml.Result.Bids.First().BidId);
        }

        [TestMethod]
        public void GetFactionWarfareStats() {
            EveApiResponse<FactionWarfareStats> xml = _character.GetFactionWarfareStats().Result;
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            EveApiResponse<IndustryJobs> xml = _character.GetIndustryJobs().Result;
            Assert.AreEqual(23264063, xml.Result.Jobs.First().JobId);
        }

        [TestMethod]
        public void GetKillLog() {
            EveApiResponse<KillLog> xml = _character.GetKillLog().Result;
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
            Assert.AreEqual(150340823, xml.Result.Kills.First().Victim.CharacterId);
            Assert.AreEqual(1000127, xml.Result.Kills.First().Attackers.First().CorporationId);
        }

        [TestMethod]
        public void getLocations() {
            EveApiResponse<Locations> xml = _character.GetLocations(0).Result;
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMailBodies() {
            EveApiResponse<MailBodies> xml = _character.GetMailBodies(0).Result;
            Assert.AreEqual(297023723, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMailingLists() {
            EveApiResponse<MailingLists> xml = _character.GetMailingLists().Result;
            Assert.AreEqual(128250439, xml.Result.Lists.First().ListId);
        }

        [TestMethod]
        public void GetMailMessages() {
            EveApiResponse<MailMessages> xml = _character.GetMailMessages().Result;
            Assert.AreEqual(290285276, xml.Result.Messages.First().MessageId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            EveApiResponse<MarketOrders> xml = _character.GetMarketOrders().Result;
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            EveApiResponse<MedalList> xml = _character.GetMedals().Result;
            Assert.AreEqual(95079, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetNotifications() {
            EveApiResponse<NotificationList> xml = _character.GetNotifications().Result;
            Assert.AreEqual(304084087, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetNotificationTexts() {
            EveApiResponse<NotificationTexts> xml = _character.GetNotificationTexts(0).Result;
            Assert.AreEqual(374044083, xml.Result.Notifications.First().NotificationId);
        }

        [TestMethod]
        public void GetResearch() {
            EveApiResponse<Research> xml = _character.GetResearch().Result;
            Assert.AreEqual(3011113, xml.Result.Entries.First().AgentId);
        }

        [TestMethod]
        public void GetSkillQueue() {
            EveApiResponse<SkillQueue> xml = _character.GetSkillQueue().Result;
            Assert.AreEqual(11441, xml.Result.Queue.First().TypeId);
        }

        [TestMethod]
        public void GetSkillTraining() {
            EveApiResponse<SkillTraining> xml = _character.GetSkillTraining().Result;
            Assert.AreEqual(3305, xml.Result.TypeId);
        }

        [TestMethod]
        public void GetStandings() {
            EveApiResponse<StandingsList> xml = _character.GetStandings().Result;
            Assert.AreEqual(3009841, xml.Result.CharacterStandings.Agents.First().FromId);
        }

        [TestMethod]
        public void GetUpcomingCalendarEvents() {
            EveApiResponse<UpcomingCalendarEvents> xml = _character.GetUpcomingCalendarEvents().Result;
            Assert.AreEqual(93264, xml.Result.Events.First().EventId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            EveApiResponse<WalletJournal> xml = _character.GetWalletJournal().Result;
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            EveApiResponse<WalletTransactions> xml = _character.GetWalletTransactions().Result;
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }
    }
}