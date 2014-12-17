using System;

namespace eZet.EveLib.Modules.Models.Resources {
    /// <summary>
    /// Represents a resource that isn't implemented. If this throws a NotImplementedException, please notify the developer.
    /// </summary>
    public class CrestNotImplemented : CrestResource {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrestNotImplemented"/> class. This shouldn't happen unless a unsupported resource is requested.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public CrestNotImplemented() {
            throw new NotImplementedException();
        }
    }
}