using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.Models.Character;
using eZet.EveLib.EveXmlModule.Models.Corporation;
using eZet.EveLib.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList = eZet.EveLib.EveXmlModule.Models.Corporation.ContactList;
using FactionWarfareStats = eZet.EveLib.EveXmlModule.Models.Corporation.FactionWarfareStats;
using MedalList = eZet.EveLib.EveXmlModule.Models.Corporation.MedalList;
using StandingsList = eZet.EveLib.EveXmlModule.Models.Corporation.StandingsList;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Corporation_StaticDeserializationTests {
        private readonly Corporation _corp;

        public Corporation_StaticDeserializationTests() {
            _corp = new Corporation(new CorporationKey(0, ""), 0);
            _corp.RequestHandler = new StaticXmlRequestHandler(new XmlSerializer());
        }

        [TestMethod]
        public void GetAccountBalance() {
            EveXmlResponse<AccountBalance> xml = _corp.GetAccountBalance();
            Assert.AreEqual(4759, xml.Result.Accounts.First().AccountId);
        }

        [TestMethod]
        public void GetAssetList() {
            EveXmlResponse<AssetList> xml = _corp.GetAssetList();
            Assert.AreEqual(150354641, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetContactList() {
            EveXmlResponse<ContactList> xml = _corp.GetContactList();
            Assert.AreEqual(797400947, xml.Result.CorporationContacts.First().ContactId);
        }

        [TestMethod]
        public void GetContainerLog() {
            EveXmlResponse<ContainerLog> xml = _corp.GetContainerLog();
            Assert.AreEqual(2051471251, xml.Result.LogEntries.First().ItemId);
        }

        [TestMethod]
        public void GetContracts() {
            EveXmlResponse<ContractList> xml = _corp.GetContracts();
            // TODO Get sample
        }

        [TestMethod]
        public void GetContractItems() {
            EveXmlResponse<ContractItems> xml = _corp.GetContractItems(0);
            Assert.AreEqual(600515136, xml.Result.Items.First().RecordId);
        }

        [TestMethod]
        public void GetContractBids() {
            EveXmlResponse<ContractBids> xml = _corp.GetContractBids();
            Assert.AreEqual(123123123, xml.Result.Bids.First().BidId);
        }

        [TestMethod]
        public void GetCorporationSheet() {
            EveXmlResponse<CorporationSheet> xml = _corp.GetCorporationSheet();
            Assert.AreEqual(150212025, xml.Result.CorporationId);
        }

        [TestMethod]
        public void GetFactionalWarfareStats() {
            EveXmlResponse<FactionWarfareStats> xml = _corp.GetFactionWarfareStats();
            Assert.AreEqual(500001, xml.Result.FactionId);
        }

        [TestMethod]
        public void GetIndustryJobs() {
            EveXmlResponse<IndustryJobs> xml = _corp.GetIndustryJobs();
        }

        [TestMethod]
        public void GetKillLog() {
            EveXmlResponse<KillLog> xml = _corp.GetKillLog();
            Assert.AreEqual(63, xml.Result.Kills.First().KillId);
        }

        [TestMethod]
        public void GetLocations() {
            EveXmlResponse<Locations> xml = _corp.GetLocations(0);
            Assert.AreEqual(887875612, xml.Result.Items.First().ItemId);
        }

        [TestMethod]
        public void GetMarketOrders() {
            EveXmlResponse<MarketOrders> xml = _corp.GetMarketOrders();
            Assert.AreEqual(5630641, xml.Result.Orders.First().OrderId);
        }

        [TestMethod]
        public void GetMedals() {
            EveXmlResponse<MedalList> xml = _corp.GetMedals();
            Assert.AreEqual(123123, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetMemberMedals() {
            EveXmlResponse<MemberMedals> xml = _corp.GetMemberMedals();
            Assert.AreEqual(24216, xml.Result.Medals.First().MedalId);
        }

        [TestMethod]
        public void GetMemberSecurity() {
            EveXmlResponse<MemberSecurity> xml = _corp.GetMemberSecurity();
            Assert.AreEqual(123456789, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberSecurityLog() {
            EveXmlResponse<MemberSecurityLog> xml = _corp.GetMemberSecurityLog();
            Assert.AreEqual(1234567890, xml.Result.RoleHistory.First().CharacterId);
        }

        [TestMethod]
        public void GetMemberTracking() {
            EveXmlResponse<MemberTracking> xml = _corp.GetMemberTracking(true);
            Assert.AreEqual(921331161, xml.Result.Members.First().CharacterId);
        }

        [TestMethod]
        public void GetOutpostList() {
            EveXmlResponse<OutpostList> xml = _corp.GetOutpostList();
            Assert.AreEqual(61000368, xml.Result.Outposts.First().StationId);
        }

        [TestMethod]
        public void GetOutpostServiceDetail() {
            EveXmlResponse<OutpostServiceDetails> xml = _corp.GetOutpostServiceDetails(0);
            Assert.AreEqual(61000368, xml.Result.Services.First().StationId);
        }

        [TestMethod]
        public void GetShareholders() {
            EveXmlResponse<ShareholderList> xml = _corp.GetShareholders();
            Assert.AreEqual(126891489, xml.Result.Shareholders.First().ShareholderId);
        }

        [TestMethod]
        public void GetStandings() {
            EveXmlResponse<StandingsList> xml = _corp.GetStandings();
            Assert.AreEqual(3009841, xml.Result.CorporationStandings.Agents.First().FromId);
        }

        [TestMethod]
        public void GetStarbaseDetail() {
            EveXmlResponse<StarbaseDetails> xml = _corp.GetStarbaseDetails(0);
            Assert.AreEqual(4, xml.Result.State);
        }

        [TestMethod]
        public void GetStarbaseList() {
            EveXmlResponse<StarbaseList> xml = _corp.GetStarbaseList();
            Assert.AreEqual(100449451, xml.Result.Starbases.First().ItemId);
        }

        [TestMethod]
        public void GetTitles() {
            EveXmlResponse<TitleList> xml = _corp.GetTitles();
            Assert.AreEqual(8192, xml.Result.Titles.First().RolesAtHq.First().RoleId);
        }

        [TestMethod]
        public void GetWalletJournal() {
            EveXmlResponse<WalletJournal> xml = _corp.GetWalletJournal();
            Assert.AreEqual(150337897, xml.Result.Journal.First().OwnerId);
        }

        [TestMethod]
        public void GetWalletTransactions() {
            EveXmlResponse<WalletTransactions> xml = _corp.GetWalletTransactions();
            Assert.AreEqual(1309776438, xml.Result.Transactions.First().TransactionId);
        }

        [TestMethod]
        public async Task GetBlueprints() {
            EveXmlResponse<BlueprintList> xml = await _corp.GetBlueprintsAsync();
            Assert.IsTrue(xml.Result.Blueprints.Any());
        }
    }
}