using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Exceptions;
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
            Assert.AreNotEqual(0, first.Id);
        }

        [TestMethod]
        public async Task MarketTypes() {
            var result =
                await crest.GetRoot().QueryAsync(r => r.MarketTypes);
            var item = result.Items.First();
            Assert.IsNotNull(item.MarketGroup);
            Assert.IsNotNull(item.Type);
        }


        [TestMethod]
        public void ThreadTest() {
            EveCrest ec = new EveCrest();
            //ec.EnableRootCache = false;
            var list = new List<Thread>();
            var allregions = ec.GetRoot().Query(r => r.Regions);
            foreach (var regionLink in allregions.AllItems()) {
                list.Add(new Thread(() => {
                    Console.WriteLine("Starting Thread");
                    EveCrest ecT = new EveCrest();
                    //ecT.EnableRootCache = false;

                    //ERROR spawning here
                    var region = ecT.Load(regionLink);
                    foreach (var cons in region.Constellations) {
                        var constellation = ecT.Load(
                            cons);
                        foreach (var sys in constellation.Systems) {
                            var system = ecT.Load(sys);
                            foreach (var pl in system.Planets) {
                                var planet = ecT.Load(pl);
                            }
                        }
                    }
                }));
            }
            foreach (var thread in list) {
                thread.Start();
            }
            foreach (var thread in list)
                thread.Join();
        }

        [TestMethod]
        public void Update() {
            eZet.EveLib.EveCrestModule.EveCrest ec = new eZet.EveLib.EveCrestModule.EveCrest();
            ec.EnableRootCache = false;
            var allregions = ec.GetRoot().Query(r => r.Regions);
            foreach (var item in allregions.AllItems()) {
                eZet.EveLib.EveCrestModule.Models.Links.Href<eZet.EveLib.EveCrestModule.Models.Resources.Region>
                    regionHref = item.Href;
                new Thread(() => {
                    Console.WriteLine("Starting Thread");
                    eZet.EveLib.EveCrestModule.EveCrest ecT = new eZet.EveLib.EveCrestModule.EveCrest();
                    ecT.EnableRootCache = false;

                    //ERROR spawning here
                    var region = ecT.Load(regionHref, new string[] {});
                    foreach (var cons in region.Constellations) {
                        var constellation = ecT.Load<eZet.EveLib.EveCrestModule.Models.Resources.Constellation>(
                            cons.Uri, new string[] {});
                        foreach (var sys in constellation.Systems) {
                            var system = ecT.Load<eZet.EveLib.EveCrestModule.Models.Resources.SolarSystem>(sys.Uri,
                                new string[] {});
                            foreach (var pl in system.Planets) {
                                var planet = ecT.Load<eZet.EveLib.EveCrestModule.Models.Resources.Planet>(pl.Uri,
                                    new string[] {});
                            }
                        }
                    }
                }).Start();
            }
        }


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
            var type = response.Query(r => r.Items.Single(t => t.Id == 200));
            Assert.IsNotNull(type.GraphicId);
            Assert.AreNotEqual(0, type.Dogma.Attributes.Count);
            Assert.AreNotEqual(0, type.Dogma.Effects.Count);
        }

        [TestMethod]
        public async Task GetConstellations() {
            var response = await crest.GetRoot().QueryAsync(r => r.Constellations);
            Assert.AreNotEqual(0, response.Items.Count);
        }



        [TestMethod]
        public async Task GetSystems() {
            var response = await crest.GetRoot().QueryAsync(r => r.Systems);
            Assert.AreNotEqual(0, response.Items.Count);
        }

        [TestMethod]
        public async Task GetDogmaAttributes() {
            var response = await crest.GetRoot().QueryAsync(r => r.Dogma.Attributes);
            Assert.AreNotEqual(0, response.Items.Count);
            var item = response.Items.First();
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual("isOnline", item.Name);
            Assert.AreEqual("https://public-crest.eveonline.com/dogma/attributes/2/", item.Href.ToString());
        }

        [TestMethod]
        public async Task GetDogmaAttribute() {
            var item =
                await (await (crest.GetRoot().QueryAsync(r => r.Dogma.Attributes))).QueryAsync(r => r.Items.First());
            Assert.AreEqual(2, item.Id);
            Assert.AreEqual("", item.DisplayName);
            Assert.AreEqual("isOnline", item.Name);
            Assert.AreEqual(0, item.DefaultValue);
            Assert.AreEqual(false, item.Published);
            Assert.AreEqual(true, item.HighIsGood);
            Assert.AreEqual(true, item.Stackable);
            Assert.AreEqual("Boolean to store status of online effect", item.Description);
        }

        [TestMethod]
        public async Task GetDogmaEffects() {
            var response = await crest.GetRoot().QueryAsync(r => r.Dogma.Effects);
            Assert.AreNotEqual(0, response.Items.Count);
            var item = response.Items.First();
            Assert.AreEqual(4, item.Id);
            Assert.AreEqual("shieldBoosting", item.Name);
            Assert.AreEqual("https://public-crest.eveonline.com/dogma/effects/4/", item.Href.ToString());
        }

        [TestMethod]
        public async Task GetDogmaEffect() {
            var item =
                await (await (crest.GetRoot().QueryAsync(r => r.Dogma.Effects))).QueryAsync(r => r.Items.First());
            Assert.AreEqual(4, item.Id);
            Assert.AreEqual("", item.DisplayName);
            Assert.AreEqual("shieldBoosting", item.Name);
            Assert.AreEqual(false, item.Published);
            Assert.AreEqual(1, item.EffectCategory);
            Assert.AreEqual(131, item.PostExpression);
            Assert.AreEqual(false, item.IsAssistance);
            Assert.AreEqual(false, item.IsOffensive);
            Assert.AreEqual(false, item.DisallowAutoRepeat);
            Assert.AreEqual(true, item.IsWarpSafe);
            Assert.AreEqual(false, item.ElectronicChance);
            Assert.AreEqual(false, item.RangeChange);
            Assert.AreEqual(183, item.PreExpression);
            Assert.AreEqual(6, item.DischargeAttributeId.Id);
            Assert.AreEqual(73, item.DurationAttributeId.Id);
            Assert.AreEqual("", item.Description);
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
    }
}
