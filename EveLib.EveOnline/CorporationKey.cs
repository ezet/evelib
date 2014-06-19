using System;
using System.Linq;
using System.Threading.Tasks;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to Corporation objects and related API calls.
    /// </summary>
    public class CorporationKey : ApiKey {
        private readonly Lazy<Corporation> _corporation;

        /// <summary>
        ///     Creates a new key using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public CorporationKey(long keyId, string vCode)
            : base(keyId, vCode) {
            _corporation = new Lazy<Corporation>(() => new Corporation(this, ApiKeyInfo.KeyEntities.Single()));
        }

        /// <summary>
        ///     Creates a new CorporationKey using data from an existing ApiKey
        /// </summary>
        /// <param name="key"></param>
        internal CorporationKey(ApiKey key)
            : base(key) {
            _corporation = new Lazy<Corporation>(() => new Corporation(this, ApiKeyInfo.KeyEntities.Single()));
        }

        /// <summary>
        ///     Gets the Corporation this key provides access to.
        /// </summary>
        public Corporation Corporation {
            get { return _corporation.Value; }
        }

        /// <summary>
        ///     Initializes properties.
        /// </summary>
        /// <returns></returns>
        public new async Task<CorporationKey> InitAsync() {
            return await base.InitAsync().ConfigureAwait(false) as CorporationKey;
        }

        // Hide ApiKey.GetActualKey
        private new void GetActualKey() {
            throw new NotImplementedException();
        }
    }
}