using System;

namespace eZet.EveLib.Core.Exceptions {
    /// <summary>
    ///     Base for all EveLib Exceptions
    /// </summary>
    public class EveLibException : Exception {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="message"></param>
        protected EveLibException(string message) : base(message) {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="iException"></param>
        protected EveLibException(string message, Exception iException) : base(message, iException) {
        }
    }
}