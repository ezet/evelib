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
        public void GetIncursions_NoErrors() {
            EveCrestIncursions data = EveCrest.GetIncursions();
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            EveCrestAlliances data = EveCrest.GetAlliances();
        }

        [TestMethod]
        public void GetAlliance_NoErrors() {
            EveCrestAlliance data = EveCrest.GetAlliance(AllianceId);
            Assert.AreNotEqual(data.Id, 0);
        }

        [TestMethod]
        public void GetKillmail_NoErrors() {
            EveCrestKillmail data = EveCrest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetMarketHistory_NoErrors() {
            EveCrestMarketHistory data = EveCrest.GetMarketHistory(RegionId, TypeId);
        }

        [TestMethod]
        public void GetWars_NoErrors() {
            EveCrestWars data = EveCrest.GetWars();
        }

        [TestMethod]
        public void GetWar_NoErrors() {
            EveCrestWar data = EveCrest.GetWar(291410);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            EveCrestKillmails data = EveCrest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof (EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            EveCrestWar data = await EveCrest.GetWarAsync(999999999);
        }
    }
}