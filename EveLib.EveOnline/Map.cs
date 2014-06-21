using System;
using System.Threading.Tasks;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Map;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to Map related requests.
    /// </summary>
    public class Map : BaseEntity {

        /// <summary>
        ///     Returns a list of contestable solarsystems and the NPC faction currently occupying them.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<FactionWarfareSystems> GetFactionWarSystems() {
            return GetFactionWarSystemsAsync().Result;
        }

        /// <summary>
        ///     Returns a list of contestable solarsystems and the NPC faction currently occupying them.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<FactionWarfareSystems>> GetFactionWarSystemsAsync() {
            const string path = "/map/FacWarSystems.xml.aspx";
            return requestAsync<FactionWarfareSystems>(path);
        }

        /// <summary>
        ///     Returns all possible stargate jumps.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Jumps> GetJumps() {
            return GetJumpsAsync().Result;
        }

        /// <summary>
        ///     Returns all possible stargate jumps.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<Jumps>> GetJumpsAsync() {
            const string path = "/map/Jumps.xml.aspx";
            return requestAsync<Jumps>(path);
        }

        /// <summary>
        ///     Returns the number of kills in solarsystems within the last hour. Only solar system where kills have been made are
        ///     listed.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Kills> GetKills() {
            return GetKillsAsync().Result;
        }

        /// <summary>
        ///     Returns the number of kills in solarsystems within the last hour. Only solar system where kills have been made are
        ///     listed.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<Kills>> GetKillsAsync() {
            const string path = "/map/Kills.xml.aspx";
            return requestAsync<Kills>(path);
        }

        /// <summary>
        ///     Returns a list of solarsystems and what faction or alliance controls them.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Sovereignty> GetSovereignty() {
            return GetSovereigntyAsync().Result;
        }

        /// <summary>
        ///     Returns a list of solarsystems and what faction or alliance controls them.
        /// </summary>
        /// <returns></returns>
        public Task<EveApiResponse<Sovereignty>> GetSovereigntyAsync() {
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