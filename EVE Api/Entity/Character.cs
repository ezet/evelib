using eZet.Eve.EveApi.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Entity {

    public class Character {

        public const int AccountKey = 1000;

        public string Name { get; private set; }

        public int Id { get; private set; }

        public Corporation Corporation { get; private set; }

        public Auth ApiKey { get; private set; }

        public AccountBalance Balance { get; private set; }

        public Character(string name, int id, string corporationName, int corporationId, Auth apiKey) {
            this.Name = name;
            this.Id = id;
            this.ApiKey = apiKey;
            Corporation = new Corporation(corporationName, corporationId, apiKey);
        }

        public XmlResponse<AccountBalance> getAccountBalance() {
            string uri = "/char/AccountBalance.xml.aspx";
            var data = WebHelper.Request(uri, ApiKey, "characterId", Id);
            XmlResponse<AccountBalance> balance;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlResponse<AccountBalance>));
                balance = (XmlResponse<AccountBalance>)serializer.Deserialize(reader);
            }
            return balance;
        }


        public XmlResponse<TransactionCollection> getWalletTransactions() {
            string uri = "/char/WalletTransactions.xml.aspx";
            var data = WebHelper.Request(uri, ApiKey, "characterId", Id, "accountKey", AccountKey);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlResponse<TransactionCollection>));
            XmlResponse<TransactionCollection> xml;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xml = (XmlResponse<TransactionCollection>)serializer.Deserialize(reader);
            }
            return xml;
        }

        public XmlResponse<CharacterSheet> getCharacterSheet() {
            string uri = "/char/CharacterSheet.xml.aspx";
            var data = WebHelper.Request(uri, ApiKey, "characterId", Id);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlResponse<CharacterSheet>));
            XmlResponse<CharacterSheet> xml;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xml = (XmlResponse<CharacterSheet>)serializer.Deserialize(reader);
            }
            return xml;
        }

        public override string ToString() {
            return String.Format("ID: {0}, Name: {1}", Id, Name);
        }
    }
}
