using System;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    public class StaticData {

        public enum DataFormat {
            Json,
            Xml,
            Yaml
        }

        public const string DefaultUri = "http://element-43.com/";

        public const string DefaultApiPath = "api/";

        public StaticData(DataFormat format = DataFormat.Json) {
            RequestHandler = new RequestHandler(new HttpRequester(), new SimpleJsonSerializer());
            BaseUri = new Uri(DefaultUri);
            ApiPath = DefaultApiPath;
            Format = format;
        }

        public DataFormat Format { get; private set; }

        public void SetFormat(DataFormat format) {
            Format = format;
            // TODO set format
        }

        public string ApiPath { get; set; }

        /// <summary>
        ///     Gets or sets the base URI for requests.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the RequestHandler used to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        public StaticDataCollection<InvType> GetInvTypes(int page = 1) {
            const string relPath = "invType/";
            return request<StaticDataCollection<InvType>>(relPath, "page=" + page);
        }

        public InvType GetInvType(long id) {
            string relPath = "invType/" + id;
            return request<InvType>(relPath);
        }

        private T request<T>(string relUri, string queryString = "") {
            var uri = new Uri(BaseUri, ApiPath + relUri + "?" + queryString + "&format=" + Format.ToString().ToLower());
            return RequestHandler.Request<T>(uri);
        }
    }
}
