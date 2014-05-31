using System;
using System.Net;
using System.Threading.Tasks;
using eZet.EveLib.Core;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to all image related requests.
    /// </summary>
    public class Image {
        public enum AllianceLogoSize {
            X30 = 30,
            X32 = 32,
            X64 = 64,
            X128 = 128,
        }

        public enum CharacterPortraitSize {
            X30 = 30,
            X32 = 32,
            X64 = 64,
            X128 = 128,
            X200 = 200,
            X256 = 256,
            X512 = 512,
            X1024 = 1024
        }

        public enum CorporationLogoSize {
            X30 = 30,
            X32 = 32,
            X64 = 64,
            X128 = 128,
            X256 = 256,
        }

        public enum RenderSize {
            X32 = 32,
            X64 = 64,
            X128 = 128,
            X256 = 256,
            X512 = 512,
        }

        public enum TypeIconSize {
            X32 = 32,
            X64 = 64,
        }

        public Image() {
            BaseUri = new Uri("http://image.eveonline.com");
            ImageRequester = new ImageRequester();
        }

        /// <summary>
        ///     Gets or sets the base URI.
        /// </summary>
        public Uri BaseUri { get; set; }

        public IImageRequester ImageRequester { get; private set; }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public string GetCharacterPortrait(long characterId, CharacterPortraitSize size, string path) {
            return GetCharacterPortraitAsync(characterId, size, path).Result;
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public Task<string> GetCharacterPortraitAsync(long characterId, CharacterPortraitSize size, string path) {
            const string relUri = "/Character";
            const string ext = ".jpg";
            return requestImageAsync(relUri, characterId, (int)size, ext, path);
        }

        /// <summary>
        ///     Returns the character portrait data.
        /// </summary>
        public byte[] GetCharacterPortraitData(long characterId, CharacterPortraitSize size) {
            return GetCharacterPortraitDataAsync(characterId, size).Result;
        }

        /// <summary>
        ///     Returns the character portrait data.
        /// </summary>
        public Task<byte[]> GetCharacterPortraitDataAsync(long characterId, CharacterPortraitSize size) {
            const string relUri = "/Character";
            const string ext = ".jpg";
            return requestImageDataAsync(relUri, characterId, (int) size, ext);
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public string GetCorporationLogo(long corporationId, CorporationLogoSize size, string path) {
            return GetCorporationLogoAsync(corporationId, size, path).Result;
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public Task<string> GetCorporationLogoAsync(long corporationId, CorporationLogoSize size, string path) {
            const string relUri = "/Corporation";
            const string ext = ".png";
            return requestImageAsync(relUri, corporationId, (int)size, ext, path);
        }

        /// <summary>
        ///     Returns the corporation logo data.
        /// </summary>
        public byte[] GetCorporationLogoData(long corporationId, CorporationLogoSize size) {
            return GetCorporationLogoDataAsync(corporationId, size).Result;
        }

        /// <summary>
        ///     Returns the corporation logo data.
        /// </summary>
        public Task<byte[]> GetCorporationLogoDataAsync(long corporationId, CorporationLogoSize size) {
            const string relUri = "/Corporation";
            const string ext = ".png";
            return requestImageDataAsync(relUri, corporationId, (int)size, ext);
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public string GetAllianceLogo(long allianceId, AllianceLogoSize size, string path) {
            return GetAllianceLogoAsync(allianceId, size, path).Result;
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public Task<string> GetAllianceLogoAsync(long allianceId, AllianceLogoSize size, string path) {
            const string relUri = "/Alliance";
            const string ext = ".png";
            return requestImageAsync(relUri, allianceId, (int)size, ext, path);
        }

        /// <summary>
        ///     Returns the alliance logo.
        /// </summary>
        public byte[] GetAllianceLogoData(long allianceId, AllianceLogoSize size) {
            return GetAllianceLogoDataAsync(allianceId, size).Result;
        }

        /// <summary>
        ///     Returns the alliance logo.
        /// </summary>
        public Task<byte[]> GetAllianceLogoDataAsync(long allianceId, AllianceLogoSize size) {
            const string relUri = "/Alliance";
            const string ext = ".png";
            return requestImageDataAsync(relUri, allianceId, (int)size, ext);
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public string GetTypeIcon(long typeId, TypeIconSize size, string path) {
            return GetTypeIconAsync(typeId, size, path).Result;
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public Task<string> GetTypeIconAsync(long typeId, TypeIconSize size, string path) {
            const string relUri = "/InventoryType";
            const string ext = ".png";
            return requestImageAsync(relUri, typeId, (int)size, ext, path);
        }

        /// <summary>
        ///     Returns the type icon.
        /// </summary>
        public byte[] GetTypeIconData(long typeId, TypeIconSize size) {
            return GetTypeIconDataAsync(typeId, size).Result;
        }

        /// <summary>
        ///     Returns the type icon.
        /// </summary>
        public Task<byte[]> GetTypeIconDataAsync(long typeId, TypeIconSize size) {
            const string relUri = "/InventoryType";
            const string ext = ".png";
            return requestImageDataAsync(relUri, typeId, (int)size, ext);
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public string GetRender(long typeId, RenderSize size, string path) {
            return GetRenderAsync(typeId, size, path).Result;
        }

        /// <summary>
        ///     Saves the image to disk , and returns the path to the image.
        /// </summary>
        public Task<string> GetRenderAsync(long typeId, RenderSize size, string path) {
            const string relUri = "/Render";
            const string ext = ".png";
            return requestImageAsync(relUri, typeId, (int)size, ext, path);
        }

        /// <summary>
        ///     Returns the render image.
        /// </summary>
        public byte[] GetRenderData(long typeId, RenderSize size) {
            return GetRenderDataAsync(typeId, size).Result;
        }

        /// <summary>
        ///     Returns the render image.
        /// </summary>
        public Task<byte[]> GetRenderDataAsync(long typeId, RenderSize size) {
            const string relUri = "/Render";
            const string ext = ".png";
            return requestImageDataAsync(relUri, typeId, (int)size, ext);
        }

        private Task<byte[]> requestImageDataAsync(string relPath, long id, int size, string extension) {
            string fileName = id + "_" + size + extension;
            var uri = new Uri(BaseUri, relPath + Config.Separator + fileName);
            return ImageRequester.RequestImageDataAsync(uri);
        }

        private async Task<string> requestImageAsync(string relUri, long id, int size, string extension, string path) {
            string fileName = id + "_" + size + extension;
            var uri = new Uri(BaseUri, relUri + Config.Separator + fileName);
            string file = path + Config.Separator + fileName;
            await ImageRequester.RequestImageAsync(uri, file).ConfigureAwait(false);
            return file;
        }
    }

    public interface IImageRequester {
        Task<byte[]> RequestImageDataAsync(Uri uri);

        Task RequestImageAsync(Uri uri, string file);
    }

    public class ImageRequester : IImageRequester {
        public Task<byte[]> RequestImageDataAsync(Uri uri) {
            var client = new WebClient();
            return client.DownloadDataTaskAsync(uri);
        }

        public Task RequestImageAsync(Uri uri, string file) {
            var client = new WebClient();
            return client.DownloadFileTaskAsync(uri, file);
        }
    }
}