using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Util;
using Newtonsoft.Json;

namespace eZet.EveLib.EveAuth {
    public enum CrestScope {
        None,
        PublicData

    }
    public static class EveSso {


        private static string resolveScope(CrestScope crestScope) {
            switch (crestScope) {
                case CrestScope.None:
                    return "";
                case CrestScope.PublicData:
                    return "publicData";
            }
            return "";
        }


        public static string CreateAuthorizatinLink(string clientId, string redirectUri, CrestScope crestScope) {
            string url =
                "https://login.eveonline.com/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + resolveScope(crestScope);
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

        public static string Encode(string clientId, string clientSecret) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            return Convert.ToBase64String(plainTextBytes);
        }


    }
}
