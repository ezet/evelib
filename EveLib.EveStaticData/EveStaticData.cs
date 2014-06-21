using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules {
    /// <summary>
    /// Class for accessing the static data API from Elemen43
    /// </summary>
    public class EveStaticData {

        /// <summary>
        /// Represents the data formats
        /// </summary>
        public enum DataFormat {
            /// <summary>
            /// JSON
            /// </summary>
            Json,
            //Xml,
            //Yaml
        }

        /// <summary>
        /// The default URI base.
        /// </summary>
        public const string DefaultUri = "http://element-43.com/";

        /// <summary>
        /// The default relative path for the API base.
        /// </summary>
        public const string DefaultApiPath = "api/";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="format">The format to request</param>
        public EveStaticData(DataFormat format = DataFormat.Json) {
            RequestHandler = new RequestHandler(new JsonSerializer());
            BaseUri = new Uri(DefaultUri);
            ApiPath = DefaultApiPath;
            Format = format;
        }

        /// <summary>
        /// Gets the format requested by this instance.
        /// </summary>
        public DataFormat Format { get; private set; }


        /// <summary>
        ///     Gets or sets the relative path for the API.
        /// </summary>
        public string ApiPath { get; set; }

        /// <summary>
        ///     Gets or sets the base URI for requests.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the RequestHandler used to perform requests.
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        /// Sets the format requested by this instance
        /// </summary>
        /// <param name="format"></param>
        public void SetFormat(DataFormat format) {
            Format = format;
            // TODO set format
        }

        /// <summary>
        ///     Returns a list of InvTypes
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>InvType list</returns>
        public StaticDataCollection<InvType> GetInvTypes(int page = 1) {
            return GetInvTypesAsync(page).Result;
        }


        /// <summary>
        ///     Returns a list of InvTypes
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>InvType list</returns>
        public Task<StaticDataCollection<InvType>> GetInvTypesAsync(int page = 1) {
            const string relPath = "invType/";
            return requestAsync<StaticDataCollection<InvType>>(relPath, "page=" + page);
        }

        /// <summary>
        ///     Returns data for a specific InvType
        /// </summary>
        /// <param name="id">InvType ID</param>
        /// <returns></returns>
        public InvType GetInvType(long id) {
            return GetInvTypeAsync(id).Result;
        }

        /// <summary>
        ///     Returns data for a specific InvType
        /// </summary>
        /// <param name="id">InvType ID</param>
        /// <returns></returns>
        public Task<InvType> GetInvTypeAsync(long id) {
            string relPath = "invType/" + id;
            return requestAsync<InvType>(relPath);
        }

        private Task<T> requestAsync<T>(string relUri, string queryString = "") {
            var uri = new Uri(BaseUri, ApiPath + relUri + "?" + queryString + "&format=" + Format.ToString().ToLower());
            return RequestHandler.RequestAsync<T>(uri);
        }
    }
}