using System;

namespace eZet.EveLib.Modules.Util {
    public class EveCrestException : Exception {
        /// <summary>
        ///     Creates a new Eve Crest Exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="key"></param>
        /// <param name="exceptionType"></param>
        /// <param name="refId"></param>
        public EveCrestException(string message, Exception innerException, string key, string exceptionType,
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