using System;
using System.Globalization;
using System.Linq;
using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Dto.EveApi.Core;

namespace eZet.Eve.EveApi.Entity {
    public class Core : EveApiEntity {

        public XmlResponse<AllianceList> GetAllianceList() {
            const string path = "/eve/AllianceList.xml.aspx";
            return request(path, new AllianceList());
        }

        public XmlResponse<CertificateTree> GetCertificateTree() {
            const string path = "/eve/CertificateTree.xml.aspx";
            return request(path, new CertificateTree());

        }

        public XmlResponse<CharacterAffiliation> GetCharacterAffiliation() {
            const string path = "/eve/CharacterAffiliation.xml.aspx";
            return request(path, new CharacterAffiliation());
        }

        public XmlResponse<CharacterNameId> GetCharacterId(params string[] list) {
            const string path = "/eve/CharacterID.xml.aspx";
            var names = String.Join(",", list);
            var postString = WebHelper.GeneratePostString("names", names);
            return request(path, new CharacterNameId(), postString);
        }

        public XmlResponse<CharacterInfo> GetCharacterInfo(long id, ApiKey key = default(ApiKey)) {
            const string path = "/eve/CharacterInfo.xml.aspx";
            var postString = key.Equals(default(ApiKey)) ? WebHelper.GeneratePostString("characterID", id)
                                                         : WebHelper.GeneratePostString(ApiKey, "characterID", id);
            return request(path, new CharacterInfo(), postString);
        }

        public XmlResponse<CharacterNameId> GetCharacterName(params long[] list) {
            const string path = "/eve/CharacterName.xml.aspx";
            var ids = String.Join(",", list);
            var postString = WebHelper.GeneratePostString("ids", ids);
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
            //var ids = String.Join(",", list.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
            var ids = String.Join(",", list);
            var postString = WebHelper.GeneratePostString("ids", ids);
            return request(path, new TypeName(), postString);
        }









    }
}
