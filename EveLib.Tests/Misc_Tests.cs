using System.Linq;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Misc_Tests {
        private const string CharName = "CCP Garthagk";

        private const long CharId = 797400947;
        private readonly Eve api = new Eve();

        [TestMethod]
        public void GetAllianceList_ValidRequest_HasResult() {
            EveApiResponse<AllianceList> xml = api.GetAllianceList();
            Assert.IsNotNull(xml.Result.Alliances.First());
        }

        /// <summary>
        ///     Currently disabled by CCP
        /// </summary>
        [TestMethod]
        public void GetCertificateTree_ValidRequest_HasResult() {
            EveApiResponse<CertificateTree> xml = api.GetCertificateTree();
            Assert.IsNotNull(xml.Result);
        }

        /// <summary>
        ///     Not yet implemented by CCP
        /// </summary>
        [TestMethod]
        public void GetCharacterAffiliation_ValidRequest_HasResult() {
            EveApiResponse<CharacterAffiliation> xml = api.GetCharacterAffiliation(CharId);
            Assert.IsNotNull(xml.Result.Characters.First());
        }

        [TestMethod]
        public void GetCharacterId_ValidName_IdIsEqual() {
            EveApiResponse<CharacterNameId> xml = api.GetCharacterId(CharName);
            Assert.AreEqual(CharId, xml.Result.Characters.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidId_IdIsEqual() {
            EveApiResponse<CharacterInfo> xml = api.GetCharacterInfo(CharId);
            Assert.AreEqual(CharId, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetCharacterName_ValidId_NameIsEqual() {
            EveApiResponse<CharacterNameId> xml = api.GetCharacterName(CharId);
            Assert.AreEqual(CharName, xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetConquerableStations_ValidRequest_HasResult() {
            EveApiResponse<ConquerableStations> xml = api.GetConquerableStations();
            Assert.IsNotNull(xml.Result.Stations.First().StationName);
        }

        [TestMethod]
        public void GetErrorList_ValidRequest_HasResult() {
            EveApiResponse<ErrorList> xml = api.GetErrorList();
            Assert.IsNotNull(xml.Result.Errors.First().ErrorText);
        }

        [TestMethod]
        public void GetFactionWarfareStats_ValidRequest_HasResult() {
            EveApiResponse<FactionWarfareStats> xml = api.GetFactionWarfareStats();
            Assert.IsNotNull(xml.Result.Factions.First().FactionName);
        }

        [TestMethod]
        public void GetFactionWarfareTopList_ValidRequest_HasResult() {
            EveApiResponse<FactionWarTopStats> xml = api.GetFactionWarfareTopList();
            Assert.IsNotNull(xml.Result.Characters.KillsYesterday.First().CharacterName);
        }

        [TestMethod]
        public void GetReferenceTypes_ValidRequest_HasResult() {
            EveApiResponse<ReferenceTypes> xml = api.GetReferenceTypes();
            Assert.IsNotNull(xml.Result.RefTypes.First().RefTypeName);
        }

        [TestMethod]
        public void GetSkillTree_ValidRequest_HasResult() {
            EveApiResponse<SkillTree> xml = api.GetSkillTree();
            Assert.IsNotNull(xml.Result.Groups.First());
        }

        [TestMethod]
        public void GetTypeName_ValidId_HasResult() {
            EveApiResponse<TypeName> xml = api.GetTypeName(12345);
            Assert.AreEqual("200mm Railgun I Blueprint", xml.Result.Types.First().TypeName);
        }

        [TestMethod]
        public void GetServerStatus_ValidRequest_HasResult() {
            EveApiResponse<ServerStatus> xml = api.GetServerStatus();
            Assert.IsNotNull(xml.Result.ServerOpen);
        }

        [TestMethod]
        public void GetCallList_ValidRequest_HasResult() {
            EveApiResponse<CallList> xml = api.GetCallList();
            Assert.IsNotNull(xml.Result.CallGroups.First());
            Assert.IsNotNull(xml.Result.Calls.First());
        }

        [TestMethod]
        public void GetOwner_ValidRequest_HasResult() {
            EveApiResponse<OwnerCollection> xml = api.GetOwnerId(CharName);
            Assert.IsNotNull(xml.Result.Owners.First());
            Assert.AreEqual(CharId, xml.Result.Owners.First().OwnerId);
        }
    }
}