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
        [DataMember] private bool enableScan;
        [DataMember] private bool manualMode;

        //public virtual ICollection<Alarm> Alarms { get; set; }

        public InputTag()
        {
            //Alarms = new List<Alarm>();
        }

        public InputTag(string tagName, string description, string driver, string ioAddress,
                        float scanTime, bool enableScan, bool manualMode)
            : base(tagName, description, driver, ioAddress)
        {
            //Alarms = new List<Alarm>();
            this.scanTime = scanTime;
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