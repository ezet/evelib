using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;

namespace eZet.EveLib.Modules.Util {
    /// <summary>
    ///     Handles requests to the Eve API. Caching is accomplished by using the native HttpWebRequest caching (IE Cache).
    /// </summary>
    public class CachedRequestHandler : RequestHandlerBase {
        private const string ContentType = "application/x-www-form-urlencoded";

        public CachedRequestHandler(ISerializer serializer)
            : base(serializer) {
        }

        /// <summary>
        ///     Performs a request to the specified URI and returns an EveApiResponse of specified type.
        /// </summary>
        /// <typeparam name="T">The type parameter for the xml response.</typeparam>
        /// <param name="uri">The URI to request.</param>
        /// <returns></returns>
        public override T Request<T>(Uri uri) {
            DateTime cachedUntil;
            bool fromCache = CacheExpirationRegister.TryGetValue(uri, out cachedUntil) && DateTime.UtcNow < cachedUntil;
            string data = "";
            HttpWebRequest request = HttpRequestHelper.CreateRequest(uri);
            request.ContentType = ContentType;
            request.CachePolicy = fromCache
                ? new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable)
                : new HttpRequestCachePolicy(HttpRequestCacheLevel.Reload);
            request.Proxy = null;
            try {
                using (var response = HttpRequestHelper.GetResponse(request)) {
                    Debug.WriteLine("From cache: " + response.IsFromCache);
                    Stream responseStream = response.GetResponseStream();
                    if (responseStream != null) {
                        using (var reader = new StreamReader(responseStream)) {
                            data = reader.ReadToEnd();
                            Debug.Write(data);
                        }
                    }
                }
                //data = HttpRequestHelper.GetContent(request);
            } catch (WebException e) {
                var response = (HttpWebResponse)e.Response;
                if (response == null) throw;
                Debug.WriteLine("From cache: " + response.IsFromCache);
                if (response.StatusCode != HttpStatusCode.BadRequest)
                    throw new InvalidRequestException("Request caused a WebException.", e);
                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) throw new InvalidRequestException("Request caused a WebException.", e);
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                    var error = Serializer.Deserialize<EveApiError>(data);
                    throw new InvalidRequestException(error.Error.ErrorText, error.Error.ErrorCode, e);
                }
            }
            var xml = Serializer.Deserialize<T>(data);
            register(uri, xml);
            SaveCacheState();
            return xml;
        }

        private void register(Uri uri, dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            // TODO type check
            CacheExpirationRegister.AddOrUpdate(uri, xml.CachedUntil);
        }
    }
}