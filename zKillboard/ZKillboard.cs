using System;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules {
    public class ZKillboard {

        public const string DefaultUri = "https://zkillboard.com";

        public Uri BaseUri { get; private set; }

        public ZKillboard(string baseUri = DefaultUri) : this(new RequestHandler(new DynamicJsonSerializer()), baseUri) {
        }

        public ZKillboard(IRequestHandler requestHandler, string baseUri = DefaultUri) {
            RequestHandler = requestHandler;
            BaseUri = new Uri(baseUri);
        }

        public IRequestHandler RequestHandler { get; private set; }

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

        public dynamic GetSolo(ZKillboardOptions options) {
            string relPath = "/solo";
            relPath = options.GetQueryString(relPath);
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        public dynamic GetWSpace(ZKillboardOptions options) {
            string relPath = "/w-space";
            relPath = options.GetQueryString(relPath);
            return request<dynamic>(new Uri(BaseUri, relPath));
        }

        private T request<T>(Uri uri) {
            return RequestHandler.Request<T>(uri);
        }
    }
}
