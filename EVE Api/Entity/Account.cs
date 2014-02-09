using eZet.Eve.EveApi.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Entity {
    public class Account {

        public ApiKey ApiKey;

        public Account(ApiKey apiKey) {
            this.ApiKey = apiKey;
        }


        public XmlResponse<CharacterCollection> GetCharacterList() {
            var uri = "/account/Characters.xml.aspx";
            string data = WebHelper.Request(uri, ApiKey);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlResponse<CharacterCollection>));
            XmlResponse<CharacterCollection> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<CharacterCollection>)serializer.Deserialize(reader);
            }
            xmlResponse.ApiKey = ApiKey;
            return xmlResponse;
        }

        public XmlResponse<AccountStatus> GetAccountStatus() {
            var uri = "/account/AccountStatus.xml.aspx";
            string data = WebHelper.Request(uri, ApiKey);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlResponse<AccountStatus>));
            XmlResponse<AccountStatus> xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (XmlResponse<AccountStatus>)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }

        public XmlResponse<AccountStatus> GetApiKeyInfo() {
            throw new NotImplementedException();
        }

    }
}
