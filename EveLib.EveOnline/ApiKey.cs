using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Exceptions;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Eve Online API Key Types
    /// </summary>
    public enum ApiKeyType {
        /// <summary>
        ///     Key with access to all characters.
        /// </summary>
        [XmlEnum("Account")] Account,

        /// <summary>
        ///     Key with access to a single character.
        /// </summary>
        [XmlEnum("Character")] Character,

        /// <summary>
        ///     Key with access to a single corporation.
        /// </summary>
        [XmlEnum("Corporation")] Corporation
    }


    /// <summary>
    ///     Represents a general API Account key. This type can be used if the exact type of the key is unknown, but prevents
    ///     access to Characters and Corporations.
    /// </summary>
    public class ApiKey : BaseEntity {
        private ApiKeyInfo.ApiKeyData _apiKeyInfo;
        private bool _isInitialized;
        private bool? _isValidKey;
        private object _lazyLoadLock = new object();

        /// <summary>
        ///     Creates a new instance using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public ApiKey(long keyId, string vCode) {
            KeyId = keyId;
            VCode = vCode;
        }

        /// <summary>
        ///     Creates a new ApiKey using data from an existing key.
        /// </summary>
        /// <param name="key"></param>
        protected ApiKey(ApiKey key) {
            Contract.Requires(key != null);
            ApiKeyInfo = key.ApiKeyInfo;
            _isValidKey = key._isValidKey;
            KeyId = key.KeyId;
            VCode = key.VCode;
        }

        /// <summary>
        ///     Gets or sets the ApiKeyData used to initialize properties.
        /// </summary>
        protected ApiKeyInfo.ApiKeyData ApiKeyInfo {
            get {
                Init();
                return _apiKeyInfo;
            }
            set { _apiKeyInfo = value; }
        }

        /// <summary>
        ///     Gets the key ID for this key.
        /// </summary>
        public long KeyId { get; protected set; }

        /// <summary>
        ///     Gets the VCode for this key.
        /// </summary>
        public string VCode { get; protected set; }

        /// <summary>
        ///     Returns true if this key is initialized, or false otherwise.
        /// </summary>
        public bool IsInitialized {
            get { return _isInitialized; }
            private set { _isInitialized = value; }
        }

        /// <summary>
        ///     Gets the CAK access mask of this key. Note: If this object has not already been initialized, this will send a web
        ///     request to the API.
        /// </summary>
        public int AccessMask {
            get { return ApiKeyInfo.AccessMask; }
        }

        /// <summary>
        ///     Gets the type of this key. Note: If this object has not already been initialized, this will send a web request to
        ///     the API.
        /// </summary>
        public ApiKeyType KeyType {
            get { return ApiKeyInfo.Type; }
        }

        /// <summary>
        ///     Gets the expiration date of this key. Note: If this object has not already been initialized, this will send a web
        ///     request to the API.
        /// </summary>
        public DateTime ExpiryDate {
            get { return ApiKeyInfo.ExpireDate; }
        }

        /// <summary>
        ///     Returns a new Key for this KeyIDs actual type. It preserves any key data, so the returned object comes
        ///     pre-initialized.
        ///     The returned key should be cast to it's real type by using GetType().
        /// </summary>
        public virtual ApiKey GetActualKey() {
            switch (KeyType) {
                case ApiKeyType.Character:
                    return new CharacterKey(this);
                case ApiKeyType.Account:
                    return new CharacterKey(this);
                case ApiKeyType.Corporation:
                    return new CorporationKey(this);
                default:
                    return this;
            }
        }

        /// <summary>
        ///     This de-initializes the key and it's data, allowing it to be fetched again from the API with Init() or InitAsync().
        /// </summary>
        public virtual void Reset() {
            IsInitialized = false;
            ApiKeyInfo = null;
        }

        /// <summary>
        ///     Initiates all properties on this object. Method will return immediately if this object is already initialized.
        /// </summary>
        /// <returns></returns>
        public virtual ApiKey Init() {
            if (IsInitialized) return this;
            ensureInitialized().Wait();
            return this;
        }

        /// <summary>
        ///     Initiates all properties on this object asynchronously. Method will return immediately if this object is already
        ///     initialized.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ApiKey> InitAsync() {
            if (IsInitialized) return this;
            await ensureInitialized().ConfigureAwait(false);
            return this;
        }

        private async Task ensureInitialized() {
            EveApiResponse<ApiKeyInfo> result = await GetApiKeyInfoAsync().ConfigureAwait(false);
            LazyInitializer.EnsureInitialized(ref _apiKeyInfo, ref _isInitialized, ref _lazyLoadLock,
                () => result.Result.Key);
        }

        /// <summary>
        ///     Returns api key info. Calling Init() or InitAsync() will store all information from this endpoint in the key.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ApiKeyInfo> GetApiKeyInfo() {
            return GetApiKeyInfoAsync().Result;
        }


        /// <summary>
        ///     Returns api key info. Calling Init() or InitAsync() will store all information from this endpoint in the key.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<ApiKeyInfo>> GetApiKeyInfoAsync() {
            //const int mask = 0;
            const string uri = "/account/APIKeyInfo.xml.aspx";
            return requestAsync<ApiKeyInfo>(uri, this);
        }

        /// <summary>
        ///     Returns a list of all characters on this account.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CharacterList> GetCharacterList() {
            return GetCharacterListAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all characters on this account.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<CharacterList>> GetCharacterListAsync() {
            //const int mask = 0;
            const string uri = "/account/Characters.xml.aspx";
            return requestAsync<CharacterList>(uri, this);
        }


        /// <summary>
        ///     Returns true if this key is valid, otherwise false. Note: If this object has not already been initialized, this
        ///     will send a web request to the API.
        /// </summary>
        /// <returns></returns>
        public bool IsValidKey() {
            if (_isValidKey.HasValue) return _isValidKey.Value;
            try {
                Init();
            }
            catch (AggregateException e) {
                if (e.InnerException.GetType() == typeof (EveOnlineException)) {
                    var ire = (EveOnlineException) e.InnerException;
                    if (((HttpWebResponse) ire.WebException.Response).StatusCode == HttpStatusCode.Forbidden) {
                        _isValidKey = false;
                    }
                }
                else throw;
            }
            return _isValidKey.GetValueOrDefault(true);
        }

        /// <summary>
        ///     Returns true if this key is valid, otherwise false. Note: If this object has not already been initialized, this
        ///     will send a web request to the API.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsValidKeyAsync() {
            if (_isValidKey.HasValue) return _isValidKey.Value;
            try {
                await InitAsync().ConfigureAwait(false);
            }
            catch (EveOnlineException e) {
                    if (((HttpWebResponse) e.WebException.Response).StatusCode == HttpStatusCode.Forbidden) {
                        _isValidKey = false;
                    }
                else throw;
            }
            return _isValidKey.GetValueOrDefault(true);
        }
    }
}