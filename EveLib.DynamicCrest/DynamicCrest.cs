using System;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.DynamicCrest.Exceptions;
using eZet.EveLib.EveAuthModule;

namespace eZet.EveLib.DynamicCrest {
    public class DynamicCrest {
        /// <summary>
        ///     Enum EveCrest Access Mode
        /// </summary>
        public enum CrestMode {
            /// <summary>
            ///     Public CREST
            /// </summary>
            Public,

            /// <summary>
            ///     Authenticated CREST. This requires a valid AccessToken or a valid RefreshToken and EncryptedKey
            /// </summary>
            Authenticated
        }

        public static string DefaultHost = "https://crest-tq.eveonline.com/";


        /// <summary>
        ///     Initializes a new instance of the <see cref="EveCrest" /> class, in Public mode.
        /// </summary>
        public DynamicCrest() {
            RequestHandler = new DynamicCrestRequestHandler(new JsonSerializer("yyyy.MM.dd HH:mm:ss"));
            //ImageRequestHandler = new ImageRequestHandler();
            ApiPath = "/";
            Host = DefaultHost;
            Mode = CrestMode.Public;
            EnableRootCache = true;
            EnableAutomaticPaging = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveCrest" /> class, in Authenticated mode.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public DynamicCrest(string accessToken)
            : this() {
            AccessToken = accessToken;
            Mode = CrestMode.Authenticated;
            EveAuth = new EveAuth();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EveCrest" /> class, in Authenticated mode.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="encodedKey">The encoded key.</param>
        public DynamicCrest(string refreshToken, string encodedKey)
            : this() {
            RefreshToken = refreshToken;
            AccessToken = "";
            EncodedKey = encodedKey;
            Mode = CrestMode.Authenticated;
            EveAuth = new EveAuth();
            EnableAutomaticTokenRefresh = true;
        }

        public string Host { get; set; }

        public DynamicCrestRequestHandler RequestHandler { get; set; }


        /// <summary>
        ///     Gets or sets the IEveAuth instance used for Eve SSO.
        /// </summary>
        /// <value>The eve sso.</value>
        public IEveAuth EveAuth { get; set; }


        /// <summary>
        ///     Gets or sets the CREST Access Token
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the refresh token.
        /// </summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Gets or sets the encoded key. This is required to refresh access tokens.
        /// </summary>
        /// <value>The encoded key.</value>
        public string EncodedKey { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether EveCrest is allowed to cache the CrestRoot object. This is enabled by
        ///     default.
        /// </summary>
        /// <value><c>true</c> if [allow root cache]; otherwise, <c>false</c>.</value>
        public bool EnableRootCache { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to allow the library to automatically refresh the access token. This
        ///     requires a valid RefreshToken and EncryptedKey to be set. This is enabled by default if using the RefreshToken
        ///     ctor.
        /// </summary>
        /// <value><c>true</c> if [allow automatic refresh]; otherwise, <c>false</c>.</value>
        public bool EnableAutomaticTokenRefresh { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to allow QueryAsync() methods to allow automatic paging. This may perform
        ///     additional web requests.
        /// </summary>
        /// <value><c>true</c> if [allow automatic paging]; otherwise, <c>false</c>.</value>
        public bool EnableAutomaticPaging { get; set; }

        /// <summary>
        ///     Gets the CREST access mode.
        /// </summary>
        /// <value>The mode.</value>
        public CrestMode Mode { get; }

        public string ApiPath { get; set; }

        public Task<Expando> GetAsync(dynamic url) {
            var uri = "";
            if (url is string) {
                uri = url;
            }
            else if (url is ExpandoObject) {
                uri = url.href;
            }
            return getAsync<ExpandoObject>(uri);
        }

        public Task PostAsync(object url, object entity) {
            return postAsync(entity, (string) url);
        }

        /// <summary>
        ///     post as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        private async Task<string> postAsync(object entity, string url) {
            var data = RequestHandler.Serializer.Serialize(entity);
            try {
                return
                    await RequestHandler.PostAsync(new Uri(url), AccessToken, data).ConfigureAwait(false);
            }
            catch (EveCrestException e) {
                await tryRefreshTokenAsync(e).ConfigureAwait(false);
                return
                    await RequestHandler.PostAsync(new Uri(url), AccessToken, data).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///     Gets the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The path.</param>
        /// <returns>System.Threading.Tasks.Task&lt;T&gt;.</returns>
        private async Task<Expando> getAsync<T>(string url) {
            T response;
            //url = string.IsNullOrEmpty(url) ? Host : url;
            var uri = new Uri(url);
            if (Mode == CrestMode.Authenticated) {
                try {
                    response =
                        await RequestHandler.GetAsync<T>(uri, AccessToken).ConfigureAwait(false);
                }
                catch (EveCrestException e) {
                    await tryRefreshTokenAsync(e).ConfigureAwait(false);
                    response =
                        await RequestHandler.GetAsync<T>(uri, AccessToken).ConfigureAwait(false);
                }
            }
            else {
                response = await RequestHandler.GetAsync<T>(uri, null).ConfigureAwait(false);
            }
            //response?.Inject(this);
            var res = new Expando(response);
            res.DynamicCrest = this;
            return res;
        }

        /// <summary>
        ///     Refreshes the access token. This requires a valid RefreshToken and EncodedKey to have been set.
        ///     The EveCrest instance is updated with the new access token.
        /// </summary>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        public async Task<AuthResponse> RefreshAccessTokenAsync() {
            var response = await EveAuth.RefreshAsync(EncodedKey, RefreshToken).ConfigureAwait(false);
            AccessToken = response.AccessToken;
            RefreshToken = response.RefreshToken;
            return response;
        }

        /// <summary>
        ///     Tries the refresh token asynchronous.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        private Task tryRefreshTokenAsync(EveCrestException e) {
            if (!EnableAutomaticTokenRefresh) throw e;
            var error = e.WebException.Response as HttpWebResponse;
            if (error == null || error.StatusCode != HttpStatusCode.Unauthorized) throw e;
            return RefreshAccessTokenAsync();
        }
    }

    internal interface IEditableEntity {
    }
}