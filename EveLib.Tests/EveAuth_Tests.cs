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

        private const string AuthCode = "ty2wPC3x81YD5CzU6tM8p2TnvT4uJ8vjqLoSyQEvuFNV6SzzG70gvkVIptFk-7fe0";

        private const string RefreshToken = "E9nZjXvx_tFu-PdpTC6yT_j4FupJ-84ybEtNsE8iMko1";
        private readonly EveAuth _eveAuth = new EveAuth();

        [TestMethod]
        public void GetAuthorizationLink() {
            string response = _eveAuth.CreateAuthLink(ClientId, "/", "default", CrestScope.PublicData);
            Trace.WriteLine(response);
        }

        [TestMethod]
        public void Authenticate() {
            AuthResponse response = _eveAuth.AuthenticateAsync(EncodedKey, AuthCode).Result;
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine("Access Token: " + response.AccessToken);
            Trace.WriteLine("Refresh Token: " + response.RefreshToken);
        }

        [TestMethod]
        public async Task Refresh() {
            AuthResponse response = await _eveAuth.RefreshAsync(EncodedKey, RefreshToken);
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine("Access Token: " + response.AccessToken);
            Trace.WriteLine("Refresh Token: " + response.RefreshToken);
        }
    }
}