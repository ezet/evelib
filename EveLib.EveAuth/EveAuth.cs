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
    /// Enum CrestScope
    /// </summary>
    public enum CrestScope {
        /// <summary>
        ///     The publicData scope
        /// </summary>
        PublicData,

        /// <summary>
        /// The character statistics read
        /// </summary>
        CharacterStatisticsRead,

        /// <summary>
        /// The character contacts read
        /// </summary>
        CharacterContactsRead,

        /// <summary>
        /// The character fittings read
        /// </summary>
        CharacterFittingsRead,

        /// <summary>
        /// The character fittings write
        /// </summary>
        CharacterFittingsWrite,
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
            Host = "login.eveonline.com";
            Protocol = "https://";
        }

        public string Protocol { get; set; }

        /// <summary>
        ///     Gets or sets the base URI.
        /// </summary>
        /// <value>The base URI.</value>
        public string Host { get; set; }

        /// <summary>
        ///     Authenticates the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="authCode">The authentication code.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> AuthenticateAsync(string encodedKey, string authCode) {
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(Protocol + Host + "/oauth/token"));
            request.Host = Host;
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
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(Protocol + Host + "/oauth/token"));
            request.Host = Host;
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
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(Protocol + Host + "/oauth/verify"));
            request.Host = Host;
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            request.Method = "GET";
            string response = await requestAsync(request).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<VerifyResponse>(response);
            return result;
        }

        private static string resolveScope(params CrestScope[] crestScopes) {
            string scope = "";
            foreach (var crestScope in crestScopes)
            switch (crestScope) {
                case CrestScope.PublicData:
                    scope += "publicData ";
                    break;
                case CrestScope.CharacterFittingsRead:
                    scope += "characterFittingsRead ";
                    break;
                case CrestScope.CharacterContactsRead:
                    scope += "characterContactsRead ";
                    break;
                case CrestScope.CharacterStatisticsRead:
                    scope += "characterStatisticsRead ";
                    break;
                case CrestScope.CharacterFittingsWrite:
                    scope += "characterFittingsWrite ";
                    break;
            }
            return scope;
        }


        /// <summary>
        ///     Creates an authentication link.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="crestScope">The crest scope.</param>
        /// <param name="state"></param>
        /// <returns>System.String.</returns>
        public string CreateAuthLink(string clientId, string redirectUri, string state, params CrestScope[] crestScope) {
            string url =
                Protocol + Host + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId +
                "&scope=" + resolveScope(crestScope) + "&state=" + state;
            return url;
        }


        /// <summary>
        /// Creates the authentication link.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="state">The state.</param>
        /// <param name="scopes">The scopes.</param>
        /// <returns>System.String.</returns>
        public string CreateAuthLink(string clientId, string redirectUri, string state, string scopes) {
            string url =
                Protocol + Host + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId +
                "&scope=" + scopes + "&state=" + state;
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