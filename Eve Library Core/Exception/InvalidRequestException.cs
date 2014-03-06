namespace eZet.EveLib.Core.Exception {
    public class InvalidRequestException : EveLibException {
        public InvalidRequestException(string message)
            : base(message) {
        }

        public InvalidRequestException(string message, System.Exception iException)
            : base(message, iException) {
        }

        public InvalidRequestException(int code, string description, System.Exception iException)
            : base(description, iException) {
            ErrorCode = code;
        }

        public int ErrorCode { get; private set; }
    }
}