using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to Character objects and related API calls.
    /// </summary>
    public class CharacterKey : ApiKey {
        private readonly Lazy<ReadOnlyCollection<Character>> _characters;

        /// <summary>
        ///     Creates a new key using the specified key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public CharacterKey(long keyId, string vCode)
            : base(keyId, vCode) {
            _characters =
                new Lazy<ReadOnlyCollection<Character>>(
                    () => ApiKeyInfo.KeyEntities.Select(c => new Character(this, c)).ToList().AsReadOnly());
        }

        /// <summary>
        ///     Creates a new CharacterKey using data from an existing key
        /// </summary>
        /// <param name="key"></param>
        internal CharacterKey(ApiKey key)
            : base(key) {
            _characters =
                new Lazy<ReadOnlyCollection<Character>>(
                    () => ApiKeyInfo.KeyEntities.Select(c => new Character(this, c)).ToList().AsReadOnly());
        }

        /// <summary>
        ///     Gets a list of Characters this key has access to.
        /// </summary>
        public ReadOnlyCollection<Character> Characters {
            get { return _characters.Value; }
        }

        /// <summary>
        ///     Initializes properties.
        /// </summary>
        /// <returns></returns>
        public new async Task<CharacterKey> InitAsync() {
            return await base.InitAsync().ConfigureAwait(false) as CharacterKey;
        }

        /// <summary>
        ///     Returns basic account information including when the subscription lapses, total play time in minutes, total times
        ///     logged on and date of account creation.
        ///     <para></para>
        ///     In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<AccountStatus> GetAccountStatus() {
            return GetAccountStatusAsync().Result;
        }

        /// <summary>
        ///     Returns basic account information including when the subscription lapses, total play time in minutes, total times
        ///     logged on and date of account creation.
        ///     <para></para>
        ///     In the case of game time code accounts it will also look for available offers of time codes.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<AccountStatus>> GetAccountStatusAsync() {
            //const int mask = 33554432;
            const string uri = "/account/AccountStatus.xml.aspx";
            return requestAsync<AccountStatus>(uri, this);
        }

        // Hide ApiKey.GetActualKey
        private new void GetActualKey() {
            throw new NotImplementedException();
        }
    }
}