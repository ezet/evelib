using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi {
    public class Corporation {

        public string Name { get; private set; }

        public long Id { get; private set; }

        public ApiKey ApiKey { get; private set; }

        public Corporation(ApiKey key, long id) {
            ApiKey = key;
            Id = id;
            load();   
        }

        public Corporation(ApiKey key, string name, long id) {
            this.ApiKey = key;
            this.Name = name;
            this.Id = id;
        }

        private void load();

    }
}
