using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EolNet.Test {

    [TestClass]
    public class Core_Deserialize {

        private readonly EolNet api = new EolNet();

        private const string CharName = "CCP Garthagk";

        private const long CharId = 797400947;


        [TestMethod]
        public void TestAllianceList() {
            var xml = api.Eve.GetAllianceList();
            Assert.IsNotNull(xml.Result.Alliances.First().AllianceName);
        }

        [TestMethod]
        public void TestCertificateTree() {
            var xml = api.Eve.GetCertificateTree();
            Assert.IsNotNull(xml.Result);
        }

        [TestMethod]
        public void TestCharacterAffiliation() {
            // TODO Not implemented by CCP yet
            //var xml = api.Eve.GetCharacterAffiliation(CharId);
            //Assert.IsNotNull(xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void TestCharacterId() {
            var xml = api.Eve.GetCharacterId(CharName);
            Assert.AreEqual(CharId, xml.Result.Characters.First().CharacterId);
        }

        [TestMethod]
        public void TestCharacterInfo() {
            var xml = api.Eve.GetCharacterInfo(CharId);
            Assert.AreEqual(CharId, xml.Result.CharacterId);
        }

        [TestMethod]
        public void TestCharacterName() {
            var xml = api.Eve.GetCharacterName(CharId);
            Assert.AreEqual(CharName, xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void TestConquerableStations() {
            var xml = api.Eve.GetConquerableStations();
            Assert.IsNotNull(xml.Result.Stations.First().StationName);
        }

        [TestMethod]
        public void TestErrorList() {
            var xml = api.Eve.GetErrorList();
            Assert.IsNotNull(xml.Result.Errors.First().ErrorText);
        }

        [TestMethod]
        public void TestFactionWarfareStats() {
            var xml = api.Eve.GetFactionWarfareStats();
            Assert.IsNotNull(xml.Result.Factions.First().FactionName);
        }

        [TestMethod]
        public void TestFactionWarfareTopList() {
            var xml = api.Eve.GetFactionWarfareTopList();
            // TODO write test
            Assert.IsNotNull(xml.Result);
        }

        [TestMethod]
        public void TestReferenceTypes() {
            var xml = api.Eve.GetReferenceTypes();
            Assert.IsNotNull(xml.Result.RefTypes.First().RefTypeName);
        }

        [TestMethod]
        public void TestSkillTree() {
            var xml = api.Eve.GetSkillTree();
            Assert.IsNotNull(xml.Result.Groups);
        }

        [TestMethod]
        public void TestTypeName() {
            var xml = api.Eve.GetTypeName(12345);
            Assert.AreEqual("200mm Railgun I Blueprint", xml.Result.Types.First().TypeName);
        }

        [TestMethod]
        public void TestServerStatus() {
            var xml = api.Eve.GetServerStatus();
            Assert.IsNotNull(xml.Result.ServerOpen);
        }

        [TestMethod]
        public void TestCallList() {
            var xml = api.Eve.GetCallList();
            Assert.IsNotNull(xml.Result.CallGroups.RowSetMeta.Key);
            Assert.IsNotNull(xml.Result.Calls.RowSetMeta.Key);
        }
    }
}
