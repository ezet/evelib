using System.Diagnostics;
using eZet.EveLib.EveAuthModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveAuth_Tests {
        private const string clientId = "46daa2b378bd4bc189df4c3a73af226a";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private readonly EveAuth _eveAuth = new EveAuth();
        private string authCode = "8nOSjSN0p1LfNee1Rs6cgaui6nRESMiwKP75rN5TjTUd9YeqorYxZqPJWzEwdc4T0";

        [TestMethod]
        public void GetAuthorizatinLink() {
            string response = _eveAuth.CreateAuthLink(clientId, "/", CrestScope.PublicData);
            Trace.WriteLine(response);
        }


        [TestMethod]
        public void Authenticate() {
            AuthResponse response = _eveAuth.AuthenticateAsync(EncodedKey, authCode).Result;
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine(response.AccessToken);
        }
    }
}