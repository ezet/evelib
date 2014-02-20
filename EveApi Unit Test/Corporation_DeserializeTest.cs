using System;
using System.Linq;
using eZet.Eve.EveApi.Dto.EveApi.Character;
using eZet.Eve.EveApi.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveApi.Test {
    [TestClass]
    public class CorporationDeserializeTest {
        private const int KeyId = 3053778;

        private const string VCode = "Hu3uslqNc3HDP8XmMMt1Cgb56TpPqqnF2tXssniROFkIMEDLztLPD8ktx6q5WVC2";

        private const int Id = 977615922;

        private static readonly EveApi Api = new EveApi(KeyId, VCode, Id);

        private static readonly Corporation Corp = Api.Character.Corporation;

        public CorporationDeserializeTest() {
            Corp.RequestHelper = new MockRequestHelper();
        }


        [TestMethod]
        public void GetAccountBalance() {
            var xml = Corp.GetAccountBalance();
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            var xml = Corp.GetAssetList();
            Assert.AreEqual(150354641, xml.Result.Assets.First().ItemId);
        }

        [TestMethod]
        public void GetContactList() {
            var xml = Corp.GetContactList();
            Assert.AreEqual(797400947, xml.Result.Contacts.First().ContactId);
        }

        [TestMethod]
        public void GetContainerLog() {
            var xml = Corp.GetContainerLog();
            Assert.AreEqual(2051471251, xml.Result.LogEntries.First().ItemId);
        }

        [TestMethod]
        public void GetContracts() {
            var xml = Corp.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetGontractItems() {
            var xml = Corp.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            var xml = Corp.GetContractBids(0);
            // TODO get samle
        }

        [TestMethod]
        public void GetCorporationSheet() {
            var xml = Corp.GetCorporationSheet();
            Assert.AreEqual(150212025, xml.Result.CorporationId);
        }

        [TestMethod]
        public void GetFactionalWarfareStats() {
            var xml = Corp.GetFactionWarfareStats();
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            var xml = Corp.GetIndustryJobs();
            Assert.AreEqual(23264063, xml.Result.Jobs.First().JobId);
        }

        [TestMethod]
        public void GetKillLog() {
            var xml = Corp.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
        }

        [TestMethod]
        public void GetLocations() {
            var xml = Corp.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            var xml = Corp.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            var xml = Corp.GetMedals();
            // TODO get sample
        }

        [TestMethod]
        public void GetMemberMedals() {
            var xml = Corp.GetMemberMedals();
            Assert.AreEqual(24216, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetMemberSecurity() {
            var xml = Corp.GetMemberSecurity();
            Assert.AreEqual(123456789, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberSecurityLog() {
            var xml = Corp.GetMemberSecurityLog();
            Assert.AreEqual(1234567890, xml.Result.LogEntries.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberTracking() {
            var xml = Corp.GetMemberTracking(true);
            Assert.AreEqual(921331161, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetOutpostList() {
            var xml = Corp.GetOutpostList();
            Assert.AreEqual(61000368, xml.Result.Outposts.First().StationId);
        }

        [TestMethod]
        public void GetOutpostServiceDetail() {
            var xml = Corp.GetOutpostServiceDetails();
            Assert.AreEqual(61000368, xml.Result.Services.First().StationId);
        }

        [TestMethod]
        public void GetShareholders() {
            var xml = Corp.GetShareholders();
            Assert.AreEqual(126891489, xml.Result.Shareholders.First().ShareholderId);
        }

        [TestMethod]
        public void GetStandings() {
            var xml = Corp.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CorporationStandings.Standings.First().FromId);
        }

        [TestMethod]
        public void GetStarbaseDetail() {
            var xml = Corp.GetStarbaseDetails(0);
            Assert.AreEqual(4, xml.Result.State);
        }

        [TestMethod]
        public void GetStarbaseList() {
            var xml = Corp.GetStarbaseList();
            Assert.AreEqual(100449451, xml.Result.Starbases.First().ItemId);
        }

        [TestMethod]
        public void GetTitles() {
            var xml = Corp.GetTitles();
            Assert.AreEqual(8192, xml.Result.Titles.First().RolesAtHq.First().RoleId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            var xml = Corp.GetWalletJournal();
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            var xml = Corp.GetWalletTransactions();
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }

    }


}
