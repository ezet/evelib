namespace eZet.EveLib {
    public class AuthResponse {

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }

        public string RefreshToken { get; set; }

    }
}
