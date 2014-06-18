using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class StaticData_Tests {
        public readonly EveStaticData Api = new EveStaticData();

        [TestMethod]
        public void GetInvTypes_ValidRequest_NoErrors() {
            StaticDataCollection<InvType> result = Api.GetInvTypes();
        }
    }
}