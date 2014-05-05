using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {


    [TestClass]
    public class Crest_Tests {

        public EveCrest EveCrest = new EveCrest();

        [TestMethod]
        public void GetIncurstions_NoErrors() {
            var data = EveCrest.GetIncurstions();
            var a = data.totalCount_str;
        }
    }
}
