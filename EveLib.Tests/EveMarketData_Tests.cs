using System;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderType = eZet.EveLib.Modules.OrderType;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveMarketData_Tests {
        private const int RegionId = 10000002;

        private const int TypeId = 34;
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
            EveMarketDataResponse<EmdRecentUploads> res = _api.GetRecentUploads(_validOptions, UploadType.Orders);
            EmdRecentUploads.RecentUploadsEntry entry = res.Result.Uploads.First();
            Assert.AreEqual(UploadType.Orders, entry.UploadType);
            Assert.AreEqual(TypeId, res.Result.Uploads.First().TypeId);
            Assert.AreEqual(RegionId, res.Result.Uploads.First().RegionId);
            Assert.AreNotEqual("", entry.UploadType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public async Task GetRecentUploadsAsync_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdRecentUploads> res =
                await _api.GetRecentUploadsAsync(_validOptions, UploadType.Orders);
            EmdRecentUploads.RecentUploadsEntry entry = res.Result.Uploads.First();
            Assert.AreEqual(UploadType.Orders, entry.UploadType);
            Assert.AreEqual(TypeId, res.Result.Uploads.First().TypeId);
            Assert.AreEqual(RegionId, res.Result.Uploads.First().RegionId);
            Assert.AreNotEqual("", entry.UploadType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetRecentUploads_NoOptions_NoException() {
            EveMarketDataResponse<EmdRecentUploads> res = _api.GetRecentUploads(_invalidOptions, UploadType.Orders);
        }

        [TestMethod]
        public void GetItemPrice_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdItemPrices> res = _api.GetItemPrice(_validOptions, OrderType.Buy, MinMax.Min);
            EmdItemPrices.ItemPriceEntry entry = res.Result.Prices.First();
            Assert.AreEqual(OrderType.Buy, entry.OrderType);
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.Price);
            Assert.AreNotEqual("", entry.OrderType);
            Assert.AreNotEqual("", entry.Updated);
        }


        [TestMethod]
        public async Task GetItemPriceAsync_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdItemPrices> res =
                await _api.GetItemPriceAsync(_validOptions, OrderType.Buy, MinMax.Min);
            EmdItemPrices.ItemPriceEntry entry = res.Result.Prices.First();
            Assert.AreEqual(OrderType.Buy, entry.OrderType);
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual(RegionId, entry.RegionId);
            Assert.AreNotEqual(0, entry.Price);
            Assert.AreNotEqual("", entry.OrderType);
            Assert.AreNotEqual("", entry.Updated);
        }

        [TestMethod]
        public void GetItemPrice_NoOptions_NoException() {
            EveMarketDataResponse<EmdItemPrices> res = _api.GetItemPrice(_invalidOptions, OrderType.Buy, MinMax.Min);
        }

        [TestMethod]
        public void GetItemOrders_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdItemOrders> res = _api.GetItemOrders(_validOptions, OrderType.Buy);
            EmdItemOrders.ItemOrderEntry entry = res.Result.Orders.First();
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
        public async Task GetItemOrdersAsync_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdItemOrders> res = await _api.GetItemOrdersAsync(_validOptions, OrderType.Buy);
            EmdItemOrders.ItemOrderEntry entry = res.Result.Orders.First();
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
            EveMarketDataResponse<EmdItemOrders> res = _api.GetItemOrders(_invalidOptions, OrderType.Buy);
        }

        [TestMethod]
        public void GetItemHistory_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdItemHistory> res = _api.GetItemHistory(_validOptions);
            EmdItemHistory.ItemHistoryEntry entry = res.Result.History.First();
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
        public async Task GetItemHistoryAsync_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdItemHistory> res = await _api.GetItemHistoryAsync(_validOptions);
            EmdItemHistory.ItemHistoryEntry entry = res.Result.History.First();
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
            EveMarketDataResponse<EmdItemHistory> res = _api.GetItemHistory(_invalidOptions);
        }

        //[TestMethod]
        public void GetStationRank_ValidRequest_ValidResponse() {
            EveMarketDataResponse<EmdStationRank> res = _api.GetStationRank(_validOptions);
            EmdStationRank.StationRankEntry entry = res.Result.Stations.First();
            Assert.AreNotEqual(0, entry.StationId);
            Assert.AreNotEqual("", entry.Date);
            Assert.AreNotEqual(0, entry.RankByOrders);
            Assert.AreNotEqual(0, entry.RankByPrice);
        }

        //[TestMethod]
        public async Task GetStationRank_ValidRequestAsync_ValidResponse() {
            EveMarketDataResponse<EmdStationRank> res = await _api.GetStationRankAsync(_validOptions);
            EmdStationRank.StationRankEntry entry = res.Result.Stations.First();
            Assert.AreNotEqual(0, entry.StationId);
            Assert.AreNotEqual("", entry.Date);
            Assert.AreNotEqual(0, entry.RankByOrders);
            Assert.AreNotEqual(0, entry.RankByPrice);
        }

        [TestMethod]
        [ExpectedException(typeof (Exception), AllowDerivedTypes = true)]
        public void GetStationRank_InvalidArgument_ContractException() {
            EveMarketDataResponse<EmdStationRank> res = _api.GetStationRank(_invalidOptions);
        }
    }
}