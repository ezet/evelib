using System;
using eZet.EveLib.Core.Util;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Provides basic properties and methods for Eve Api RequestHandler objects.
    /// </summary>
    public abstract class CachedRequestHandler : IRequestHandler {

        /// <summary>
        ///     Cache for XML
        /// </summary>

        protected CachedRequestHandler(IHttpRequester httpRequester, ISerializer serializer, IEveApiCache cache) {
            HttpRequester = httpRequester;
            Serializer = serializer;
            Cache = cache;
        }

        public IEveApiCache Cache { get; set; }

        public IHttpRequester HttpRequester { get; set; }

        /// <summary>
        ///     A serializer for deserializing objects.
        /// </summary>
        public ISerializer Serializer { get; set; }

        public abstract T Request<T>(Uri uri);

        protected virtual DateTime getCacheExpirationTime(dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            // TODO type check
            return xml.CachedUntil;
        }
    }
}