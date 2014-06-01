using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;

namespace eZet.EveLib.Modules {

    /// <summary>
    /// Api key types
    /// </summary>
    public enum ApiKeyType {
        [XmlEnum("Account")] Account,
        [XmlEnum("Character")] Character,
        [XmlEnum("Corporation")] Corporation
    }

    /// <summary>
    ///     Represents an API Account key. This type can be used if the exact type of the key is unknown.
    /// </summary>
    public class AccountKey : BaseEntity {
        protected object LazyLoadLock = new object();
        private EveApiResponse<ApiKeyInfo> _apiKeyInfo;
        private bool _isInitialized;
        private bool? _isValidKey;

        /// <summary>
        ///     Creates a new instance using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public AccountKey(long keyId, string vCode) {
            BaseUri = new Uri("https://api.eveonline.com");
            KeyId = keyId;
            VCode = vCode;
        }

        /// <summary>
        /// Creates a new AccountKey using data from an existing key.
        /// </summary>
        /// <param name="key"></param>
        protected AccountKey(AccountKey key) {
            BaseUri = new Uri("https://api.eveonline.com");
            ApiKeyInfo = key.ApiKeyInfo;
            KeyId = key.KeyId;
            VCode = key.VCode;
        }

        protected EveApiResponse<ApiKeyInfo> ApiKeyInfo {
            get {
                LazyInitializer.EnsureInitialized(ref _apiKeyInfo, ref _isInitialized, ref LazyLoadLock, GetApiKeyInfo);
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
        /// Returns true if this object has already been initialized.
        /// </summary>
        public bool IsInitialized {
            get { return _isInitialized; }
        }

        /// <summary>
        /// Returns true if this is a valid key.
        /// </summary>
        public bool IsValidKey {
            get {
                if (_isValidKey != null) return _isValidKey.Value;
                lock (LazyLoadLock) {
                    if (_isValidKey == null)
                        _isValidKey = getIsValidKeyAsync(false).Result;
                }
                return _isValidKey.Value;
            }
        }

        /// <summary>
        ///     Gets the CAK access mask of this key.
        /// </summary>
        public int AccessMask {
            get { return ApiKeyInfo.Result.Key.AccessMask; }
        }

        /// <summary>
        ///     Gets the type of this key.
        /// </summary>
        public ApiKeyType KeyType {
            get { return ApiKeyInfo.Result.Key.Type; }
        }

        /// <summary>
        ///     Gets the expiration date of this key.
        /// </summary>
        public DateTime ExpiryDate {
            get { return ApiKeyInfo.Result.Key.ExpireDate; }
        }

        /// <summary>
        /// Returns a new Key for this KeyIDs actual type. It preserves any key data, so the returned object comes pre-initialized.
        /// The returned key should be cast to it's real type by using GetType() or KeyType.
        /// </summary>
        public virtual AccountKey ActualKey {
            get {
                switch (KeyType) {
                    case ApiKeyType.Character:
                        return new CharacterKey(this);
                    case ApiKeyType.Corporation:
                        return new CorporationKey(this);
                    default:
                        return this;
                }
            }
        }

        /// <summary>
        /// Initiates all properties on this object.
        /// </summary>
        /// <returns></returns>
        public virtual AccountKey Init() {
            EveApiResponse<ApiKeyInfo> unused = ApiKeyInfo;
            return this;
        }

        /// <summary>
        /// Initiates all properties on this object asynchronously.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<AccountKey> InitAsync() {
            if (IsInitialized) return this;
            EveApiResponse<ApiKeyInfo> keyInfo = await GetApiKeyInfoAsync().ConfigureAwait(false);
            LazyInitializer.EnsureInitialized(ref _apiKeyInfo, ref _isInitialized, ref LazyLoadLock, () => keyInfo);
            return this;
        }

        /// <summary>
        ///     Returns api key info. All of this information is already available as properties on this object.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ApiKeyInfo> GetApiKeyInfo() {
            return GetApiKeyInfoAsync().Result;
        }


        /// <summary>
        ///     Returns api key info. All of this information is already available as properties on this object.
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


        private async Task<bool> getIsValidKeyAsync(bool throwException) {
            try {
                EveApiResponse<ApiKeyInfo> unused = ApiKeyInfo;
            }
            catch (InvalidRequestException e) {
                if (!throwException && ((HttpWebResponse) (e.InnerException).Response).StatusCode ==
                    HttpStatusCode.Forbidden) {
                    return false;
                }
                throw;
            }
            return true;
        }
    }
}