namespace eZet.EveLib.Common.Exception {
    public abstract class EveLibException : System.Exception {
        protected EveLibException() {
        }

        protected EveLibException(string message) : base(message) {
        }

        protected EveLibException(string message, System.Exception iException) : base(message, iException) {
        }
    }
}