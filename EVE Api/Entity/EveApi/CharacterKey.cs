using System.Collections.ObjectModel;
using System.Linq;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Model.EveApi.Account;

namespace eZet.Eve.EveLib.Entity.EveApi {
    public class CharacterKey : ApiKey {

        private ReadOnlyCollection<Character> _characters;

        /// <summary>
        /// A list of valid character ids for this key.
        /// </summary>
        public ReadOnlyCollection<Character> Characters {
            get {
                if (_characters == null)
                    lazyLoad();
                return _characters;
            }
            private set { _characters = value; }
        }

        public CharacterKey(long keyId, string vCode) : base(keyId, vCode) {
        }

        /// <summary>
        /// Returns basic account information including when the subscription lapses, total play time in minutes, total times logged on and date of account creation.
        /// <para></para>
        /// In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AccountStatus> GetAccountStatus() {
            //const int mask = 33554432;
            const string uri = "/account/AccountStatus.xml.aspx";
            return request<AccountStatus>(uri, this);
        }

        protected override void lazyLoad() {
            var info = GetApiKeyInfo();
            var list = info.Result.Key.Characters.Select(c => new Character(this, c.CharacterId, c.CharacterName)).ToList();
            Characters = list.AsReadOnly();
            load(info);
        }
    }
}
