using eZet.Eve.EveApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi.Entity {
    public class Transaction {

        public string DateTime { get; private set; }

        public long TransactionId { get; private set; }

        public int Quantity { get; private set; }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public long ClientId { get; private set; }

        public string ClientName { get; private set; }

        public long StationId { get; private set; }

        public string StationName { get; private set; }

        public string TransactionType { get; private set; }

        public string TransactionFor { get; private set; }

        public string JournalTransactionId { get; private set; }


    }
}
