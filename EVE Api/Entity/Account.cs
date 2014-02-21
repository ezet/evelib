using System;
using System.Threading.Tasks;
using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Dto.EveApi.Account;

namespace eZet.Eve.EolNet.Entity {
    public class Account : BaseEntity {

        protected override sealed string UriBase { get; set; }

        public ApiKey Key { get; private set; }

        internal Account(ApiKey key) {
            UriBase = "https://api.eveonline.com";
            Key = key;
        }

        public XmlResponse<CharacterList> GetCharacterList() {
            const string uri = "/account/Characters.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            var response = request(uri, new CharacterList(), postString);
            response.ApiKey = Key;
            return response;
        }

        public async Task<XmlResponse<CharacterList>> GetCharacterListAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetCharacterList());
            return result;
        }

        public XmlResponse<AccountStatus> GetAccountStatus() {
            const string uri = "/account/AccountStatus.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            return request(uri, new AccountStatus(), postString);
        }

        public async Task<XmlResponse<AccountStatus>> GetAccountStatusAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetAccountStatus());
            return result;
        }

        public XmlResponse<ApiKeyInfo> GetApiKeyInfo() {
            return Key.GetInfo();
        }

        public async Task<XmlResponse<ApiKeyInfo>> GetApiKeyInfoAsync(IProgress<int> progress = null) {
            var result = await Key.GetInfoAsync(progress);
            return result;
        }

    }
}
