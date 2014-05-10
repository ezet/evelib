using System;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Provides basic properties and methods for Eve Api RequestHandler objects.
    /// </summary>
    public abstract class CachedRequestHandler : IHttpRequester {

        /// <summary>
        ///     Cache for XML
        /// </summary>
        public IEveXmlCache Cache;

        protected CachedRequestHandler(ISerializer serializer, IEveXmlCache cache) {
            Serializer = serializer;
            Cache = cache;
        }

        /// <summary>
        ///     A serializer for deserializing objects.
        /// </summary>
        public ISerializer Serializer { get; set; }


        /// <summary>
        ///     Performs a request using the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of EveApiResponse.</typeparam>
        /// <param name="uri">The uri to request.</param>
        /// <returns></returns>
        public abstract string Request<T>(Uri uri);

        protected virtual DateTime getCacheExpirationTime(dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            // TODO type check
            return xml.CachedUntil;
        }
    }
}