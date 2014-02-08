using eZet.Eve.EveApi.Dto;
using eZet.Eve.EveApi.Entity;
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

        private List<Transaction> Transactions = new List<Transaction>();

        public AccountBalance Balance { get; private set; }


        public Character(string name, int id, string corporationName, int corporationId, Auth apiKey) {
            this.Name = name;
            this.Id = id;
            this.ApiKey = apiKey;
            Corporation = new Corporation(corporationName, corporationId, apiKey);
        }

        public AccountBalanceDto getAccountBalance() {
            string uri = "/char/AccountBalance.xml.aspx";
            var data = WebHelper.Request(uri, ApiKey, "characterId", Id);
            using (var reader = XmlReader.Create(new StringReader(data))) {
                XmlSerializer serializer = new XmlSerializer(typeof(EveApiXml<AccountBalanceDto>));
                var dto = (EveApiXml<AccountBalanceDto>)serializer.Deserialize(reader);
            }
            return new AccountBalanceDto();
        }


        public List<Transaction> getWalletTransactions() {
            string uri = "/char/WalletTransactions.xml.aspx";
            var data = WebHelper.Request(uri, ApiKey, "characterId", Id, "accountKey", AccountKey);

            using (var reader = XmlReader.Create(new StringReader(data))) {
                reader.ReadToFollowing("row");
                XmlSerializer serializer = new XmlSerializer(typeof(TransactionDto));
                while (reader.Name == "row") {
                    var dto = (TransactionDto)serializer.Deserialize(reader);
                    Transaction transaction = new Transaction(dto);
                    Transactions.Add(transaction);
                    reader.ReadToNextSibling("row");
                }
            }
            return Transactions;
        }

        public void CharacterSheet() {
            //string uri = "/char/CharacterSheet.xml.aspx";
            //var data = WebHelper.Request(uri, ApiKey, "characterId", Id);
            //using (var reader = XmlReader.Create(new StringReader(data))) {
            //    reader.ReadToFollowing("result");
            //    XmlSerializer serializer = new XmlSerializer(typeof(CharacterSheetDto));
            //    var dto = (CharacterSheetDto)serializer.Deserialize(reader);
            //}
        }

        public override string ToString() {
            return String.Format("ID: {0}, Name: {1}", Id, Name);
        }
    }
}
