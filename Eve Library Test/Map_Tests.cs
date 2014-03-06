using System.Linq;
using eZet.EveLib.EveOnlineApi;
using eZet.EveLib.EveOnlineApi.Model;
using eZet.EveLib.EveOnlineApi.Model.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    /// <summary>
    ///     Summary description for MapTest
    /// </summary>
    [TestClass]
    public class Map_Tests {
        private readonly Map api = new Map();


        [TestMethod]
        public void TestFacWarSystems_ValidRequest_HasResult() {
            EveApiResponse<FactionWarfareSystems> res = api.GetFactionWarSystems();
            Assert.IsNotNull(res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestJumps_ValidRequest_HasResult() {
            EveApiResponse<Jumps> res = api.GetJumps();
            Assert.AreNotEqual(0, res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestKills_ValidRequest_HasResult() {
            EveApiResponse<Kills> res = api.GetKills();
            Assert.AreNotEqual(0, res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestSovereignty_ValidRequest_HasResult() {
            EveApiResponse<Sovereignty> res = api.GetSovereignty();
            Assert.IsNotNull(res.Result.SolarSystems.First());
        }

        /// <summary>
        ///     Disabled by CCP
        /// </summary>
        [TestMethod]
        public void TestSovereigntyStatus_ValidRequest_HasResult() {
            Assert.Fail("Disabled by CCP.");
            //var res = api.GetSovereigntyStatus();
        }
    }
}