using System;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CharacterKey_Sisi {

        private const string SisiVCode = "nNsODzp8SwufvWeMUmE0UINIMxTpNpEqqr2MOn6DmAXgQBRjKwFc7C4i5pp5uVRX";

        private const int SisiKeyId = 1467543;

        private readonly CharacterKey _sisiKey = new CharacterKey(SisiKeyId, SisiVCode);


        public CharacterKey_Sisi() {
            _sisiKey.BaseUri = new Uri("https://api.testeveonline.com");
            _sisiKey.Characters.First().BaseUri = new Uri("https://api.testeveonline.com");
        }

        [TestMethod]
        public async Task GetNewIndustryJobs_NoErrors() {
            var data = await _sisiKey.Characters.First().GetNewIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetIndustryJobsHistory_NoErrors() {
            var data = await _sisiKey.Characters.First().GetNewIndustryJobsAsync();
        }
    }
}
