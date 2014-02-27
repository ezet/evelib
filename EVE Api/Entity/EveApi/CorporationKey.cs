using System.Linq;

namespace eZet.Eve.EveLib.Entity.EveApi {
    public class CorporationKey : ApiKey {

        private Corporation _corporation;

        public Corporation Corporation {
            get {
                if (_corporation == null)
                    lazyLoad();
                return _corporation;

            }
            private set { _corporation = value; }
        }
        public CorporationKey(long keyId, string vCode)
            : base(keyId, vCode) {
        }

        protected override void lazyLoad() {
            var info = GetApiKeyInfo();
            load(info);
            Corporation = new Corporation(this, info.Result.Key.Characters.First().CorporationId, info.Result.Key.Characters.First().CorporationName);
        }
    }
}
