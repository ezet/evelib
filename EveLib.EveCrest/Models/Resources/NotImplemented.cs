using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Exceptions;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a resource that isn't implemented. If this throws a ResourceNotSupportedException, please notify the
    ///     developer.
    /// </summary>
    public sealed class NotImplemented : CrestResource<NotImplemented> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotImplemented" /> class.
        /// </summary>
        public NotImplemented() {
            ContentType = "";
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context) {
            throw new ResourceNotSupportedException();
        }
    }
}