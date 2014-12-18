using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     A base class for Eve Lib API modules.
    /// </summary>
    public abstract class EveLibApiBase {
        private string _host;

        /// <summary>
        ///     Constructor
        /// </summary>
        protected EveLibApiBase() {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestHandler"></param>
        protected EveLibApiBase(string uri, IRequestHandler requestHandler) {
            RequestHandler = requestHandler;
            Host = uri;
            ApiPath = "/";
        }

        /// <summary>
        ///     Gets or sets the request handler used by this instance
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Gets or sets the base URI used to access this API.
        /// </summary>
        public string Host {
            get { return _host; }
            set { _host = value.TrimEnd('/', '\\'); }
        }

        /// <summary>
        ///     Gets or sets the path to the API root relative to Host.
        /// </summary>
        public string ApiPath { get; set; }

        /// <summary>
        ///     Performs a request using the request handler.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="relPath">Relative path</param>
        /// <returns></returns>
        protected Task<T> requestAsync<T>(string relPath) {
            return RequestHandler.RequestAsync<T>(new Uri(Host + ApiPath + relPath));
        }
    }
}