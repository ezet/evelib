// ***********************************************************************
// Assembly         : EveLib.EveXml
// Author           : larsd
// Created          : 09-26-2015
//
// Last Modified By : larsd
// Last Modified On : 09-26-2015
// ***********************************************************************
// <copyright file="Bookmarks.cs" company="Lars Kristian Dahl">
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
    ///     Class Bookmarks.
    /// </summary>
    [Serializable]
    [XmlRoot("result")]
    public class Bookmarks {
        /// <summary>
        ///     Gets or sets the folders.
        /// </summary>
        /// <value>The folders.</value>
        [XmlElement("rowset")]
        public EveXmlRowCollection<Folder> Folders { get; set; }

        /// <summary>
        ///     Class Folder.
        /// </summary>
        [Serializable]
        [XmlRoot("row")]
        public class Folder : IXmlSerializable {
            /// <summary>
            ///     Gets or sets the folder identifier.
            /// </summary>
            /// <value>The folder identifier.</value>
            [XmlAttribute("folderID")]
            public long FolderId { get; set; }

            /// <summary>
            ///     Gets or sets the name of the folder.
            /// </summary>
            /// <value>The name of the folder.</value>
            [XmlAttribute("folderName")]
            public string FolderName { get; set; }

            /// <summary>
            ///     Gets or sets the creator identifier.
            /// </summary>
            /// <value>The creator identifier.</value>
            [XmlAttribute("creatorID")]
            public long CreatorId { get; set; }

            /// <summary>
            ///     Gets or sets the bookmarks.
            /// </summary>
            /// <value>The bookmarks.</value>
            [XmlElement("rowset")]
            private EveXmlRowCollection<Bookmark> Bookmarks { get; set; }

            /// <summary>
            ///     Gets or sets the folders.
            /// </summary>
            /// <value>The folders.</value>
            [XmlElement("rowset")]
            private EveXmlRowCollection<Folder> Folders { get; set; }

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
                FolderId = xml.getLongAttribute("folderID");
                FolderName = xml.getStringAttribute("folderName");
                CreatorId = xml.getLongAttribute("creatorID");
                Bookmarks = xml.deserializeRowSet<Bookmark>("bookmarks");
                Folders = xml.deserializeRowSet<Folder>("folders");
            }

            /// <summary>
            ///     Writes the XML.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <exception cref="System.NotImplementedException"></exception>
            public void WriteXml(XmlWriter writer) {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Class Bookmark.
            /// </summary>
            [Serializable]
            [XmlRoot("row")]
            public class Bookmark {
                /// <summary>
                ///     Gets or sets the bookmark identifier.
                /// </summary>
                /// <value>The bookmark identifier.</value>
                [XmlAttribute("bookmarkID")]
                public long BookmarkId { get; set; }

                /// <summary>
                ///     Gets or sets the creator identifier.
                /// </summary>
                /// <value>The creator identifier.</value>
                [XmlAttribute("creatorID")]
                public long CreatorId { get; set; }

                /// <summary>
                ///     Gets or sets the created.
                /// </summary>
                /// <value>The created.</value>
                public DateTime Created { get; set; }

                /// <summary>
                ///     Gets or sets the created as string.
                /// </summary>
                /// <value>The created as string.</value>
                [XmlAttribute("created")]
                public string CreatedAsString {
                    get { return Created.ToString(XmlHelper.DateFormat); }
                    set { Created = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
                }

                /// <summary>
                ///     Gets or sets the item identifier.
                /// </summary>
                /// <value>The item identifier.</value>
                [XmlAttribute("itemID")]
                public long ItemId { get; set; }

                /// <summary>
                ///     Gets or sets the type identifier.
                /// </summary>
                /// <value>The type identifier.</value>
                [XmlAttribute("typeID")]
                public int TypeId { get; set; }

                /// <summary>
                ///     Gets or sets the location identifier.
                /// </summary>
                /// <value>The location identifier.</value>
                [XmlAttribute("locationID")]
                public long LocationId { get; set; }

                /// <summary>
                ///     Gets or sets the x.
                /// </summary>
                /// <value>The x.</value>
                [XmlAttribute("x")]
                public float X { get; set; }

                /// <summary>
                ///     Gets or sets the y.
                /// </summary>
                /// <value>The y.</value>
                [XmlAttribute("y")]
                public float Y { get; set; }

                /// <summary>
                ///     Gets or sets the z.
                /// </summary>
                /// <value>The z.</value>
                [XmlAttribute("z")]
                public float Z { get; set; }

                /// <summary>
                ///     Gets or sets the memo.
                /// </summary>
                /// <value>The memo.</value>
                [XmlAttribute("memo")]
                public string Memo { get; set; }

                /// <summary>
                ///     Gets or sets the note.
                /// </summary>
                /// <value>The note.</value>
                [XmlAttribute("note")]
                public string Note { get; set; }
            }
        }
    }
}