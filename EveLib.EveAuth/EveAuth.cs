using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Serializers;
using eZet.EveLib.Core.Util;
using Newtonsoft.Json;

namespace eZet.EveLib.EveAuth {
    public static class EveAuth {

        public static async Task<AuthResponse> Authenticate(string clientCode, string authCode) {
            var request = HttpRequestHelper.CreateRequest(new Uri("https://login.eveonline.com/oauth/token"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Basic " + clientCode);
            request.Method = "POST";
            HttpRequestHelper.AddPostData(request, "grant_type=authorization_code&code=" + authCode);
            var response = await HttpRequestHelper.GetResponseContentAsync(request);
            var result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }
    }
}
