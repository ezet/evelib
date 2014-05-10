using System;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public class Element43 {

        public const string DefaultUri = "http://element-43.com/";

        public const string DefaultApiPath = "api/";

        public string ApiPath { get; set; }
        public Element43() {
            RequestHandler = new RequestHandler(new HttpRequester(), new DynamicJsonSerializer());
            BaseUri = new Uri(DefaultUri);
            ApiPath = DefaultApiPath;
        }

        /// <summary>
        ///     Gets or sets the base URI for requests.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the RequestHandler used to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        public Element43Collection<InvType> GetInvTypes(int page = 1) {
            const string relPath = "invType/";
            return request<Element43Collection<InvType>>(relPath, "page=" + page);
        }

        public InvType GetInvType(long id) {
            string relPath = "invType/" + id;
            return request<InvType>(relPath);
        }

        private T request<T>(string relUri, string queryString = "") {
            var uri = new Uri(BaseUri, ApiPath + relUri + "?" + queryString);
            return RequestHandler.Request<T>(uri);
        }
    }
}
