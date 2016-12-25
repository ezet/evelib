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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.Core.Util;
using Newtonsoft.Json;

namespace eZet.EveLib.EveAuthModule
{
    /// <summary>
    /// Enum CrestScope
    /// </summary>
    public enum CrestScope
    {
        /// <summary>
        ///     The publicData scope
        /// </summary>
        PublicData,

        /// <summary>
        /// The character contacts read
        /// </summary>
        CharacterContactsRead,

        /// <summary>
        /// The characters contacts write
        /// </summary>
        CharactersContactsWrite,

        /// <summary>
        /// The character fittings read
        /// </summary>
        CharacterFittingsRead,

        /// <summary>
        /// The character fittings write
        /// </summary>
        CharacterFittingsWrite,

        /// <summary>
        /// The character location read
        /// </summary>
        CharacterLocationRead,

        /// <summary>
        /// The character navigation write
        /// </summary>
        CharacterNavigationWrite,

        /// <summary>
        /// Allows an application to read your character’s account information.
        /// </summary>
        CharacterAccountRead,

        /// <summary>
        /// Allows an application to read your character’s assets.
        /// </summary>
        CharacterAssetsRead,

        /// <summary>
        /// Allows an application to read your character’s bookmarks.
        /// </summary>
        CharacterBookmarksRead,

        /// <summary>
        /// Allows an application to read your character’s calendar.
        /// </summary>
        CharacterCalendarRead,

        /// <summary>
        /// Allows an application to read a list of the chat channels your character is in.
        /// </summary>
        CharacterChatChannelsRead,

        /// <summary>
        /// Allows an application to read a list of your character’s clones.
        /// </summary>
        CharacterClonesRead,

        /// <summary>
        /// Allows access to create and update your character’s contacts.
        /// </summary>
        CharacterContactsWrite,

        /// <summary>
        /// Allows an application to read your character’s FW information.
        /// </summary>
        CharacterFactionalWarfareRead,

        /// <summary>
        /// Allows an application to read your character’s industry jobs.
        /// </summary>
        CharacterIndustryJobsRead,

        /// <summary>
        /// Allows an application to read your character’s killmails. Only killmail that the character is the victim or the finalBlow will be returned with this scope.
        /// </summary>
        CharacterKillsRead,

        /// <summary>
        /// Allows an application to read your character’s mail.
        /// </summary>
        CharacterMailRead,

        /// <summary>
        /// Allows an application to read your character’s market orders.
        /// </summary>
        CharacterMarketOrdersRead,

        /// <summary>
        /// CharacterMedalsRead
        /// </summary>
        CharacterMedalsRead,

        /// <summary>
        /// Allows an application to read your character’s notifications.
        /// </summary>
        CharacterNotificationsRead,

        /// <summary>
        /// Allows an application to read your character’s research information.
        /// </summary>
        CharacterResearchRead,

        /// <summary>
        /// Allows an application to read your character’s skills.
        /// </summary>
        CharacterSkillsRead,

        /// <summary>
        /// Allows an application to read your character’s wallet.
        /// </summary>
        CharacterWalletRead

    }

    /// <summary>
    ///     Class EveAuth. A helper class for Eve Online SSO authentication
    /// </summary>
    public class EveAuth : IEveAuth
    {
        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveAuth" /> class.
        /// </summary>
        public EveAuth()
        {
            Host = "login.eveonline.com";
            Protocol = "https://";
        }

        /// <summary>
        /// Initializes static members of the <see cref="EveAuth"/> class.
        /// </summary>
        static EveAuth()
        {
            AllCrestScopes = Enum.GetValues(typeof(CrestScope)).Cast<CrestScope>().ToArray();
        }

