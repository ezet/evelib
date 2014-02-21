using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Account;

namespace eZet.Eve.EoLib.Entity {
    public class ApiKey : BaseEntity {

        /// <summary>
        /// The base URI for all requests by this entity
        /// </summary>
        protected override sealed string UriBase { get; set; }

        /// <summary>
        /// The Key ID for this key.
        /// </summary>
        public long KeyId { get; private set; }

        /// <summary>
        /// The VCode for this key.
        /// </summary>
        public string VCode { get; private set; }

        private int _accessMask;

        /// <summary>
        /// The CAK access mask of this key.
        /// </summary>
        public int AccessMask {
            get {
                if (_accessMask == default(int))
                    load();
                return _accessMask;
            }
            private set { _accessMask = value; }
        }

        private string _type;

        /// <summary>
        /// The type of key, possible values are character or corporation.
        /// </summary>
        public string Type {
            get {
                if (_type == null)
                    load();
                return _type;
            }
            private set { _type = value; }
        }

        private DateTime _expireTime;

        /// <summary>
        /// The expiration date of this key.
        /// </summary>
        public DateTime ExpireDate {
            get {
                if (_expireTime == default(DateTime))
                    load();
                return _expireTime;
            }
            private set { _expireTime = value; }
        }

        private ReadOnlyCollection<long> _characters;

        /// <summary>
        /// A list of valid character ids for this key.
        /// </summary>
        public ReadOnlyCollection<long> Characters {
            get {
                if (_characters == null)
                    load();
                return _characters;
            }
            private set { _characters = value; }
        }

        /// <summary>
        /// Creates a new instance using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public ApiKey(long keyId, string vCode) {
            KeyId = keyId;
            VCode = vCode;
            UriBase = "https://api.eveonline.com";
        }

        internal XmlResponse<ApiKeyInfo> GetInfo() {
            const int mask = 0;
            const string uri = "/account/APIKeyInfo.xml.aspx";
            var postString = RequestHelper.GeneratePostString(this);
            return request(uri, new ApiKeyInfo(), postString);
        }

        internal async Task<XmlResponse<ApiKeyInfo>> GetInfoAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetInfo());
            return result;
        }

        private void load() {
            var info = GetInfo();
            AccessMask = info.Result.Key.AccessMask;
            Type = info.Result.Key.Type;
            ExpireDate = info.Result.Key.ExpireDate;
            var list = info.Result.Key.Characters.Select(c => c.CharacterId).ToList();
            Characters = list.AsReadOnly();
        }
    }
}
