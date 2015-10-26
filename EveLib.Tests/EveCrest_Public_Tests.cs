using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {

    [TestClass]
    public class EveCrest_Public_Tests {
        private const int AllianceId = 434243723; // C C P Alliance

        private const int RegionId = 10000002; // The Forge 

        private const int TypeId = 34; // Tritanium

        private const string Killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";


        private readonly EveCrest crest = new EveCrest();

        public EveCrest_Public_Tests() {
            crest.EnableAutomaticTokenRefresh = true;
            crest.RequestHandler.ThrowOnDeprecated = true;
        }

        [TestMethod]
        public void GetRoot() {
            CrestRoot root = crest.GetRoot();
            Debug.WriteLine(root.UserCounts.Dust);
            Debug.WriteLine(root.ServerName);
        }

        [TestMethod]
        public void GetKillmail_NoErrors() {
            Killmail data = crest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetIncursions_NoErrors() {
            IncursionCollection incursionCollection = crest.GetRoot().Query(r => r.Incursions);
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            AllianceCollection response = crest.GetRoot().Query(r => r.Alliances);
            Console.WriteLine(response);
        }

        //[TestMethod]
        //public void GetAlliance_NoErrors() {
        //    AllianceCollection allianceCollection = crest.GetRoot().Query(r => r.Alliances);
        //    var all = allianceCollection.Query(f => f.Single(a => a.Id == AllianceId));
        //    var alliance = allianceCollection.AllItems().Where(f => f.Id == AllianceId);
        //    Console.WriteLine(alliance.First().Alliance.Name);
        //}

        //[TestMethod]
        //public void CollectionPaging_Manual() {
        //    AllianceCollection allianceLinks = crest.GetRoot().Query(r => r.Alliances);
        //    AllianceCollection.Alliance alliance =
        //        allianceLinks.Items.SingleOrDefault(f => f.Alliance.Id == AllianceId).Alliance;
        //    while (alliance == null && allianceLinks.Next != null) {
        //        allianceLinks = allianceLinks.Query(f => f.Next);
        //        alliance =
        //        allianceLinks.Items.SingleOrDefault(f => f.Alliance.Id == AllianceId).Alliance;
        //    }
        //    Debug.WriteLine(allianceLinks.Query(f => alliance).Name);
        //}


        [TestMethod]
        public void GetMarketHistory_NoErrors() {
            MarketHistoryCollection data = crest.GetMarketHistory(RegionId, TypeId);
        }

        [TestMethod]
        public async Task GetMarketPrices() {
            MarketTypePriceCollection result = await crest.GetMarketPricesAsync();
            Console.WriteLine(result.Items.Count);
        }

        [TestMethod]
        public void GetWars_NoErrors() {
            WarCollection data = crest.GetWars();
        }

        [TestMethod]
        public void GetWar_NoErrors() {
            var warCollection = crest.GetRoot().Query(r => r.Wars);
            var data = warCollection.Query(f => f.Single(w => w.Id == 291410));
            Debug.WriteLine(data.Id);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            KillmailCollection data = crest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof(EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            War data = await crest.GetWarAsync(999999999);
        }

        [TestMethod]
        public async Task GetSpecialities() {
            IndustrySpecialityCollection result = await crest.GetSpecialitiesAsync();
        }

        [TestMethod]
        public async Task GetSpeciality() {
            IndustrySpeciality result = await crest.GetSpecialityAsync(10);
        }


        [TestMethod]
        public async Task GetIndustryTeams() {
            IndustryTeamCollection result = await crest.GetIndustryTeamsAsync();
            Console.Write(result);
        }

        [TestMethod]
        public async Task GetIndustryTeam() {
            IndustryTeamCollection teams = await crest.GetIndustryTeamsAsync();
            IndustryTeam result = await crest.GetIndustryTeamAsync(teams.Items.Last().Id);
        }

        [TestMethod]
        public async Task GetIndustrySystemsAsync() {
            IndustrySystemCollection result = await crest.GetIndustrySystemsAsync();
            Console.Write(result);
        }

        [TestMethod]
        public async Task GetIndustryTeamAuctions() {
            IndustryTeamCollection result = await crest.GetIndustryTeamAuctionsAsync();
        }

        [TestMethod]
        public async Task GetIndustryFacilities() {
            IndustryFacilityCollection result = await crest.GetIndustryFacilitiesAsync();
        }

        [TestMethod]
        public async Task ItemGroups() {
            ItemGroupCollection itemGroups = await crest.GetRoot().QueryAsync(r => r.ItemGroups);
            var group = itemGroups.Query(f => f.Single(g => g.Id == 354753));

            Console.WriteLine(group.Name);
        }

        [TestMethod]
        public async Task GetSovereigntyStructures() {
            var response = await crest.GetRoot().QueryAsync(r => r.Sovereignty.Structures);
        }

        [TestMethod]
        public async Task GetSovereigntyCampaigns() {
            var response = await crest.GetRoot().QueryAsync(r => r.Sovereignty.Campaigns);
        }

        [TestMethod]
        public async Task GetItemTypes() {
            var response = await crest.GetRoot().QueryAsync(r => r.ItemTypes);
            var type = response.Query(r => r.Items.Single(t => t.Id == 200));
            Assert.IsNotNull(type.GraphicId);
        }

        [TestMethod]
        public async Task GetBuyOrderWith() {
            var orders =
                (await
                    (await
                        (await crest.GetRootAsync())
                    .QueryAsync(r => r.Regions))
                .QueryAsync(x => x.Single(r => r.Name == "The Forge")))
                .Query(r => r.MarketBuyOrders, "type",
                            "https://public-crest.eveonline.com/types/34/");
        }
    }
}
