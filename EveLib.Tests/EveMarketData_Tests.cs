using System;
using System.Linq;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderType = eZet.EveLib.Modules.OrderType;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveMarketData_Tests {
        private const long RegionId = 10000002;

        private const long TypeId = 34;
        private readonly EveMarketData _api;
        private readonly EveMarketDataOptions _invalidOptions;
        private readonly EveMarketDataOptions _validOptions;

        public EveMarketData_Tests() {
            _api = new EveMarketData();
            _validOptions = new EveMarketDataOptions();
            _validOptions.Items.Add(TypeId);
            _validOptions.Regions.Add(RegionId);
            _validOptions.AgeSpan = TimeSpan.FromDays(5);
            _invalidOptions = new EveMarketDataOptions();
        }

        [TestMethod]
        public void GetRecentUploads_ValidRequest_ValidResponse() {
            EveMarketDataResponse<RecentUploads> res = _api.GetRecentUploads(_validOptions, UploadType.Orders);
            RecentUploads.RecentUploadsEntry entry = res.Result.Uploads.First();
            Assert.AreEqual(UploadType.Orders, entry.UploadType);
            Assert.AreEqual(TypeId, res.Result.Uploads.First().TypeId);
            Assert.AreEqual(RegionId, res.Result.Uploads.First().RegionId);
            Assert.AreNotEqual("", entry.UploadType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetRecentUploads_NoOptions_NoException() {
            EveMarketDataResponse<RecentUploads> res = _api.GetRecentUploads(_invalidOptions, UploadType.Orders);
        }

        [TestMethod]
        public void GetItemPrice_ValidRequest_ValidResponse() {
            EveMarketDataResponse<ItemPrices> res = _api.GetItemPrice(_validOptions, OrderType.Buy, MinMax.Min);
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
            EveMarketDataResponse<ItemPrices> res = _api.GetItemPrice(_invalidOptions, OrderType.Buy, MinMax.Min);
        }

        [TestMethod]
        public void GetItemOrders_ValidRequest_ValidResponse() {
            EveMarketDataResponse<ItemOrders> res = _api.GetItemOrders(_validOptions, OrderType.Buy);
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
            EveMarketDataResponse<ItemOrders> res = _api.GetItemOrders(_invalidOptions, OrderType.Buy);
        }

        [TestMethod]
        public void GetItemHistory_ValidRequest_ValidResponse() {
            EveMarketDataResponse<ItemHistory> res = _api.GetItemHistory(_validOptions);
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
        [ExpectedException(typeof (Exception), AllowDerivedTypes = true)]
        public void GetItemHistory_InvalidArgument_ContractException() {
            EveMarketDataResponse<ItemHistory> res = _api.GetItemHistory(_invalidOptions);
        }

        //[TestMethod]
        public void GetStationRank_ValidRequest_ValidResponse() {
            EveMarketDataResponse<StationRank> res = _api.GetStationRank(_validOptions);
            StationRank.StationRankEntry entry = res.Result.Stations.First();
            Assert.AreNotEqual(0, entry.StationId);
            Assert.AreNotEqual("", entry.Date);
            Assert.AreNotEqual(0, entry.RankByOrders);
            Assert.AreNotEqual(0, entry.RankByPrice);
        }

        [TestMethod]
        [ExpectedException(typeof (Exception), AllowDerivedTypes = true)]
        public void GetStationRank_InvalidArgument_ContractException() {
            EveMarketDataResponse<StationRank> res = _api.GetStationRank(_invalidOptions);
        }
    }
}