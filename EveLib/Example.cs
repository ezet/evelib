using System;
using System.Linq;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Character;
using eZet.EveLib.Modules.Models.Misc;

namespace eZet.EveLib {
    public class Example {
        /// This shows how you can access API endpoints that do not require authentication
        public void NoAuthRequired() {
            // Access the API. You should probably wrap this in a try/catch block
            AllianceList result = EveOnlineApi.Eve.GetAllianceList().Result;
            foreach (AllianceList.AllianceData alliance in result.Alliances) {
                Console.WriteLine(alliance.AllianceName);
            }
        }

        /// This shows how to retrieve a character object from a Key object, and is the safest way to access the API.
        public void CharacterFromKey() {
            // Create a CharacterKey
            CharacterKey key = EveOnlineApi.CreateCharacterKey(123, "foo");
            // key.Characters is a list of all characters this key has access to, we select one
            Character fox = key.Characters.SingleOrDefault(c => c.CharacterName == "Fox");
            // abort if we couldnt find him, you should probably handle this differently
            if (fox == null) return;
            // All methods prefixed with "Get" access the API, so this causes a web request if it isnt in the cache
            AccountBalance result = fox.GetAccountBalance().Result;
            // Print the balance of each account
            foreach (AccountBalanceRow account in result.Accounts) {
                Console.WriteLine(account.Balance);
            }
            // Unlike the below example, because this Character is from a Key, all properties are already loaded from the API.
            Console.WriteLine(fox.CharacterName);
            Console.WriteLine(fox.AllianceName);
        }

        /// This creates a Character object directly, without verifying if the character exists or if the key is valid until we use it.
        public void CharacterFromNew() {
            // This attempts to create a character directly, with the ID 987.
            Character prism = EveOnlineApi.CreateCharacter(123, "foo", 987);
            //These properties are lazily loaded from the API on access, so they might cause an error if the key is invalid. You should warp this in a try/catch block
            Console.WriteLine(prism.CharacterName);
            // Because we accessed a property above, all properties are loaded. This will therefore not cause another web request.
            Console.WriteLine(prism.CorporationName);
        }

        // This example shows you how to handle an unknown key, that is you don't know if it's for a Character or Corporation
        public void UsingUnknownKey() {
            // Create a more general ApiKey
            ApiKey key = EveOnlineApi.CreateApiKey(567, "bar");
            if (key.KeyType == ApiKeyType.Character) {
                var characterKey = key.GetActualKey() as CharacterKey;
                // Use your shiny new character key
            }
            else if (key.KeyType == ApiKeyType.Corporation) {
                var corpKey = key.GetActualKey() as CorporationKey;
                // Do something else if it's a corporation key
            }
            else if (key.KeyType == ApiKeyType.Account) {
                var characterKey = key.GetActualKey() as CharacterKey;
                // ApiKeyType.Account is just a CharacterKey with access to more than one character
            }
        }

        public void Crest() {
            var crest = new EveCrest();
            CrestWar result = crest.GetWar(1);
        }

        public void test() {
            CharacterKey key = new CharacterKey(1, "");
            var result = key.GetAccountStatus().Result;
        }

    }
}