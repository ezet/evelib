using System.Threading.Tasks;
using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {


    [TestClass]
    public class EveCrest_SiSi_Tests {
    private readonly EveCrest _crest = new EveCrest();

        public EveCrest_SiSi_Tests() {
            _crest.BaseUri = "http://public-crest-sisi.testeveonline.com/";
        }

        [TestMethod]
        public async Task GetSpecialities() {
            var result = await _crest.GetSpecialitiesAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeams() {
            var result = await _crest.GetIndustryTeamsAsync();
        }
    }
}
