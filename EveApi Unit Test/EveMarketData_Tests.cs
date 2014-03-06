using System;
using System.Linq;
using eZet.EveLib.EveMarketDataLib;
using eZet.EveLib.EveMarketDataLib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {
    [TestClass]
    public class EveMarketData_Tests {
        private const long RegionId = 10000002;

        private const long TypeId = 34;
        private readonly EveMarketData api;
        private readonly EveMarketDataOptions invalidOptions;
        private readonly EveMarketDataOptions validOptions;

        public EveMarketData_Tests() {
            api = new EveMarketData();
            validOptions = new EveMarketDataOptions();
            validOptions.Items.Add(TypeId);
            validOptions.Regions.Add(RegionId);
            validOptions.AgeSpan = TimeSpan.FromDays(5);
            invalidOptions = new EveMarketDataOptions();
        }

        [TestMethod]
        public void GetRecentUploads_ValidRequest_ValidResponse() {
            EveMarketDataResponse<RecentUploads> res = api.GetRecentUploads(validOptions, UploadType.Orders);
            RecentUploads.RecentUploadsEntry entry = res.Result.Uploads.First();
            Assert.AreEqual(UploadType.Orders, entry.UploadType);
            Assert.AreEqual(TypeId, res.Result.Uploads.First().TypeId);
            Assert.AreEqual(RegionId, res.Result.Uploads.First().RegionId);
            Assert.AreNotEqual("", entry.UploadType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetRecentUploads_NoOptions_NoException() {
            EveMarketDataResponse<RecentUploads> res = api.GetRecentUploads(invalidOptions, UploadType.Orders);
        }

        [TestMethod]
        public void GetItemPrice_ValidRequest_ValidResponse() {
            EveMarketDataResponse<ItemPrices> res = api.GetItemPrice(validOptions, OrderType.Buy, MinMax.Min);
            ItemPrices.ItemPriceEntry entry = res.Result.Prices.First();
            Assert.AreEqual(OrderType.Buy, entry.OrderType);
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.Price);
            Assert.AreNotEqual("", entry.OrderType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetItemPrice_NoOptions_NoException() {
            EveMarketDataResponse<ItemPrices> res = api.GetItemPrice(invalidOptions, OrderType.Buy, MinMax.Min);
        }

        [TestMethod]
        public void GetItemOrders_ValidRequest_ValidResponse() {
            EveMarketDataResponse<ItemOrders> res = api.GetItemOrders(validOptions, OrderType.Buy);
            ItemOrders.ItemOrderEntry entry = res.Result.Orders.First();
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
            EveMarketDataResponse<ItemOrders> res = api.GetItemOrders(invalidOptions, OrderType.Buy);
        }

        [TestMethod]
        public void GetItemHistory_ValidRequest_ValidResponse() {
            EveMarketDataResponse<ItemHistory> res = api.GetItemHistory(validOptions);
            ItemHistory.ItemHistoryEntry entry = res.Result.History.First();
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
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void GetItemHistory_InvalidArgument_ContractException() {
            EveMarketDataResponse<ItemHistory> res = api.GetItemHistory(invalidOptions);
        }

        [TestMethod]
        public void GetStationRank_ValidRequest_ValidResponse() {
            EveMarketDataResponse<StationRank> res = api.GetStationRank(validOptions);
            StationRank.StationRankEntry entry = res.Result.Stations.First();
            Assert.AreNotEqual(0, entry.StationId);
            Assert.AreNotEqual("", entry.Date);
            Assert.AreNotEqual(0, entry.RankByOrders);
            Assert.AreNotEqual(0, entry.RankByPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void GetStationRank_InvalidArgument_ContractException() {
            EveMarketDataResponse<StationRank> res = api.GetStationRank(invalidOptions);
        }

    }
}