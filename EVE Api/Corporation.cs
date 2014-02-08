using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZet.Eve.EveApi {
    public class Corporation {


        public string Name { get; private set; }

        public int Id { get; private set; }

        public Auth ApiKey { get; private set; }

        public Corporation(string name, int id, Auth apiKey) {
            this.Name = name;
            this.Id = id;
            this.ApiKey = apiKey;
        }

    }
}
