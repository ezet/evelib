// ***********************************************************************
// Assembly         : EveLib.EveOnline
// Author           : Lars Kristian
// Created          : 03-06-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 06-19-2014
// ***********************************************************************
// <copyright file="ErrorList.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Misc {
    /// <summary>
    ///     Class ErrorList.
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ErrorList {
        /// <summary>
        ///     Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Error> Errors { get; set; }

        /// <summary>
        ///     Class Error.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Error {
            /// <summary>
            ///     Gets or sets the error code.
            /// </summary>
            /// <value>The error code.</value>
            [XmlAttribute("errorCode")]
            public int ErrorCode { get; set; }

            /// <summary>
            ///     Gets or sets the error text.
            /// </summary>
            /// <value>The error text.</value>
            [XmlAttribute("errorText")]
            public string ErrorText { get; set; }
        }
    }
}