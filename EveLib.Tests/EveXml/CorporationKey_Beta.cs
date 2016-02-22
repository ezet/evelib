using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CorporationKey_Beta {
        private const int SisiKeyId = 1467544;

        private const string SisiVCode = "Y7Uopdrv1CJ6iCp0LydYDQ932kkz0p0NvE4FLWydnbCHFZGzaE85erfczpR2XuPj";

        private readonly CorporationKey _sisiKey = new CorporationKey(SisiKeyId, SisiVCode);


        public CorporationKey_Beta() {
            _sisiKey.BaseUri = "https://api.testeveonline.com";
            _sisiKey.Corporation.BaseUri = "https://api.testeveonline.com";
        }

        [TestMethod]
        public async Task GetBlueprints() {
            var result = await _sisiKey.Corporation.GetBlueprintsAsync();
        }
    }
}