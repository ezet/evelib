using System;
using eZet.Eve.EolNet.Dto.EveApi;
using eZet.Eve.EolNet.Dto.EveApi.Core;
using CharacterInfo = eZet.Eve.EolNet.Dto.EveApi.Core.CharacterInfo;

namespace eZet.Eve.EolNet.Entity {
    public class Eve : BaseEntity {

        protected override sealed string UriBase { get; set; }

        public ApiKey Key { get; private set; }

        internal Eve() {
            // TODO Add key handling for characterinfo
            UriBase = "https://api.eveonline.com";
        }

        public XmlResponse<AllianceList> GetAllianceList() {
            const string path = "/eve/AllianceList.xml.aspx";
            return request(path, new AllianceList());
        }

        public XmlResponse<CertificateTree> GetCertificateTree() {
            const string path = "/eve/CertificateTree.xml.aspx";
            return request(path, new CertificateTree());
        }

        public XmlResponse<CharacterAffiliation> GetCharacterAffiliation(params long[] list) {
            const string path = "/eve/CharacterAffiliation.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("ids", ids);
            return request(path, new CharacterAffiliation(), postString);
        }

        public XmlResponse<CharacterNameId> GetCharacterId(params string[] list) {
            const string path = "/eve/CharacterID.xml.aspx";
            var names = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("names", names);
            return request(path, new CharacterNameId(), postString);
        }

        public XmlResponse<CharacterInfo> GetCharacterInfo(long id, ApiKey key = default(ApiKey)) {
            const string path = "/eve/CharacterInfo.xml.aspx";
            var postString = key.Equals(default(ApiKey)) ? RequestHelper.GeneratePostString("characterID", id)
                                                         : RequestHelper.GeneratePostString(Key, "characterID", id);
            return request(path, new CharacterInfo(), postString);
        }

        public XmlResponse<CharacterNameId> GetCharacterName(params long[] list) {
            const string path = "/eve/CharacterName.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("ids", ids);
            return request(path, new CharacterNameId(), postString);
        }

        public XmlResponse<ConquerableStations> GetConquerableStations() {
            const string path = "/eve/ConquerableStationList.xml.aspx";
            return request(path, new ConquerableStations());
        }

        public XmlResponse<ErrorList> GetErrorList() {
            const string path = "/eve/ErrorList.xml.aspx";
            return request(path, new ErrorList());
        }

        public XmlResponse<FactionWarfareStats> GetFactionWarfareStats() {
            // TODO Separate Factions and FactionWars
            const string path = "/eve/FacWarStats.xml.aspx";
            return request(path, new FactionWarfareStats());
        }

        public XmlResponse<FactionWarfareTopList> GetFactionWarfareTopList() {
            // TODO Find a way to separate rowsets
            throw new NotImplementedException();
        }

        public XmlResponse<ReferenceTypes> GetReferenceTypes() {
            const string path = "/eve/RefTypes.xml.aspx";
            return request(path, new ReferenceTypes());
        }

        public XmlResponse<SkillTree> GetSkillTree() {
            // TODO Separate rowsets
            throw new NotImplementedException();
        }

        public XmlResponse<TypeName> GetTypeName(params long[] list) {
            const string path = "/eve/TypeName.xml.aspx";
            var ids = String.Join(",", list);
            var postString = RequestHelper.GeneratePostString("ids", ids);
            return request(path, new TypeName(), postString);
        }

        public XmlResponse<ServerStatus> GetServerStatus() {
            const string path = "/server/ServerStatus.xml.aspx";
            return request(path, new ServerStatus());
        }

        public XmlResponse<CallList> GetCallList() {
            // TODO Separate rowsets
            const string path = "/api/calllist.xml.aspx";
            return request(path, new CallList());
        }
    }
}
