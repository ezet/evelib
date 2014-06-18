using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules {
    public class ZKillboard {
        public const string DefaultUri = "https://zkillboard.com";


        public ZKillboard() {
            RequestHandler = new RequestHandler(new HttpRequester(), new DynamicJsonSerializer());
            BaseUri = new Uri(DefaultUri);
        }

        public Uri BaseUri { get; set; }

        public IRequestHandler RequestHandler { get; set; }

        public dynamic GetKills(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetKillsAsync(options).Result;
        }

        public Task<dynamic> GetKillsAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api/kills";
            relPath = options.GetQueryString(relPath);
            return requestAsync<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetLosses(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetLossesAsync(options).Result;
        }

        public Task<dynamic> GetLossesAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api/losses";
            relPath = options.GetQueryString(relPath);
            return requestAsync<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetAll(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            return GetAllAsync(options).Result;
        }

        public Task<dynamic> GetAllAsync(ZKillboardOptions options) {
            Contract.Requires(options != null, "Options cannot be null");
            string relPath = "/api";
            relPath = options.GetQueryString(relPath);
            return requestAsync<dynamic>(new Uri(BaseUri, relPath));
        }

        private Task<T> requestAsync<T>(Uri uri) {
            return RequestHandler.RequestAsync<T>(uri);
        }
    }
}