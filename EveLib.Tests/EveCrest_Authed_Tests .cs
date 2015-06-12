using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using eZet.EveLib.EveCrestModule.Models.Resources.Tournaments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedVariable

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveCrest_Authed_Tests {
        private const int AllianceId = 99000006;

        private const int RegionId = 10000002; // The Forge

        private const int TypeId = 34; // Tritanium

        private const string Killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";

        private const string RefreshToken = "E9nZjXvx_tFu-PdpTC6yT_j4FupJ-84ybEtNsE8iMko1";

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

        //[TestMethod]
        //public void CollectionPaging_Automatic() {
        //    IEnumerable<Alliance> result =
        //        crest.GetRoot().Query(r => r.Alliances).Query(r => r.Where(f => f.Name == "Brave Collective"));
        //    Debug.WriteLine(result.FirstOrDefault());
        //}

        //[TestMethod]
        //public void CollectionPaging_Manual() {
        //    AllianceCollection allianceLinks = crest.GetRoot().Query(r => r.Alliances);
        //    AllianceCollection.Alliance alliance = allianceLinks.Items.SingleOrDefault(f => f.Id == 99000738);
        //    while (alliance == null && allianceLinks.Next != null) {
        //        allianceLinks = allianceLinks.Query(f => f.Next);
        //        alliance = allianceLinks.Items.SingleOrDefault(f => f.Id == 99000738);
        //    }
        //    Debug.WriteLine(allianceLinks.Query(f => alliance).Name);
        //}

        //[TestMethod]
        //public void CollectionPaging_Manual_NullReference() {
        //    AllianceCollection allianceLinks = crest.GetRoot().Query(r => r.Alliances);
        //    AllianceCollection.Alliance alliance = allianceLinks.Items.SingleOrDefault(f => f.Id == 99000738);
        //    alliance = null;
        //    allianceLinks.Query(f => alliance);
        //}

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
            CrestRoot result = await crest.GetRootAsync();
        }

        [TestMethod]
        public async Task CorporationRoles() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.CorporationRoles);
        }

        [TestMethod]
        public async Task ItemGroups() {
            ItemGroupCollection response = await crest.GetRoot().QueryAsync(r => r.ItemGroups);
        }

        [TestMethod]
        public async Task Channels() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.Channels);
        }

        [TestMethod]
        public async Task Corporations() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.Corporations);
        }

        [TestMethod]
        public async Task Alliances() {
            AllianceCollection response = await crest.GetRoot().QueryAsync(r => r.Alliances);
        }

        [TestMethod]
        public async Task ItemTypes() {
            ItemTypeCollection response = await crest.GetRoot().QueryAsync(r => r.ItemTypes);
            MarketTypeCollection types = crest.GetRoot().Query(r => r.MarketTypes);
            List<MarketTypeCollection.Item> list = types.Items.ToList();
            while (types.Next != null) {
                types = types.Query(t => t.Next);
                list.AddRange(types.Items);
            }
        }

        [TestMethod]
        public async Task Decode() {
            TokenDecode response = await crest.GetRoot().QueryAsync(r => r.Decode);
            Debug.WriteLine(response.Character);
        }

        [TestMethod]
        public async Task BattleTheatres() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.BattleTheatres);
        }

        [TestMethod]
        public async Task MarketPrices() {
            MarketTypePriceCollection response = await crest.GetRoot().QueryAsync(r => r.MarketPrices);
        }

        [TestMethod]
        public async Task ItemCategories() {
            MarketTypePriceCollection response = await crest.GetRoot().QueryAsync(r => r.ItemCategories);
        }

        [TestMethod]
        public async Task Regions() {
            RegionCollection response = await crest.GetRoot().QueryAsync(r => r.Regions);
        }

        [TestMethod]
        public async Task Bloodlines() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.Bloodlines);
        }

        [TestMethod]
        public async Task MarketGroups() {
            MarketGroupCollection response = await crest.GetRoot().QueryAsync(r => r.MarketGroups);
        }

        [TestMethod]
        public async Task Tournaments() {
            TournamentCollection response = await crest.GetRoot().QueryAsync(r => r.Tournaments);
        }

        [TestMethod]
        public void Map() {
            Href<string> response = crest.GetRoot().VirtualGoodStore;
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
            WarCollection response = await crest.GetRoot().QueryAsync(r => r.Wars);
        }

        [TestMethod]
        public async Task Incursions() {
            IncursionCollection response = await crest.GetRoot().QueryAsync(r => r.Incursions);
        }

        [TestMethod]
        public async Task Races() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.Races);
        }

        [TestMethod]
        public void AuthEndpoints() {
            Assert.AreEqual("https://login-tq.eveonline.com/oauth/token/", crest.GetRoot().AuthEndpoint.Uri);
        }

        [TestMethod]
        public void ServiceStatis() {
            CrestRoot.ServerStatus status = crest.GetRoot().ServiceStatus;
            Assert.AreEqual(CrestRoot.ServiceStatusType.Online, status.Dust);
            Assert.AreEqual(CrestRoot.ServiceStatusType.Online, status.Eve);
            Assert.AreEqual(CrestRoot.ServiceStatusType.Online, status.Server);
        }

        [TestMethod]
        public void UserCounts() {
            CrestRoot.UserCount counts = crest.GetRoot().UserCounts;
            Assert.AreNotEqual(0, counts.Dust);
            Assert.AreNotEqual(0, counts.Eve);
        }

        [TestMethod]
        public async Task IndustryFacilities() {
            IndustryFacilityCollection response = await crest.GetRoot().QueryAsync(r => r.Industry.Facilities);
        }

        [TestMethod]
        public async Task IndustrySpecialities() {
            IndustrySpecialityCollection response = await crest.GetRoot().QueryAsync(r => r.Industry.Specialities);
        }

        [TestMethod]
        public async Task IndustryTeamsInAuction() {
            IndustryTeamCollection response = await crest.GetRoot().QueryAsync(r => r.Industry.TeamsInAuction);
        }

        [TestMethod]
        public async Task IndustrySystems() {
            IndustrySystemCollection response = await crest.GetRoot().QueryAsync(r => r.Industry.Systems);
        }

        [TestMethod]
        public async Task IndustryTeams() {
            IndustryTeamCollection response = await crest.GetRoot().QueryAsync(r => r.Industry.Teams);
        }

        [TestMethod]
        public async Task Clients() {
            EveRoot eve = await crest.GetRoot().QueryAsync(r => r.Clients.Eve);
            DustRoot dust = await crest.GetRoot().QueryAsync(r => r.Clients.Dust);
        }

        [TestMethod]
        public async Task Time() {
            NotImplemented response = await crest.GetRoot().QueryAsync(r => r.Time);
        }


        [TestMethod]
        public async Task MarketTypes() {
            MarketTypeCollection response = await crest.GetRoot().QueryAsync(r => r.MarketTypes);
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
            byte[] image = crest.LoadImage(data.Aggressor.Icon);
            Debug.WriteLine(image);
        }

        [TestMethod]
        public async Task GetWarKillmails_NoErrors() {
            KillmailCollection data = await crest.GetWarKillmailsAsync(1);
        }

        [TestMethod]
        [ExpectedException(typeof (EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            War data = await crest.GetWarAsync(999999999);
        }
    }
}