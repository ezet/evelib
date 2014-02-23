using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EoLib.Test {
    /// <summary>
    /// Summary description for MapTest
    /// </summary>
    /// 
    [TestClass]
    public class Map_Tests {

        private readonly EoLib api = new EoLib();
  

        [TestMethod]
        public void TestFacWarSystems_ValidRequest_HasResult() {
            var res = api.Map.GetFactionWarSystems();
            Assert.IsNotNull(res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestJumps_ValidRequest_HasResult() {
            var res = api.Map.GetJumps();
            Assert.AreNotEqual(0, res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestKills_ValidRequest_HasResult() {
            var res = api.Map.GetKills();
            Assert.AreNotEqual(0, res.Result.SolarSystems.First());
        }

        [TestMethod]
        public void TestSovereignty_ValidRequest_HasResult() {
            var res = api.Map.GetSovereignty();
            Assert.IsNotNull(res.Result.SolarSystems.First());
        }

        /// <summary>
        /// Disabled by CCP
        /// </summary>
        [TestMethod]
        public void TestSovereigntyStatus_ValidRequest_HasResult() {
            Assert.Fail();
            //var res = api.Map.GetSovereigntyStatus();

        }





    }
}
