using System.Diagnostics.CodeAnalysis;
using System.Net;
using eZet.EveLib.Core.Exceptions;

namespace eZet.EveLib.EveXmlModule.Exceptions {
    /// <summary>
    ///     Exception class for the Eve Online API.
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class EveXmlException : EveLibWebException {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="message">Messaged returned by the Eve Online API</param>
        /// <param name="code">Error code returned by the Eve Online API</param>
        /// <param name="iException">The WebException thrown by the request</param>
        public EveXmlException(string message, int code, WebException iException)
            : base(message, iException) {
            ErrorCode = code;
        }

        /// <summary>
        ///     Gets the error code returned by the Eve Online API.
        /// </summary>
        public int ErrorCode { get; private set; }
    }
}