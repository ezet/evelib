using System.Net;

namespace eZet.EveLib.Core.Exception {
    public class InvalidRequestException : EveLibException {

        public new WebException InnerException { get; set; }
        public InvalidRequestException(string message)
            : base(message) {
        }

        public InvalidRequestException(string message, WebException iException)
            : base(message, iException) {
            InnerException = iException;
        }

        public InvalidRequestException(string message, int code, WebException iException)
            : base(message, iException) {
            ErrorCode = code;
            InnerException = iException;
        }

        public int ErrorCode { get; private set; }
    }
}