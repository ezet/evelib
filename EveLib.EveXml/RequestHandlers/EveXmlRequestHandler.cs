using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core.Cache;
using eZet.EveLib.Core.RequestHandlers;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using eZet.EveLib.EveXmlModule.Exceptions;
using eZet.EveLib.EveXmlModule.Models;

namespace eZet.EveLib.EveXmlModule.RequestHandlers {
    /// <summary>
    ///     Handles requests to the Eve API using a cache.
    /// </summary>
    public class EveXmlRequestHandler : ICachedRequestHandler {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Gets or sets the Cache.
        /// </summary>
        public IEveLibCache Cache { get; set; }

        /// <summary>
        ///     Gets or sets the cache level.
        /// </summary>
        /// <value>The cache level.</value>
        public CacheLevel CacheLevel { get; set; }

        /// <summary>
        ///     Gets or sets the serializer.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        ///     Requests data from uri, with error handling specific to the Eve Online API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<T> RequestAsync<T>(Uri uri) {
            string data = null;
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.CacheOnly)
                data = await Cache.LoadAsync(uri).ConfigureAwait(false);
            var cached = data != null;
            if (cached) return Serializer.Deserialize<T>(data);
            if (CacheLevel == CacheLevel.CacheOnly) return default(T);
            try {
                var response = await HttpRequestHelper.GetResponseAsync(HttpRequestHelper.CreateRequest(uri)).ConfigureAwait(false);
                // special handling for status code 000, because we cannot fetch the response body
                if (response.StatusCode.ToString() == "0") {
                    throw new EveXmlException("Kill log exhausted (You can only fetch kills that are less than a month old)", 119, new WebException("Unknown", null, WebExceptionStatus.UnknownError, response));
                }
                data = await HttpRequestHelper.GetResponseContentAsync(response);

            }
            catch (WebException e) {
                _trace.TraceEvent(TraceEventType.Error, 0, "Http Request failed");
                var response = (HttpWebResponse) e.Response;
                if (response == null) throw new EveXmlException("Unknown", 0, e);
                var responseStream = response.GetResponseStream();
                if (responseStream == null) throw;
                using (var reader = new StreamReader(responseStream)) {
                    data = reader.ReadToEnd();
                    var error = Serializer.Deserialize<EveXmlError>(data);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Error: {0}, Code: {1}", error.Error.ErrorText,
                        error.Error.ErrorCode);
                    throw new EveXmlException(error.Error.ErrorText, error.Error.ErrorCode, e);
                }
            }
            var xml = Serializer.Deserialize<T>(data);
            if (CacheLevel == CacheLevel.Default || CacheLevel == CacheLevel.Refresh)
                await Cache.StoreAsync(uri, getCacheExpirationTime(xml), data).ConfigureAwait(false);
            return xml;
        }

        /// <summary>
        ///     Gets the CachedUntil value from a EveXmlResponse object.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private DateTime getCacheExpirationTime(dynamic xml) {
            //if (o.GetType().Is) throw new System.Exception("Should never occur.");
            return xml.CachedUntil;
        }
    }
}