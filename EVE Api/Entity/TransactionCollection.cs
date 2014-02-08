using eZet.Eve.EveApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi.Entity {
    public class TransactionCollection {

        public EveApiMeta Meta { get; private set; }

        public List<Transaction> transactions { get; private set; }

        public TransactionCollection(EveXml<TransactionCollectionDto> dto) {
            transactions = new List<Transaction>();
            Meta = new EveApiMeta(dto.version, dto.currentTime, dto.cachedUntil);
            transactions = new List<Transaction>();
            foreach (var row in dto.result.rowset.row) {
                transactions.Add(new Transaction(row));
            }
        }

        public void Add(EveXml<TransactionCollectionDto> dto) {
            Meta = new EveApiMeta(dto.version, dto.currentTime, dto.cachedUntil);
            transactions = new List<Transaction>();
            foreach (var row in dto.result.rowset.row) {
                transactions.Add(new Transaction(row));
            }
        }
    }
}
