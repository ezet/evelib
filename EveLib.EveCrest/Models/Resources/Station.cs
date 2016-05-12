using System.Collections.Generic;
using System.Runtime.Serialization;
using eZet.EveLib.EveCrestModule.Models.Links;
using eZet.EveLib.EveCrestModule.Models.Shared;

namespace eZet.EveLib.EveCrestModule.Models.Resources {
    /// <summary>
    /// Station Resource
    /// </summary>
    public sealed class Station : CrestResource<Station> {
        /// <summary>
        /// Initializes a new instance of the <see cref="Station" /> class.
        /// </summary>
        public Station() {
            ContentType = "application/vnd.ccp.eve.Station-v1+json";
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the reprocessing efficiency.
        /// </summary>
        /// <value>
        /// The reprocessing efficiency.
        /// </value>
        [DataMember(Name = "reprocessingEfficiency")]
        public double ReprocessingEfficiency { get; set; }

        /// <summary>
        /// Gets or sets the office rental cost.
        /// </summary>
        /// <value>
        /// The office rental cost.
        /// </value>
        [DataMember(Name = "officeRentalCost")]
        public double OfficeRentalCost { get; set; }

        /// <summary>
        /// Gets or sets the maximum ship volume dockable.
        /// </summary>
        /// <value>
        /// The maximum ship volume dockable.
        /// </value>
        [DataMember(Name = "maxShipVolumeDockable")]
        public double MaxShipVolumeDockable { get; set; }

        /// <summary>
        /// Gets or sets the reprocessing stations take.
        /// </summary>
        /// <value>
        /// The reprocessing stations take.
        /// </value>
        [DataMember(Name = "reprocessingStationsTake")]
        public double ReprocessingStationsTake { get; set; }

        /// <summary>
        /// Gets or sets the system.
        /// </summary>
        /// <value>
        /// The system.
        /// </value>
        [DataMember(Name = "system")]
        public LinkedEntity<SolarSystem> System { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        [DataMember(Name = "services")]
        public IReadOnlyList<Service> Services { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        [DataMember(Name = "race")]
        public LinkedEntity<NotImplemented> Race { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        [DataMember(Name = "owner")]
        public Href<NotImplemented> Owner { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [DataMember(Name = "position")]
        public CrestPosition Position { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type")]
        public Href<ItemType> Type { get; set; }

        /// <summary>
        /// Station Service
        /// </summary>
        public class Service {

            /// <summary>
            /// Gets or sets the name of the service.
            /// </summary>
            /// <value>
            /// The name of the service.
            /// </value>
            [DataMember(Name = "serviceName")]
            public string ServiceName { get; set; }
        }



    }
}