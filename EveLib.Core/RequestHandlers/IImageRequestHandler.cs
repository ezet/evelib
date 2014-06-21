using System;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.RequestHandlers {
    /// <summary>
    /// Interface for requesting images from URIs
    /// </summary>
    public interface IImageRequestHandler {

        /// <summary>
        /// Requests and returns image data
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns>The image data</returns>
        Task<byte[]> RequestImageDataAsync(Uri uri);

        /// <summary>
        /// Requests image and saves it to a file.
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <param name="file">File to save image as.</param>
        /// <returns>The task</returns>
        Task RequestImageAsync(Uri uri, string file);
    }
}
