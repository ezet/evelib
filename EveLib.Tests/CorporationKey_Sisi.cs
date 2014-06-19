using System;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Corporation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CorporationKey_Sisi {
        private const int SisiKeyId = 1467544;

        private const string SisiVCode = "Y7Uopdrv1CJ6iCp0LydYDQ932kkz0p0NvE4FLWydnbCHFZGzaE85erfczpR2XuPj";

        private readonly CorporationKey _sisiKey = new CorporationKey(SisiKeyId, SisiVCode);


        public CorporationKey_Sisi() {
            _sisiKey.BaseUri = new Uri("https://api.testeveonline.com");
            _sisiKey.Corporation.BaseUri = new Uri("https://api.testeveonline.com");
        }

        [TestMethod]
        public async Task GetNewIndustryJobs_NoErrors() {
            EveApiResponse<IndustryJobs> result = await _sisiKey.Corporation.GetIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetIndustryJobsHistory_NoErrors() {
            EveApiResponse<IndustryJobs> result = await _sisiKey.Corporation.GetIndustryJobsAsync();
        }

        [TestMethod]
        public async Task GetFacilities_NoErrors() {
            EveApiResponse<Facilities> result = await _sisiKey.Corporation.GetFacilitiesAsync();
        }
    }
}