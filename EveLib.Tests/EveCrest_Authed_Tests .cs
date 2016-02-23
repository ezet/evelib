using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedVariable

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Authed_Tests {
        private const int AllianceId = 99000006;

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        private const string Killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";

        private const string RefreshToken =
            "g92QOVphazTOcNhV9hpq22eoo3cK7oBrLOHdBc71cFl76OHZ-3DRAR6bnAn7orMprjJN05pjgWHvCTIWwQ_hVA2";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private readonly EveCrest crest = new EveCrest(RefreshToken, EncodedKey);

        public EveCrest_Authed_Tests() {
            //crest.AccessToken =
            //    "UsIcawIKnTkLBknGg6Tjx-zFkU_XK0LOMWucbKXoaWrHjYtrldb8bZPjEEkj9rueXD97lYkInjg0urr7SbJ1UA2";
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            crest.RequestHandler.ThrowOnDeprecated = true;
            crest.RequestHandler.ThrowOnMissingContentType = true;
            crest.EnableAutomaticPaging = true;
        }

        [TestMethod]
        public async Task RefreshAccessTokenAsync() {
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            await crest.RefreshAccessTokenAsync();
        }

        [TestMethod]
        public void GetRoot() {
            var root = crest.GetRoot();
            Assert.AreEqual(EveCrest.DefaultAuthHost, root.CrestEndpoint.Uri);
        }

        [TestMethod]
        public async Task GetContacts() {
            var contacts =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Contacts);
            Assert.AreNotEqual(0, contacts.Items.Count);
            var first = contacts.Items.First();
            Console.WriteLine(first.Contact.Name);
        }

        [TestMethod]
        public async Task GetFittings() {
            var fittings =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Fittings);
            Console.WriteLine(fittings.Items.First().Name);
        }

        [TestMethod]
        public async Task GetLocation() {
            var location =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Location);
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public async Task CorporationRoles() {
            var response = await crest.GetRoot().QueryAsync(r => r.CorporationRoles);
        }

        [TestMethod]
        public async Task Channels() {
            var response = await crest.GetRoot().QueryAsync(r => r.Channels);
        }

        [TestMethod]
        public async Task Decode() {
            var response = await crest.GetRoot().QueryAsync(r => r.Decode);
            Debug.WriteLine(response.Character);
        }

        [TestMethod]
        public async Task Clients() {
            var eve = await crest.GetRoot().QueryAsync(r => r.Clients.Eve);
            var dust = await crest.GetRoot().QueryAsync(r => r.Clients.Dust);
        }
    }
}