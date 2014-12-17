using System;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Exceptions;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Tests {
        private const int AllianceId = 434243723; // C C P Alliance

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        private const string killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";

        public EveCrest EveCrest = new EveCrest();

        public EveCrest_Tests() {
            EveCrest.AccessToken =
                "UsIcawIKnTkLBknGg6Tjx-zFkU_XK0LOMWucbKXoaWrHjYtrldb8bZPjEEkj9rueXD97lYkInjg0urr7SbJ1UA2";
            //EveCrest.Mode = CrestMode.Authenticated;
            EveCrest.RequestHandler.ThrowOnDeprecated = true;
        }

        [TestMethod]
        public async Task GetRoot() {
            CrestRoot result = await EveCrest.GetRootAsync();
            var test = await EveCrest.Load(result.Alliances);
        }


        [TestMethod]
        public async Task GetKillmail_NoErrors() {
            CrestKillmail data = EveCrest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            var system = await EveCrest.Load(data.SolarSystem);
            var stats = await EveCrest.Load(system.Stats);
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetIncursions_NoErrors() {
            CrestIncursionCollection data = EveCrest.GetIncursions();
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            CrestAllianceCollection data = EveCrest.GetAlliances();
        }

        [TestMethod]
        public void GetAlliance_NoErrors() {
            CrestAlliance data = EveCrest.GetAlliance(AllianceId);
            Assert.AreNotEqual(data.Id, 0);
        }


        [TestMethod]
        public void GetMarketHistory_NoErrors() {
            CrestMarketHistory data = EveCrest.GetMarketHistory(RegionId, TypeId);
        }

        [TestMethod]
        public async Task GetMarketPrices() {
            CrestMarketTypePriceCollection result = await EveCrest.GetMarketPricesAsync();
            Console.WriteLine(result.Prices.Count);
        }

        [TestMethod]
        public void GetWars_NoErrors() {
            CrestWarCollection data = EveCrest.GetWars();
        }

        [TestMethod]
        public void GetWar_NoErrors() {
            CrestWar data = EveCrest.GetWar(291410);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            CrestKillmailCollection data = EveCrest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof (EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            CrestWar data = await EveCrest.GetWarAsync(999999999);
        }

        [TestMethod]
        public async Task GetSpecialities() {
            CrestIndustrySpecialityCollection result = await EveCrest.GetSpecialitiesAsync();
        }

        [TestMethod]
        public async Task GetSpeciality() {
            CrestIndustrySpeciality result = await EveCrest.GetSpecialityAsync(10);
        }


        [TestMethod]
        public async Task GetIndustryTeams() {
            CrestIndustryTeamCollection result = await EveCrest.GetIndustryTeamsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeam() {
            CrestIndustryTeamCollection teams = await EveCrest.GetIndustryTeamsAsync();
            CrestIndustryTeam result = await EveCrest.GetIndustryTeamAsync(teams.Items.Last().Id);
        }

        [TestMethod]
        public async Task GetIndustrySystemsAsync() {
            CrestIndustrySystemCollection result = await EveCrest.GetIndustrySystemsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeamAuctions() {
            CrestIndustryTeamAuction result = await EveCrest.GetIndustryTeamAuctionsAsync();
        }

        [TestMethod]
        public async Task GetIndustryFacilities() {
            CrestIndustryFacilityCollection result = await EveCrest.GetIndustryFacilitiesAsync();
        }
    }
}