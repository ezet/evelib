using System.Threading.Tasks;
using eZet.EveLib.EveWhoModule;
using eZet.EveLib.EveWhoModule.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveWho_Tests {
        private readonly EveWho _api = new EveWho();

        [TestMethod]
        public async Task GetCharacter_NoErrors() {
            EveWhoResponse<Character> data = await _api.GetCharacterAsync(1633218082);
        }

        [TestMethod]
        public async Task GetCorporation_NoErrors() {
            EveWhoResponse<Corporation> data = await _api.GetCorporationAsync(869043665);
        }

        [TestMethod]
        public async Task GetCorporationMember_NoErrors() {
            EveWhoResponse<CorporationMembers> data = await _api.GetCorporationMembersAsync(869043665);
        }

        [TestMethod]
        public async Task GetAlliance_NoErrors() {
            EveWhoResponse<Alliance> data = await _api.GetAllianceAsync(99001433);
        }

        [TestMethod]
        public async Task GetAllianceMembers_NoErrors() {
            EveWhoResponse<AllianceMembers> data = await _api.GetAllianceMembersAsync(99001433);
        }
    }
}