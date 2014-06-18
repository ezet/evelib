using System;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Static helper facade for accessing the Eve Online API.
    /// </summary>
    public static class EveOnlineApi {
        private static readonly Lazy<Eve> _eve;
        private static readonly Lazy<Image> _image;
        private static readonly Lazy<Map> _map;

        static EveOnlineApi() {
            _eve = new Lazy<Eve>();
            _image = new Lazy<Image>();
            _map = new Lazy<Map>();
        }

        /// <summary>
        ///     Provides access to a default instance of Eve
        /// </summary>
        public static Eve Eve {
            get { return _eve.Value; }
        }

        /// <summary>
        ///     Provides access to a default instance of Image
        /// </summary>
        public static Image Image {
            get { return _image.Value; }
        }

        /// <summary>
        ///     Provides access to a default instance of Map
        /// </summary>
        public static Map Map {
            get { return _map.Value; }
        }

        /// <summary>
        ///     Creates a new ApiKey and returns it. This is the same as invoking new ApiKey
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <returns></returns>
        public static ApiKey CreateApiKey(int keyId, string vCode) {
            return new ApiKey(keyId, vCode);
        }

        /// <summary>
        ///     Creates a new CharacterKey and returns it. This is the same as invoking new CharacterKey
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <returns></returns>
        public static CharacterKey CreateCharacterKey(int keyId, string vCode) {
            return new CharacterKey(keyId, vCode);
        }

        /// <summary>
        ///     Creates a new CorporationKey returns it. This is the same as invoking new CorporationKey
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <returns></returns>
        public static CorporationKey CreateCorporationKey(int keyId, string vCode) {
            return new CorporationKey(keyId, vCode);
        }

        /// <summary>
        ///     Creates a new CharacterKey and Character, and returns the Character.
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <param name="characterId">Eve Online Character ID</param>
        /// <returns></returns>
        public static Character CreateCharacter(int keyId, string vCode, long characterId) {
            return new Character(keyId, vCode, characterId);
        }

        /// <summary>
        ///     Creates a new CorporationKey and Corporation, and returns the Corporation.
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <param name="corporationId">Eve Online Corporation ID</param>
        /// <returns></returns>
        public static Corporation CreateCorporation(int keyId, string vCode, long corporationId) {
            return new Corporation(keyId, vCode, corporationId);
        }
    }
}