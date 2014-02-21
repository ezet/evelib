
using System;
using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Dto.EveApi.Map;

namespace eZet.Eve.EolNet.Entity {
    public class Map : BaseEntity {
        protected override sealed string UriBase { get; set; }

        internal Map() {
            UriBase = "https://api.eveonline.com";
        }

        public XmlResponse<FacWarSystems> GetFactionWarSystems() {
            const string path = "/map/FacWarSystems.xml.aspx";
            return request(path, new FacWarSystems());
        }

        public XmlResponse<Jumps> GetJumps() {
            const string path = "/map/Jumps.xml.aspx";
            return request(path, new Jumps());
        }

        public XmlResponse<Kills> GetKills() {
            const string path = "/map/Kills.xml.aspx";
            return request(path, new Kills());
        }

        public XmlResponse<Sovereignty> GetSovereignty() {
            const string path = "/map/Sovereignty.xml.aspx";
            return request(path, new Sovereignty());
        }

        public void GetSovereigntyStatus() {
            throw new NotImplementedException();
            // Temporarily disabled by CCP
        }



    }
}
