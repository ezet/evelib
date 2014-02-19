using System;
using eZet.Eve.EveApi.Dto.EveApi;
using eZet.Eve.EveApi.Dto.EveApi.Character;
using eZet.Eve.EveApi.Dto.EveApi.Corporation;
using MedalList = eZet.Eve.EveApi.Dto.EveApi.Corporation.MedalList;


namespace eZet.Eve.EveApi.Entity {
    public class Corporation : EveApiEntity {

        private string _corporationName;

        public string CorporationName {
            get {
                if (_corporationName == null)
                    load();
                return _corporationName;
            }
            private set { _corporationName = value; }
        }

        public long CorporationId { get; private set; }

        public long CharacterId { get; set; }

        public Corporation(ApiKey key, long characterId, long corporationId) : base(key) {
            CharacterId = characterId;
            CorporationId = corporationId;
        }

        public XmlResponse<AccountBalance> GetAccountBalance() {
            const string relPath = "/corp/AccountBalance.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new AccountBalance(), postString);
        }

        public XmlResponse<AssetList> GetAssetList() {
            const string relPath = "/corp/AssetList.xsml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new AssetList(), postString);
        }

        public XmlResponse<ContactList> GetContactList() {
            const string relPath = "/corp/ContactList.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new ContactList(), postString);
        }

        public void GetContainerLog() {
            // TODO Implement
        }

        public XmlResponse<ContractList> GetContracts() {
            const string relPath = "/corp/Contracts.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new ContractList(), postString);
        }

        public XmlResponse<ContractItems> GetContractItems(long contractId) {
            const string relPath = "/corp/ContractItems.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId, "contractID", contractId);
            return request(relPath, new ContractItems(), postString);
        }

        public XmlResponse<ContractBids> GetContractBids(long contractId) {
            const string relPath = "/corp/ContractBids.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId, "contractID", contractId);
            return request(relPath, new ContractBids(), postString);
        }

        public XmlResponse<CorporationSheet> GetCorporationSheet() {
            const string relPath = "/corp/CorporationSheet.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new CorporationSheet(), postString);
        }

        public XmlResponse<Dto.EveApi.Corporation.FactionWarfareStats> GetFactionWarfareStats() {
            const string relPath = "/corp/FacWarStats.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new Dto.EveApi.Corporation.FactionWarfareStats(), postString);
        }

        public XmlResponse<IndustryJobs> GetIndustryJobs() {
            const string relPath = "/corp/IndustryJobs.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new IndustryJobs(), postString);
        }

        public XmlResponse<KillLog> GetKillLog() {
            const string relPath = "/corp/Killlog.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new KillLog(), postString);
        }

        public XmlResponse<Locations> GetLocations(params long[] itemIds) {
            const string relPath = "/corp/Locations.xml.aspx";
            var ids = String.Join(",", itemIds);
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId, "IDs", ids);
            return request(relPath, new Locations(), postString);
        }

        public XmlResponse<MarketOrders> GetMarketOrders(long orderId) {
            const string relPath = "/corp/MarketOrders.xml.aspx";
            var postString = (orderId == 0) ? WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId)
                : WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId, "orderID", orderId);
            return request(relPath, new MarketOrders(), postString);
        }

        public XmlResponse<MedalList> GetMedals() {
            const string relPath = "/corp/Medals.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new MedalList(), postString);
        }

        public XmlResponse<MemberMedals> GetMemberMedals() {
            const string relPath = "/corp/MemberMedals.xml.aspx";
            var postString = WebHelper.GeneratePostString(ApiKey, "characterId", CharacterId);
            return request(relPath, new MemberMedals(), postString);
        }


        private void load() {


        }

    }
}
