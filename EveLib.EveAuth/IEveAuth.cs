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
        Task<AuthResponse> Authenticate(string encodedKey, string authCode);

        /// <summary>
        ///     Refreshes the specified encoded key.
        /// </summary>
        /// <param name="encodedKey">The encoded key.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>Task&lt;AuthResponse&gt;.</returns>
        Task<AuthResponse> Refresh(string encodedKey, string refreshToken);
    }
}