using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class ZKillboard_Tests {
        public ZKillboard Api = new ZKillboard();

        public ZKillboardOptions Options = new ZKillboardOptions();

        public ZKillboard_Tests() {
            Options.Limit = 1;
            Options.WSpace = true;
        }

        [TestMethod]
        public void GetKills_ValidRequest_NoErrors() {
            dynamic result = Api.GetKills(Options);
        }

        [TestMethod]
        public void GetLosses_ValidRequest_NoErrors() {
            dynamic result = Api.GetLosses(Options);
        }

        [TestMethod]
        public void GetAll_ValidRequest_NoErrors() {
            dynamic result = Api.GetLosses(Options);
        }
    }
}