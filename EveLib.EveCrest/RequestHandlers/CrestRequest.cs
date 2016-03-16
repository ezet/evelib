// ***********************************************************************
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
using System.Diagnostics;
using System.IO;
using System.Net;
using eZet.EveLib.Core;

namespace eZet.EveLib.EveCrestModule.RequestHandlers {
    /// <summary>
    ///     Class CrestRequest.
    /// </summary>
    public class CrestRequest {
        /// <summary>
        ///     The content type
        /// </summary>
        public const string ContentType = "application/x-www-form-urlencoded";

        /// <summary>
        ///     The trace
        /// </summary>
        private static readonly TraceSource Trace = new TraceSource("EveLib");


        /// <summary>
        ///     Initializes a new instance of the <see cref="CrestRequest" /> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public CrestRequest(Uri uri) {
            Request = WebRequest.CreateHttp(uri);
            Request.Proxy = null;
            Request.UserAgent = Config.UserAgent;
            Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.GZip;
            Request.ContentType = ContentType;
        }

        /// <summary>
        ///     Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public HttpWebRequest Request { get; set; }

        /// <summary>
        ///     Gets or sets the response.
        /// </summary>
        /// <value>The response.</value>
        public HttpWebResponse Response { get; set; }

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }


        /// <summary>
        ///     Adds the post data.
        /// </summary>
        /// <param name="postData">The post data.</param>
        public void SetPostData(string postData) {
            Request.ContentLength = postData.Length;
            using (var writer = new StreamWriter(Request.GetRequestStream())) {
                // TODO: Use async
                writer.Write(postData);
            }
        }
    }
}