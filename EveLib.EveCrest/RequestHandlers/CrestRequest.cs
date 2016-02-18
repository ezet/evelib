<<<<<<< db277dd1c425c6e81ed234956b64b05cc4596f47
﻿// ***********************************************************************
// Assembly         : EveLib.EveCrest
// Author           : larsd
// Created          : 02-17-2016
//
// Last Modified By : larsd
// Last Modified On : 02-17-2016
// ***********************************************************************
// <copyright file="CrestRequest.cs" company="Lars Kristian Dahl">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
=======
﻿using System;
>>>>>>> Did some work. Need to clean up HttpRequests and correct ContentType
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
<<<<<<< db277dd1c425c6e81ed234956b64b05cc4596f47
    /// <summary>
    /// Class CrestRequest.
    /// </summary>
    public class CrestRequest {

        /// <summary>
        /// The content type
        /// </summary>
        public const string ContentType = "application/x-www-form-urlencoded";

        /// <summary>
        /// The trace
        /// </summary>
        private static readonly TraceSource Trace = new TraceSource("EveLib");

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public HttpWebRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrestRequest"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="method">The method.</param>
        public CrestRequest(Uri uri, string method) {
            Request = WebRequest.CreateHttp(uri);
            Request.Proxy = null;
            Request.UserAgent = Config.UserAgent;
            Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.GZip;
            Request.ContentType = ContentType;
        }


        /// <summary>
        /// Adds the post data.
        /// </summary>
        /// <param name="postData">The post data.</param>
        public void SetPostData(string postData) {
            Request.ContentLength = postData.Length;
            using (var writer = new StreamWriter(Request.GetRequestStream())) {
=======



    public class CrestRequest {

        private static readonly TraceSource Trace = new TraceSource("EveLib");

        public const string ContentType = "application/x-www-form-urlencoded";

        public CrestRequest(Uri uri, string method) {
            request = WebRequest.CreateHttp(uri);
            request.Method = method;
            request.Proxy = null;
            request.UserAgent = Config.UserAgent;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.GZip;
            request.ContentType = ContentType;
        }

        public HttpWebRequest request { get; set; }

        public HttpWebResponse response { get; set; }

        public string content { get; set; }


        public void SetPostData(string postData) {
            request.ContentLength = postData.Length;
            using (var writer = new StreamWriter(request.GetRequestStream())) {
>>>>>>> Did some work. Need to clean up HttpRequests and correct ContentType
                writer.Write(postData);
            }
        }

<<<<<<< db277dd1c425c6e81ed234956b64b05cc4596f47
        /// <summary>
        /// get response as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;HttpWebResponse&gt;.</returns>
        public async Task<HttpWebResponse> GetResponseAsync() {
            HttpWebResponse response;
            try {
                response = (HttpWebResponse)await Request.GetResponseAsync().ConfigureAwait(false);
=======

        public async Task<HttpWebResponse> GetResponseAsync() {
            if (response != null) return response;
            try {
                response = (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false);
>>>>>>> Did some work. Need to clean up HttpRequests and correct ContentType
                if (response != null) {
                    Trace.TraceEvent(TraceEventType.Information, 0,
                        "Response status: " + response.StatusCode + ", " + response.StatusDescription);
                    Trace.TraceEvent(TraceEventType.Verbose, 0, "From cache: " + response.IsFromCache);
                }
            }
            catch (WebException e) {
                response = (HttpWebResponse)e.Response;
                if (response == null) throw;
                Trace.TraceEvent(TraceEventType.Information, 0,
                    "Response status: " + response.StatusCode + ", " + response.StatusDescription);
                Trace.TraceEvent(TraceEventType.Verbose, 0, "From cache: " + response.IsFromCache);
                throw;
            }
            return response;
        }

<<<<<<< db277dd1c425c6e81ed234956b64b05cc4596f47

        /// <summary>
        /// get response content as an asynchronous operation.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> GetResponseContentAsync(HttpWebResponse response) {
            string data;
            Stream responseStream = response.GetResponseStream();
            if (responseStream == null) return null;
            using (var reader = new StreamReader(responseStream)) {
                data = await reader.ReadToEndAsync().ConfigureAwait(false);
            }
            return data;
        }


        /// <summary>
        /// get response content as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> GetResponseContentAsync() {
            Trace.TraceEvent(TraceEventType.Start, 0, "Starting request: " + Request.RequestUri);
            string data = "";
            using (HttpWebResponse response = await GetResponseAsync().ConfigureAwait(false)) {
                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) return data;
                using (var reader = new StreamReader(responseStream)) {
                    data = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
            Trace.TraceEvent(TraceEventType.Stop, 0, "Finished request: " + Request.RequestUri);
            return data;
        }
=======
        public async Task<string> GetResponseContentAsync() {
            if (content != null) return content;
            Trace.TraceEvent(TraceEventType.Start, 0, "Starting request: " + request.RequestUri);
            content = "";
            response = await GetResponseAsync().ConfigureAwait(false);
                var responseStream = response.GetResponseStream();
                if (responseStream == null) return content;
                using (var reader = new StreamReader(responseStream)) {
                    content = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            Trace.TraceEvent(TraceEventType.Stop, 0, "Finished request: " + request.RequestUri);
            return content;
        }

>>>>>>> Did some work. Need to clean up HttpRequests and correct ContentType
    }
}