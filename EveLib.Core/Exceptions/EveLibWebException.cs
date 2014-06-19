using System.Net;

namespace eZet.EveLib.Core.Exceptions {
    /// <summary>
    ///     Base for EveLib WebExceptions
    /// </summary>
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