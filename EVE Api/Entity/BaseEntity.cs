using System;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib.Entity {
    /// <summary>
    /// Provides general utility methods for all library entities. The Serializer and Requester can be changed at runtime.
    /// </summary>
    public abstract class BaseEntity {

        /// <summary>
        /// The base url for all requests
        /// </summary>
        /// TODO Convert to URI
        protected abstract Uri UriBase { get; set; }

        protected BaseEntity() {
            Serializer = new XmlSerializerWrapper();
            Requester = new WebRequester(new FileCacheHandler());
        }

        /// <summary>
        /// The serializer used to deserialize the repsonses for this entity.
        /// </summary>
        public IXmlSerializer Serializer { get; set; }

        /// <summary>
        /// The requester this entity uses to perform requests.
        /// </summary>
        public BaseRequester Requester { get; private set; }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relPath">A relative path to the resource to be requested.</param>
        /// <param name="args">Arguments for the request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relPath, params object[] args) where T : XmlElement {
            var uri = new Uri(UriBase, relPath + generatePostString(null, args));
            var data = Requester.Request(uri);
            return Serializer.Deserialize<T>(data);
        }

        /// <summary>
        /// Performs a request on the requester, using the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type used for response deserialization.</typeparam>
        /// <param name="type">An instance of the type used for response deserialization.</param>
        /// <param name="relPath">A relative path to the resource to be requested.</param>
        /// <param name="key">An API Key to be used with this request.</param>
        /// <returns></returns>
        protected XmlResponse<T> request<T>(T type, string relPath, ApiKey key) where T : XmlElement {
            var uri = new Uri(UriBase, relPath + generatePostString(key));
            var data = Requester.Request(uri);
            return Serializer.Deserialize<T>(data);
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
        protected XmlResponse<T> request<T>(T type, string relPath, ApiKey key, params object[] args) where T : XmlElement {
            var uri = new Uri(UriBase, relPath + generatePostString(key, args));
            var data = Requester.Request(uri);
            return Serializer.Deserialize<T>(data);
        }

        private string generatePostString(ApiKey key = null, params object[] args) {
            var postString = "?";
            if (key != null)
                postString = "?keyID=" + key.KeyId + "&vCode=" + key.VCode + "&";
            for (var i = 0; i < args.Length; i += 2) {
                postString += args[i] + "=" + args[i + 1] + "&";
            }
            return postString;
        }
    }
}
