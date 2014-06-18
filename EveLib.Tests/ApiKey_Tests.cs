using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class ApiKey_Tests {
        private const int KeyId = 3120814;

        private const string VCode = "L7jbIZe6EPxRgz0kIv64jym4zvwNAmEf36zMZlRA2c8obMlWC9DFEmdytdQP4N0l";

        private readonly ApiKey _validKey = new ApiKey(KeyId, VCode);

        [TestMethod]
        public void Init_NoExceptions() {
            ApiKey res = _validKey.Init();
        }

        [TestMethod]
        public async Task InitAsync_NoExceptions() {
            ApiKey res = await _validKey.InitAsync();
        }

        [TestMethod]
        public void GetApiKeyInfo_NoExceptions() {
            EveApiResponse<ApiKeyInfo> res = _validKey.GetApiKeyInfoAsync().Result;
        }

        [TestMethod]
        public void GetCharacterList_NoExceptions() {
            EveApiResponse<CharacterList> res = _validKey.GetCharacterListAsync().Result;
        }

        [TestMethod]
        public void Properties_LazyLoaded() {
            Assert.AreEqual(ApiKeyType.Character, _validKey.KeyType);
            Assert.IsNotNull(_validKey.ExpiryDate);
            Assert.AreEqual(268435455, _validKey.AccessMask);
        }

        /// <summary>
        ///     Returns 403 Forbidden with error content on invalid key requests
        /// </summary>
        [TestMethod]
        public void IsValidKey_InvalidKey_NoExceptions() {
            var key = new ApiKey(0, "invalid");
            Assert.AreEqual(false, key.IsValidKey());
        }

        /// <summary>
        ///     Returns 403 Forbidden with error content on invalid key requests
        /// </summary>
        [TestMethod]
        public async Task IsValidKeyAsync_InvalidKey_NoExceptions() {
            var key = new ApiKey(0, "invalid");
            Assert.AreEqual(false, await key.IsValidKeyAsync());
        }
    }
}