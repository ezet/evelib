using System.Threading.Tasks;
using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {


    [TestClass]
    public class EveCrest_Beta_Tests {
    private readonly EveCrest _crest = new EveCrest();

        public EveCrest_Beta_Tests() {
            _crest.BaseUri = "http://public-crest-sisi.testeveonline.com/";
        }

        [TestMethod]
        public async Task GetRoot() {
            var result = await _crest.GetRootAsync();
        }

        [TestMethod]
        public async Task GetSpecialities() {
            var result = await _crest.GetSpecialitiesAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeams() {
            var result = await _crest.GetIndustryTeamsAsync();
        }

        [TestMethod]
        public async Task GetIndustrySystems() {
            var result = await _crest.GetIndustrySystemsAsync();
        }

        [TestMethod]
        public async Task GetIndustryTeamAuctions() {
            var result = await _crest.GetIndustryTeamAuctionsAsync();
        }

        [TestMethod]
        public async Task GetSpeciality() {
            var result = await _crest.GetSpecialityAsync(10);
        }

        [TestMethod]
        public async Task GetMarketPrices() {
            var result = await _crest.GetMarketPricesAsync();
        }
    }
}
