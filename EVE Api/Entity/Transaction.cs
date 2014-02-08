using eZet.Eve.EveApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi.Entity {
    public class Transaction {

        public DateTime Time { get; private set; }

        public uint TransactionId { get; private set; }

        public int Quantity { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public uint ClientId { get; private set; }

        public string ClientName { get; private set; }

        public uint StationId { get; private set; }

        public string StationName { get; private set; }

        public string TransactionType { get; private set; }

        public string TransactionFor { get; private set; }

        public Transaction(TransactionRow row) {
            Time = DateTime.Parse(row.transactionDateTime);
            TransactionId = row.transactionID;
            Quantity = row.quantity;
            Name = row.typeName;
            Price = row.price;
            ClientId = row.clientID;
            ClientName = row.clientName;
            StationId = row.stationID;
            StationName = row.stationName;
            TransactionType = row.transactionType;
            TransactionFor = row.transactionFor;
        }


    }
}
