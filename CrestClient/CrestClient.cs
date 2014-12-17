// ***********************************************************************
// Assembly         : EveLib.CrestClient
// Author           : Lars Kristian
// Created          : 12-16-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="CrestClient.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using eZet.EveLib.Core.Serializers;
using eZet.EveLib.EveCrestModule.RequestHandlers;

namespace eZet.EveLib.CrestClientModule {
    /// <summary>
    ///     Class CrestClient.
    /// </summary>
    public class CrestClient {
        /// <summary>
        ///     The default URI used to access the CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string DefaultUri = "http://public-crest.eveonline.com/";

        /// <summary>
        ///     The default URI used to access the authenticated CREST API. This can be overridded by setting the BasePublicUri.
        /// </summary>
        public const string AuthedUri = "https://crest-tq.eveonline.com/";

        /// <summary>
        ///     Initializes a new instance of the <see cref="CrestClient" /> class.
        /// </summary>
        public CrestClient() {
            RequestHandler = new CrestRequestHandler(new JsonSerializer());
        }

        /// <summary>
        ///     Gets or sets the request handler.
        /// </summary>
        /// <value>The request handler.</value>
        public ICrestRequestHandler RequestHandler { get; set; }
    }
}