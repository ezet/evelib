// ***********************************************************************
// Assembly         : EveLib.EveAuth
// Author           : Lars Kristian
// Created          : 12-10-2014
//
// Last Modified By : Lars Kristian
// Last Modified On : 12-17-2014
// ***********************************************************************
// <copyright file="EveAuth.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.Core.Util;
using Newtonsoft.Json;

namespace eZet.EveLib.EveAuthModule {
    /// <summary>
    ///     Enum CrestScope
    /// </summary>
    public enum CrestScope {
        /// <summary>
        ///     No scope
        /// </summary>
        None,

        /// <summary>
        ///     The publicData scope
        /// </summary>
        PublicData
    }

    /// <summary>
    ///     Class EveAuth. A helper class for Eve Online SSO authentication
    /// </summary>
    public class EveAuth : IEveAuth {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveAuth" /> class.
        /// </summary>
        public EveAuth() {
            BaseUri = "https://login.eveonline.com";
        }

        /// <summary>
        ///     Gets or sets the base URI.
        /// </summary>
        /// <value>The base URI.</value>
        public string BaseUri { get; set; }

        /// <summary>
        ///     Authenticates the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="authCode">The authentication code.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> AuthenticateAsync(string encodedKey, string authCode) {
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(BaseUri + "/oauth/token"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Basic " + encodedKey);
            request.Method = "POST";
            HttpRequestHelper.AddPostData(request, "grant_type=authorization_code&code=" + authCode);
            string response = await requestAsync(request).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }

        /// <summary>
        ///     Refreshes the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> RefreshAsync(string encodedKey, string refreshToken) {
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(BaseUri + "/oauth/token"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Basic " + encodedKey);
            request.Method = "POST";
            HttpRequestHelper.AddPostData(request, "grant_type=refresh_token&refresh_token=" + refreshToken);
            string response = await requestAsync(request).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }

        /// <summary>
        ///     Verifies the access token
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>Task&lt;VerifyResponse&gt;.</returns>
        public async Task<VerifyResponse> VerifyAsync(string accessToken) {
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(BaseUri + "/oauth/verify"));
            request.Host = "login.eveonline.com";
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            request.Method = "GET";
            string response = await requestAsync(request).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<VerifyResponse>(response);
            return result;
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
        ///     Creates an authentication link.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="crestScope">The crest scope.</param>
        /// <param name="state"></param>
        /// <returns>System.String.</returns>
        public string CreateAuthLink(string clientId, string redirectUri, CrestScope crestScope, string state = "defaultState") {
            string url =
                BaseUri + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId +
                "&scope=" + resolveScope(crestScope) + "&state=" + state;
            return url;
        }

        /// <summary>
        ///     Encodes the specified client identifier and secret.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <returns>System.String.</returns>
        public static string Encode(string clientId, string clientSecret) {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            return Convert.ToBase64String(plainTextBytes);
        }

        private async Task<string> requestAsync(HttpWebRequest request) {
            try {
                return await HttpRequestHelper.GetResponseContentAsync(request).ConfigureAwait(false);
            }
            catch (WebException e) {
                _trace.TraceEvent(TraceEventType.Error, 0, "Auth failed.");
                var response = (HttpWebResponse) e.Response;

                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) throw new EveAuthException("Undefined error", e);
                using (var reader = new StreamReader(responseStream)) {
                    string data = reader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError) throw new EveAuthException(data, e);
                    var error = JsonConvert.DeserializeObject<AuthError>(data);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Message: {0}, Key: {1}",
                        "Exception Type: {2}, Ref ID: {3}", error.Message, error.Key, error.ExceptionType,
                        error.RefId);
                    throw new EveAuthException(error.Message, e, error.Key, error.ExceptionType, error.RefId);
                }
            }
        }
    }
}