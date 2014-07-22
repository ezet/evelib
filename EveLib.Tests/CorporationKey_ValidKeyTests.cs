using System;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Corporation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList = eZet.EveLib.Modules.Models.Corporation.ContactList;
using MedalList = eZet.EveLib.Modules.Models.Corporation.MedalList;
using StandingsList = eZet.EveLib.Modules.Models.Corporation.StandingsList;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CorporationKey_ValidKeyTests {
        private const int CorpId = 3120830;

        private const string CorpCode = "Zw1DpOUDPYrv49iGTVkDHoRburv2rAAYEbret9B5IVfcVjVDR4DE2bo7p1RMZQMU";

        private readonly CorporationKey _validKey = new CorporationKey(CorpId, CorpCode);

        [TestMethod]
        public void Corporation_ValidRequest_HasName() {
            Assert.IsNotNull(_validKey.Corporation.CorporationName);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            EveApiResponse<AccountBalance> res = _validKey.Corporation.GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            EveApiResponse<AssetList> res = _validKey.Corporation.GetAssetList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            EveApiResponse<ContactList> res = _validKey.Corporation.GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContainerLog_ValidRequest_HasResult() {
            EveApiResponse<ContainerLog> res = _validKey.Corporation.GetContainerLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            EveApiResponse<ContractList> res = _validKey.Corporation.GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetContractItems_InvalidId_InvalidRequestException() {
            _validKey.Corporation.GetContractItems(0);
            // Returns http 500 on invalid id
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            EveApiResponse<ContractBids> res = _validKey.Corporation.GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetCorporationSheet_ValidRequest_HasResult() {
            EveApiResponse<CorporationSheet> res = _validKey.Corporation.GetCorporationSheet();
            Assert.IsNotNull(res.Result);
        }

        /// <summary>
        ///     Test using character that has not participated in factional warfare
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetFactionalWarfareStats_InvalidRequest_InvalidRequestException() {
            _validKey.Corporation.GetFactionWarfareStats();
        }

        [TestMethod]
        public async Task GetIndustryJobs_NoErrors() {
            EveApiResponse<IndustryJobs> result = await _validKey.Corporation.GetIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetIndustryJobsHistory_NoErrors() {
            EveApiResponse<IndustryJobs> result = await _validKey.Corporation.GetIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetFacilities_NoErrors() {
            EveApiResponse<Facilities> result = await _validKey.Corporation.GetFacilitiesAsync();
        }

        [TestMethod]
        public void GetKillLog_ValidRequest_HasResult() {
            EveApiResponse<KillLog> res = _validKey.Corporation.GetKillLog();
            Assert.IsNotNull(res.Result);
            // TODO Test this further
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetLocations_InvalidId_InvalidRequestException() {
            _validKey.Corporation.GetLocations(0);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            EveApiResponse<MarketOrders> res = _validKey.Corporation.GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            EveApiResponse<MedalList> res = _validKey.Corporation.GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberMedals_ValidRequest_HasResult() {
            EveApiResponse<MemberMedals> res = _validKey.Corporation.GetMemberMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberSecurity_ValidRequest_HasResult() {
            EveApiResponse<MemberSecurity> res = _validKey.Corporation.GetMemberSecurity();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberSecurityLog_ValidRequest_HasResult() {
            EveApiResponse<MemberSecurityLog> res = _validKey.Corporation.GetMemberSecurityLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberTracking_ValidRequest_HasResult() {
            EveApiResponse<MemberTracking> res = _validKey.Corporation.GetMemberTracking(true);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetOutpostList_ValidRequest_HasResult() {
            EveApiResponse<OutpostList> res = _validKey.Corporation.GetOutpostList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetOutpostServiceDetails_InvalidId_NoException() {
            _validKey.Corporation.GetOutpostServiceDetails(0);
            // Returns http 200 and empty Result on invalid ID
        }

        [TestMethod]
        public void GetShareholders_ValidRequest_HasResult() {
            EveApiResponse<ShareholderList> res = _validKey.Corporation.GetShareholders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            EveApiResponse<StandingsList> res = _validKey.Corporation.GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (AggregateException))]
        public void GetStarbaseDetails_InvalidId_InvalidRequestException() {
            _validKey.Corporation.GetStarbaseDetails(0);
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetStarbaseList_ValidRequest_HasResult() {
            EveApiResponse<StarbaseList> res = _validKey.Corporation.GetStarbaseList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetTitles_ValidRequest_HasResult() {
            EveApiResponse<TitleList> res = _validKey.Corporation.GetTitles();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            EveApiResponse<WalletJournal> res = _validKey.Corporation.GetWalletJournal(1001, 5);
            Assert.IsNotNull(res.Result);
            //var older = res.Result.GetOlder(50);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            EveApiResponse<WalletTransactions> res = _validKey.Corporation.GetWalletTransactions(50);
            Assert.IsNotNull(res.Result);
            //res = res.Result.GetOlder(50);
        }

        [TestMethod]
        public void GetCustomsOffices_ValidRequest_HasResult() {
            EveApiResponse<CustomsOffices> res = _validKey.Corporation.GetCustomsOffices();
        }

        [TestMethod]
        public async Task GetCustomsOfficesAsync_ValidRequest_HasResult() {
            EveApiResponse<CustomsOffices> res = await _validKey.Corporation.GetCustomsOfficesAsync();
        }
    }
}