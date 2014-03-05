using System.Linq;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Model.EveApi.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {
    [TestClass]
    public class Core_Tests {
        private const string CharName = "CCP Garthagk";

        private const long CharId = 797400947;
        private readonly EveLib api = EveLib.Create();

        [TestMethod]
        public void GetAllianceList_ValidRequest_HasResult() {
            EveApiResponse<AllianceList> xml = api.Core.GetAllianceList();
            Assert.IsNotNull(xml.Result.Alliances.First());
        }

        /// <summary>
        ///     Currently disabled by CCP
        /// </summary>
        [TestMethod]
        public void GetCertificateTree_ValidRequest_HasResult() {
            EveApiResponse<CertificateTree> xml = api.Core.GetCertificateTree();
            Assert.IsNotNull(xml.Result);
        }

        /// <summary>
        ///     Not yet implemented by CCP
        /// </summary>
        [TestMethod]
        public void GetCharacterAffiliation_ValidRequest_HasResult() {
            EveApiResponse<CharacterAffiliation> xml = api.Core.GetCharacterAffiliation(CharId);
            Assert.IsNotNull(xml.Result.Characters.First(), "Not implemented by CCP yet.");
        }

        [TestMethod]
        public void GetCharacterId_ValidName_IdIsEqual() {
            EveApiResponse<CharacterNameId> xml = api.Core.GetCharacterId(CharName);
            Assert.AreEqual(CharId, xml.Result.Characters.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidId_IdIsEqual() {
            EveApiResponse<CharacterInfo> xml = api.Core.GetCharacterInfo(CharId);
            Assert.AreEqual(CharId, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetCharacterName_ValidId_NameIsEqual() {
            EveApiResponse<CharacterNameId> xml = api.Core.GetCharacterName(CharId);
            Assert.AreEqual(CharName, xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetConquerableStations_ValidRequest_HasResult() {
            EveApiResponse<ConquerableStations> xml = api.Core.GetConquerableStations();
            Assert.IsNotNull(xml.Result.Stations.First().StationName);
        }

        [TestMethod]
        public void GetErrorList_ValidRequest_HasResult() {
            EveApiResponse<ErrorList> xml = api.Core.GetErrorList();
            Assert.IsNotNull(xml.Result.Errors.First().ErrorText);
        }

        [TestMethod]
        public void GetFactionWarfareStats_ValidRequest_HasResult() {
            EveApiResponse<FactionWarfareStats> xml = api.Core.GetFactionWarfareStats();
            Assert.IsNotNull(xml.Result.Factions.First().FactionName);
        }

        [TestMethod]
        public void GetFactionWarfareTopList_ValidRequest_HasResult() {
            EveApiResponse<FactionWarTopStats> xml = api.Core.GetFactionWarfareTopList();
            Assert.IsNotNull(xml.Result.Characters.KillsYesterday.First().CharacterName);
        }

        [TestMethod]
        public void GetReferenceTypes_ValidRequest_HasResult() {
            EveApiResponse<ReferenceTypes> xml = api.Core.GetReferenceTypes();
            Assert.IsNotNull(xml.Result.RefTypes.First().RefTypeName);
        }

        [TestMethod]
        public void GetSkillTree_ValidRequest_HasResult() {
            EveApiResponse<SkillTree> xml = api.Core.GetSkillTree();
            Assert.IsNotNull(xml.Result.Groups.First());
        }

        [TestMethod]
        public void GetTypeName_ValidId_HasResult() {
            EveApiResponse<TypeName> xml = api.Core.GetTypeName(12345);
            Assert.AreEqual("200mm Railgun I Blueprint", xml.Result.Types.First().TypeName);
        }

        [TestMethod]
        public void GetServerStatus_ValidRequest_HasResult() {
            EveApiResponse<ServerStatus> xml = api.Core.GetServerStatus();
            Assert.IsNotNull(xml.Result.ServerOpen);
        }

        [TestMethod]
        public void GetCallList_ValidRequest_HasResult() {
            EveApiResponse<CallList> xml = api.Core.GetCallList();
            Assert.IsNotNull(xml.Result.CallGroups.First());
            Assert.IsNotNull(xml.Result.Calls.First());
        }
    }
}