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

        private const string RefreshToken = "ldF1J8ny_fEjLKyyG4yixGjU8Hi4XCA-5cAdDCzlzNw1";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private readonly EveCrest crest = new EveCrest();

        public EveCrest_Public_Tests() {
            //crest.AccessToken =
            //    "UsIcawIKnTkLBknGg6Tjx-zFkU_XK0LOMWucbKXoaWrHjYtrldb8bZPjEEkj9rueXD97lYkInjg0urr7SbJ1UA2";
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            crest.EnableAutomaticTokenRefresh = true;
            //crest.RequestHandler.ThrowOnDeprecated = true;
        }

        [TestMethod]
        public async Task RefreshAccessTokenAsync() {
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            await crest.RefreshAccessTokenAsync();
        }

        [TestMethod]
        public void GetRoot() {
            CrestRoot root = crest.GetRoot();
            Debug.WriteLine(root.UserCounts.Dust);
            Debug.WriteLine(root.ServerName);
            //Debug.WriteLine(root.Regions.Uri);
            //var regionsData = crest.GetRoot().Query(f => f.Regions).Query(regions => regions.Items);
        }

        public async Task GetRootAsync() {
            MarketTypeCollection root = await (await crest.GetRootAsync()).QueryAsync(r => r.MarketTypes);
        }

        [TestMethod]
        public void GetKillmail_NoErrors() {
            Killmail data = crest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetIncursions_NoErrors() {
            IncursionCollection response = crest.GetRoot().Query(r => r.Incursions);
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            AllianceCollection response = crest.GetRoot().Query(r => r.Alliances);
        }

        [TestMethod]
        public void GetAlliance_NoErrors() {
            Alliance response = crest.GetRoot().Query(r => r.Alliances).Query(r => r.Single(a => a.Id == AllianceId));
        }


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
            War data = crest.GetWar(291410);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            KillmailCollection data = crest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof (EveCrestException))]
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
        }

        [TestMethod]
        public async Task GetIndustryTeam() {
            IndustryTeamCollection teams = await crest.GetIndustryTeamsAsync();
            IndustryTeam result = await crest.GetIndustryTeamAsync(teams.Items.Last().Id);
        }

        [TestMethod]
        public async Task GetIndustrySystemsAsync() {
            IndustrySystemCollection result = await crest.GetIndustrySystemsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeamAuctions() {
            IndustryTeamCollection result = await crest.GetIndustryTeamAuctionsAsync();
        }

        [TestMethod]
        public async Task GetIndustryFacilities() {
            IndustryFacilityCollection result = await crest.GetIndustryFacilitiesAsync();
        }
    }
}