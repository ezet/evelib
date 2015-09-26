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
    /// Class ChatChannels.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class ChatChannels {

        /// <summary>
        /// Gets or sets the channels.
        /// </summary>
        /// <value>The channels.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Channel> Channels { get; set; }


        /// <summary>
        /// Class Channel.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Channel : IXmlSerializable {

            [XmlAttribute("channelID")]
            public long ChannelId { get; set; }

            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("ownerName")]
            public string OwnerName { get; set; }

            [XmlAttribute("displayName")]
            public string DisplayName { get; set; }

            [XmlAttribute("comparisonKey")]
            public string ComparisonKey { get; set; }

            [XmlAttribute("hasPassword")]
            public bool HasPassword { get; set; }

            [XmlAttribute("motd")]
            public string Motd { get; set; }

            [XmlAttribute("rowset")]
            public EveXmlRowCollection<Accessor> Allowed { get; set; }

            [XmlElement("rowset")]
            public EveXmlRowCollection<Accessor> Blocked { get; set; }

            [XmlElement("rowset")]
            public EveXmlRowCollection<Accessor> Muted { get; set; }

            [XmlElement("rowset")]
            public EveXmlRowCollection<Accessor> Operators { get; set; }

            public XmlSchema GetSchema() {
                return null;
            }

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

            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }

        }

    }

    [Serializable]
    [XmlRoot("row")]
    public class Accessor {

        [XmlAttribute("accessorID")]
        public long AccessorId { get; set; }

        [XmlAttribute("accessorName")]
        public string AccessorName { get; set; }

        public DateTime UntilWhen { get; set; }

        [XmlAttribute("untilWhen")]
        public string UntilWhenString {
            get { return UntilWhen.ToString(XmlHelper.DateFormat); }
            set { UntilWhen = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }
    
        [XmlAttribute("reason")]
        public string Reason { get; set; }
    }
}