using System.Linq;
using eZet.Eve.EveApi.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveApi.Test {

    [TestClass]
    public class AccountDeserializeTest {

        private readonly Account acc;
        
        public AccountDeserializeTest() {
            acc = new Account(default(ApiKey));
            acc.RequestHelper = new TestRequestHelper();
        }

        [TestMethod]
        public void GetAccountStatus() {
            var xml = acc.GetAccountStatus();
            Assert.AreEqual(9999, xml.Result.LogonCount);
            Assert.AreEqual(9999, xml.Result.LogonMinutes);
            Assert.AreEqual("2004-01-01 00:00:00", xml.Result.CreationDate);
            Assert.AreEqual("2011-01-01 00:00:00", xml.Result.PaidUntil);
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
