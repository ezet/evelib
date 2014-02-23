using eZet.Eve.EoLib.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EoLib.Test {

    [TestClass]
    class ApiKey_Tests {

        private const int KeyId = 3120814;

        private const string VCode = "L7jbIZe6EPxRgz0kIv64jym4zvwNAmEf36zMZlRA2c8obMlWC9DFEmdytdQP4N0l";

        private readonly ApiKey validKey = EoLib.GetCharacterKey(KeyId, VCode);


        [TestMethod]
        public void GetApiKeyInfo_NoExceptions() {
            var res = validKey.GetApiKeyInfo();
        }

        [TestMethod]
        public void GetCharacterList_NoExceptions() {
            var res = validKey.GetCharacterList();
        }

        [TestMethod]
        public void Properties_LazyLoaded() {
            Assert.AreEqual(ApiKeyType.Character, validKey.KeyType);
            Assert.IsNotNull(validKey.ExpireDate);
            Assert.AreEqual(268435455, validKey.AccessMask);
        }
    }
}
