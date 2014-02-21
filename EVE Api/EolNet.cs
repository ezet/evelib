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

using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Dto.EveApi.Account;
using eZet.Eve.EoLib.Entity;
using eZet.Eve.EoLib.Exceptions;
using Character = eZet.Eve.EoLib.Entity.Character;

namespace eZet.Eve.EoLib {
 
    public class EolNet {

        private const int Key = 3035238;

        private const string VCode = "ubXVyyqDzjCRIcFbFxbTyS4I9B8n3ncQepGwDkz6EmVkoG2k9lTHhObiIxYgC8eQ";

        /// <summary>
        /// Gets the ApiKey for this instance
        /// </summary>
        public ApiKey ApiKey { get; private set; }       

        /// <summary>
        /// Gets the current Character for this instance
        /// </summary>
        public Character Character { get; private set; }
        
        /// <summary>
        /// Gets the Account for this instance
        /// </summary>
        public Account Account { get; private set; }

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

        static public void Main() {
            
            var api = new EolNet(Key, VCode);
            XmlResponse<AccountStatus> xml;
            xml = api.Account.GetAccountStatusAsync().Result;

            api.Core.GetErrorList();
        }

        /// <summary>
        /// Creates a new instance, only allowing access to functionaly that doesn't require a valid key.
        /// </summary>
        public EolNet() {
            Core = new Entity.Core();
            Map = new Map();
            EveCentral = new EveCentral();
            Image = new Image();
        }

        /// <summary>
        /// Creates a new instance using the given Api Key.
        /// </summary>
        /// <param name="key">A valid API key.</param>
         public EolNet(ApiKey key) : this() {
            ApiKey = key;
            Account = new Account(ApiKey);
        }

        /// <summary>
        /// Creates a new instance using the given key and character id.
        /// </summary>
        /// <param name="key">A ApiKey object.</param>
        /// <param name="characterId">A valid character id for the key. Use ApiKey.Characters to get a list of valid ids.</param>
        public EolNet(ApiKey key, long characterId) : this(key) {
            verifyCharacter(key, characterId);
            Character = new Entity.Character(ApiKey, characterId);
        }

        /// <summary>
        /// Creates a new instance using the provided key information.
        /// </summary>
        /// <param name="keyId">The id of a valid API key.</param>
        /// <param name="vCode">The corresponding vcode of the key id.</param>
        public EolNet(int keyId, string vCode) : this(new ApiKey(keyId, vCode)) {
        }

        /// <summary>
        /// Creates a new instance using the provided key information and character id.
        /// </summary>
        /// <param name="keyId">The id of a valid API key.</param>
        /// <param name="vCode">The corresponding vcode of the key id.</param>
        /// <param name="characterId">A valid character id for the key.  Use ApiKey.Characters to get a list of valid ids.</param>
        public EolNet(int keyId, string vCode, long characterId)
            : this(new ApiKey(keyId, vCode), characterId) {
        }

        /// <summary>
        /// Verifies that the provided character id is accessible using the provided key.
        /// </summary>
        /// <param name="key">Key to verify against.</param>
        /// <param name="characterId">Character id to verify.</param>
        private void verifyCharacter(ApiKey key, long characterId) {
            if (!key.Characters.Contains(characterId))
                throw new IllegalCharacterIdException("The API Key is not valid for this character.", key, characterId);
        }
    }
}
