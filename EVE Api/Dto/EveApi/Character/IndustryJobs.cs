using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eZet.Eve.EveApi.Dto.EveApi.Character {
    public class IndustryJobs : XmlResult {
        
        [XmlElement("rowset")]
        public XmlRowSet<IndustryJob> Jobs { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class IndustryJob {
            
            [XmlAttribute("jobID")]
            public long JobId { get; set; }

            [XmlAttribute("assemblyLineID")]
            public long AssemblyLineId { get; set; }

            [XmlAttribute("containerID")]
            public long ContainerId { get; set; }

            [XmlAttribute("installedItemID")]
            public long InstalledItemId { get; set; }

            [XmlAttribute("installedItemLocationID")]
            public long InstalledItemLocationId { get; set; }

            [XmlAttribute("installedItemQuantity")]
            public int InstalledItemQuantity { get; set; }

            [XmlAttribute("installedItemProductivityLevel")]
            public int InstalledItemProducivityLevel { get; set; }

            [XmlAttribute("installedItemMaterialLevel")]
            public int InstalledItemMaterialLevel { get; set; }

            [XmlAttribute("installedItemLicenseProductionRunsRemaining")]
            public int InstalledItemLicenseProductionRunsRemaining { get; set; }

            [XmlAttribute("outputLocationID")]
            public long OutputLocationId { get; set; }

            [XmlAttribute("installerID")]
            public long InstallerId { get; set; }

            [XmlAttribute("runs")]
            public int Runs { get; set; }

            [XmlAttribute("licensedProductionRuns")]
            public int LicensedProductionRuns { get; set; }

            [XmlAttribute("installedInSolarSystemID")]
            public long InstalledInSolarSystemId { get; set; }

            [XmlAttribute("containerLocationID")]
            public long ContainerLocationId { get; set; }

            [XmlAttribute("materialMultiplier")]
            public float MaterialMultiplier { get; set; }

            [XmlAttribute("charMaterialMultiplier")]
            public float CharMaterialMultiplier { get; set; }

            [XmlAttribute("timeMultiplier")]
            public float TimeMultiplier { get; set; }

            [XmlAttribute("charTimeMultiplier")]
            public float CharTimeMultiplier { get; set; }

            [XmlAttribute("installedItemTypeID")]
            public long InstalledItemTypeId { get; set; }

            [XmlAttribute("outputTypeID")]
            public long OutputTypeId { get; set; }

            [XmlAttribute("containerTypeID")]
            public long containerTypeId { get; set; }

            [XmlAttribute("intalledItemCopy")]
            public bool InstalledItemCopy { get; set; }

            [XmlAttribute("completed")]
            public bool Completed { get; set; }

            [XmlAttribute("completedSuccessfully")]
            public bool CompletedSuccessfully { get; set; }

            [XmlAttribute("installedItemFlag")]
            public int InstalledItemFlag { get; set; }

            [XmlAttribute("outputFlag")]
            public int OutputFlag { get; set; }

            [XmlAttribute("activityID")]
            public int ActivityId { get; set; }

            [XmlAttribute("completedStatus")]
            public CompletedStatusType CompletedStatus { get; set; }

            // TODO DateTime
            [XmlAttribute("installTime")]
            public string InstallTime { get; set; }

            [XmlAttribute("beginProductionTime")]
            public string BeginProductionTime { get; set; }

            [XmlAttribute("endProductionTime")]
            public string EndProductionTime { get; set; }

            [XmlAttribute("pauseProductionTime")]
            public string PauseProductionTime { get; set; }

        }

        public enum CompletedStatusType {
            [XmlEnum("0")]
            Failed,
            [XmlEnum("1")]
            Delivered,
            [XmlEnum("2")]
            Aborted,
            [XmlEnum("3")]
            GmAborted,
            [XmlEnum("4")]
            Unanchored,
            [XmlEnum("5")]
            Destroyed
        }
    }
}
