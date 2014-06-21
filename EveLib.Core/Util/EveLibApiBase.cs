using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.Core.Util {
    /// <summary>
    ///     A base class for Eve Lib API modules.
    /// </summary>
    public abstract class EveLibApiBase {
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
            BaseUri = uri;
        }

        /// <summary>
        ///     Gets or sets the request handler used by this instance
        /// </summary>
        public IRequestHandler RequestHandler { get; set; }

        /// <summary>
        ///     Gets or sets the base URI used to access this API. This should include a trailing backslash.
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the relative path to the API base.
        /// </summary>
        public string ApiPath { get; set; }

        /// <summary>
        ///     Performs a request using the request handler.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="relPath">Relative path</param>
        /// <returns></returns>
        protected Task<T> requestAsync<T>(string relPath) {
            return RequestHandler.RequestAsync<T>(new Uri(BaseUri + ApiPath + relPath));
        }
    }
}