        /// <summary>
        /// Gets all crest scopes.
        /// </summary>
        /// <value>All crest scopes.</value>
        public static CrestScope[] AllCrestScopes { get; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
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
        public async Task<AuthResponse> AuthenticateAsync(string encodedKey, string authCode)
        {
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
        public async Task<AuthResponse> RefreshAsync(string encodedKey, string refreshToken)
        {
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
        public async Task<VerifyResponse> VerifyAsync(string accessToken)
        {
            HttpWebRequest request = HttpRequestHelper.CreateRequest(new Uri(Protocol + Host + "/oauth/verify"));
            request.Host = Host;
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            request.Method = "GET";
            string response = await requestAsync(request).ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<VerifyResponse>(response);
            return result;
        }

        private static string resolveScope(params CrestScope[] crestScopes)
        {
            var scope = "";
            foreach (var crestScope in crestScopes)
            {
                switch (crestScope)
                {
                    case CrestScope.PublicData:
                        scope += "publicData";
                        break;
                    case CrestScope.CharacterContactsRead:
                        scope += "characterContactsRead";
                        break;
                    case CrestScope.CharactersContactsWrite:
                        scope += "characterContactsWrite";
                        break;
                    case CrestScope.CharacterFittingsRead:
                        scope += "characterFittingsRead";
                        break;
                    case CrestScope.CharacterFittingsWrite:
                        scope += "characterFittingsWrite";
                        break;
                    case CrestScope.CharacterLocationRead:
                        scope += "characterLocationRead";
                        break;
                    case CrestScope.CharacterNavigationWrite:
                        scope += "characterNavigationWrite";
                        break;
                    case CrestScope.CharacterAssetsRead:
                        scope += "characterAssetsRead";
                        break;
                    case CrestScope.CharacterBookmarksRead:
                        scope += "characterBookmarksRead";
                        break;
                    case CrestScope.CharacterAccountRead:
                        scope += "characterAccountRead";
                        break;
                    case CrestScope.CharacterCalendarRead:
                        scope += "characterCalendarRead";
                        break;
                    case CrestScope.CharacterChatChannelsRead:
                        scope += "characterChatChannelsRead";
                        break;
                    case CrestScope.CharacterClonesRead:
                        scope += "characterClonesRead";
                        break;
                    case CrestScope.CharacterContactsWrite:
                        scope += "characterContactsWrite";
                        break;
                    case CrestScope.CharacterFactionalWarfareRead:
                        scope += "characterFactionalWarfareRead";
                        break;
                    case CrestScope.CharacterIndustryJobsRead:
                        scope += "characterIndustryJobsRead";
                        break;
                    case CrestScope.CharacterSkillsRead:
                        scope += "characterSkillsRead";
                        break;
                    case CrestScope.CharacterWalletRead:
                        scope += "characterWalletRead";
                        break;
                    case CrestScope.CharacterResearchRead:
                        scope += "characterResearchRead";
                        break;
                    case CrestScope.CharacterNotificationsRead:
                        scope += "characterNotificationsRead";
                        break;
                    case CrestScope.CharacterMedalsRead:
                        scope += "characterMedalsRead";
                        break;
                    case CrestScope.CharacterMarketOrdersRead:
                        scope += "characterMarketOrdersRead";
                        break;
                    case CrestScope.CharacterMailRead:
                        scope += "characterMailRead";
                        break;
                    case CrestScope.CharacterKillsRead:
                        scope += "characterKillsRead";
                        break;
                    default:
                        break;
                }
                scope += " ";
            }
            return crestScopes.Length > 0 ? scope.Substring(0, scope.Length - 1) : scope;
        }


        /// <summary>
        ///     Creates an authentication link.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="crestScope">The crest scope.</param>
        /// <param name="state"></param>
        /// <returns>System.String.</returns>
        public string CreateAuthLink(string clientId, string redirectUri, string state, params CrestScope[] crestScope)
        {
            string url = Protocol + Host + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + resolveScope(crestScope) + "&state=" + state;
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
        public string CreateAuthLink(string clientId, string redirectUri, string state, string scopes)
        {
            string url = Protocol + Host + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + scopes + "&state=" + state;
            return url;
        }

        /// <summary>
        ///     Encodes the specified client identifier and secret.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <returns>System.String.</returns>
        public static string Encode(string clientId, string clientSecret)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(clientId + ":" + clientSecret);
            return Convert.ToBase64String(plainTextBytes);
        }

        private async Task<string> requestAsync(HttpWebRequest request)
        {
            try
            {
                return await HttpRequestHelper.GetResponseContentAsync(request).ConfigureAwait(false);
            }
            catch (WebException e)
            {
                _trace.TraceEvent(TraceEventType.Error, 0, "Auth failed.");
                var response = (HttpWebResponse)e.Response;

                Stream responseStream = response.GetResponseStream();
                if (responseStream == null) throw new EveAuthException("Undefined error", e);
                using (var reader = new StreamReader(responseStream))
                {
                    string data = reader.ReadToEnd();
                    if (response.StatusCode == HttpStatusCode.InternalServerError) throw new EveAuthException(data, e);
                    var error = JsonConvert.DeserializeObject<AuthError>(data);
                    _trace.TraceEvent(TraceEventType.Verbose, 0, "Message: {0}, Key: {1}", "Exception Type: {2}, Ref ID: {3}", error.Message, error.Key, error.ExceptionType, error.RefId);
                    throw new EveAuthException(error.Message, e, error.Key, error.ExceptionType, error.RefId);
                }
            }
        }
    }
}