using System.Linq;
using eZet.Eve.EveApi.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveApi.Test {
    [TestClass]
    public class CorporationDeserializeTest {

        private Corporation api;

        public CorporationDeserializeTest() {
            api = new Corporation(default(ApiKey), 0, 0);
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
        public void GetContactList() {
            var xml = api.GetContactList();
            Assert.AreEqual(797400947, xml.Result.Contacts.First().ContactId);
        }

        [TestMethod]
        public void GetContainerLog() {
            var xml = api.GetContainerLog();
            Assert.AreEqual(2051471251, xml.Result.LogEntries.First().ItemId);
        }

        [TestMethod]
        public void GetContracts() {
            var xml = api.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetGontractItems() {
            var xml = api.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            var xml = api.GetContractBids();
            // TODO get samle
        }

        [TestMethod]
        public void GetCorporationSheet() {
            var xml = api.GetCorporationSheet();
            Assert.AreEqual(150212025, xml.Result.CorporationId);
        }

        [TestMethod]
        public void GetFactionalWarfareStats() {
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
            var xml = api.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
        }

        [TestMethod]
        public void GetLocations() {
            var xml = api.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            var xml = api.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            var xml = api.GetMedals();
            // TODO get sample
        }

        [TestMethod]
        public void GetMemberMedals() {
            var xml = api.GetMemberMedals();
            Assert.AreEqual(24216, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetMemberSecurity() {
            var xml = api.GetMemberSecurity();
            Assert.AreEqual(123456789, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberSecurityLog() {
            var xml = api.GetMemberSecurityLog();
            Assert.AreEqual(1234567890, xml.Result.LogEntries.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberTracking() {
            var xml = api.GetMemberTracking(true);
            Assert.AreEqual(921331161, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetOutpostList() {
            var xml = api.GetOutpostList();
            Assert.AreEqual(61000368, xml.Result.Outposts.First().StationId);
        }

        [TestMethod]
        public void GetOutpostServiceDetail() {
            var xml = api.GetOutpostServiceDetails();
            Assert.AreEqual(61000368, xml.Result.Services.First().StationId);
        }

        [TestMethod]
        public void GetShareholders() {
            var xml = api.GetShareholders();
            Assert.AreEqual(126891489, xml.Result.Shareholders.First().ShareholderId);
        }

        [TestMethod]
        public void GetStandings() {
            var xml = api.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CorporationStandingsType.Standings.First().FromId);
        }

        [TestMethod]
        public void GetStarbaseDetail() {
            var xml = api.GetStarbaseDetails(0);
            Assert.AreEqual(4, xml.Result.State);
        }

        [TestMethod]
        public void GetStarbaseList() {
            var xml = api.GetStarbaseList();
            Assert.AreEqual(100449451, xml.Result.Starbases.First().ItemId);
        }

        [TestMethod]
        public void GetTitles() {
            var xml = api.GetTitles();
            Assert.AreEqual(8192, xml.Result.Titles.First().RolesAtHq.First().RoleId);
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