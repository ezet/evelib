using System;
using System.Diagnostics.Contracts;
using System.Net;
using eZet.EveLib.Core.Exception;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;

namespace eZet.EveLib.Modules {
    public enum ApiKeyType {
        Account,
        Character,
        Corporation
    }

    /// <summary>
    ///     Base class for Key entities, providing common properties and methods.
    /// </summary>
    public class ApiKey : BaseEntity {
        private int _accessMask;
        private DateTime _expireTime;
        private ApiKeyType? _type;
        private bool? _isValidKey;

        protected readonly object LazyLoadLock = new object();

        protected EveApiResponse<ApiKeyInfo> Data { get; set; }

        /// <summary>
        ///     Creates a new instance using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public ApiKey(long keyId, string vCode) {
            BaseUri = new Uri("https://api.eveonline.com");
            KeyId = keyId;
            VCode = vCode;
        }

        /// <summary>
        ///     Gets the key ID for this key.
        /// </summary>
        public long KeyId { get; protected set; }

        /// <summary>
        ///     Gets the VCode for this key.
        /// </summary>
        public string VCode { get; protected set; }

        public bool IsValidKey {
            get {
                if (_isValidKey != null) return _isValidKey.Value;
                lock (LazyLoadLock) {
                    if (_isValidKey == null)
                        _isValidKey = getIsValidKey();
                }
                return _isValidKey.Value;
            }
        }

        /// <summary>
        ///     Gets the CAK access mask of this key.
        /// </summary>
        public int AccessMask {
            get {
                if (_accessMask != default(int)) return _accessMask;
                lock (LazyLoadLock) {
                    if (_accessMask == default(int))
                        lazyLoad();
                }
                return _accessMask;
            }
            protected set { _accessMask = value; }
        }

        /// <summary>
        ///     Gets the type of this key.
        /// </summary>
        public ApiKeyType? KeyType {
            get {
                if (_type != null) return _type;
                lock (LazyLoadLock) {
                    if (_type == null)
                        lazyLoad();
                }
                return _type;
            }
            protected set { _type = value; }
        }

        /// <summary>
        ///     Gets the expiration date of this key.
        /// </summary>
        public DateTime ExpireDate {
            get {
                if (_expireTime != default(DateTime)) return _expireTime;
                lock (LazyLoadLock) {
                    if (_expireTime == default(DateTime))
                        lazyLoad();
                }
                return _expireTime;
            }
            protected set { _expireTime = value; }
        }

        /// <summary>
        ///     Returns api key info. All of this information is already available as properties on this object.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<ApiKeyInfo> GetApiKeyInfo() {
            //const int mask = 0;
            const string uri = "/account/APIKeyInfo.xml.aspx";
            return request<ApiKeyInfo>(uri, this);
        }

        /// <summary>
        ///     Returns a list of all characters on an account.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<CharacterList> GetCharacterList() {
            //const int mask = 0;
            const string uri = "/account/Characters.xml.aspx";
            EveApiResponse<CharacterList> response = request<CharacterList>(uri, this);
            return response;
        }

        private bool getIsValidKey() {
            try {
                Data = GetApiKeyInfo();
            } catch (InvalidRequestException e) {
                if (e.InnerException.GetType() == typeof(WebException)) {
                    if (((HttpWebResponse)((WebException)e.InnerException).Response).StatusCode ==
                        HttpStatusCode.Forbidden) {
                        return false;
                    }
                    throw;
                }
                throw;
            }
            return true;
        }

        protected virtual void lazyLoad() {
            if (IsValidKey)
                load(Data);
        }

        protected void load(EveApiResponse<ApiKeyInfo> info) {
            Contract.Requires(info != null);
            AccessMask = info.Result.Key.AccessMask;
            KeyType = (ApiKeyType)Enum.Parse(typeof(ApiKeyType), info.Result.Key.Type);
            ExpireDate = info.Result.Key.ExpireDate;
        }
    }
}