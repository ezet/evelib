using System;
using System.Xml.Serialization;
using eZet.EveLib.Modules.Util;

namespace eZet.EveLib.Modules.Models.Account {
    /// <summary>
    /// Account Status
    /// </summary>
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class AccountStatus {
        
        /// <summary>
        /// Gets PaidUntil
        /// </summary>
        [XmlIgnore]
        public DateTime PaidUntil { get; private set; }

        /// <summary>
        /// Gets or sets PaidUntil as a string
        /// </summary>
        [XmlElement("paidUntil")]
        public string PaidUntilAsString {
            get { return PaidUntil.ToString(XmlHelper.DateFormat); }
            set { PaidUntil = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        /// Gets CreationDate
        /// </summary>
        [XmlIgnore]
        public DateTime CreationDate { get; private set; }

        /// <summary>
        /// Gets or sets CreationDate as a string
        /// </summary>
        [XmlElement("createDate")]
        public string CreationDateAsString {
            get { return CreationDate.ToString(XmlHelper.DateFormat); }
            set { CreationDate = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }

        /// <summary>
        /// Gets or sets LogonCount
        /// </summary>
        [XmlElement("logonCount")]
        public int LogonCount { get; set; }

        /// <summary>
        /// Gets or sets LogonMinutes
        /// </summary>
        [XmlElement("logonMinutes")]
        public int LogonMinutes { get; set; }

        /// <summary>
        /// Gets or sets the MultiCharacterTraining row set
        /// </summary>
        [XmlElement("multiCharacterTraining")]
        public EveOnlineRowCollection<MultiCharacterTraining> MultiCharacterTraining { get; set; }
            
    }


    /// <summary>
    /// Multi Character Training
    /// </summary>
    public class MultiCharacterTraining {

        /// <summary>
        /// Gets or sets TrainingEnd
        /// </summary>
        [XmlIgnore]
        public DateTime TrainingEnd { get; set; }

        /// <summary>
        /// Gets or sets TrainingEnd as a string
        /// </summary>
        [XmlElement("trainingEnd")]
        public string CreationDateAsString {
            get { return TrainingEnd.ToString(XmlHelper.DateFormat); }
            set { TrainingEnd = DateTime.ParseExact(value, XmlHelper.DateFormat, null); }
        }
    }
}