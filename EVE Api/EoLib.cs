/**
Licensed to the Apache Software Foundation (ASF) under one
or more contributor license agreements.  See the NOTICE file
distributed with this work for additional information
regarding copyright ownership.  The ASF licenses this file
to you under the Apache License, Version 2.0 (the
"License"); you may not use this file except in compliance
with the License.  You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an
"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, either express or implied.  See the License for the
specific language governing permissions and limitations
under the License.
 * 
 *
*/

using eZet.Eve.EoLib.Entity;

namespace eZet.Eve.EoLib {
 
    public class EoLib {

        private const int Key = 3035238;

        private const string VCode = "ubXVyyqDzjCRIcFbFxbTyS4I9B8n3ncQepGwDkz6EmVkoG2k9lTHhObiIxYgC8eQ";

        private const int MiraId = 3120814;

        private const string MiraCode = "L7jbIZe6EPxRgz0kIv64jym4zvwNAmEf36zMZlRA2c8obMlWC9DFEmdytdQP4N0l";

        private const int CorpId = 3120830;

        private const string CorpCode = "Zw1DpOUDPYrv49iGTVkDHoRburv2rAAYEbret9B5IVfcVjVDR4DE2bo7p1RMZQMU";

        /// <summary>
        /// Gets the Core for this instance
        /// </summary>
        public Core Core { get; private set; }


        /// <summary>
        /// Gets the Map for this instance
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        /// Gets the EveCentral for this instance
        /// </summary>
        public EveCentral EveCentral { get; private set; }


        /// <summary>
        /// Gets the Image for this instance
        /// </summary>
        public Image Image { get; private set; }

        public static CharacterKey GetCharacterKey(long keyId, string vCode) {
            return new CharacterKey(keyId, vCode);
        }

        public static CorporationKey GetCorporationKey(long keyId, string vCode) {
            return new CorporationKey(keyId, vCode);
        }

        public static void Main() {
            var corp = new CorporationKey(CorpId, CorpCode);
            var mira = new CharacterKey(MiraId, MiraCode);
            var corpinfo = corp.GetApiKeyInfo();
            corpinfo = corp.GetApiKeyInfo();
            //var mirainfo = mira.GetApiKeyInfo();
            //var res = corp.Corporation.GetWalletTransactions(50);
            return;
        }

        /// <summary>
        /// Creates a new instance, only allowing access to functionaly that doesn't require a valid key.
        /// </summary>
        public EoLib() {
            Core = new Core();
            Map = new Map();
            EveCentral = new EveCentral();
            Image = new Image();
        }

        /// <summary>
        /// Verifies that the provided character id is accessible using the provided key.
        /// </summary>
        /// <param name="key">Key to verify against.</param>
        /// <param name="characterId">Character id to verify.</param>
        private void verifyCharacter(ApiKey key, long characterId) {
            //if (!key.Characters.Contains(characterId))
            //    throw new IllegalCharacterIdException("The API Key is not valid for this character.", key, characterId);
        }
    }
}
