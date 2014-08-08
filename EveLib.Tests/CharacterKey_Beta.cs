using System;
using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Character;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class CharacterKey_Beta {
        private const string SisiVCode = "nNsODzp8SwufvWeMUmE0UINIMxTpNpEqqr2MOn6DmAXgQBRjKwFc7C4i5pp5uVRX";

        private const int SisiKeyId = 1467543;

        private readonly CharacterKey _sisiKey = new CharacterKey(SisiKeyId, SisiVCode);


        public CharacterKey_Beta() {
            _sisiKey.BaseUri = "https://api.testeveonline.com";
            _sisiKey.Characters.First().BaseUri = "https://api.testeveonline.com";
        }

        [TestMethod]
        public async Task GetBlueprints() {
            var result = _sisiKey.Characters.First().GetBlueprintsAsync();
        }


    }
}