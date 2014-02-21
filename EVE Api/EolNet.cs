using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Dto.EveApi.Account;
using eZet.Eve.EolNet.Dto.EveCentral;
using eZet.Eve.EolNet.Entity;
using eZet.Eve.EolNet.Exceptions;
using Character = eZet.Eve.EolNet.Entity.Character;

namespace eZet.Eve.EolNet {
 
    public class EolNet {

        private const int Key = 3035238;

        private const string VCode = "ubXVyyqDzjCRIcFbFxbTyS4I9B8n3ncQepGwDkz6EmVkoG2k9lTHhObiIxYgC8eQ";

        public ApiKey ApiKey { get; private set; }       

        public Character Character { get; private set; }
        
        public Account Account { get; private set; }

        public Entity.Eve Eve { get; private set; }

        public Map Map { get; private set; }

        public EveCentral EveCentral { get; private set; }

        public Image Image { get; private set; }

        static public void Main() {
            
            var api = new EolNet(Key, VCode);
            XmlResponse<AccountStatus> xml;
            xml = api.Account.GetAccountStatusAsync().Result;
           


            api.Eve.GetErrorList();
        }

        public EolNet() {
            Eve = new Entity.Eve();
            Map = new Map();
            EveCentral = new EveCentral();
            Image = new Image();
        }

        public void SelectCharacter(long characterId) {
            verifyCharacter(ApiKey, characterId);
            Character = new Entity.Character(ApiKey, characterId);
        }

        public EolNet(ApiKey key) {
            ApiKey = key;
            Account = new Account(ApiKey);
        }

        public EolNet(ApiKey key, long characterId) : this(key) {
            verifyCharacter(key, characterId);
            Character = new Entity.Character(ApiKey, characterId);
        }

        public EolNet(int keyId, string vCode) : this(new ApiKey(keyId, vCode)) {
        }

        public EolNet(int keyId, string vCode, long characterId)
            : this(new ApiKey(keyId, vCode), characterId) {
        }

        private void verifyCharacter(ApiKey key, long id) {
            if (!key.CharacterIds.Contains(id))
                throw new IllegalCharacterIdException("The API Key is not valid for this character.", key, id);
        }
    }
}
