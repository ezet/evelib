using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.EveCrestModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedVariable

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Authed_Tests {
        private const int AllianceId = 99000006;

        private const string RefreshToken =
            "w_FqWliGJYDmPBycG2GtwYyizqMK-wQw6yuBfQf2r05bwG-BJgCM3HcdzUDFc2-N23sv-VGmWCgVttWpcOLq6w2";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private readonly EveCrest crest = new EveCrest(RefreshToken, EncodedKey);

        public EveCrest_Authed_Tests() {
            //crest.AccessToken =
            //    "Aa-88YrDtEQiu7_QIqZuDCluw6W-VbeUjvbt4ULYMqZzB4VHUwOh8KCUwMxDchkQVdeiCTCsYtlP2GspTr3xqw2";
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            crest.RequestHandler.ThrowOnDeprecated = true;
            crest.RequestHandler.ThrowOnMissingContentType = true;
            crest.EnableAutomaticPaging = true;
            crest.RequestHandler.CacheLevel = CacheLevel.BypassCache;
        }

        [TestMethod]
        public async Task RefreshAccessToken() {
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            await crest.RefreshAccessTokenAsync();
        }

        [TestMethod]
        public async Task GetRoot() {
            var root = await crest.GetRootAsync();
            Assert.AreEqual(EveCrest.DefaultHost, root.CrestEndpoint.Uri);
        }

        [TestMethod]
        public async Task GetOptions() {
            var root = await crest.GetRootAsync();

            var options = crest.QueryOptions(root);

            Assert.IsTrue(options.Representations.Any());
            var first = options.Representations.First();
            Assert.IsNotNull(first.AcceptType);
            Assert.IsNotNull(first.Verb);
            Assert.AreNotEqual(0, first.Version);
            Assert.IsNotNull(first.AcceptType.jsonDumpOfStructure);
            Assert.IsNotNull(first.AcceptType.Name);

        }

        [TestMethod]
        public async Task GetHead() {
            var root = await crest.GetRootAsync();
            var head = await crest.QueryHeadAsync(root.Alliances);
        }

        [TestMethod]
        public async Task GetCharacterStats() {
            var response = await crest.GetCharacterStats(157924121);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task AddAutopilotWaypoint() {
            var c = await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character);
            var wp = c.Waypoints.Create();
            var system = crest.GetRoot().Query(r => r.Systems).Items.Single(s => s.Name == "Jita");
            wp.SolarSystem = system;
            wp.First = true;
            wp.ClearOtherWaypoints = true;
            Assert.IsTrue(await wp.SaveAsync());
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
            Console.WriteLine(first.ContactType);
        }

        [TestMethod]
        public async Task AddCharacterContact() {
            var character =
     (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character));
            var contact = character.Contacts.Create();
            contact.Contact.Href = "https://crest-tq.eveonline.com/characters/157924121/";
            contact.Watched = false;
            contact.Standing = 0;
            Assert.IsTrue(await contact.SaveAsync());
        }

        [TestMethod]
        public async Task UpdateCharacterContact() {
            var contacts =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Contacts);
            var contact = contacts.Items.Single(r => r.Contact.Id == 157924121);
            contact.Standing = 10;
            Assert.IsTrue(await contact.SaveAsync());
        }

        [TestMethod]
        public async Task DeleteCharacterContact() {
            var contacts =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Contacts);
            var contact = contacts.Items.First();
            Assert.IsTrue(await contact.DeleteAsync());
            contact.Save(true);
        }

        [TestMethod]
        public async Task AddCorporationContact() {
            var character =
                (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character));
            var contact = character.Contacts.Create();
            contact.Contact.Href = "https://crest-tq.eveonline.com/alliances/99000006/";
            contact.Standing = 10;
            Assert.IsTrue(await contact.SaveAsync());
            Assert.AreEqual("https://crest-tq.eveonline.com/characters/157924121/contacts/99000006/", contact.PostUri);
        }



        [TestMethod]
        public async Task UpdateCorpprationContact() {
            var contacts =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Contacts);
            var contact = contacts.Items.First();
            contact.Standing = 10;
            Assert.IsTrue(await contact.SaveAsync());
        }

        [TestMethod]
        public async Task DeleteCorporationContact() {
            var contacts =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Contacts);
            var contact = contacts.Items.First();
            Assert.IsTrue(await contact.DeleteAsync());
            contact.Save(true);
        }

        [TestMethod]
        public async Task GetFittings() {
            var fittings =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Fittings);
            Assert.IsTrue(fittings.Items.Count > 0);
            var fit = fittings.Items.First();
            Assert.IsNotNull(fit.Name);
            Assert.IsNotNull(fit.Description);
            Assert.AreNotEqual(0, fit.FittingId);
            Assert.IsTrue(fit.Items.Count > 0);
            Assert.IsNotNull(fit.Ship);
        }

        [TestMethod]
        public async Task AddFitting() {
            var fit =
            (await
                (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                    .QueryAsync(r => r.Fittings)).Items.First();
            fit.Name = "test123123";
            //fit.PostUri = "https://crest-tq.eveonline.com/characters/157924121/fittings/";
            Assert.IsTrue(await fit.SaveAsync(true));
        }

        [TestMethod]
        public async Task EditFitting() {
            var fittings =
    await
        (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
            .QueryAsync(r => r.Fittings);
            var fit = fittings.Items.First();
            Assert.IsTrue(await fit.DeleteAsync());
            fit.Delete();
            fit.Name = "Test123123";
            var result = await fit.SaveAsync(true);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteFitting() {
            var fittings =
           await
               (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                   .QueryAsync(r => r.Fittings);
            var fit = fittings.Items.Last();
            var result = await fit.DeleteAsync();
            Assert.IsTrue(result);
            fit.Save(true);
        }

        [TestMethod]
        public async Task GetLocation() {
            var location =
                await
                    (await (await (await crest.GetRootAsync()).QueryAsync(r => r.Decode)).QueryAsync(r => r.Character))
                        .QueryAsync(r => r.Location);
            Assert.IsNotNull(location);
        }

        //[TestMethod]
        //public async Task CorporationRoles() {
        //    var response = await crest.GetRoot().QueryAsync(r => r.CorporationRoles);
        //}

        //[TestMethod]
        //public async Task Channels() {
        //    var response = await crest.GetRoot().QueryAsync(r => r.Channels);
        //}

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