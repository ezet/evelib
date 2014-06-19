using System.Net;
using eZet.EveLib.Core.Exceptions;

namespace eZet.EveLib.Modules.Exceptions {
    /// <summary>
    ///     Exception for EveCrest
    /// </summary>
    public class EveCrestException : EveLibWebException {
        /// <summary>
        ///     Creates a new Eve Crest Exception
        /// </summary>
        /// <param name="message">Error message returned by CREST</param>
        /// <param name="innerException">The WebException that caused this exception</param>
        /// <param name="key">The Key returned by CREST</param>
        /// <param name="exceptionType">The Exception Type returned by CREST</param>
        /// <param name="refId">the Ref ID returned by CREST</param>
        public EveCrestException(string message, WebException innerException, string key, string exceptionType,
            string refId)
            : base(message, innerException) {
            Key = key;
            ExceptionType = exceptionType;
            RefId = refId;
        }

        /// <summary>
        ///     Gets the Eve CREST Exception key
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        ///     Gets the Eve CREST Exception Type
        /// </summary>
        public string ExceptionType { get; private set; }

        /// <summary>
        ///     Gets the Eve CREST Exception Reference ID, if any.
        /// </summary>
        public string RefId { get; private set; }
    }
}