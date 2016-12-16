using System.Runtime.Serialization;

namespace eZet.EveLib.DynamicCrest.Models {
    /// <summary>
    ///     Represents a CREST exception
    /// </summary>
    [DataContract]
    public class CrestError {
        /// <summary>
        ///     The error message
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        ///     The error key
        /// </summary>
        [DataMember(Name = "key")]
        public string Key { get; set; }

        /// <summary>
        ///     The exception type
        /// </summary>
        [DataMember(Name = "exceptionType")]
        public string ExceptionType { get; set; }

        /// <summary>
        ///     The exception reference ID, if any
        /// </summary>
        [DataMember(Name = "refID")]
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is localized.
        /// </summary>
        /// <value><c>true</c> if this instance is localized; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isLocalized")]
        public bool IsLocalized { get; set; }
    }
}