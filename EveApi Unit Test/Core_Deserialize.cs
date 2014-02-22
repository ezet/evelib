using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EoLib.Test {

    [TestClass]
    public class Core_Deserialize {

        private readonly EoLib api = new EoLib();

        private const string CharName = "CCP Garthagk";

        private const long CharId = 797400947;


        [TestMethod]
        public void TestAllianceList() {
            var xml = api.Core.GetAllianceList();
            Assert.IsNotNull(xml.Result.Alliances.First().AllianceName);
        }

        [TestMethod]
        public void TestCertificateTree() {
            var xml = api.Core.GetCertificateTree();
            Assert.IsNotNull(xml.Result);
        }

        [TestMethod]
        public void TestCharacterAffiliation() {
            // TODO Not implemented by CCP yet
            //var xml = api.Core.GetCharacterAffiliation(CharId);
            //Assert.IsNotNull(xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void TestCharacterId() {
            var xml = api.Core.GetCharacterId(CharName);
            Assert.AreEqual(CharId, xml.Result.Characters.First().CharacterId);
        }

        [TestMethod]
        public void TestCharacterInfo() {
            var xml = api.Core.GetCharacterInfo(CharId);
            Assert.AreEqual(CharId, xml.Result.CharacterId);
        }

        [TestMethod]
        public void TestCharacterName() {
            var xml = api.Core.GetCharacterName(CharId);
            Assert.AreEqual(CharName, xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void TestConquerableStations() {
            var xml = api.Core.GetConquerableStations();
            Assert.IsNotNull(xml.Result.Stations.First().StationName);
        }

        [TestMethod]
        public void TestErrorList() {
            var xml = api.Core.GetErrorList();
            Assert.IsNotNull(xml.Result.Errors.First().ErrorText);
        }

        [TestMethod]
        public void TestFactionWarfareStats() {
            var xml = api.Core.GetFactionWarfareStats();
            Assert.IsNotNull(xml.Result.Factions.First().FactionName);
        }

        [TestMethod]
        public void TestFactionWarfareTopList() {
            var xml = api.Core.GetFactionWarfareTopList();
            Assert.IsNotNull(xml.Result.Characters.KillsYesterday.First().CharacterName);
        }

        [TestMethod]
        public void TestReferenceTypes() {
            var xml = api.Core.GetReferenceTypes();
            Assert.IsNotNull(xml.Result.RefTypes.First().RefTypeName);
        }

        [TestMethod]
        public void TestSkillTree() {
            var xml = api.Core.GetSkillTree();
            Assert.IsNotNull(xml.Result.Groups);
        }

        [TestMethod]
        public void TestTypeName() {
            var xml = api.Core.GetTypeName(12345);
            Assert.AreEqual("200mm Railgun I Blueprint", xml.Result.Types.First().TypeName);
        }

        [TestMethod]
        public void TestServerStatus() {
            var xml = api.Core.GetServerStatus();
            Assert.IsNotNull(xml.Result.ServerOpen);
        }

        [TestMethod]
        public void TestCallList() {
            var xml = api.Core.GetCallList();
            Assert.IsNotNull(xml.Result.CallGroups.RowSetMeta.Key);
            Assert.IsNotNull(xml.Result.Calls.RowSetMeta.Key);
        }
    }
}
