using System.Linq;
using eZet.Eve.EoLib.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EoLib.Test {

    [TestClass]
    public class Account_StaticDeserializationTests {

        private readonly Account acc;
        
        public Account_StaticDeserializationTests() {
            var api = new EoLib(new ApiKey(0, ""));
            acc = api.Account;
            acc.RequestHelper = new TestRequestHelper();
            acc.Key.RequestHelper = new TestRequestHelper();
        }

        [TestMethod]
        public void GetAccountStatus() {
            var xml = acc.GetAccountStatus();
            Assert.AreEqual(9999, xml.Result.LogonCount);
            Assert.AreEqual(9999, xml.Result.LogonMinutes);
        }

        [TestMethod]
        public void GetApiKeyInfo() {
            var res = acc.GetApiKeyInfo().Result;
            Assert.AreEqual(59760264, res.Key.AccessMask);
            Assert.AreEqual(898901870, res.Key.Characters.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacters() {
            var res = acc.GetCharacterList().Result;
            Assert.AreEqual(1365215823, res.Characters.First().CharacterId);
        }
    }
}
