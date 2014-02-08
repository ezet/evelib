using eZet.Eve.EveApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi.Entity {
    public class AccountBalance {

        public long AccountId { get; private set; }

        public int AccountKey { get; private set; }

        public double Balance { get; private set; }

        public AccountBalance(AccountBalanceDto dto) {
        }
    }
}
