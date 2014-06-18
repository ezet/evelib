using System.Linq;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Element43Legacy_Tests {
        private const int RegionId = 10000002;
        private const int TypeId = 34;
        private readonly Element43Legacy _api;
        private readonly Element43Options _validOptions;

        public Element43Legacy_Tests() {
            _api = new Element43Legacy();
            _validOptions = new Element43Options();
            _validOptions.Items.Add(TypeId);
            _validOptions.Region = RegionId;
        }

        [TestMethod]
        public void GetMarketStat_ValidRequest_ValidResponse() {
            Element43MarketStatResponse res = _api.GetMarketStat(_validOptions);
            Element43MarketStatItem entry = res.Result.First();
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