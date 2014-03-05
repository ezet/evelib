using System.Linq;
using eZet.Eve.EveLib.Exception;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Model.EveApi.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {
    /// <summary>
    ///     Summary description for MapTest
    /// </summary>
    [TestClass]
    public class Map_Tests {
        private readonly EveLib api = EveLib.Create();


        [TestMethod]
        public void TestFacWarSystems_ValidRequest_HasResult() {
            EveApiResponse<FactionWarfareSystems> res = api.Map.GetFactionWarSystems();
            Assert.IsNotNull(res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestJumps_ValidRequest_HasResult() {
            EveApiResponse<Jumps> res = api.Map.GetJumps();
            Assert.AreNotEqual(0, res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestKills_ValidRequest_HasResult() {
            EveApiResponse<Kills> res = api.Map.GetKills();
            Assert.AreNotEqual(0, res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestSovereignty_ValidRequest_HasResult() {
            EveApiResponse<Sovereignty> res = api.Map.GetSovereignty();
            Assert.IsNotNull(res.Result.SolarSystems.First());
        }

        /// <summary>
        ///     Disabled by CCP
        /// </summary>
        [TestMethod]
        public void TestSovereigntyStatus_ValidRequest_HasResult() {
            Assert.Fail("Disabled by CCP.");
            //var res = api.Map.GetSovereigntyStatus();
        }
    }
}