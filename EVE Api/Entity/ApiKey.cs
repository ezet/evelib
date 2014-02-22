using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Account;

namespace eZet.Eve.EoLib.Entity {

    public enum ApiKeyType {
        Character, Corporation
    }

    public abstract class ApiKey : BaseEntity {

        /// <summary>
        /// The base URI for all requests by this entity
        /// </summary>
        protected override sealed string UriBase { get; set; }

        /// <summary>
        /// The Key ID for this key.
        /// </summary>
        public long KeyId { get; protected set; }

        /// <summary>
        /// The VCode for this key.
        /// </summary>
        public string VCode { get; protected set; }

        private int _accessMask;

        /// <summary>
        /// The CAK access mask of this key.
        /// </summary>
        public int AccessMask {
            get {
                if (_accessMask == default(int))
                    lazyLoad();
                return _accessMask;
            }
            protected set { _accessMask = value; }
        }

        private ApiKeyType? _type;

        /// <summary>
        /// The type of key, possible values are character or corporation.
        /// </summary>
        public ApiKeyType? KeyType {
            get {
                if (_type != null)
                    lazyLoad();
                return _type;
            }
            protected set { _type = value; }
        }

        private DateTime _expireTime;

        /// <summary>
        /// The expiration date of this key.
        /// </summary>
        public DateTime ExpireDate {
            get {
                if (_expireTime == default(DateTime))
                    lazyLoad();
                return _expireTime;
            }
            protected set { _expireTime = value; }
        }

        /// <summary>
        /// Creates a new instance using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        protected ApiKey(long keyId, string vCode) {
            UriBase = "https://api.eveonline.com";
            KeyId = keyId;
            VCode = vCode;
        }

        internal XmlResponse<ApiKeyInfo> GetApiKeyInfo() {
            const int mask = 0;
            const string uri = "/account/APIKeyInfo.xml.aspx";
            return request(new ApiKeyInfo(), uri, this);
        }

        internal async Task<XmlResponse<ApiKeyInfo>> GetApiKeyGetInfoAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetApiKeyInfo());
            return result;
        }


        /// <summary>
        /// Returns a list of all characters on an account.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CharacterList> GetCharacterList() {
            const int mask = 0;
            const string uri = "/account/Characters.xml.aspx";
            var response = request(new CharacterList(), uri, this);
            return response;
        }

        /// <summary>
        /// Returns a list of all characters on an account.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<XmlResponse<CharacterList>> GetCharacterListAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetCharacterList());
            return result;
        }

        private void lazyLoad() {
            var info = GetApiKeyInfo();
            load(info);
        }

        protected virtual void load(XmlResponse<ApiKeyInfo> info) {
            AccessMask = info.Result.Key.AccessMask;
            KeyType =  (ApiKeyType)Enum.Parse(typeof(ApiKeyType), info.Result.Key.Type);
            ExpireDate = info.Result.Key.ExpireDate;
        }
    }
}
