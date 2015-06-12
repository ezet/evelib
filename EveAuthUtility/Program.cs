using System;
using eZet.EveLib.EveAuthModule;

namespace eZet.EveLib.EveAuthUtility {
    public class EveAuthUtility {

        static public EveAuth Auth = new EveAuth();
        static void Main(string[] args) {
            Console.WriteLine("Simple tool for obtaining access and refresh tokens from the Eve Online SSO.");
            Console.WriteLine("No information is stored, some data is exchanged with the eve login servers.");
            Console.WriteLine("The sourcecode is available here: https://github.com/ezet/evelib");
            Console.WriteLine("You need to register an application at https://developers.eveonline.com, \nthe callback URL can be set to '/'.");
            Console.WriteLine("Your client ID and secret key will be provided by \nhttps://developers.eveonline.com after registering an application.\n");

            Console.WriteLine("For easier editing, rightclick the title bar for the console window, \nthen go to Properties -> Options -> enable QuickEdit mode.\n");
            Console.Write("Enter your client ID: ");
            string clientId = Console.ReadLine();
            Console.Write("Enter your secret key: ");
            string secret = Console.ReadLine();
            string encodedKey = EveAuth.Encode(clientId, secret);
            string authLink = Auth.CreateAuthLink(clientId, "/", CrestScope.PublicData);
            Console.WriteLine("Please log in using the following link: ");
            Console.WriteLine(authLink);
            Console.WriteLine("After logging in, copy the full URL from your browser.");
            Console.WriteLine("Enter the full URL: ");
            string url = Console.ReadLine();
            string authCode = "";
            try {
                int start = url.IndexOf("?code=", System.StringComparison.Ordinal);
                int end = url.IndexOf("&state", System.StringComparison.Ordinal);
                authCode = url.Substring(start + 6, end - start - 6);
            } catch (Exception) {
                Console.WriteLine("Unable to locate authentication code, please try again.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Authentication code found: " + authCode);
            Console.WriteLine("Authenticating...");
            AuthResponse response;
            try {
                response = Auth.AuthenticateAsync(encodedKey, authCode).Result;
            } catch (Exception) {
                Console.WriteLine("Authentication unsuccessfull, please try again.");
                return;
            }
            Console.WriteLine("Authentication successfull!");
            Console.WriteLine("\nAccess token:\n" + response.AccessToken);
            Console.WriteLine("\nRefresh token:\n" + response.RefreshToken);
            Console.WriteLine("\nEncoded key:\n" + encodedKey);
            Console.ReadKey();
        }
    }
}
