using System;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public class Element43 {

        public const string DefaultUri = "http://element-43.com";

        /// <summary>
        ///     Default constructor, with a default base uri and request handler.
        /// </summary>
        public Element43(string baseUri = DefaultUri)
            : this(new RequestHandler(new DynamicJsonSerializer()), baseUri) {
        }

        public Element43(IRequestHandler requestHandler, string baseUri = DefaultUri) {
            RequestHandler = requestHandler;
            BaseUri = new Uri(baseUri);
        }

        /// <summary>
        ///     Gets or sets the base URI for requests.
        /// </summary>
        public Uri BaseUri { get; private set; }

        /// <summary>
        ///     Gets or sets the RequestHandler used to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; private set; }

        public Element43Collection<dynamic> MapLocationWormholeClass() {
            const string relPath = "/mapLocationWormholeClass/";
            return request<dynamic>(relPath, "");

        }

        public Element43Collection<InvType> GetInvTypes(int page = 1) {
            const string relPath = "/invType/";
            return request<Element43Collection<InvType>>(relPath, "page=" + page);
        }

        public InvType GetInvType(long id) {
            string relPath = "/invType/" + id;
            return request<InvType>(relPath);
        }


        private T request<T>(string relUri, string queryString = "") {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.Request<T>(uri);
        }



    }
}
