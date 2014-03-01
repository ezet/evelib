using System.Linq;
using eZet.Eve.EveLib.Entity.EveMarketData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {
    [TestClass]
    public class EveMarketData_Tests {

        public EveMarketData Api = EveLib.Create().EveMarketData;
        
        public MarketDataOptions Options = new MarketDataOptions();

        public long RegionId = 10000002;
        public long TypeId = 34;

        public EveMarketData_Tests() {
            Options.Items.Add(TypeId);
            Options.Regions.Add(RegionId);
            Options.DayLimit = 1;
        }

        [TestMethod]
        public void GetRecentUploads_ValidRequest_ValidResponse() {
            var res = Api.GetRecentUploads(Options, UploadType.Orders);
            var entry = res.Result.Uploads.First();
            Assert.AreEqual(UploadType.Orders, entry.UploadType);
            Assert.AreEqual(TypeId, res.Result.Uploads.First().TypeId);
            Assert.AreEqual(RegionId, res.Result.Uploads.First().RegionId);
            Assert.AreNotEqual("", entry.UploadType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetItemHistory_ValidRequest_ValidResponse() {
            var res = Api.GetItemHistory(Options);
            var entry = res.Result.History.First();
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.AvgPrice);
            Assert.AreNotEqual(0, entry.MaxPrice);
            Assert.AreNotEqual(0, entry.MinPrice);
            Assert.AreNotEqual(0, entry.Orders);
            Assert.AreNotEqual(0, entry.Volume);
            Assert.AreNotEqual("", entry.Date);
        }

        [TestMethod]
        public void GetItemPrice_ValidRequest_ValidResponse() {
            var res = Api.GetItemPrice(Options, OrderType.Buy, MinMax.Min);
            var entry = res.Result.Prices.First();
            Assert.AreEqual(OrderType.Buy, entry.OrderType);
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.Price);
            Assert.AreNotEqual("", entry.OrderType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetItemOrders_ValidRequest_ValidResponse() {
            var res = Api.GetItemOrders(Options, OrderType.Buy);
            var entry = res.Result.Orders.First();
            Assert.AreEqual(OrderType.Buy, entry.OrderType);
            Assert.AreNotEqual(0, entry.OrderId);
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.StationId);
            Assert.AreNotEqual(0, entry.SolarSystemId);
            Assert.AreNotEqual(0, entry.Price);
            Assert.AreNotEqual(0, entry.VolEntered);
            Assert.AreNotEqual(0, entry.VolRemaining);
            Assert.AreNotEqual(0, entry.MinVolume);
            Assert.AreNotEqual("", entry.IssuedDate);
            Assert.AreNotEqual("", entry.ExpiresDate);
            Assert.AreNotEqual("", entry.CreatedDate);
        }

        [TestMethod]
        public void GetStationRank_ValidRequest_ValidResult() {
            var res = Api.GetStationRank(Options);
            var entry = res.Result.Stations.First();
            Assert.AreNotEqual(0, entry.StationId);
            Assert.AreNotEqual("", entry.Date);
            Assert.AreNotEqual(0, entry.RankByOrders);
            Assert.AreNotEqual(0, entry.RankByPrice);
            //Assert.AreNotEqual(0, entry.SellOrders);
            //Assert.AreNotEqual(0, entry.BuyOrders);
            //Assert.AreNotEqual(0, entry.SellTotal);
            //Assert.AreNotEqual(0, entry.BuyTotal);
            //Assert.AreNotEqual(0, entry.AvgSellPrice);
            //Assert.AreNotEqual(0, entry.AvgBuyPrice);
        }

    }
}
