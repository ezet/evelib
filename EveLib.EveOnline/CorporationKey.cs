using System;
using System.Linq;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to Corporation objects and related API calls.
    /// </summary>
    public class CorporationKey : AccountKey {

        private readonly Lazy<Corporation> _corporation;

        /// <summary>
        ///     Creates a new key using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public CorporationKey(long keyId, string vCode)
            : base(keyId, vCode) {
            _corporation = new Lazy<Corporation>(() => new Corporation(this, ApiKeyInfo.Result.Key.KeyEntities.Single()));
        }

        /// <summary>
        /// Creates a new CorporationKey using data from an existing AccountKey
        /// </summary>
        /// <param name="key"></param>
        internal CorporationKey(AccountKey key)
            : base(key) {
            _corporation = new Lazy<Corporation>(() => new Corporation(this, ApiKeyInfo.Result.Key.KeyEntities.Single()));
        }

        /// <summary>
        ///     Gets the Corporation this key provides access to.
        /// </summary>
        public Corporation Corporation {
            get { return _corporation.Value; }
        }

        // Hide AccountKey.ActualKey
        private new void ActualKey() {

        }
    }
}