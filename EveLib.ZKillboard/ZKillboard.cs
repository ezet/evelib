using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.RequestHandlers;

namespace eZet.EveLib.Modules {
    public class ZKillboard {
        public const string DefaultUri = "https://zkillboard.com";


        public ZKillboard() {
            RequestHandler = new ZkbRequestHandler(new DynamicJsonSerializer(), new EveLibFileCache());
            BaseUri = new Uri(DefaultUri);
        }

        public Uri BaseUri { get; set; }

        public IRequestHandler RequestHandler { get; set; }

        public ZkbResponse GetKills(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetKillsAsync(options).Result;
        }

        public Task<ZkbResponse> GetKillsAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api/kills";
            relPath = options.GetQueryString(relPath);
            return requestAsync<ZkbResponse>(new Uri(BaseUri, relPath));
        }

        public ZkbResponse GetLosses(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetLossesAsync(options).Result;
        }

        public Task<ZkbResponse> GetLossesAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api/losses";
            relPath = options.GetQueryString(relPath);
            return requestAsync<ZkbResponse>(new Uri(BaseUri, relPath));
        }

        public ZkbResponse GetAll(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetAllAsync(options).Result;
        }

        public Task<ZkbResponse> GetAllAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api";
            relPath = options.GetQueryString(relPath);
            return requestAsync<ZkbResponse>(new Uri(BaseUri, relPath));
        }

        private Task<T> requestAsync<T>(Uri uri) {
            return RequestHandler.RequestAsync<T>(uri);
        }
    }
}