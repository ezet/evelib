using System;
using System.Runtime.Serialization;

namespace eZet.EveLib.EveAuthModule {
    
    [DataContract]
    public class VerifyResponse {

        [DataMember(Name = "characterID")]
        public int CharacterId { get; set; }

        [DataMember(Name = "characterName")]
        public string CharacterName { get; set; }

        [DataMember(Name = "expiresOn")]
        public DateTime ExpiresOn { get; set; }

        [DataMember(Name = "scopes")]
        public string Scopes { get; set; }

        [DataMember(Name = "characterOwnerHash")]
        public string CharacterOwnerHash { get; set; }

    }
}
