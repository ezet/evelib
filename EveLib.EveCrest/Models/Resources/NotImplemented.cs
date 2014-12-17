using System;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    ///     Represents a resource that isn't implemented. If this throws a NotImplementedException, please notify the
    ///     developer.
    /// </summary>
    public class NotImplemented : CrestResource {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotImplemented" /> class. This shouldn't happen unless a
        ///     unsupported resource is requested.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public NotImplemented() {
            throw new NotImplementedException();
        }
    }
}