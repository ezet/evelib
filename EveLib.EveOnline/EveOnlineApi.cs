using System;

namespace eZet.EveLib.Modules {

    /// <summary>
    /// Static helper facade for accessing the Eve Online API.
    /// </summary>
    public static class EveOnlineApi {

        /// <summary>
        /// Provides access to a default instance of Eve
        /// </summary>
        public static Lazy<Eve> Eve { get; private set; }

        /// <summary>
        /// Provides access to a default instance of Image
        /// </summary>
        public static Lazy<Image> Image { get; private set; }

        /// <summary>
        /// Provides access to a default instance of Map
        /// </summary>
        public static Lazy<Map> Map { get; private set; }

        static EveOnlineApi() {
            Eve = new Lazy<Eve>();
            Image = new Lazy<Image>();
            Map = new Lazy<Map>();
        }

        /// <summary>
        /// Creates a new CharacterKey and returns it. This is the same as invoking new CharacterKey
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <returns></returns>
        public static CharacterKey CreateCharacterKey(int keyId, string vCode) {
            return new CharacterKey(keyId, vCode);
        }

        /// <summary>
        /// Creates a new CorporationKey returns it. This is the same as invoking new CorporationKey
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <returns></returns>
        public static CorporationKey CreateCorporationKey(int keyId, string vCode) {
            return new CorporationKey(keyId, vCode);
        }

        /// <summary>
        /// Creates a new CharacterKey and Character, and returns the Character.
        /// </summary>
        /// <param name="keyId">Eve API Key ID</param>
        /// <param name="vCode">Eve API Verification Code (vCode)</param>
        /// <param name="characterId">Eve Online Character ID</param>
        /// <returns></returns>
        public static Character CreateCharacter(int keyId, string vCode, long characterId) {
            return new Character(keyId, vCode, characterId);
        }

        /// <summary>
        /// Creates a new CorporationKey and Corporation, and returns the Corporation.
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
