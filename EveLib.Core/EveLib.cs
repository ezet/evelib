using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Core {
    /// <summary>
    /// This is a class for general EveLib utilities and methods
    /// </summary>
    public class EveLib : EveLibApiBase {
        private readonly JsonSerializer _jsonSerializer = new JsonSerializer();

        private readonly XmlSerializer _xmlSerializer = new XmlSerializer();

        /// <summary>
        /// Default constructor
        /// </summary>
        public EveLib() {
            RequestHandler = new RequestHandler(_jsonSerializer);
        }

        /// <summary>
        /// Requests and deserializes JSON content to a dynamic object
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns></returns>
        public Task<dynamic> RequestJsonAsync(string uri) {
            RequestHandler.Serializer = _jsonSerializer;
            return requestAsync<dynamic>(uri);
        }

        /// <summary>
        /// Requests and deserializes JSON content to a dynamic object
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns></returns>
        public dynamic RequestJson(string uri) {
            return RequestJsonAsync(uri).Result;
        }

        /// <summary>
        /// Requests and deserializes XML content to a dynamic object. Not implemented yet.
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns></returns>
        public Task<dynamic> RequestXmlAsync(string uri) {
            throw new NotImplementedException();
            RequestHandler.Serializer = _xmlSerializer;
            return requestAsync<dynamic>(uri);
        }

        /// <summary>
        /// Requests and deserializes XML content to a dynamic object. Not implemented yet.
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns></returns>
        public dynamic RequestXml(string uri) {
            throw new NotImplementedException();
            return RequestXmlAsync(uri).Result;
        }
    }
}