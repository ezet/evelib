using System.Linq;
using System.Threading.Tasks;
using eZet.EveLib.DynamicCrest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.EveLib.Test {
    [TestClass]
    public class DynamicCrestTest {

        private const string RefreshToken =
         "w_FqWliGJYDmPBycG2GtwYyizqMK-wQw6yuBfQf2r05bwG-BJgCM3HcdzUDFc2-N23sv-VGmWCgVttWpcOLq6w2";

        private const string EncodedKey =
            "NDZkYWEyYjM3OGJkNGJjMTg5ZGY0YzNhNzNhZjIyNmE6SzhHY1dBRGxqZ25MWnlyS0dGZmlxekhWdlZpR2hhcE9ZU0NFeTgzaA==";

        private DynamicCrest.DynamicCrest crest = new DynamicCrest.DynamicCrest(RefreshToken, EncodedKey);

        [TestMethod]
        public async Task SimpleGet() {
            var root = await crest.GetAsync(crest.Host);
            var alliance = await (await root.GetAsync(r => r.alliances)).GetAsync(a => a.First(o => o.shortName == "666"));
        }

        [TestMethod]
        public async Task AutomaticPaging() {
            var root = await crest.GetAsync(crest.Host);
            var alliance = await (await root.GetAsync(r => r.alliances)).GetAsync(a => a.First(o => o.id == 99000967));
        }

        [TestMethod]
        public async Task Contacts() {
            var character = await (await (await crest.GetAsync(crest.Host)).GetAsync(r => r.decode)).GetAsync(r => r.character);
            var contact = (await character.GetAsync(r => r.contacts)).First();
            crest.PostAsync(contact, character["contacts"].href);

        }

        [TestMethod]
        public async Task AddWaypoint() {
            var character = await (await (await crest.GetAsync(crest.Host)).GetAsync(r => r.decode)).GetAsync(r => r.character);
            var system = (await(await crest.GetAsync(crest.Host)).GetAsync(r => r.systems)).First();
            //var system = new Resource(30000142, "http://crest.regner.dev/solarsystems/30000142/");
            var wp = new AutopilotWaypoint(system);
            //wp.SolarSystem = system;
            await crest.PostAsync(character["waypoints"].href, wp);
        }
    }
}
