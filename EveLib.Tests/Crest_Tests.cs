using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {



    [TestClass]
    public class Crest_Tests {
        
        private const int AllianceId = 434243723; // C C P Alliance

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        public EveCrest EveCrest = new EveCrest();

        [TestMethod]
        public void GetIncurstions_NoErrors() {
            var data = EveCrest.GetIncursions();
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            var data = EveCrest.GetAlliances();
        }

        [TestMethod]
        public void GetAlliance_NoErrors() {
            var data = EveCrest.GetAlliance(AllianceId);
        }

        [TestMethod]
        public void GetKillmails_NoErrors() {
            var data = EveCrest.GetKillmails(1, "test");
        }

        [TestMethod]
        public void GetMarketHistory_NoErrors() {
            var data = EveCrest.GetMarketHistory(RegionId, TypeId);
        }
    }
}
