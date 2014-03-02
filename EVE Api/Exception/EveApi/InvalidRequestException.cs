namespace eZet.Eve.EveLib.Exception.EveApi {

    public class InvalidRequestException : System.Exception {

        public int ErrorCode { get; private set; }

        public string Description { get; private set; }

        public InvalidRequestException(int code, string description) {
            
        }

    }
}
