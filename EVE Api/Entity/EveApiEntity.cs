using System;
using eZet.Eve.EoLib.Dto.EveApi;

namespace eZet.Eve.EoLib.Entity {
    public abstract class EveApiEntity : BaseEntity {
        //protected override Uri UriBase { get; set; }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relPath">A relative path to the resource to be requested.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relPath, params object[] args) where T : new() {
            var uri = new Uri(UriBase, relPath + generatePostString(null, args));
            return RequestHandler.Request(type, uri);
        }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relPath">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relPath, ApiKey key) where T : new() {
            var uri = new Uri(UriBase, relPath + generatePostString(key));
            return RequestHandler.Request(type, uri);
        }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relPath">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relPath, ApiKey key, params object[] args) where T : new() {
            var uri = new Uri(UriBase, relPath + generatePostString(key, args));
            return RequestHandler.Request(type, uri);
        }
    }
}
