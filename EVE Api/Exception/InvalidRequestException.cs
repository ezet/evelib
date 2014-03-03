namespace eZet.Eve.EveLib.Exception {
    public class InvalidRequestException : EveLibException {

        public InvalidRequestException(string message) : base(message) {
           
        }

        public InvalidRequestException(string message, System.Exception iException) : base(message, iException) {
            
        }
    }
}
