using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    /// <summary>
    /// Eve Online Blueprint response
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class BlueprintList {
        /// <summary>
        /// A list of blueprints
        /// </summary>
        [XmlElement("blueprints")]
        public List<Blueprint> Blueprints { get; set; }


        /// <summary>
        /// Represents a blueprint
        /// </summary>
        public class Blueprint {
            /// <summary>
            /// Unique ID of the blueprint
            /// </summary>
            [XmlAttribute("itemID")]
            public int ItemId { get; set; }

            /// <summary>
            /// ID for the location of the blueprint
            /// </summary>
            [XmlAttribute("locationID")]
            public int LocationId { get; set; }

            /// <summary>
            /// TypeID of the blueprint
            /// </summary>
            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            /// <summary>
            /// Typename of the blueprint
            /// </summary>
            [XmlAttribute("typeName")]
            public string TypeName { get; set; }

            /// <summary>
            /// Indicates something about this item's storage location. The flag is used to differentiate between hangar divisions, drone bay, fitting location, and similar. Please see the Inventory Flags documentation.
            /// </summary>
            [XmlAttribute("flagID")]
            public int Flag { get; set; }

            /// <summary>
            /// Typically will be -1 or -2 designating a singleton item, where -1 is an original and -2 is a copy. It can be a positive integer if it is a stack of blueprint originals fresh from the market (no activities performed on them yet).
            /// </summary>
            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            /// <summary>
            /// Time Efficiency Level of the blueprint.
            /// </summary>
            [XmlAttribute("timeEfficienty")]
            public int TimeEfficienty { get; set; }
            
            /// <summary>
            /// Material Efficiency Level of the blueprint.
            /// </summary>
            [XmlAttribute("MaterialEfficiency")]
            public int MaterialEfficiency { get; set; }

            /// <summary>
            /// Number of runs remaining if the blueprint is a copy, -1 if it is an original.
            /// </summary>
            [XmlAttribute("runs")]
            public int Runs { get; set; }

            
        }
    }
}
