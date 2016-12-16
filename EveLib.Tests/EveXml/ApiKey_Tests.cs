using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class ApiKey_Tests {
        private const int KeyId = 4438372;

        private const string VCode = "v7NFEMJ8tMb74tN5XYPUZ5LwZuFlnFEbLCv2WhtH1UxYoDMrvEQkNljcI2hdBgjl";

        private readonly ApiKey _validKey = new ApiKey(KeyId, VCode);

        [TestMethod]
        public void Init_NoExceptions() {
            var res = _validKey.Init();
        }

        [TestMethod]
        public async Task InitAsync_NoExceptions() {
            var res = await _validKey.InitAsync();
        }

        [TestMethod]
        public void GetApiKeyInfo_NoExceptions() {
            var res = _validKey.GetApiKeyInfoAsync().Result;
        }

        [TestMethod]
        public void GetCharacterList_NoExceptions() {
            var res = _validKey.GetCharacterListAsync().Result;
        }

        [TestMethod]
        public void Properties_LazyLoaded() {
            Assert.AreEqual(ApiKeyType.Account, _validKey.KeyType);
            Assert.IsNotNull(_validKey.ExpiryDate);
            Assert.AreEqual(268435455ul, _validKey.AccessMask);
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