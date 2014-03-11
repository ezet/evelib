namespace eZet.EveLib.Core.Exception {
    public class InvalidRequestException : EveLibException {
        public InvalidRequestException(string message)
            : base(message) {
        }

        public InvalidRequestException(string message, System.Exception iException)
            : base(message, iException) {
        }

        public InvalidRequestException(string message, int code, System.Exception iException)
            : base(message, iException) {
            ErrorCode = code;
        }

        public int ErrorCode { get; private set; }
    }
}