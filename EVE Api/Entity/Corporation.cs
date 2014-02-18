using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.Eve.EveApi.Entity;

namespace eZet.Eve.EveApi {
    public class Corporation : EveApiEntity {

        public string Name { get; private set; }

        public long Id { get; private set; }

        public Corporation(ApiKey key, long id) : base(key){
            Id = id;
            load();   
        }

        public Corporation(ApiKey key, string name, long id) : base(key) {
            Name = name;
            Id = id;
        }

        private void load() {

        }

    }
}
