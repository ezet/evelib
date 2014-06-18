using System;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Corporation {
    [Serializable]
    [XmlRoot("result")]
    public class CustomsOffices {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<CustomsOffice> Pocos { get; set; }

        public class CustomsOffice {
            [XmlAttribute("itemID")]
            public int ItemId { get; set; }

            [XmlAttribute("solarSystemID")]
            public int SolarSystemId { get; set; }

            [XmlAttribute("solarSystemName")]
            public string SolarSystemName { get; set; }

            [XmlAttribute("reinforceHour")]
            public int ReinforceHour { get; set; }

            [XmlAttribute("allowAlliance")]
            public bool AllowAlliance { get; set; }

            [XmlAttribute("allowStandings")]
            public bool AllowStandings { get; set; }

            [XmlAttribute("taxRateAlliance")]
            public double TaxRateAlliance { get; set; }

            [XmlAttribute("taxRateCorp")]
            public double TaxRateCorp { get; set; }

            [XmlAttribute("taxRateStandingHigh")]
            public double TaxRateStandingHigh { get; set; }

            [XmlAttribute("taxRateStandingGood")]
            public double TaxRateStandingGood { get; set; }

            [XmlAttribute("taxRateStandingNeutral")]
            public double TaxRateStandingNeutral { get; set; }

            [XmlAttribute("taxRateStandingBad")]
            public double TaxRateStandingBad { get; set; }

            [XmlAttribute("taxRateStandingHorrible")]
            public double TaxRateStandingHorrible { get; set; }
        }
    }
}