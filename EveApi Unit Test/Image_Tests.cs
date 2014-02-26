using eZet.Eve.EoLib.Entity;
using eZet.Eve.EoLib.Entity.EveApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EoLib.Test {
    [TestClass]
    public class Image_Tests {

        private readonly Image image = new Image();

        private const long CharId = 797400947;

        [TestMethod]
        public void GetCharacterPortrait_ValidRequest_NoExceptions() {
            image.GetCharacterPortrait(CharId, Image.CharacterPortraitSize.X256);
        }
        
        [TestMethod]
        public void GetCharacterPortraitData_ValidRequest_NoExceptions() {
            image.GetCharacterPortraitData(CharId, Image.CharacterPortraitSize.X30);
        }


    }
}
