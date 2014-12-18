using System.Diagnostics;
using System.Threading.Tasks;
using eZet.EveLib.EveAuthModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveAuth_Tests {
        private const string ClientId = "46daa2b378bd4bc189df4c3a73af226a";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private const string AuthCode = "8nOSjSN0p1LfNee1Rs6cgaui6nRESMiwKP75rN5TjTUd9YeqorYxZqPJWzEwdc4T0";

        private const string RefreshToken = "ldF1J8ny_fEjLKyyG4yixGjU8Hi4XCA-5cAdDCzlzNw1";
        private readonly EveAuth _eveAuth = new EveAuth();

        [TestMethod]
        public void GetAuthorizatinLink() {
            string response = _eveAuth.CreateAuthLink(ClientId, "/", CrestScope.PublicData);
            Trace.WriteLine(response);
        }

        [TestMethod]
        public void Authenticate() {
            AuthResponse response = _eveAuth.AuthenticateAsync(EncodedKey, AuthCode).Result;
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine(response.AccessToken);
        }

        [TestMethod]
        public async Task Refresh() {
            AuthResponse response = await _eveAuth.RefreshAsync(EncodedKey, RefreshToken);
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine(response.AccessToken);
        }
    }
}