using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Exceptions;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Resources.Industry;
using eZet.EveLib.EveCrestModule.Models.Resources.Market;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {

    [TestClass]
    public class EveCrest_Public_Tests {

        private const int AllianceId = 434243723; // C C P Alliance

        private const int RegionId = 10000002; // The Forge 

        private const int TypeId = 34; // Tritanium

        private const string Killmail = "30290604/787fb3714062f1700560d4a83ce32c67640b1797";

        private readonly EveCrest crest = new EveCrest();

        public EveCrest_Public_Tests() {
            crest.EnableAutomaticTokenRefresh = true;
            crest.RequestHandler.ThrowOnDeprecated = true;
        }

        [TestMethod]
        public void GetRoot() {
            var root = crest.GetRoot();
        }

        [TestMethod]
        public void GetNext() {
            var root = crest.GetRoot();
            var items = root.Query(r => r.ItemTypes);
            items.Query(i => i.Next);
        }

        [TestMethod]
        public void GetRegions() {
            var root = crest.GetRoot();
            var regions = root.Query(r => r.Regions);
            var region = regions.Items.First();
            Assert.AreNotEqual(0, region);
            Assert.AreNotEqual("", region.Name);
            Assert.AreNotEqual("", region.Href);
        }

        [TestMethod]
        public void GetRegion() {
            var root = crest.GetRoot();
            var region = root.Query(r => r.Regions).Query(r => r.Items.First());
            Assert.AreNotEqual(0, region.Id);
            Assert.AreNotEqual("", region.Name);
            Assert.AreNotEqual(0, region.Constellations.Count);
            Assert.AreNotEqual("", region.MarketBuyOrders);
            Assert.AreNotEqual("", region.MarketSellOrders);

        }

        [TestMethod]
        public void GetKillmail_NoErrors() {
            Killmail data = crest.GetKillmail(28694894, "3d9702696cf8e75d6168734ad26a772e17efc9ba");
            Assert.AreEqual(30000131, data.SolarSystem.Id);
            Assert.AreEqual(99000652, data.Victim.Alliance.Id);
        }

        [TestMethod]
        public void GetIncursions_NoErrors() {
            IncursionCollection incursionCollection = crest.GetRoot().Query(r => r.Incursions);
        }

        [TestMethod]
        public void GetAlliances_NoErrors() {
            AllianceCollection response = crest.GetRoot().Query(r => r.Alliances);
            Console.WriteLine(response);
        }

        [TestMethod]
        public void GetAlliance_NoErrors() {
            AllianceCollection allianceCollection = crest.GetRoot().Query(r => r.Alliances);
            //var all = AllianceCollectionV1.Query(f => f.Single(a => a.Id == AllianceId));
            //var alliance = AllianceCollectionV1.AllItems().Where(f => f.Id == AllianceId);
            //Console.WriteLine(alliance.First().Alliance.Name);
        }

        //[TestMethod]
        //public void CollectionPaging_Manual() {
        //    AllianceCollectionV1 allianceLinks = crest.GetRoot().Query(r => r.Alliances);
        //    AllianceCollectionV1.Alliance alliance =
        //        allianceLinks.Items.SingleOrDefault(f => f.Alliance.Id == AllianceId).Alliance;
        //    while (alliance == null && allianceLinks.Next != null) {
        //        allianceLinks = allianceLinks.Query(f => f.Next);
        //        alliance =
        //        allianceLinks.Items.SingleOrDefault(f => f.Alliance.Id == AllianceId).Alliance;
        //    }
        //    Debug.WriteLine(allianceLinks.Query(f => alliance).Name);
        //}


        [TestMethod]
        public void GetMarketHistory_NoErrors() {
            MarketHistoryCollection data = crest.GetMarketHistory(RegionId, TypeId);
        }

        [TestMethod]
        public async Task GetMarketPrices() {
            MarketTypePriceCollection result = await crest.GetMarketPricesAsync();
            Console.WriteLine(result.Items.Count);
        }

        [TestMethod]
        public void GetWars_NoErrors() {
            WarCollection data = crest.GetWars();
        }

        [TestMethod]
        public void GetWar_NoErrors() {
            var warCollection = crest.GetRoot().Query(r => r.Wars);
            var data = warCollection.Query(f => f.Single(w => w.Id == 291410));
            Debug.WriteLine(data.Id);
        }

        [TestMethod]
        public void GetWarKillmails_NoErrors() {
            KillmailCollection data = crest.GetWarKillmails(1);
        }

        [TestMethod]
        [ExpectedException(typeof(EveCrestException))]
        public async Task GetWar_InvalidId_EveCrestException() {
            War data = await crest.GetWarAsync(999999999);
        }

        [TestMethod]
        // TODO Test this properly
        public async Task GetIndustrySystemsAsync() {
            IndustrySystemCollection result = await crest.GetIndustrySystemsAsync();
            Console.Write(result);
        }

        [TestMethod]
        // TODO Test this properly
        public async Task GetIndustryFacilities() {
            IndustryFacilityCollection result = await crest.GetIndustryFacilitiesAsync();
        }

        [TestMethod]
        public async Task ItemGroups() {
            ItemGroupCollection itemGroups = await crest.GetRoot().QueryAsync(r => r.ItemGroups);
            var group = itemGroups.Query(f => f.Single(g => g.Id == 354753));
            Console.WriteLine(group.Name);
        }

        [TestMethod]
        public async Task MarketGroups() {
            var result = await crest.GetRoot().QueryAsync(r => r.MarketGroups);
            var first = result.Items.First();
            Assert.IsNotNull(first.Types);
            Assert.IsNotNull(first.Description);
            testLinkedEntity(first);
        }

        [TestMethod]
        public async Task MarketTypes() {
            var result =
                await crest.GetRoot().QueryAsync(r => r.MarketTypes);
            var item = result.Items.First();
            Assert.IsNotNull(item.MarketGroup);
            Assert.IsNotNull(item.Type);
            testLinkedEntity(item.Type);
            testLinkedEntity(item.MarketGroup);
        }



        //[TestMethod]
        //public void ThreadTest() {
        //    var ec = new EveCrest {EnableRootCache = false};
        //    var allregions = ec.GetRoot().Query(r => r.Regions);
        //    foreach (var item in allregions.AllItems()) {
        //        var regionHref = item.Href;
        //        new Thread(() => {
        //            Console.WriteLine("Starting Thread");
        //            eZet.EveLib.EveCrestModule.EveCrest ecT = new eZet.EveLib.EveCrestModule.EveCrest();
        //            ecT.EnableRootCache = false;

        //            //ERROR spawning here
        //            var region = ecT.Load(regionHref, new string[] {});
        //            foreach (var cons in region.Constellations) {
        //                var constellation = ecT.Load<eZet.EveLib.EveCrestModule.Models.Resources.Constellation>(
        //                    cons.Uri, new string[] {});
        //                foreach (var sys in constellation.Systems) {
        //                    var system = ecT.Load<eZet.EveLib.EveCrestModule.Models.Resources.SolarSystem>(sys.Uri,
        //                        new string[] {});
        //                    foreach (var pl in system.Planets) {
        //                        var planet = ecT.Load<eZet.EveLib.EveCrestModule.Models.Resources.Planet>(pl.Uri,
        //                            new string[] {});
        //                    }
        //                }
        //            }
        //        }).Start();
        //    }
        //}


        [TestMethod]
        public async Task GetSovereigntyStructures() {
            var response = await crest.GetRoot().QueryAsync(r => r.Sovereignty.Structures);

        }

        [TestMethod]
        public async Task GetSovereigntyCampaigns() {
            var response = await crest.GetRoot().QueryAsync(r => r.Sovereignty.Campaigns);
        }

        [TestMethod]
        public async Task GetItemTypes() {
            var response = await crest.GetRoot().QueryAsync(r => r.ItemTypes);
            Assert.AreNotEqual(0, response.Items.Count);
            testLinkedEntity(response.Items.First());
        }

        [TestMethod]
        public async Task GetItemType() {
            var response = await crest.GetRoot().QueryAsync(r => r.ItemTypes);
            var type = response.Query(r => r.Items.Single(t => t.Id == 200));
            Assert.IsNotNull(type.GraphicId);
            Assert.AreNotEqual(0, type.Dogma.Attributes.Count);
            Assert.IsNotNull(type.Dogma.Attributes.First());
            Assert.IsNotNull(type.Dogma.Effects.First());
            Assert.AreNotEqual(0, type.Dogma.Effects.Count);
            testLinkedEntity(type.Dogma.Attributes.First().Attribute);
            testLinkedEntity(type.Dogma.Effects.First().Effect);
        }

        [TestMethod]
        public async Task GetConstellations() {
            var response = await crest.GetRoot().QueryAsync(r => r.Constellations);
            Assert.AreNotEqual(0, response.Items.Count);
            testLinkedEntity(response.Items.First());
        }



        [TestMethod]
        public async Task GetSystems() {
            var response = await crest.GetRoot().QueryAsync(r => r.Systems);
            Assert.AreNotEqual(0, response.Items.Count);
            testLinkedEntity(response.Items.First());
        }

        [TestMethod]
        public async Task GetDogmaAttributes() {
            var response = await crest.GetRoot().QueryAsync(r => r.Dogma.Attributes);
            Assert.AreNotEqual(0, response.Items.Count);
            var item = response.Items.First();
            testLinkedEntity(item);
        }

        [TestMethod]
        public async Task GetDogmaAttribute() {
            var item =
                await (await (crest.GetRoot().QueryAsync(r => r.Dogma.Attributes))).QueryAsync(r => r.Items.First());
            Assert.IsNotNull(item.DisplayName);
            Assert.IsNotNull(item.Description);
        }

        [TestMethod]
        public async Task GetDogmaEffects() {
            var response = await crest.GetRoot().QueryAsync(r => r.Dogma.Effects);
            Assert.AreNotEqual(0, response.Items.Count);
            var item = response.Items.First();
            testLinkedEntity(item);
        }

        [TestMethod]
        public async Task GetDogmaEffect() {
            var item =
                await (await (crest.GetRoot().QueryAsync(r => r.Dogma.Effects))).QueryAsync(r => r.Items.First());
            Assert.IsNotNull(item.Description);
        }

        [TestMethod]
        public async Task GetBuyOrderWith() {
            var orders =
                (await
                    (await
                        (await crest.GetRootAsync())
                    .QueryAsync(r => r.Regions))
                .QueryAsync(x => x.Single(r => r.Name == "The Forge")))
                .Query(r => r.MarketBuyOrders, "type",
                            "https://public-crest.eveonline.com/types/34/");
        }

        private static void testLinkedEntity<T>(ILinkedEntity<T> entity) {
            Assert.AreNotEqual(0, entity.Id);
            Assert.IsNotNull(entity.Href);
            Assert.IsNotNull(entity.Name);
        }
    }
}
