using System;
using System.Net;
using System.Runtime.Serialization;

namespace eZet.EveLib.Core.Exceptions {
    /// <summary>
    ///     Base for EveLib WebExceptions
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class EveLibWebException : EveLibException {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="iException"></param>
        public EveLibWebException(string message, WebException iException)
            : base(message, iException) {
            WebException = iException;
        }

        /// <summary>
        ///     The inner exception
        /// </summary>
        public WebException WebException { get; set; }

    }
}