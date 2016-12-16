using System;

namespace eZet.EveLib.DynamicCrest.Exceptions {
    /// <summary>
    ///     Class ResourceNotSupportedException.
    /// </summary>
    [Serializable]
    public class ResourceNotSupportedException : Exception {
        private const string Msg =
            "You have discovered a new CREST resource that is not yet supported by this library. Please notify the developer.";

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceNotSupportedException" /> class with a specified error
        ///     message.
        /// </summary>
        public ResourceNotSupportedException()
            : base(Msg) {
        }
    }
}