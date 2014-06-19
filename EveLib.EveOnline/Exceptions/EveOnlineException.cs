using System.Net;
using eZet.EveLib.Core.Exceptions;

namespace eZet.EveLib.Modules.Exceptions {
    /// <summary>
    ///     Exception class for the Eve Online API.
    /// </summary>
    public class EveOnlineException : EveLibWebException {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="message">Messaged returned by the Eve Online API</param>
        /// <param name="code">Error code returned by the Eve Online API</param>
        /// <param name="iException">The WebException thrown by the request</param>
        public EveOnlineException(string message, int code, WebException iException)
            : base(message, iException) {
            ErrorCode = code;
        }

        /// <summary>
        ///     Gets the error code returned by the Eve Online API.
        /// </summary>
        public int ErrorCode { get; private set; }
    }
}