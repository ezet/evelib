using System;
using System.Linq;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Account;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to Corporation objects and related API calls.
    /// </summary>
    public class CorporationKey : ApiKey {
        private Corporation _corporation;

        /// <summary>
        ///     Creates a new key using the provided key id and vcode.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="vCode"></param>
        public CorporationKey(long keyId, string vCode)
            : base(keyId, vCode) {
        }

        /// <summary>
        ///     Gets the Corporation this key provides access to.
        /// </summary>
        public Corporation Corporation {
            get {
                if (_corporation != null) return _corporation;
                lock (LazyLoadLock) {
                    if (_corporation == null)
                        lazyLoad();
                }
                return _corporation;
            }
            private set { _corporation = value; }
        }

        protected override void lazyLoad() {
            if (IsValidKey) {
                load(Data);
                Corporation = new Corporation(this, Data.Result.Key.Characters.First().CorporationId,
                    Data.Result.Key.Characters.First().CorporationName);
            }
        }
    }
}