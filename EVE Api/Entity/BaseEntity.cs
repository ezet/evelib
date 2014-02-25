using System;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib.Entity {
    /// <summary>
    /// Provides general utility methods for all library entities.
    /// </summary>
    public abstract class BaseEntity {

        /// <summary>
        /// The base url for all requests
        /// </summary>
        protected abstract Uri UriBase { get; set; }

        protected BaseEntity() {
            RequestHandler = new IeCachedRequestHandler(new XmlSerializerWrapper());
        }

        /// <summary>
        /// The requester this entity uses to perform requests.
        /// </summary>
        public EveApiRequestHandler RequestHandler { get; set; }

        protected string generatePostString(ApiKey key = null, params object[] args) {
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
