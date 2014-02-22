namespace eZet.Eve.EoLib.Util {
    public interface IRequester {

        /// <summary>
        /// Performs a request to the provided URI, using the provided arguments.
        /// </summary>
        /// <param name="uri">The URI to request.</param>
        /// <param name="args">A list of argument objects. Argument names must be followed by a comma, and a value.</param>
        /// <returns></returns>
        string Request(string uri, params object[] args);

    }
}
