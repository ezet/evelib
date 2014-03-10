using eZet.EveLib.Core.Exception;
using eZet.EveLib.EveOnline;
using eZet.EveLib.EveOnline.Model;
using eZet.EveLib.EveOnline.Model.Character;
using eZet.EveLib.EveOnline.Model.Corporation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList = eZet.EveLib.EveOnline.Model.Corporation.ContactList;
using MedalList = eZet.EveLib.EveOnline.Model.Corporation.MedalList;
using StandingsList = eZet.EveLib.EveOnline.Model.Corporation.StandingsList;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CorporationKey_ValidKeyTests {
        private const int CorpId = 3120830;

        private const string CorpCode = "Zw1DpOUDPYrv49iGTVkDHoRburv2rAAYEbret9B5IVfcVjVDR4DE2bo7p1RMZQMU";

        private readonly CorporationKey validKey = new CorporationKey(CorpId, CorpCode);

        [TestMethod]
        public void Corporation_ValidRequest_HasName() {
            Assert.IsNotNull(validKey.Corporation.CorporationName);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            EveApiResponse<AccountBalance> res = validKey.Corporation.GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            EveApiResponse<AssetList> res = validKey.Corporation.GetAssetList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            EveApiResponse<ContactList> res = validKey.Corporation.GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContainerLog_ValidRequest_HasResult() {
            EveApiResponse<ContainerLog> res = validKey.Corporation.GetContainerLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            EveApiResponse<ContractList> res = validKey.Corporation.GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetContractItems_InvalidId_InvalidRequestException() {
            validKey.Corporation.GetContractItems(0);
            // BUG Returns http 500 on invalid id
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            EveApiResponse<ContractBids> res = validKey.Corporation.GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetCorporationSheet_ValidRequest_HasResult() {
            EveApiResponse<CorporationSheet> res = validKey.Corporation.GetCorporationSheet();
            Assert.IsNotNull(res.Result);
        }

        /// <summary>
        ///     Test using character that has not participated in factional warfare
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetFactionalWarfareStats_InvalidRequest_InvalidRequestException() {
            validKey.Corporation.GetFactionWarfareStats();
        }

        [TestMethod]
        public void GetIndustryJobs_ValidRequest_HasResult() {
            EveApiResponse<IndustryJobs> res = validKey.Corporation.GetIndustryJobs();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetKillLog_ValidRequest_HasResult() {
            EveApiResponse<KillLog> res = validKey.Corporation.GetKillLog();
            Assert.IsNotNull(res.Result);
            // TODO Test this further
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetLocations_InvalidId_InvalidRequestException() {
            validKey.Corporation.GetLocations(0);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            EveApiResponse<MarketOrders> res = validKey.Corporation.GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            EveApiResponse<MedalList> res = validKey.Corporation.GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberMedals_ValidRequest_HasResult() {
            EveApiResponse<MemberMedals> res = validKey.Corporation.GetMemberMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberSecurity_ValidRequest_HasResult() {
            EveApiResponse<MemberSecurity> res = validKey.Corporation.GetMemberSecurity();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberSecurityLog_ValidRequest_HasResult() {
            EveApiResponse<MemberSecurityLog> res = validKey.Corporation.GetMemberSecurityLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberTracking_ValidRequest_HasResult() {
            EveApiResponse<MemberTracking> res = validKey.Corporation.GetMemberTracking(true);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetOutpostList_ValidRequest_HasResult() {
            EveApiResponse<OutpostList> res = validKey.Corporation.GetOutpostList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetOutpostServiceDetails_InvalidId_InvalidRequestException() {
            validKey.Corporation.GetOutpostServiceDetails(0);
            // BUG Returns http 200 and empty Result on invalid ID
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetShareholders_ValidRequest_HasResult() {
            EveApiResponse<ShareholderList> res = validKey.Corporation.GetShareholders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            EveApiResponse<StandingsList> res = validKey.Corporation.GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidRequestException))]
        public void GetStarbaseDetails_InvalidId_InvalidRequestException() {
            validKey.Corporation.GetStarbaseDetails(0);
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetStarbaseList_ValidRequest_HasResult() {
            EveApiResponse<StarbaseList> res = validKey.Corporation.GetStarbaseList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetTitles_ValidRequest_HasResult() {
            EveApiResponse<TitleList> res = validKey.Corporation.GetTitles();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            EveApiResponse<WalletJournal> res = validKey.Corporation.GetWalletJournal(1001, 5);
            Assert.IsNotNull(res.Result);
            //var older = res.Result.GetOlder(50);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            EveApiResponse<WalletTransactions> res = validKey.Corporation.GetWalletTransactions(50);
            Assert.IsNotNull(res.Result);
            //res = res.Result.GetOlder(50);
        }
    }
}