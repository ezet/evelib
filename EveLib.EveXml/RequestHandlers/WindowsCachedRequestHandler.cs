//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Net;
//using System.Net.Cache;
//using eZet.EveLib.Core.Exception;
//using eZet.EveLib.Core.Util;
//using eZet.EveLib.Modules.Models;

//namespace eZet.EveLib.Modules.Util {
//    /// <summary>
//    ///     Handles requests to the Eve API. Caching is accomplished by using the native HttpWebRequest caching (IE Cache).
//    /// </summary>
//    public class WindowsCachedRequestHandler : CachedRequestHandler {
//        private const string ContentType = "application/x-www-form-urlencoded";

//        public WindowsCachedRequestHandler(ISerializer serializer, IEveLibCache cache)
//            : base(serializer, cache) {
//        }

//        /// <summary>
//        ///     Performs a request to the specified URI and returns an EveApiResponse of specified type.
//        /// </summary>
//        /// <typeparam name="T">The type parameter for the xml response.</typeparam>
//        /// <param name="uri">The URI to request.</param>
//        /// <returns></returns>
//        public override T Request<T>(Uri uri) {
//            DateTime cachedUntil;
//            bool cached = Cache.TryGetExpirationDate(uri, out cachedUntil) && DateTime.UtcNow < cachedUntil;
//            HttpWebRequest request = HttpRequestHelper.CreateRequest(uri);
//            request.ContentType = ContentType;
//            request.CachePolicy = cached
//                ? new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable)
//                : new HttpRequestCachePolicy(HttpRequestCacheLevel.Reload);
//            request.Proxy = null;
//            string data = "";
//            try {
//                data = HttpRequestHelper.GetResponseContent(request);
//            } catch (WebException e) {
//                var response = (HttpWebResponse)e.Response;
//                if (response == null) throw;
//                var responseStream = response.GetResponseStream();
//                if (responseStream == null) throw;
//                using (var reader = new StreamReader(responseStream)) {
//                    data = reader.ReadToEnd();
//                    var error = Serializer.Deserialize<EveApiError>(data);
//                    Debug.WriteLine("Error: " + error.Error.ErrorCode + ", " + error.Error.ErrorText);
//                    throw new InvalidRequestException(error.Error.ErrorText, error.Error.ErrorCode, e);
//                }
//            }
//            var xml = Serializer.Deserialize<T>(data);
//            if (!cached)
//                Cache.StoreAsync(uri, getCacheExpirationTime(xml));
//            return xml;
//        }

//    }
//}

