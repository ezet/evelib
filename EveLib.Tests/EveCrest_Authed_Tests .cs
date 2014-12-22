using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedVariable
namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Authed_Tests {
        private const int AllianceId = 99000006;

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        private const string Killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";

        private const string RefreshToken = "ldF1J8ny_fEjLKyyG4yixGjU8Hi4XCA-5cAdDCzlzNw1";

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
        public void CollectionPaging_Automatic() {
            var result = crest.GetRoot().Query(r => r.Alliances).Query(r => r.Where(f => f.Name.Contains("ff")));
            Debug.WriteLine(result);
        }

        [TestMethod]
        public void CollectionPaging_Manual() {
            var allianceLinks = crest.GetRoot().Query(r => r.Alliances);
            var alliance = allianceLinks.Items.SingleOrDefault(f => f.Id == 99000738);
            while (alliance == null && allianceLinks.Next != null) {
                allianceLinks = allianceLinks.Query(f => f.Next);
                alliance = allianceLinks.Items.SingleOrDefault(f => f.Id == 99000738);
            }
            Debug.WriteLine(allianceLinks.Query(f => alliance).Name);
        }

        [TestMethod]
        public void CollectionPaging_Manual_NullReference() {
            var allianceLinks = crest.GetRoot().Query(r => r.Alliances);
            var alliance = allianceLinks.Items.SingleOrDefault(f => f.Id == 99000738);
            alliance = null;
            allianceLinks.Query(f => alliance);
        }

        [TestMethod]
        public async Task RefreshAccessTokenAsync() {
            crest.RefreshToken = RefreshToken;
            crest.EncodedKey = EncodedKey;
            await crest.RefreshAccessTokenAsync();
        }

        [TestMethod]
        public void GetRoot() {
            CrestRoot root = crest.GetRoot();
            Assert.AreEqual(EveCrest.DefaultAuthHost, root.CrestEndpoint.Uri);
        }

        [TestMethod]
        public void GetKillmail_NoErrors() {
            Killmail data = crest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void Motd() {
            Assert.IsNotNull(crest.GetRoot().Motd.Eve.Uri);
        }

        [TestMethod]
        public async Task CrestEndpoint() {
            var result = await crest.GetRootAsync();
        }

        [TestMethod]
        public async Task CorporationRoles() {
            var response = await crest.GetRoot().QueryAsync(r => r.CorporationRoles);
        }

        [TestMethod]
        public async Task ItemGroups() {
            var response = await crest.GetRoot().QueryAsync(r => r.ItemGroups);
        }

        [TestMethod]
        public async Task Channels() {
            var response = await crest.GetRoot().QueryAsync(r => r.Channels);
        }

        [TestMethod]
        public async Task Corporations() {
            var response = await crest.GetRoot().QueryAsync(r => r.Corporations);
        }

        [TestMethod]
        public async Task Alliances() {
            var response = await crest.GetRoot().QueryAsync(r => r.Alliances);
        }

        [TestMethod]
        public async Task ItemTypes() {
            var response = await crest.GetRoot().QueryAsync(r => r.ItemTypes);
            var types = crest.GetRoot().Query(r => r.MarketTypes);
            var list = types.Items.ToList();
            while (types.Next != null) {
                types = types.Query(t => t.Next);
                list.AddRange(types.Items);
            }
        }

        [TestMethod]
        public async Task Decode() {
            var response = await crest.GetRoot().QueryAsync(r => r.Decode);
            Debug.WriteLine(response.Character);
        }

        [TestMethod]
        public async Task BattleTheatres() {
            var response = await crest.GetRoot().QueryAsync(r => r.BattleTheatres);
        }

        [TestMethod]
        public async Task MarketPrices() {
            var response = await crest.GetRoot().QueryAsync(r => r.MarketPrices);
        }

        [TestMethod]
        public async Task ItemCategories() {
            var response = await crest.GetRoot().QueryAsync(r => r.ItemCategories);
        }

        [TestMethod]
        public async Task Regions() {
            var response = await crest.GetRoot().QueryAsync(r => r.Regions);
        }

        [TestMethod]
        public async Task Bloodlines() {
            var response = await crest.GetRoot().QueryAsync(r => r.Bloodlines);
        }

        [TestMethod]
        public async Task MarketGroups() {
            var response = await crest.GetRoot().QueryAsync(r => r.MarketGroups);
        }

        [TestMethod]
        public async Task Tournaments() {
            var response = await crest.GetRoot().QueryAsync(r => r.Tournaments);
        }

        [TestMethod]
        public void Map() {
            var response = crest.GetRoot().VirtualGoodStore;
        }

        [TestMethod]
        public void VirtualGoodStore() {
            Assert.IsNotNull(crest.GetRoot().VirtualGoodStore);
        }

        [TestMethod]
        public void ServerVersion() {
            Assert.IsNotNull(crest.GetRoot().ServerVersion);
        }

        [TestMethod]
        public async Task Wars() {
            var response = await crest.GetRoot().QueryAsync(r => r.Wars);
        }

        [TestMethod]
        public async Task Incursions() {
            var response = await crest.GetRoot().QueryAsync(r => r.Incursions);
        }

        [TestMethod]
        public async Task Races() {
            var response = await crest.GetRoot().QueryAsync(r => r.Races);
        }

        [TestMethod]
        public void AuthEndpoints() {
            Assert.AreEqual("https://login-tq.eveonline.com/oauth/token/", crest.GetRoot().AuthEndpoint.Uri);
        }

        [TestMethod]
        public void ServiceStatis() {
            var status = crest.GetRoot().ServiceStatus;
            Assert.AreEqual(CrestRoot.ServiceStatusType.Online, status.Dust);
            Assert.AreEqual(CrestRoot.ServiceStatusType.Online, status.Eve);
            Assert.AreEqual(CrestRoot.ServiceStatusType.Online, status.Server);
        }

        [TestMethod]
        public void UserCounts() {
            var counts = crest.GetRoot().UserCounts;
            Assert.AreNotEqual(0, counts.Dust);
            Assert.AreNotEqual(0, counts.Eve);
        }

        [TestMethod]
        public async Task IndustryFacilities() {
            var response = await crest.GetRoot().QueryAsync(r => r.Industry.Facilities);
        }

        [TestMethod]
        public async Task IndustrySpecialities() {
            var response = await crest.GetRoot().QueryAsync(r => r.Industry.Specialities);
        }

        [TestMethod]
        public async Task IndustryTeamsInAuction() {
            var response = await crest.GetRoot().QueryAsync(r => r.Industry.TeamsInAuction);
        }

        [TestMethod]
        public async Task IndustrySystems() {
            var response = await crest.GetRoot().QueryAsync(r => r.Industry.Systems);
        }

        [TestMethod]
        public async Task IndustryTeams() {
            var response = await crest.GetRoot().QueryAsync(r => r.Industry.Teams);
        }

        [TestMethod]
        public async Task Clients() {
            var eve = await crest.GetRoot().QueryAsync(r => r.Clients.Eve);
            var dust = await crest.GetRoot().QueryAsync(r => r.Clients.Dust);
        }

        [TestMethod]
        public async Task Time() {
            var response = await crest.GetRoot().QueryAsync(r => r.Time);
        }


        [TestMethod]
        public async Task MarketTypes() {
            var response = await crest.GetRoot().QueryAsync(r => r.MarketTypes);
        }

        [TestMethod]
        public void ServerName() {
            Assert.AreEqual("TRANQUILITY", crest.GetRoot().ServerName);
        }

        [TestMethod]
        public async Task GetMarketHistory_NoErrors() {
            MarketHistoryCollection data = await crest.GetMarketHistoryAsync(RegionId, TypeId);
        }

        [TestMethod]
        public async Task GetMarketPrices() {
            MarketTypePriceCollection result = await crest.GetMarketPricesAsync();
            Console.WriteLine(result.Items.Count);
        }



        [TestMethod]
        public async Task GetWar_NoErrors() {
            War data = await crest.GetWarAsync(291410);
            var image = crest.LoadImage(data.Aggressor.Icon);
            Debug.WriteLine(image);
        }

        [TestMethod]
        public async Task GetWarKillmails_NoErrors() {
            KillmailCollection data = await crest.GetWarKillmailsAsync(1);
        }

        [TestMethod]
        [ExpectedException(typeof(EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            War data = await crest.GetWarAsync(999999999);
        }

    }
}