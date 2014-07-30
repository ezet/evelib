using System;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Exceptions;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Tests {
        private const int AllianceId = 434243723; // C C P Alliance

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        public EveCrest EveCrest = new EveCrest();

        [TestMethod]
        public async Task GetRoot() {
            var result = await EveCrest.GetRootAsync();
        }


        [TestMethod]
        public void GetKillmail_NoErrors() {
            CrestKillmail data = EveCrest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetIncursions_NoErrors() {
            CrestIncursions data = EveCrest.GetIncursions();
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            CrestAlliances data = EveCrest.GetAlliances();
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
            var result = await EveCrest.GetMarketPricesAsync();
            Console.WriteLine(result.Prices.Count);
        }

        [TestMethod]
        public void GetWars_NoErrors() {
            CrestWars data = EveCrest.GetWars();
        }

        [TestMethod]
        public void GetWar_NoErrors() {
            CrestWar data = EveCrest.GetWar(291410);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            CrestKillmails data = EveCrest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof (EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            CrestWar data = await EveCrest.GetWarAsync(999999999);
        }

        [TestMethod]
        public async Task GetSpecialities() {
            var result = await EveCrest.GetSpecialitiesAsync();
        }

        [TestMethod]
        public async Task GetSpeciality() {
            var result = await EveCrest.GetSpecialityAsync(10);
        }


        [TestMethod]
        public async Task GetIndustryTeams() {
            var result = await EveCrest.GetIndustryTeamsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeam() {
            var result = await EveCrest.GetIndustryTeamAsync(1);
        }

        [TestMethod]
        public async Task GetIndustrySystemsAsync() {
            var result = await EveCrest.GetIndustrySystemsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeamAuctions() {
            var result = await EveCrest.GetIndustryTeamAuctionsAsync();
        }

        [TestMethod]
        public async Task GetIndustryFacilities() {
            var result = await EveCrest.GetIndustryFacilitiesAsync();
        }
    }
}