using System.Linq;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Element43_Tests {
            private const long RegionId = 10000002;
        private const long TypeId = 34;
        private readonly Element43 api;
        private readonly Element43Options validOptions;

        public Element43_Tests() {
            api = new Element43();
            validOptions = new Element43Options();
            validOptions.Items.Add(TypeId);
            validOptions.Region = RegionId;
        }

        [TestMethod]
        public void GetMarketStat_ValidRequest_ValidResponse() {
            Element43MarketStatResponse res = api.GetMarketStat(validOptions);
            var entry = res.Result.First();
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreNotEqual(0, entry.SellOrders.Average);
            Assert.AreNotEqual(0, entry.SellOrders.Volume);
            Assert.AreNotEqual(0, entry.SellOrders.Max);
            Assert.AreNotEqual(0, entry.SellOrders.Min);
            Assert.AreNotEqual(0, entry.SellOrders.StdDev);
            Assert.AreNotEqual(0, entry.SellOrders.Median);
            Assert.AreNotEqual(0, entry.SellOrders.Percentile);
            Assert.AreNotEqual(0, entry.LastUpdate);
            Assert.AreNotEqual(0, entry.VolumeLastWeek);
        }
    }
}
