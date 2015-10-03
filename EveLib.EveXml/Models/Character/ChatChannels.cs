// ***********************************************************************
// Assembly         : EveLib.EveXml
// Author           : larsd
// Created          : 09-26-2015
//
// Last Modified By : larsd
// Last Modified On : 09-26-2015
// ***********************************************************************
// <copyright file="ChatChannels.cs" company="Lars Kristian Dahl">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using eZet.EveLib.EveXmlModule.Util;

namespace eZet.EveLib.EveXmlModule.Models.Character {
    /// <summary>
    ///     Class ChatChannels.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class ChatChannels {
        /// <summary>
        ///     Gets or sets the channels.
        /// </summary>
        /// <value>The channels.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Channel> Channels { get; set; }


        /// <summary>
        ///     Class Channel.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Channel : IXmlSerializable {
            /// <summary>
            ///     Gets or sets the channel identifier.
            /// </summary>
            /// <value>The channel identifier.</value>
            [XmlAttribute("channelID")]
            public long ChannelId { get; set; }

            /// <summary>
            ///     Gets or sets the owner identifier.
            /// </summary>
            /// <value>The owner identifier.</value>
            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the owner.
            /// </summary>
            /// <value>The name of the owner.</value>
            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            /// <summary>
            ///     Gets or sets the display name.
            /// </summary>
            /// <value>The display name.</value>
            [XmlAttribute("displayName")]
            public string DisplayName { get; set; }

            /// <summary>
            ///     Gets or sets the comparison key.
            /// </summary>
            /// <value>The comparison key.</value>
            [XmlAttribute("comparisonKey")]
            public string ComparisonKey { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether this instance has password.
            /// </summary>
            /// <value><c>true</c> if this instance has password; otherwise, <c>false</c>.</value>
            [XmlAttribute("hasPassword")]
            public bool HasPassword { get; set; }

            /// <summary>
            ///     Gets or sets the motd.
            /// </summary>
            /// <value>The motd.</value>
            [XmlAttribute("motd")]
            public string Motd { get; set; }

            /// <summary>
            ///     Gets or sets the allowed.
            /// </summary>
            /// <value>The allowed.</value>
            [XmlAttribute("rowset")]
            public EveXmlRowCollection<Accessor> Allowed { get; set; }

            /// <summary>
            ///     Gets or sets the blocked.
            /// </summary>
            /// <value>The blocked.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Accessor> Blocked { get; set; }

            /// <summary>
            ///     Gets or sets the muted.
            /// </summary>
            /// <value>The muted.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Accessor> Muted { get; set; }

            /// <summary>
            ///     Gets or sets the operators.
            /// </summary>
            /// <value>The operators.</value>
            [XmlElement("rowset")]
            public EveXmlRowCollection<Accessor> Operators { get; set; }

            /// <summary>
            ///     Gets the schema.
            /// </summary>
            /// <returns>XmlSchema.</returns>
            public XmlSchema GetSchema() {
                return null;
            }

            /// <summary>
            ///     Reads the XML.
            /// </summary>
            /// <param name="reader">The reader.</param>
            public void ReadXml(XmlReader reader) {
                var xml = new XmlHelper(reader);
                ChannelId = xml.getLongAttribute("channelID");
                OwnerId = xml.getLongAttribute("ownerID");
                OwnerName = xml.getStringAttribute("ownerName");
                DisplayName = xml.getStringAttribute("displayName");
                ComparisonKey = xml.getStringAttribute("comparisonKey");
                HasPassword = xml.getBoolAttribute("hasPassword") ?? false;
                Motd = xml.getStringAttribute("motd");
                Allowed = xml.deserializeRowSet<Accessor>("allowed");
                Blocked = xml.deserializeRowSet<Accessor>("blocked");
                Muted = xml.deserializeRowSet<Accessor>("muted");
                Operators = xml.deserializeRowSet<Accessor>("operators");
            }

            /// <summary>
            ///     Writes the XML.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    ///     Class Accessor.
    /// </summary>
    [Serializable]
    [XmlRoot("row")]
    public class Accessor {
        /// <summary>
        ///     Gets or sets the accessor identifier.
        /// </summary>
        /// <value>The accessor identifier.</value>
        [XmlAttribute("accessorID")]
        public long AccessorId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the accessor.
        /// </summary>
        /// <value>The name of the accessor.</value>
        [XmlAttribute("accessorName")]
        public string AccessorName { get; set; }

        /// <summary>
        ///     Gets or sets the until when.
        /// </summary>
        /// <value>The until when.</value>
        public DateTime UntilWhen { get; set; }

        /// <summary>
        ///     Gets or sets the until when string.
        /// </summary>
        /// <value>The until when string.</value>
        [XmlAttribute("untilWhen")]
        public string UntilWhenString {
            get { return UntilWhen.ToString(XmlHelper.DateFormat); }
            set { UntilWhen = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        ///     Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        [XmlAttribute("reason")]
        public string Reason { get; set; }
    }
}