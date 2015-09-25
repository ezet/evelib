using System.Linq;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.Models.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eZet.EveLib.EveXmlModule.Models.Corporation;

namespace eZet.EveLib.Test {
    [TestClass]
    public class Misc_Tests {
        private const string CharName = "CCP Garthagk";

        private const long CharId = 797400947;
        private readonly Eve api = new Eve();

        [TestMethod]
        public void GetAllianceList_ValidRequest_HasResult() {
            EveXmlResponse<AllianceList> xml = api.GetAllianceList(true);
            Assert.IsNotNull(xml.Result.Alliances.First());
            Assert.IsNotNull(xml.Result.Alliances.First().Corporations);
        }

        /// <summary>
        ///     Currently disabled by CCP
        /// </summary>
        [TestMethod]
        public void GetCertificateTree_ValidRequest_HasResult() {
            EveXmlResponse<CertificateTree> xml = api.GetCertificateTree();
            Assert.IsNotNull(xml.Result);
        }

        /// <summary>
        ///     Not yet implemented by CCP
        /// </summary>
        [TestMethod]
        public void GetCharacterAffiliation_ValidRequest_HasResult() {
            EveXmlResponse<CharacterAffiliation> xml = api.GetCharacterAffiliation(CharId);
            Assert.IsNotNull(xml.Result.Characters.First());
        }

        [TestMethod]
        public void GetCharacterId_ValidName_IdIsEqual() {
            EveXmlResponse<CharacterNameId> xml = api.GetCharacterId(CharName);
            Assert.AreEqual(CharId, xml.Result.Characters.First().CharacterId);
        }

        [TestMethod]
        public void GetCharacterInfo_ValidId_IdIsEqual() {
            EveXmlResponse<CharacterInfo> xml = api.GetCharacterInfo(CharId);
            Assert.AreEqual(CharId, xml.Result.CharacterId);
        }

        [TestMethod]
        public void GetCharacterName_ValidId_NameIsEqual() {
            EveXmlResponse<CharacterNameId> xml = api.GetCharacterName(CharId);
            Assert.AreEqual(CharName, xml.Result.Characters.First().CharacterName);
        }

        [TestMethod]
        public void GetConquerableStations_ValidRequest_HasResult() {
            EveXmlResponse<ConquerableStations> xml = api.GetConquerableStations();
            Assert.IsNotNull(xml.Result.Stations.First().StationName);
        }

        [TestMethod]
        public void GetErrorList_ValidRequest_HasResult() {
            EveXmlResponse<ErrorList> xml = api.GetErrorList();
            Assert.IsNotNull(xml.Result.Errors.First().ErrorText);
        }

        [TestMethod]
        public void GetFactionWarfareStats_ValidRequest_HasResult() {
            EveXmlResponse<EveXmlModule.Models.Misc.FactionWarfareStats> xml = api.GetFactionWarfareStats();
            Assert.IsNotNull(xml.Result.Factions.First().FactionName);
        }

        [TestMethod]
        public void GetFactionWarfareTopList_ValidRequest_HasResult() {
            EveXmlResponse<FactionWarTopStats> xml = api.GetFactionWarfareTopList();
            Assert.IsNotNull(xml.Result.Characters.KillsYesterday.First().CharacterName);
        }

        [TestMethod]
        public void GetReferenceTypes_ValidRequest_HasResult() {
            EveXmlResponse<ReferenceTypes> xml = api.GetReferenceTypes();
            Assert.IsNotNull(xml.Result.RefTypes.First().RefTypeName);
        }

        [TestMethod]
        public void GetSkillTree_ValidRequest_HasResult() {
            EveXmlResponse<SkillTree> xml = api.GetSkillTree();
            Assert.IsNotNull(xml.Result.Groups.First());
        }

        [TestMethod]
        public void GetTypeName_ValidId_HasResult() {
            EveXmlResponse<TypeName> xml = api.GetTypeName(12345);
            Assert.AreEqual("200mm Railgun I Blueprint", xml.Result.Types.First().TypeName);
        }

        [TestMethod]
        public void GetServerStatus_ValidRequest_HasResult() {
            EveXmlResponse<ServerStatus> xml = api.GetServerStatus();
            Assert.IsNotNull(xml.Result.ServerOpen);
        }

        [TestMethod]
        public void GetCallList_ValidRequest_HasResult() {
            EveXmlResponse<CallList> xml = api.GetCallList();
            Assert.IsNotNull(xml.Result.CallGroups.First());
            Assert.IsNotNull(xml.Result.Calls.First());
        }

        [TestMethod]
        public void GetOwner_ValidRequest_HasResult() {
            EveXmlResponse<OwnerCollection> xml = api.GetOwnerId(CharName);
            Assert.IsNotNull(xml.Result.Owners.First());
            Assert.AreEqual(CharId, xml.Result.Owners.First().OwnerId);
        }

        [TestMethod]
        public void GetCorporationSheet_ValidRequest_HasResult() {
            EveXmlResponse<CorporationSheet> xml = api.GetCorporationSheet(109299958);
            Assert.AreEqual("C C P", xml.Result.CorporationName);
        }


    }
}