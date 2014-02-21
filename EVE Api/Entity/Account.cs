using System;
using System.Threading.Tasks;
using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Account;

namespace eZet.Eve.EoLib.Entity {
    public class Account : BaseEntity {

        /// <summary>
        /// The base URI for all requests by this entity
        /// </summary>
        protected override sealed string UriBase { get; set; }

        /// <summary>
        /// The API key for this instance.
        /// </summary>
        public ApiKey Key { get; private set; }

        /// <summary>
        /// Creates a new instance using the given key.
        /// </summary>
        /// <param name="key">A key used for API requests.</param>
        internal Account(ApiKey key) {
            UriBase = "https://api.eveonline.com";
            Key = key;
        }

        /// <summary>
        /// Returns basic account information including when the subscription lapses, total play time in minutes, total times logged on and date of account creation.
        /// In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AccountStatus> GetAccountStatus() {
            const int mask = 33554432;
            const string uri = "/account/AccountStatus.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            return request(uri, new AccountStatus(), postString);
        }

        /// <summary>
        /// Returns basic account information including when the subscription lapses, total play time in minutes, total times logged on and date of account creation.
        /// In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<XmlResponse<AccountStatus>> GetAccountStatusAsync(IProgress<int> progress = null) {
            var result = await Task.Run(() => GetAccountStatus());
            return result;
        }

        /// <summary>
        /// Returns information about the API key and a list of the characters exposed by it.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ApiKeyInfo> GetApiKeyInfo() {
            return Key.GetInfo();
        }

        /// <summary>
        /// Returns information about the API key and a list of the characters exposed by it.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<XmlResponse<ApiKeyInfo>> GetApiKeyInfoAsync(IProgress<int> progress = null) {
            var result = await Key.GetInfoAsync(progress);
            return result;
        }

        /// <summary>
        /// Returns a list of all characters on an account.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CharacterList> GetCharacterList() {
            const int mask = 0;
            const string uri = "/account/Characters.xml.aspx";
            var postString = RequestHelper.GeneratePostString(Key);
            var response = request(uri, new CharacterList(), postString);
            response.ApiKey = Key;
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

    }
}
