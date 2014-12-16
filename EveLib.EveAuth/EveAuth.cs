using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Util;
using Newtonsoft.Json;

namespace eZet.EveLib.EveAuth {
    public static class EveAuth {

        public enum Scope {
            None,
            PublicData

        }


        private static string resolveScope(Scope scope) {
            switch (scope) {
                case Scope.None:
                    return "";
                case Scope.PublicData:
                    return "publicData";
            }
            return "";
        }


        public static string GetAuthLink(string clientId, string redirectUri, Scope scope) {
            string url =
                "https://login.eveonline.com/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + resolveScope(scope);
            return url;
        }

        public static async Task<AuthResponse> Authenticate(string encodedKey, string authCode) {
            var request = HttpRequestHelper.CreateRequest(new Uri("https://login.eveonline.com/oauth/token"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Basic " + encodedKey);
            request.Method = "POST";
            HttpRequestHelper.AddPostData(request, "grant_type=authorization_code&code=" + authCode);
            var response = await HttpRequestHelper.GetResponseContentAsync(request);
            var result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }


    }
}
