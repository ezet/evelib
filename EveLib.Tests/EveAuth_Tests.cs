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

        private const string AuthCode = "uYwgSc5HI6-qljlloAoK8IbEdBcplEuWaOw1nlOEwY5dgdHyp7H7oRXQyeifN-0s0";

        private const string RefreshToken = "w_FqWliGJYDmPBycG2GtwYyizqMK-wQw6yuBfQf2r05bwG-BJgCM3HcdzUDFc2-N23sv-VGmWCgVttWpcOLq6w2";
        private readonly EveAuth _eveAuth = new EveAuth();

        private readonly string encodedKeySingularity =
            "Y2VmZTYwMWQ5ZjVhNDQ0MTgzZjhjNzMyNjc2NzA5ZmI6R3dnM0pOVDhWMERMWndiN1ptUmtlOXpKRFlwMWVQblVtOVY1enZqWQ==";

        private readonly string refreshTokenSingularity =
            "UHtPutexwinz1u6xWC5S2Dj39GTDLgnLgUTQSyTvM1nTryMU7NbsmKWL9I32vTPd0";

        [TestMethod]
        public void GetAuthorizationLink() {
            var response = _eveAuth.CreateAuthLink(ClientId, "/", "default", EveAuth.AllCrestScopes);
            Trace.WriteLine(response);
        }

        [TestMethod]
        public async Task Authenticate() {
            var response = await _eveAuth.AuthenticateAsync(EncodedKey, AuthCode);
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine("Access Token: " + response.AccessToken);
            Trace.WriteLine("Refresh Token: " + response.RefreshToken);
        }

        [TestMethod]
        public async Task Refresh() {
            var response = await _eveAuth.RefreshAsync(EncodedKey, RefreshToken);
            Assert.AreEqual("Bearer", response.TokenType);
            Trace.WriteLine("Access Token: " + response.AccessToken);
            Trace.WriteLine("Refresh Token: " + response.RefreshToken);
        }

        [TestMethod]
        public async Task Verify() {
            //_eveAuth.Host = "sisilogin.testeveonline.com";
            var result = await _eveAuth.RefreshAsync(EncodedKey, RefreshToken);
            var response = await _eveAuth.VerifyAsync(result.AccessToken);
        }
    }
}