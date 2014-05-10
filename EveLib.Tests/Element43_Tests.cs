using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Element43_Tests {

        public readonly Element43 Api = new Element43();

        [TestMethod]
        public void GetInvTypes_ValidRequest_NoErrors() {
            var result = Api.GetInvTypes();
        }
    }
}
