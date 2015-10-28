using System.Threading.Tasks;

namespace eZet.EveLib.EveAuthModule {
    /// <summary>
    ///     Interface IEveAuth
    /// </summary>
    public interface IEveAuth {
        /// <summary>
        ///     Authenticates the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="authCode">The authentication code.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        Task<AuthResponse> AuthenticateAsync(string encodedKey, string authCode);

        /// <summary>
        ///     Refreshes the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        Task<AuthResponse> RefreshAsync(string encodedKey, string refreshToken);

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        /// <value>The protocol.</value>
        string Protocol { get; set; }
    }
}