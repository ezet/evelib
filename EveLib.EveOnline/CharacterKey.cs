using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eZet.EveLib.EveOnline.Model;
using eZet.EveLib.EveOnline.Model.Account;

namespace eZet.EveLib.EveOnline {
    /// <summary>
    ///     Provides access to Character objects and related API calls.
    /// </summary>
    public class CharacterKey : ApiKey {
        private ReadOnlyCollection<Character> _characters;

        /// <summary>
        ///     Creates a new key using the specified key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public CharacterKey(long keyId, string vCode) : base(keyId, vCode) {
        }

        /// <summary>
        ///     Gets a list of Characters this key has access to.
        /// </summary>
        public ReadOnlyCollection<Character> Characters {
            get {
                if (_characters == null)
                    lazyLoad();
                return _characters;
            }
            private set { _characters = value; }
        }

        /// <summary>
        ///     Returns basic account information including when the subscription lapses, total play time in minutes, total times
        ///     logged on and date of account creation.
        ///     <para></para>
        ///     In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<AccountStatus> GetAccountStatus() {
            //const int mask = 33554432;
            const string uri = "/account/AccountStatus.xml.aspx";
            return request<AccountStatus>(uri, this);
        }

        protected override void lazyLoad() {
            EveApiResponse<ApiKeyInfo> info = GetApiKeyInfo();
            List<Character> list =
                info.Result.Key.Characters.Select(c => new Character(this, c.CharacterId, c.CharacterName)).ToList();
            Characters = list.AsReadOnly();
            load(info);
        }
    }
}