using System;
using System.Threading.Tasks;
using eZet.EveLib.Core.Util;
using Newtonsoft.Json;

namespace eZet.EveLib.EveAuth {
    /// <summary>
    /// Enum CrestScope
    /// </summary>
    public enum CrestScope {
        /// <summary>
        /// The 360 noscope
        /// </summary>
        None,
        /// <summary>
        /// The publicData scope
        /// </summary>
        PublicData

    }
    /// <summary>
    /// Class EveSso. A helper class for Eve Online SSO authentication
    /// </summary>
    public class EveSso {

        /// <summary>
        /// Gets or sets the base URI.
        /// </summary>
        /// <value>The base URI.</value>
        public static string BaseUri { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EveSso"/> class.
        /// </summary>
        public EveSso() {
            BaseUri = "https://login.eveonline.com";
        }


        private static string resolveScope(CrestScope crestScope) {
            switch (crestScope) {
                case CrestScope.None:
                    return "";
                case CrestScope.PublicData:
                    return "publicData";
            }
            return "";
        }


        /// <summary>
        /// Creates an authentication link.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="crestScope">The crest scope.</param>
        /// <returns>System.String.</returns>
        public string CreateAuthLink(string clientId, string redirectUri, CrestScope crestScope) {
            string url =
                BaseUri + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + resolveScope(crestScope);
            return url;
        }

        /// <summary>
        /// Authenticates the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="authCode">The authentication code.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> Authenticate(string encodedKey, string authCode) {
            var request = HttpRequestHelper.CreateRequest(new Uri(BaseUri + "/oauth/token"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Basic " + encodedKey);
            request.Method = "POST";
            HttpRequestHelper.AddPostData(request, "grant_type=authorization_code&code=" + authCode);
            var response = await HttpRequestHelper.GetResponseContentAsync(request);
            var result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }

        /// <summary>
        /// Refreshes the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> Refresh(string encodedKey, string refreshToken) {
            var request = HttpRequestHelper.CreateRequest(new Uri(BaseUri + "/oauth/token"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Basic " + encodedKey);
            request.Method = "POST";
            HttpRequestHelper.AddPostData(request, "grant_type=refresh_token&code=" + refreshToken);
            var response = await HttpRequestHelper.GetResponseContentAsync(request);
            var result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }

        /// <summary>
        /// Encodes the specified client identifier and secret.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <returns>System.String.</returns>
        public static string Encode(string clientId, string clientSecret) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            return Convert.ToBase64String(plainTextBytes);
        }


    }
}
