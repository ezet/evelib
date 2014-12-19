using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Class TokenDecode. This class cannot be inherited.
    /// </summary>
    [DataContract]
    public sealed class TokenDecode : CrestResource<TokenDecode> {

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenDecode"/> class.
        /// </summary>
        public TokenDecode() {
            ContentType = "application/vnd.ccp.eve.TokenDecode-v1+json";
        }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value>The character.</value>
        [DataMember(Name = "character")]
        public Href<NotImplemented> Character { get; set; }
    }
}
