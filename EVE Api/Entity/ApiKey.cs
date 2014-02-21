using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Dto.EveApi.Account;

namespace eZet.Eve.EolNet.Entity {
    public class ApiKey : BaseEntity {

        protected override sealed string UriBase { get; set; }

        internal ApiKey() {
            UriBase = "https://api.eveonline.com";
        }

        public long KeyId { get; private set; }

        public string VCode { get; private set; }

        private int _accessMask;

        public int AccessMask {
            get {
                if (_accessMask == default(int))
                    load();
                return _accessMask;
            }
            private set { _accessMask = value; }
        }

        private string _type;

        public string Type {
            get {
                if (_type == null)
                    load();
                return _type;
            }
            private set { _type = value; }
        }

        private DateTime _expireTime;

        public DateTime ExpireDate {
            get {
                if (_expireTime == default(DateTime))
                    load();
                return _expireTime;
            }
            private set { _expireTime = value; }
        }

        private ReadOnlyCollection<long> _characterIds;

        public ReadOnlyCollection<long> CharacterIds {
            get {
                if (_characterIds == null)
                    load();
                return _characterIds;
            }
            private set { _characterIds = value; }
        }

        public ApiKey(long keyId, string vCode) {
            KeyId = keyId;
            VCode = vCode;
        }

        public XmlResponse<ApiKeyInfo> GetInfo() {
            const string uri = "/account/APIKeyInfo.xml.aspx";
            var postString = RequestHelper.GeneratePostString(this);
            return request(uri, new ApiKeyInfo(), postString);
        }

        public async Task<XmlResponse<ApiKeyInfo>> GetInfoAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetInfo());
            return result;
        }

        public XmlResponse<CharacterList> GetCharacterList() {
            const string uri = "/account/Characters.xml.aspx";
            var postString = RequestHelper.GeneratePostString(this);
            var response = request(uri, new CharacterList(), postString);
            response.ApiKey = this;
            return response;
        }

        public async Task<XmlResponse<CharacterList>> GetCharacterListAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetCharacterList());
            return result;
        }

        public XmlResponse<AccountStatus> GetAccountStatus() {
            const string uri = "/account/AccountStatus.xml.aspx";
            var postString = RequestHelper.GeneratePostString(this);
            return request(uri, new AccountStatus(), postString);
        }

        public async Task<XmlResponse<AccountStatus>> GetAccountStatusAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetAccountStatus());
            return result;
        }

        public string GetAuthString() {
            return "keyID=" + KeyId + "&vCode=" + VCode + "&";
        }

        private void load() {
            var info = GetInfo();
            AccessMask = info.Result.Key.AccessMask;
            Type = info.Result.Key.Type;
            ExpireDate = info.Result.Key.ExpireDate;
            var list = info.Result.Key.Characters.Select(c => c.CharacterId).ToList();
            CharacterIds = list.AsReadOnly();
        }
    }
}
