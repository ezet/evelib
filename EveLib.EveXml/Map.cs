using System;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.Models.Map;

namespace eZet.EveLib.EveXmlModule {
    /// <summary>
    ///     Provides access to Map related requests.
    /// </summary>
    public class Map : BaseEntity {
        /// <summary>
        ///     Returns a list of contestable solarsystems and the NPC faction currently occupying them.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<FactionWarfareSystems> GetFactionWarSystems() {
            return GetFactionWarSystemsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of contestable solarsystems and the NPC faction currently occupying them.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<FactionWarfareSystems>> GetFactionWarSystemsAsync() {
            const string path = "/map/FacWarSystems.xml.aspx";
            return requestAsync<FactionWarfareSystems>(path);
        }

        /// <summary>
        ///     Returns all possible stargate jumps.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<Jumps> GetJumps() {
            return GetJumpsAsync().Result;
        }

        /// <summary>
        ///     Returns all possible stargate jumps.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<Jumps>> GetJumpsAsync() {
            const string path = "/map/Jumps.xml.aspx";
            return requestAsync<Jumps>(path);
        }

        /// <summary>
        ///     Returns the number of kills in solarsystems within the last hour. Only solar system where kills have been made are
        ///     listed.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<Kills> GetKills() {
            return GetKillsAsync().Result;
        }

        /// <summary>
        ///     Returns the number of kills in solarsystems within the last hour. Only solar system where kills have been made are
        ///     listed.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<Kills>> GetKillsAsync() {
            const string path = "/map/Kills.xml.aspx";
            return requestAsync<Kills>(path);
        }

        /// <summary>
        ///     Returns a list of solarsystems and what faction or alliance controls them.
        /// </summary>
        /// <returns></returns>
        public EveXmlResponse<Sovereignty> GetSovereignty() {
            return GetSovereigntyAsync().Result;
        }

        /// <summary>
        ///     Returns a list of solarsystems and what faction or alliance controls them.
        /// </summary>
        /// <returns></returns>
        public Task<EveXmlResponse<Sovereignty>> GetSovereigntyAsync() {
            const string path = "/map/Sovereignty.xml.aspx";
            return requestAsync<Sovereignty>(path);
        }

        /// <summary>
        ///     Returns a list of all sovereignty structures in EVE.
        /// </summary>
        public void GetSovereigntyStatus() {

            throw new NotImplementedException();
            // Temporarily disabled by CCP
        }
    }
}