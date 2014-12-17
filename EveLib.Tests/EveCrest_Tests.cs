using System;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Exceptions;
using eZet.EveLib.Modules.Models.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Tests {
        private const int AllianceId = 434243723; // C C P Alliance

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        private const string Killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";

        private const string RefreshToken = "ldF1J8ny_fEjLKyyG4yixGjU8Hi4XCA-5cAdDCzlzNw1";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private readonly EveCrest crest = new EveCrest();

        public EveCrest_Tests() {
            //crest.AccessToken =
            //    "UsIcawIKnTkLBknGg6Tjx-zFkU_XK0LOMWucbKXoaWrHjYtrldb8bZPjEEkj9rueXD97lYkInjg0urr7SbJ1UA2";
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            crest.Mode = CrestMode.Authenticated;
            crest.RequestHandler.ThrowOnDeprecated = true;
        }

        [TestMethod]
        public async Task RefreshAccessToken() {
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            await crest.RefreshAccessToken();
        }

        [TestMethod]
        public async Task GetRoot() {
            CrestRoot result = await crest.GetRootAsync();
            var test = await crest.Load(result.Alliances);
        }


        [TestMethod]
        public async Task GetKillmail_NoErrors() {
            CrestKillmail data = crest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            var system = await crest.Load(data.SolarSystem);
            var stats = await crest.Load(system.Stats);
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetIncursions_NoErrors() {
            CrestIncursionCollection data = crest.GetIncursions();
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            CrestAllianceCollection data = crest.GetAlliances();
        }

        [TestMethod]
        public void GetAlliance_NoErrors() {
            CrestAlliance data = crest.GetAlliance(AllianceId);
            Assert.AreNotEqual(data.Id, 0);
        }


        [TestMethod]
        public void GetMarketHistory_NoErrors() {
            CrestMarketHistory data = crest.GetMarketHistory(RegionId, TypeId);
        }

        [TestMethod]
        public async Task GetMarketPrices() {
            CrestMarketTypePriceCollection result = await crest.GetMarketPricesAsync();
            Console.WriteLine(result.Prices.Count);
        }

        [TestMethod]
        public void GetWars_NoErrors() {
            CrestWarCollection data = crest.GetWars();
        }

        [TestMethod]
        public void GetWar_NoErrors() {
            CrestWar data = crest.GetWar(291410);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            CrestKillmailCollection data = crest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof(EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            CrestWar data = await crest.GetWarAsync(999999999);
        }

        [TestMethod]
        public async Task GetSpecialities() {
            CrestIndustrySpecialityCollection result = await crest.GetSpecialitiesAsync();
        }

        [TestMethod]
        public async Task GetSpeciality() {
            CrestIndustrySpeciality result = await crest.GetSpecialityAsync(10);
        }


        [TestMethod]
        public async Task GetIndustryTeams() {
            CrestIndustryTeamCollection result = await crest.GetIndustryTeamsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeam() {
            CrestIndustryTeamCollection teams = await crest.GetIndustryTeamsAsync();
            CrestIndustryTeam result = await crest.GetIndustryTeamAsync(teams.Items.Last().Id);
        }

        [TestMethod]
        public async Task GetIndustrySystemsAsync() {
            CrestIndustrySystemCollection result = await crest.GetIndustrySystemsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeamAuctions() {
            CrestIndustryTeamCollection result = await crest.GetIndustryTeamAuctionsAsync();
        }

        [TestMethod]
        public async Task GetIndustryFacilities() {
            CrestIndustryFacilityCollection result = await crest.GetIndustryFacilitiesAsync();
        }
    }
}