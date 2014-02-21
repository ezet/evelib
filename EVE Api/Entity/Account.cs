using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Dto.EveApi.Account;

namespace eZet.Eve.EveApi.Entity {
    public class Account : BaseEntity {

        public Account(ApiKey key) : base(key) {
            
        }

        public XmlResponse<CharacterList> GetCharacterList() {
            const string uri = "/account/Characters.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            var response = request(uri, new CharacterList(), postString);
            response.ApiKey = Key;
            return response;
        }

        public XmlResponse<AccountStatus> GetAccountStatus() {
            const string uri = "/account/AccountStatus.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            return request(uri, new AccountStatus(), postString);
        }

        public XmlResponse<ApiKeyInfo> GetApiKeyInfo() {
            return Key.GetInfo();
        }
    }
}
