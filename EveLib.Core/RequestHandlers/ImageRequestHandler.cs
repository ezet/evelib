using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace eZet.EveLib.Core.RequestHandlers {

    /// <summary>
    /// Simple implementation for requesting images
    /// </summary>
    public class ImageRequestHandler : IImageRequestHandler {

        private readonly TraceSource _trace = new TraceSource("EveLib", SourceLevels.All);

        /// <summary>
        /// Requests and returns image data
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <returns>The image data</returns>
        public Task<byte[]> RequestImageDataAsync(Uri uri) {
            var client = new WebClient();
            return client.DownloadDataTaskAsync(uri);
        }

        /// <summary>
        /// Requests image and saves it to a file.
        /// </summary>
        /// <param name="uri">URI to request</param>
        /// <param name="file">File to save image as.</param>
        /// <returns>The task</returns>
        public Task RequestImageAsync(Uri uri, string file) {
            var client = new WebClient();
            return client.DownloadFileTaskAsync(uri, file);
        }
    }
}
