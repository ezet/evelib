using System;
using eZet.EveLib.Modules.Models;
using eZet.EveLib.Modules.Models.Map;

namespace eZet.EveLib.Modules {
    /// <summary>
    ///     Provides access to Map related requests.
    /// </summary>
    public class Map : BaseEntity {
        public Map() {
            BaseUri = new Uri("https://api.eveonline.com");
        }

        /// <summary>
        ///     Returns a list of contestable solarsystems and the NPC faction currently occupying them.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<FactionWarfareSystems> GetFactionWarSystems() {
            const string path = "/map/FacWarSystems.xml.aspx";
            return request<FactionWarfareSystems>(path);
        }

        /// <summary>
        ///     Returns all possible stargate jumps.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Jumps> GetJumps() {
            const string path = "/map/Jumps.xml.aspx";
            return request<Jumps>(path);
        }

        /// <summary>
        ///     Returns the number of kills in solarsystems within the last hour. Only solar system where kills have been made are
        ///     listed.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Kills> GetKills() {
            const string path = "/map/Kills.xml.aspx";
            return request<Kills>(path);
        }

        /// <summary>
        ///     Returns a list of solarsystems and what faction or alliance controls them.
        /// </summary>
        /// <returns></returns>
        public EveApiResponse<Sovereignty> GetSovereignty() {
            const string path = "/map/Sovereignty.xml.aspx";
            return request<Sovereignty>(path);
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