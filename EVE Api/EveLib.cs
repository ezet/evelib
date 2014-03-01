/**
Licensed to the Apache Software Foundation (ASF) under one
or more contributor license agreements.  See the NOTICE file
distributed with this work for additional information
regarding copyright ownership.  The ASF licenses this file
to you under the Apache License, Version 2.0 (the
"License"); you may not use this file except in compliance
with the License.  You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an
"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, either express or implied.  See the License for the
specific language governing permissions and limitations
under the License.
 * 
 *
*/

using eZet.Eve.EveLib.Entity.EveApi;
using eZet.Eve.EveLib.Entity.EveCentral;
using eZet.Eve.EveLib.Entity.EveMarketData;

namespace eZet.Eve.EveLib {
 
    public class EveLib {

        /// <summary>
        /// Gets the Core for this instance
        /// </summary>
        public Core Core { get; private set; }

        /// <summary>
        /// Gets the Map for this instance
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        /// Gets the Image for this instance
        /// </summary>
        public Image Image { get; private set; }

        /// <summary>
        /// Gets the EveCentral for this instance
        /// </summary>
        public EveCentral EveCentral { get; private set; }

        public EveMarketData EveMarketData { get; private set; }

        public static void Main(string[] args) {
            var lib = Create().EveMarketData;
            var opt = new EveMarketDataOptions {DayLimit = 1};
            var res = lib.GetRecentUploads(opt, UploadType.Orders);

            var result = res.Result;
        }

        public static EveLib Create() {
            return new EveLib(new Core(), new Map(), new Image(), new EveCentral(), new EveMarketData());
        }
    
        private EveLib(Core core, Map map, Image image, EveCentral evec, EveMarketData emd) {
            Core = core;
            Map = map;
            Image = image;
            EveCentral = evec;
            EveMarketData = emd;

        }

        /// <summary>
        /// Creates and returns a new CharacterKey.
        /// </summary>
        /// <param name="keyId">Eve API key id.</param>
        /// <param name="vCode">Eve API verfication code.</param>
        /// <returns></returns>
        public static CharacterKey GetCharacterKey(long keyId, string vCode) {
            return new CharacterKey(keyId, vCode);
        }


        /// <summary>
        /// Creates and returns a new CorporationKey.
        /// </summary>
        /// <param name="keyId">Eve API key id.</param>
        /// <param name="vCode">Eve Api verification code.</param>
        /// <returns></returns>
        public static CorporationKey GetCorporationKey(long keyId, string vCode) {
            return new CorporationKey(keyId, vCode);
        }

    }
}
