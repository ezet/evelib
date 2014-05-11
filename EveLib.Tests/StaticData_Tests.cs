using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class StaticData_Tests {

        public readonly StaticData Api = new StaticData();

        [TestMethod]
        public void GetInvTypes_ValidRequest_NoErrors() {
            var result = Api.GetInvTypes();
        }
    }
}
