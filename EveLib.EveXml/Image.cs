using System;
using System.Threading.Tasks;
using eZet.EveLib.Core;
using eZet.EveLib.Core.RequestHandlers;

namespace eZet.EveLib.EveXmlModule {
    /// <summary>
    ///     Provides access to all image related requests.
    /// </summary>
    public class Image {
        /// <summary>
        ///     Represents the alliance logo sizes
        /// </summary>
        public enum AllianceLogoSize {
            /// <summary>
            ///     30x30
            /// </summary>
            X30 = 30,

            /// <summary>
            ///     32x32
            /// </summary>
            X32 = 32,

            /// <summary>
            ///     64x64
            /// </summary>
            X64 = 64,

            /// <summary>
            ///     128x128
            /// </summary>
            X128 = 128
        }

        /// <summary>
        ///     Represents the character portrait sizes
        /// </summary>
        public enum CharacterPortraitSize {
            /// <summary>
            ///     30x30
            /// </summary>
            X30 = 30,

            /// <summary>
            ///     32x32
            /// </summary>
            X32 = 32,

            /// <summary>
            ///     64x64k
            /// </summary>
            X64 = 64,

            /// <summary>
            ///     128x128
            /// </summary>
            X128 = 128,

            /// <summary>
            ///     200x200
            /// </summary>
            X200 = 200,

            /// <summary>
            ///     256x256
            /// </summary>
            X256 = 256,

            /// <summary>
            ///     512x512
            /// </summary>
            X512 = 512,

            /// <summary>
            ///     1024x1024
            /// </summary>
            X1024 = 1024
        }

        /// <summary>
        ///     Represents the corporation logo sizes
        /// </summary>
        public enum CorporationLogoSize {
            /// <summary>
            ///     30x30
            /// </summary>
            X30 = 30,

            /// <summary>
            ///     32x32
            /// </summary>
            X32 = 32,

            /// <summary>
            ///     64x64
            /// </summary>
            X64 = 64,

            /// <summary>
            ///     128x128
            /// </summary>
            X128 = 128,

            /// <summary>
            ///     256x256
            /// </summary>
            X256 = 256
        }

        /// <summary>
        ///     Represents the render sizes
        /// </summary>
        public enum RenderSize {
            /// <summary>
            ///     32x32
            /// </summary>
            X32 = 32,

            /// <summary>
            ///     64x64
            /// </summary>
            X64 = 64,

            /// <summary>
            ///     128x128
            /// </summary>
            X128 = 128,

            /// <summary>
            ///     256x256
            /// </summary>
            X256 = 256,

            /// <summary>
            ///     512x512
            /// </summary>
            X512 = 512
        }

        /// <summary>
        ///     Represents the type icon sizes
        /// </summary>
        public enum TypeIconSize {
            /// <summary>
            ///     32x32
            /// </summary>
            X32 = 32,

            /// <summary>
            ///     64x64
            /// </summary>
            X64 = 64
        }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public Image() {
            RequestHandler = new ImageRequestHandler();
            BaseUri = "http://image.eveonline.com/";
        }

        /// <summary>
        ///     Gets or sets the base URI.
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        ///     Gets or sets the RequestHandler
        /// </summary>
        public IImageRequestHandler RequestHandler { get; set; }

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
            return requestImageAsync(relUri, characterId, (int) size, ext, path);
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
            return requestImageAsync(relUri, corporationId, (int) size, ext, path);
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
            return requestImageDataAsync(relUri, corporationId, (int) size, ext);
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
            return requestImageAsync(relUri, allianceId, (int) size, ext, path);
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
            return requestImageDataAsync(relUri, allianceId, (int) size, ext);
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
            return requestImageAsync(relUri, typeId, (int) size, ext, path);
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
            return requestImageDataAsync(relUri, typeId, (int) size, ext);
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
            return requestImageAsync(relUri, typeId, (int) size, ext, path);
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
            return requestImageDataAsync(relUri, typeId, (int) size, ext);
        }

        private Task<byte[]> requestImageDataAsync(string relPath, long id, int size, string extension) {
            var fileName = id + "_" + size + extension;
            var uri = new Uri(BaseUri + relPath + Config.Separator + fileName);
            return RequestHandler.RequestImageDataAsync(uri);
        }

        private async Task<string> requestImageAsync(string relUri, long id, int size, string extension, string path) {
            var fileName = id + "_" + size + extension;
            var uri = new Uri(BaseUri + relUri + Config.Separator + fileName);
            var file = path + Config.Separator + fileName;
            await RequestHandler.RequestImageAsync(uri, file).ConfigureAwait(false);
            return file;
        }
    }
}