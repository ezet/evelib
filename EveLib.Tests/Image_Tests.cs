using eZet.EveLib.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Image_Tests {
        private const long CharId = 797400947;
        private readonly Image image = new Image();

        [TestMethod]
        public void GetCharacterPortrait_ValidRequest_NoExceptions() {
            //image.GetCharacterPortrait(CharId, Image.CharacterPortraitSize.X256);
        }

        [TestMethod]
        public void GetCharacterPortraitData_ValidRequest_NoExceptions() {
            image.GetCharacterPortraitData(CharId, Image.CharacterPortraitSize.X30);
        }
    }
}