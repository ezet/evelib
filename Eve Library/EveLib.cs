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

using System;
using eZet.EveLib.Common.Util;
using eZet.EveLib.EveCentralLib;
using eZet.EveLib.EveMarketDataLib;
using eZet.EveLib.EveOnlineLib;

namespace eZet.EveLib {
    public class EveLib {
        private EveLib(Core core, Map map, Image image, EveCentral evec, EveMarketData emd) {
            Core = core;
            Map = map;
            Image = image;
            EveCentral = evec;
            EveMarketData = emd;
        }

        /// <summary>
        ///     Gets the Core for this instance
        /// </summary>
        public Core Core { get; private set; }

        /// <summary>
        ///     Gets the Map for this instance
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        ///     Gets the Image for this instance
        /// </summary>
        public Image Image { get; private set; }

        /// <summary>
        ///     Gets the EveCentral for this instance
        /// </summary>
        public EveCentral EveCentral { get; private set; }

        public EveMarketData EveMarketData { get; private set; }

        public static void Main(string[] args) {
            EveMarketData api = Create().EveMarketData;
            api.SetMode(Format.Json);
            api.RequestHandler.Serializer = new JsonSerializer();
            var options = new EveMarketDataOptions();
            options.Items.Add(34);
            options.Regions.Add(10000002);
            options.AgeSpan = TimeSpan.FromDays(2);
            var res = api.GetStationRank(options);
        }

        public static EveLib Create() {
            return new EveLib(new Core(), new Map(), new Image(), new EveCentral(), new EveMarketData());
        }

        /// <summary>
        ///     Creates and returns a new CharacterKey.
        /// </summary>
        /// <param name="keyId">Eve API key id.</param>
        /// <param name="vCode">Eve API verfication code.</param>
        /// <returns></returns>
        public static CharacterKey GetCharacterKey(long keyId, string vCode) {
            return new CharacterKey(keyId, vCode);
        }


        /// <summary>
        ///     Creates and returns a new CorporationKey.
        /// </summary>
        /// <param name="keyId">Eve API key id.</param>
        /// <param name="vCode">Eve Api verification code.</param>
        /// <returns></returns>
        public static CorporationKey GetCorporationKey(long keyId, string vCode) {
            return new CorporationKey(keyId, vCode);
        }
    }
}