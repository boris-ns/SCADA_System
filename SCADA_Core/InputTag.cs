using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace SCADA_Core
{
    [Serializable]
    [DataContract]
    public class InputTag : Tag
    {
        [DataMember] private float scanTime;

        [XmlArray("Alarms"), XmlArrayItem(typeof(Alarm), ElementName = "Alarm")]
        [DataMember] private List<Alarm> alarms;
        [DataMember] private bool enableScan;
        [DataMember] private bool manualMode;

        public InputTag()
        {
        }

        public InputTag(string tagName, string description, string driver, string ioAddress,
                        float scanTime, bool enableScan, bool manualMode)
            : base(tagName, description, driver, ioAddress)
        {
            this.scanTime = scanTime;
            this.alarms = new List<Alarm>();
            this.enableScan = enableScan;
            this.manualMode = manualMode;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public float ScanTime
        {
            get { return scanTime; }
            set { scanTime = value; }
        }

        public List<Alarm> Alarms
        {
            get { return alarms; }
            set { alarms = value; }
        }

        public bool EnableScan
        {
            get { return enableScan; }
            set { enableScan = value; }
        }

        public bool ManualMode
        {
            get { return manualMode; }
            set { manualMode = value; }
        }
    }
}