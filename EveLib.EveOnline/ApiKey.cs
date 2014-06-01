using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Core.Util;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;

namespace eZet.EveLib.Modules {

    public enum ApiKeyType {
        [XmlEnum("Account")]
        Account,
        [XmlEnum("Character")]
        Character,
        [XmlEnum("Corporation")]
        Corporation
    }

    /// <summary>
    ///     Base class for Key entities, providing common properties and methods.
    /// </summary>
    public class ApiKey : BaseEntity {
        private bool? _isValidKey;

        private EveApiResponse<ApiKeyInfo> _apiKeyInfo;

        protected object LazyLoadLock = new object();
        private bool _isInitialized;

        protected EveApiResponse<ApiKeyInfo> ApiKeyInfo {
            get {
                LazyInitializer.EnsureInitialized(ref _apiKeyInfo, ref _isInitialized, ref LazyLoadLock, GetApiKeyInfo);
                return _apiKeyInfo;
            }
        }

        protected AsyncLazy<EveApiResponse<ApiKeyInfo>> KeyInfo { get; set; }

        /// <summary>
        ///     Creates a new instance using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public ApiKey(long keyId, string vCode) {
            BaseUri = new Uri("https://api.eveonline.com");
            KeyId = keyId;
            VCode = vCode;
            KeyInfo = new AsyncLazy<EveApiResponse<ApiKeyInfo>>(() => GetApiKeyInfoAsync());
        }

        /// <summary>
        ///     Gets the key ID for this key.
        /// </summary>
        public long KeyId { get; protected set; }

        /// <summary>
        ///     Gets the VCode for this key.
        /// </summary>
        public string VCode { get; protected set; }

        public bool IsInitialized {
            get { return _isInitialized; }
        }

        public virtual ApiKey Init() {
            var unused = ApiKeyInfo;
            return this;
        }

        public virtual async Task<ApiKey> InitAsync() {
            if (IsInitialized) return this;
            var keyInfo = await GetApiKeyInfoAsync().ConfigureAwait(false);
            LazyInitializer.EnsureInitialized(ref _apiKeyInfo, ref _isInitialized, ref LazyLoadLock, () => keyInfo);
            return this;
        }

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
        public ApiKeyType? KeyType {
            get { return ApiKeyInfo.Result.Key.Type; }
        }

        /// <summary>
        ///     Gets the expiration date of this key.
        /// </summary>
        public DateTime ExpiryDate {
            get { return ApiKeyInfo.Result.Key.ExpireDate; }
        }

        public ApiKey ActualKey {
            get {
                switch (KeyType) {
                    case ApiKeyType.Character:
                        return new CharacterKey(KeyId, VCode);
                    case ApiKeyType.Corporation:
                        return new CorporationKey(KeyId, VCode);
                    default:
                        return this;
                }
            }
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
        ///     Returns a list of all characters on an account.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CharacterList> GetCharacterList() {
            return GetCharacterListAsync().Result;
        }

        /// <summary>
        ///     Returns a list of all characters on an account.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<CharacterList>> GetCharacterListAsync() {
            //const int mask = 0;
            const string uri = "/account/Characters.xml.aspx";
            return requestAsync<CharacterList>(uri, this);
        }


        private async Task<bool> getIsValidKeyAsync(bool throwException) {
            try {
                var unused = await KeyInfo;
            } catch (InvalidRequestException e) {
                if (!throwException && ((HttpWebResponse)(e.InnerException).Response).StatusCode ==
                    HttpStatusCode.Forbidden) {
                    return false;
                }
                throw;
            }
            return true;
        }

    }
}