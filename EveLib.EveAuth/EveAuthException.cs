using System.Diagnostics.CodeAnalysis;
using System.Net;
using eZet.EveLib.Core.Exceptions;

namespace eZet.EveLib.EveAuthModule {
    /// <summary>
    ///     Exception for EveCrest
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class EveAuthException : EveLibWebException {
        /// <summary>
        ///     Creates a new Eve Crest Exception
        /// </summary>
        /// <param name="message">Error message returned by CREST</param>
        /// <param name="innerException">The WebException that caused this exception</param>
        /// <param name="key">The Key returned by CREST</param>
        /// <param name="exceptionType">The Exception Type returned by CREST</param>
        /// <param name="refId">the Ref ID returned by CREST</param>
        public EveAuthException(string message, WebException innerException, string key, string exceptionType,
            string refId)
            : base(message, innerException) {
            Key = key;
            ExceptionType = exceptionType;
            RefId = refId;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveAuthException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public EveAuthException(string message, WebException innerException)
            : base(message, innerException) {
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