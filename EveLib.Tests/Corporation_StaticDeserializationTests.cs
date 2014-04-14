using System.Linq;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Corporation;
using eZet.EveLib.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList = eZet.EveLib.Modules.Models.Corporation.ContactList;
using FactionWarfareStats = eZet.EveLib.Modules.Models.Corporation.FactionWarfareStats;
using MedalList = eZet.EveLib.Modules.Models.Corporation.MedalList;
using StandingsList = eZet.EveLib.Modules.Models.Corporation.StandingsList;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Corporation_StaticDeserializationTests {
        private readonly Corporation corp;

        public Corporation_StaticDeserializationTests() {
            corp = new Corporation(new CorporationKey(0, ""), 0, "");
            corp.RequestHandler = new TestRequestHandler(new XmlSerializerWrapper());
        }

        [TestMethod]
        public void GetAccountBalance() {
            EveApiResponse<AccountBalance> xml = corp.GetAccountBalance();
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            EveApiResponse<AssetList> xml = corp.GetAssetList();
            Assert.AreEqual(150354641, xml.Result.Assets.First().ItemId);
        }

        [TestMethod]
        public void GetContactList() {
            EveApiResponse<ContactList> xml = corp.GetContactList();
            Assert.AreEqual(797400947, xml.Result.CorporationContacts.First().ContactId);
        }

        [TestMethod]
        public void GetContainerLog() {
            EveApiResponse<ContainerLog> xml = corp.GetContainerLog();
            Assert.AreEqual(2051471251, xml.Result.LogEntries.First().ItemId);
        }

        [TestMethod]
        public void GetContracts() {
            EveApiResponse<ContractList> xml = corp.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetContractItems() {
            EveApiResponse<ContractItems> xml = corp.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            EveApiResponse<ContractBids> xml = corp.GetContractBids();
            Assert.AreEqual(123123123, xml.Result.Bids.First().BidId);
        }

        [TestMethod]
        public void GetCorporationSheet() {
            EveApiResponse<CorporationSheet> xml = corp.GetCorporationSheet();
            Assert.AreEqual(150212025, xml.Result.CorporationId);
        }

        [TestMethod]
        public void GetFactionalWarfareStats() {
            EveApiResponse<FactionWarfareStats> xml = corp.GetFactionWarfareStats();
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            EveApiResponse<IndustryJobs> xml = corp.GetIndustryJobs();
            Assert.AreEqual(23264063, xml.Result.Jobs.First().JobId);
        }

        [TestMethod]
        public void GetKillLog() {
            EveApiResponse<KillLog> xml = corp.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
        }

        [TestMethod]
        public void GetLocations() {
            EveApiResponse<Locations> xml = corp.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            EveApiResponse<MarketOrders> xml = corp.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            EveApiResponse<MedalList> xml = corp.GetMedals();
            Assert.AreEqual(123123, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetMemberMedals() {
            EveApiResponse<MemberMedals> xml = corp.GetMemberMedals();
            Assert.AreEqual(24216, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetMemberSecurity() {
            EveApiResponse<MemberSecurity> xml = corp.GetMemberSecurity();
            Assert.AreEqual(123456789, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberSecurityLog() {
            EveApiResponse<MemberSecurityLog> xml = corp.GetMemberSecurityLog();
            Assert.AreEqual(1234567890, xml.Result.RoleHistory.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberTracking() {
            EveApiResponse<MemberTracking> xml = corp.GetMemberTracking(true);
            Assert.AreEqual(921331161, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetOutpostList() {
            EveApiResponse<OutpostList> xml = corp.GetOutpostList();
            Assert.AreEqual(61000368, xml.Result.Outposts.First().StationId);
        }

        [TestMethod]
        public void GetOutpostServiceDetail() {
            EveApiResponse<OutpostServiceDetails> xml = corp.GetOutpostServiceDetails(0);
            Assert.AreEqual(61000368, xml.Result.Services.First().StationId);
        }

        [TestMethod]
        public void GetShareholders() {
            EveApiResponse<ShareholderList> xml = corp.GetShareholders();
            Assert.AreEqual(126891489, xml.Result.Shareholders.First().ShareholderId);
        }

        [TestMethod]
        public void GetStandings() {
            EveApiResponse<StandingsList> xml = corp.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CorporationStandings.Agents.First().FromId);
        }

        [TestMethod]
        public void GetStarbaseDetail() {
            EveApiResponse<StarbaseDetails> xml = corp.GetStarbaseDetails(0);
            Assert.AreEqual(4, xml.Result.State);
        }

        [TestMethod]
        public void GetStarbaseList() {
            EveApiResponse<StarbaseList> xml = corp.GetStarbaseList();
            Assert.AreEqual(100449451, xml.Result.Starbases.First().ItemId);
        }

        [TestMethod]
        public void GetTitles() {
            EveApiResponse<TitleList> xml = corp.GetTitles();
            Assert.AreEqual(8192, xml.Result.Titles.First().RolesAtHq.First().RoleId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            EveApiResponse<WalletJournal> xml = corp.GetWalletJournal();
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            EveApiResponse<WalletTransactions> xml = corp.GetWalletTransactions();
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }
    }
}