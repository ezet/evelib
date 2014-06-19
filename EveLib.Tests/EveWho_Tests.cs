using System.Threading.Tasks;
using eZet.EveLib.Modules;
using eZet.EveLib.Modules.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class EveWho_Tests {
        private readonly EveWho _api = new EveWho();

        [TestMethod]
        public async Task GetCharacter_NoErrors() {
            EveWhoResponse<EveWhoCharacter> data = await _api.GetCharacterAsync(1633218082);
        }

        [TestMethod]
        public async Task GetCorporation_NoErrors() {
            EveWhoResponse<EveWhoCorporation> data = await _api.GetCorporationAsync(869043665);
        }

        [TestMethod]
        public async Task GetCorporationMember_NoErrors() {
            EveWhoResponse<EveWhoCorporationMembers> data = await _api.GetCorporationMembersAsync(869043665);
        }

        [TestMethod]
        public async Task GetAlliance_NoErrors() {
            EveWhoResponse<EveWhoAlliance> data = await _api.GetAllianceAsync(99001433);
        }

        [TestMethod]
        public async Task GetAllianceMembers_NoErrors() {
            EveWhoResponse<EveWhoAllianceMembers> data = await _api.GetAllianceMembersAsync(99001433);
        }
    }
}