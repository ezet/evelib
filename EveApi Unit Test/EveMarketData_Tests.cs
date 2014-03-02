using System;
using System.Linq;
using eZet.Eve.EveLib.Entity.EveMarketData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {
    [TestClass]
    public class EveMarketData_Tests {

        private readonly EveMarketData api;

        private readonly EveMarketDataOptions validOptions;

        private readonly EveMarketDataOptions invalidOptions;

        private const long RegionId = 10000002;
        
        private const long TypeId = 34;

        public EveMarketData_Tests() {
            api = EveLib.Create().EveMarketData;
            validOptions = new EveMarketDataOptions();
            validOptions.Items.Add(TypeId);
            validOptions.Regions.Add(RegionId);
            validOptions.AgeSpan = TimeSpan.FromDays(5);
            invalidOptions = new EveMarketDataOptions();
        }

        [TestMethod]
        public void GetRecentUploads_ValidRequest_ValidResponse() {
            var res = api.GetRecentUploads(validOptions, UploadType.Orders);
            var entry = res.Result.Uploads.First();
            Assert.AreEqual(UploadType.Orders, entry.UploadType);
            Assert.AreEqual(TypeId, res.Result.Uploads.First().TypeId);
            Assert.AreEqual(RegionId, res.Result.Uploads.First().RegionId);
            Assert.AreNotEqual("", entry.UploadType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetRecentUploads_NoOptions_NoException() {
            var res = api.GetRecentUploads(invalidOptions, UploadType.Orders);
        }

        [TestMethod]
        public void GetItemPrice_ValidRequest_ValidResponse() {
            var res = api.GetItemPrice(validOptions, OrderType.Buy, MinMax.Min);
            var entry = res.Result.Prices.First();
            Assert.AreEqual(OrderType.Buy, entry.OrderType);
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.Price);
            Assert.AreNotEqual("", entry.OrderType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetItemPrice_NoOptions_NoException() {
            var res = api.GetItemPrice(invalidOptions, OrderType.Buy, MinMax.Min);
        }

        [TestMethod]
        public void GetItemOrders_ValidRequest_ValidResponse() {
            var res = api.GetItemOrders(validOptions, OrderType.Buy);
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
        public void GetItemOrders_NoOptions_NoException() {
            var res = api.GetItemOrders(invalidOptions, OrderType.Buy);
        }

        [TestMethod]
        public void GetItemHistory_ValidRequest_ValidResponse() {
            var res = api.GetItemHistory(validOptions);
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
        [ExpectedException(typeof(ArgumentException))]
        public void GetItemHistory_InvalidRequest_ArgumentException() {
            var res = api.GetItemHistory(invalidOptions);
        }

        [TestMethod]
        public void GetStationRank_ValidRequest_ValidResult() {
            var res = api.GetStationRank(validOptions);
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStationRank_InvalidRequest_ArgumentException() {
            var res = api.GetStationRank(invalidOptions);
        }

    }
}
