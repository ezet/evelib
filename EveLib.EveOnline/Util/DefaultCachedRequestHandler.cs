using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Handles requests to the Eve API. Caching is accomplished by using the native HttpWebRequest caching (IE Cache).
    /// </summary>
    public class DefaultCachedRequestHandler : CachedRequestHandler {

        public DefaultCachedRequestHandler(IHttpRequester httpRequester, ISerializer serializer, IEveApiCache cache)
            : base(httpRequester, serializer, cache) {
        }

        /// <summary>
        ///     Performs a request to the specified URI and returns an EveApiResponse of specified type.
        /// </summary>
        /// <typeparam name="T">The type parameter for the xml response.</typeparam>
        /// <param name="uri">The URI to request.</param>
        /// <returns></returns>
        public override T Request<T>(Uri uri) {
            string data = "";
            bool cached = Cache.TryGet(uri, out data);
            if (cached) {
                Debug.WriteLine("From cache: True");
            } else {
                try {
                    data = HttpRequester.Request<T>(uri);
                } catch (InvalidRequestException e) {
                    var response = (HttpWebResponse)e.InnerException.Response;
                    if (response == null) throw;
                    var responseStream = response.GetResponseStream();
                    if (responseStream == null) throw;
                    using (var reader = new StreamReader(responseStream)) {
                        data = reader.ReadToEnd();
                        var error = Serializer.Deserialize<EveApiError>(data);
                        Debug.WriteLine("Error: " + error.Error.ErrorCode + ", " + error.Error.ErrorText);
                        throw new InvalidRequestException(error.Error.ErrorText, error.Error.ErrorCode, e.InnerException);
                    }
                }
            }
            var xml = Serializer.Deserialize<T>(data);
            if (!cached)
                Cache.Store(uri, getCacheExpirationTime(xml), data);
            return xml;
        }
    }
}