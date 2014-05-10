using System;
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
            string relPath = "/api/kills";
            relPath = options.GetQueryString(relPath);
            return request<dynamic>(new Uri(BaseUri, relPath));

        }

        public dynamic GetLosses(ZKillboardOptions options) {
            string relPath = "/api/losses";
            relPath = options.GetQueryString(relPath);
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetAll(ZKillboardOptions options) {
            string relPath = "/api";
            relPath = options.GetQueryString(relPath);
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        private T request<T>(Uri uri) {
            return RequestHandler.Request<T>(uri);
        }
    }
}
