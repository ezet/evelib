using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace eZet.EveLib.Modules.Models.Character {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AssetList {
        [XmlElement("rowset")]
        public EveOnlineRowCollection<Item> Items { get; set; }

        /// <summary>
        ///     Returns a flat list of all assets.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> Flatten() {
            return flatten(Items);
        }

        private ICollection<Item> flatten(ICollection<Item> items) {
            var list = new List<Item>();
            var stack = new Stack<Item>(items);
            while (stack.Count > 0) {
                Item current = stack.Pop();
                list.Add(current);
                if (current.Items == null) continue;
                foreach (Item child in current.Items)
                    stack.Push(child);
            }
            return list;
        }

        [Serializable]
        [XmlRoot("row")]
        public class Item {
            [XmlAttribute("itemID")]
            public long ItemId { get; set; }

            [XmlAttribute("locationID")]
            public long LocationId { get; set; }

            [XmlAttribute("typeID")]
            public int TypeId { get; set; }

            [XmlAttribute("quantity")]
            public int Quantity { get; set; }

            [XmlAttribute("flag")]
            public int Flag { get; set; }

            [XmlAttribute("singleton")]
            public bool Singleton { get; set; }

            /// <summary>
            /// Blueprint: -1 = original; -2= copy; otherwise -1 for singelton
            /// </summary>
            [XmlAttribute("rawQuantity")]
            public int RawQuantity { get; set; }

            [XmlElement("rowset")]
            public EveOnlineRowCollection<Item> Items { get; set; }
        }
    }
}