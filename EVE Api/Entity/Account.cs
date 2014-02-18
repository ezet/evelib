using eZet.Eve.EveApi.Dto.EveApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EveApi.Dto.EveApi.Account;

namespace eZet.Eve.EveApi.Entity {
    public class Account : EveApiEntity {

        public Account(ApiKey key) : base(key) {
            
        }

        public XmlResponse<CharacterCollection> GetCharacterList() {
            const string uri = "/account/Characters.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey);
            var response = request(uri, new CharacterCollection(), postString);
            response.ApiKey = ApiKey;
            return response;
        }

        public XmlResponse<AccountStatus> GetAccountStatus() {
            const string uri = "/account/AccountStatus.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey);
            return request(uri, new AccountStatus(), postString);
        }

        public XmlResponse<ApiKeyInfo> GetApiKeyInfo() {
            const string uri = "/account/APIKeyInfo.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey);
            return request(uri, new ApiKeyInfo(), postString);
        }
    }
}
