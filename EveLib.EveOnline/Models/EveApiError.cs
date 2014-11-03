// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="EveApiError.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models {
    /// <summary>
    ///     Class EveApiError.
    /// </summary>
    [Serializable]
    [XmlRoot("eveapi", IsNullable = false)]
    public class EveApiError {
        /// <summary>
        ///     Gets the current time.
        /// </summary>
        /// <value>The current time.</value>
        [XmlIgnore]
        public DateTime CurrentTime { get; private set; }

        /// <summary>
        ///     Gets or sets the current time as string.
        /// </summary>
        /// <value>The current time as string.</value>
        [XmlElement("currentTime")]
        public string CurrentTimeAsString {
            get { return CurrentTime.ToString(XmlHelper.DateFormat); }
            set { CurrentTime = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        [XmlElement("error")]
        public ErrorData Error { get; set; }

        /// <summary>
        ///     Gets or sets the cached until.
        /// </summary>
        /// <value>The cached until.</value>
        [XmlIgnore]
        public DateTime CachedUntil { get; set; }

        /// <summary>
        ///     Gets or sets the cached until as string.
        /// </summary>
        /// <value>The cached until as string.</value>
        [XmlElement("cachedUntil")]
        public string CachedUntilAsString {
            get { return CachedUntil.ToString(XmlHelper.DateFormat); }
            set { CachedUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute("version")]
        public int Version { get; set; }

        /// <summary>
        ///     Class ErrorData.
        /// </summary>
        public class ErrorData {
            /// <summary>
            ///     Gets or sets the error code.
            /// </summary>
            /// <value>The error code.</value>
            [XmlAttribute("code")]
            public int ErrorCode { get; set; }

            /// <summary>
            ///     Gets or sets the error text.
            /// </summary>
            /// <value>The error text.</value>
            [XmlText]
            public string ErrorText { get; set; }
        }
    }
}